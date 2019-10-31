using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace Tmds.Linux.Tests
{
    public class FunctionsTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Functions(CIncludes includes, string[] functions)
        {
            using (CProgram program = new CProgram())
            {
                if (TestEnvironment.Current.SupportsHeaders(includes.Headers) == false)
                {
                    return;
                }

                program.Include(includes);
                program.Include("stdint.h");
                program.BeginMain();

                var symbolsUsedByDotnet = new HashSet<string>();
                int idx = 0;
                foreach (var functionName in functions)
                {
                    bool? supported = TestEnvironment.Current.SupportsFunction(functionName);
                    if (supported == false)
                    {
                        continue;
                    }

                    MethodInfo[] methods;
                    DllImportAttribute dllImportAttribute;
                    if (functionName == "errno" ||
                        functionName == "SIGRTMIN" ||
                        functionName == "SIGRTMAX")
                    {
                        // call method
                        program.AppendLine($"int rv{idx++} = {functionName};");
                    }
                    else
                    {
                        methods = typeof(LibC).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                    .Where(mi => mi.Name == functionName)
                                    .ToArray();
                        foreach (var method in methods)
                        {
                            // call method
                            AddCall(method.Name, ref idx, method, program);

                            // add symbol used
                            dllImportAttribute = method.GetCustomAttribute<DllImportAttribute>();
                            if (dllImportAttribute != null)
                            {
                                symbolsUsedByDotnet.Add(dllImportAttribute.EntryPoint);
                            }
                        }
                    }

                    // If the function calls a private function it is named "_{function}"
                    methods = typeof(LibC).GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
                                    .Where(mi => mi.Name == $"_{functionName}")
                                    .ToArray();
                    foreach (var method in methods)
                    {
                        dllImportAttribute = method.GetCustomAttribute<DllImportAttribute>();
                        if (dllImportAttribute != null)
                        {
                            // add symbol used
                            symbolsUsedByDotnet.Add(dllImportAttribute.EntryPoint);
                        }
                    }
                }
                program.EndMain();

                string elfFile = program.Compile();

                var nativeUsed = ElfReader.GetUndefinedSymbols(elfFile);
                IEnumerable<string> wrongNames = symbolsUsedByDotnet.Except(nativeUsed);
                IEnumerable<string> actualNames = nativeUsed.Except(symbolsUsedByDotnet);
                Assert.True(wrongNames.Count() == 0,
                    $"Used  : {string.Join(", ", wrongNames)}\nActual: {string.Join(", ", actualNames)}");
            }
        }

        private void AddCall(string name, ref int idx, MethodInfo method, CProgram program)
        {
            var arguments = new List<string>();
            if (name == "execve")
            {
                arguments.AddRange(new[] { "(char*)1", "(char * const*)1", "(char * const*)1" });
            }
            else if (name == "fexecve")
            {
                arguments.AddRange(new[] { "(int)1", "(char * const*)1", "(char * const*)1" });
            }
            else
            {
                foreach (ParameterInfo arg in method.GetParameters())
                {
                    string cType = TypeToCType(arg.ParameterType);
                    if (cType == null)
                    {
                        Assert.True(false, $"Unsupported type: {arg.ParameterType}");
                    }
                    string argument = $"({cType})1";
                    arguments.Add(argument);
                }
            }

            string returnType = TypeToCType(method.ReturnType);

            program.AddCall(returnType == "void" ? null : $"{returnType} rv{idx++}", name, arguments);
        }

        private static string TypeToCType(Type parameterType)
        {
            string parameterTypeName = parameterType.Name;
            string nameNoPointer = parameterTypeName.TrimEnd('*');
            string cType = CType.GetName(nameNoPointer);
            return cType + new string('*', parameterTypeName.Length - nameNoPointer.Length);
        }

        public static string[] s_uncheckedFunctions = new string[] {
            "CMSG_DATA",
            "CMSG_NXTHDR",
            "CMSG_FIRSTHDR",
            "CMSG_LEN",
            "CMSG_ALIGN",
            "CMSG_SPACE",
            "htons",
            "ntohs",
            "GROUP_FILTER_SIZE",
            "io_setup",
            "io_destroy",
            "io_submit",
            "io_getevents",
            "SO_EE_OFFENDER",
            "CPU_SET_S",
            "CPU_CLR_S",
            "CPU_ISSET_S",
            "CPU_AND_S",
            "CPU_OR_S",
            "CPU_XOR_S",
            "CPU_COUNT_S",
            "CPU_ZERO_S",
            "CPU_EQUAL_S",
            "CPU_SET",
            "CPU_CLR",
            "CPU_ISSET",
            "CPU_AND",
            "CPU_OR",
            "CPU_XOR",
            "CPU_COUNT",
            "CPU_ZERO",
            "CPU_EQUAL",
            "S_ISDIR",
            "S_ISCHR",
            "S_ISBLK",
            "S_ISREG",
            "S_ISFIFO",
            "S_ISLNK",
            "S_ISSOCK",
            "io_uring_register",
            "io_uring_setup",
            "io_uring_enter",
            "mlock2"
        };

        [Fact]
        public void UncheckedFunctions() // Verifies s_uncheckedFunctions is up-to-date
        {
            IEnumerable<MethodInfo> methods = typeof(LibC).GetMethods(BindingFlags.Static | BindingFlags.Public);

            // Skip property getters
            methods = methods.Where(m => !m.DeclaringType.GetProperties()
                .Any(prop => prop.GetGetMethod() == m));

            // Remove unchecked functions
            methods = methods.Where(m => !s_uncheckedFunctions.Contains(m.Name));

            // Remove checked functions
            methods = methods.Where(m => !Data.Any(d => ((string[])((object[])d)[1]).Contains(m.Name)));

            Assert.True(!methods.Any(),
                $"Unchecked functions: {string.Join(", ", methods.Select(m => m.Name).Distinct())}");
        }

        private unsafe Dictionary<string, IntPtr> s_dlopened = new Dictionary<string, IntPtr>();

        [Fact]
        public unsafe void LibraryNames()
        {
            var methods = typeof(LibC).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var method in methods)
            {
                DllImportAttribute dllImportAttribute = method.GetCustomAttribute<DllImportAttribute>();
                if (dllImportAttribute != null)
                {
                    string functionName = dllImportAttribute.EntryPoint;
                    string libName = dllImportAttribute.Value;
                    IntPtr libHandle = IntPtr.Zero;
                    lock (s_dlopened)
                    {
                        if (!s_dlopened.TryGetValue(libName, out libHandle))
                        {
                            fixed (byte* filename = Encoding.UTF8.GetBytes(libName))
                            {
                                libHandle = new IntPtr(LibC.dlopen(filename, LibC.RTLD_LAZY));
                            }
                            Assert.True(IntPtr.Zero != libHandle, $"Library not found: {libName}");
                            s_dlopened.Add(libName, libHandle);
                        }
                    }
                    fixed(byte* symbol = Encoding.UTF8.GetBytes(functionName))
                    {
                        IntPtr symbolHandle = new IntPtr(LibC.dlsym(libHandle.ToPointer(), symbol));
                        Assert.True(IntPtr.Zero != symbolHandle, $"Function symbol not found in {libName}: {functionName}");
                    }
                }
            }
        }

        public static TheoryData<CIncludes, string[]> Data =>
            new TheoryData<CIncludes, string[]>
                {
                    { "sys/socket.h",
                      new[] {
                        "socket",
                        "socketpair",
                        "shutdown",
                        "bind",
                        "connect",
                        "listen",
                        "accept",
                        "getsockname",
                        "getpeername",
                        "send",
                        "recv",
                        "sendto",
                        "recvfrom",
                        "sendmsg",
                        "recvmsg",
                        "getsockopt",
                        "setsockopt" }
                    },
                    { new CIncludes("sys/socket.h",
                                    gnuSource: true),
                      new[] {
                        "accept4" }
                    },
                    { "errno.h",
                      new[] {
                        "errno" }
                    },
                    { "string.h",
                      new[] {
                        "strerror_r" }
                    },
                    { "unistd.h",
                      new[] {
                        "_exit" } // no return function
                    },
                    { "unistd.h",
                      new[] {
                        "syscall",
                        "sbrk",
                        "getlogin",
                        "getcwd",
                        "ttyname", }
                    },
                    { "grp.h",
                      new[] {
                        "setgroups"
                        }
                    },
                    { "stdio.h",
                      new[] {
                        "ctermid"
                        }
                    },
                    { new CIncludes(new[] { "fcntl.h",
                                            "unistd.h" /* missing ssize_t declaration for fcntl.h */ },
                                    gnuSource: true),
                      new[] {
                        "creat",
                        "fcntl",
                        "open",
                        "openat",
                        "posix_fadvise",
                        "posix_fallocate",
                        "fallocate",
                        "name_to_handle_at",
                        "open_by_handle_at",
                        "readahead",
                        "sync_file_range",
                        "vmsplice",
                        "splice",
                        "tee"}
                    },
                    { new CIncludes("unistd.h",
                                    gnuSource: true),
                      new[] {
                        "pipe",
                        "pipe2",
                        "close",
                        "dup",
                        "dup2",
                        "dup3",
                        "lseek",
                        "fsync",
                        "fdatasync",
                        "read",
                        "write",
                        "pread",
                        "pwrite",
                        "chown",
                        "fchown",
                        "lchown",
                        "fchownat",
                        "link",
                        "linkat",
                        "symlink",
                        "symlinkat",
                        "readlink",
                        "readlinkat",
                        "unlink",
                        "unlinkat",
                        "rmdir",
                        "truncate",
                        "ftruncate",
                        "access",
                        "faccessat",
                        "chdir",
                        "fchdir",
                        "alarm",
                        "sleep",
                        "pause",
                        "fork",
                        "getpid",
                        "getppid",
                        "getpgrp",
                        "getpgid",
                        "setpgid",
                        "setsid",
                        "getsid",
                        "ttyname_r",
                        "isatty",
                        "tcgetpgrp",
                        "tcsetpgrp",
                        "getuid",
                        "geteuid",
                        "getgid",
                        "getegid",
                        "getgroups",
                        "setuid",
                        "seteuid",
                        "setgid",
                        "setegid",
                        "getlogin_r",
                        "gethostname",
                        "pathconf",
                        "fpathconf",
                        "sysconf",
                        "confstr",
                        "setreuid",
                        "setregid",
                        "lockf",
                        "gethostid",
                        "nice",
                        "sync",
                        "setpgrp",
                        "usleep",
                        "ualarm",
                        "brk",
                        "vfork",
                        "vhangup",
                        "chroot",
                        "getpagesize",
                        "getdtablesize",
                        "sethostname",
                        "getdomainname",
                        "setdomainname",
                        "daemon",
                        "setusershell",
                        "endusershell",
                        "acct",
                        "setresuid",
                        "setresgid",
                        "getresuid",
                        "getresgid",
                        "syncfs",
                        "euidaccess",
                        "eaccess",
                        "fexecve",
                        "execve" }
                    },
                    { "sys/epoll.h",
                      new[] {
                        "epoll_create",
                        "epoll_create1",
                        "epoll_ctl",
                        "epoll_wait",
                        "epoll_pwait" }
                    },
                    { "sys/ioctl.h",
                      new[] {
                        "ioctl" }
                    },
                    { new CIncludes("sched.h", true),
                      new[] {
                        "sched_get_priority_max",
                        "sched_get_priority_min",
                        "getscheduler",
                        "sched_rr_get_interval",
                        "sched_yield",
                        "clone",
                        "unshare",
                        "setns",
                        "sched_getcpu",
                        "sched_getaffinity",
                        "sched_setaffinity",
                        "sched_getscheduler", }
                    },
                    { new CIncludes("signal.h", gnuSource: true),
                      new[] {
                        "SIGRTMIN",
                        "SIGRTMAX",
                        "sigpause",
                        "sigrelse",
                        "sigisemptyset",
                        "sigorset",
                        "sigandset",
                        "raise",
                        "kill",
                        "sigemptyset",
                        "sigfillset",
                        "sigaddset",
                        "sigdelset",
                        "sigismember",
                        "sigprocmask",
                        "sigsuspend",
                        "sigaction",
                        "sigpending",
                        "sigwait",
                        "sigwaitinfo",
                        "sigtimedwait",
                        "sigqueue",
                        "pthread_sigmask",
                        "pthread_kill",
                        "psiginfo",
                        "psignal",
                        "killpg",
                        "sigaltstack",
                        "sighold",
                        "sigignore",
                        "siginterrupt", }
                    },
                    { new CIncludes("dlfcn.h", true),
                      new[] {
                        "dlclose",
                        "dlerror",
                        "dlopen",
                        "dlsym",
                        "dlvsym",
                        "dladdr",
                        "dlinfo" }
                    },
                    { "sys/stat.h",
                      new[] {
                        "stat",
                        "fstat",
                        "lstat",
                        "fstatat",
                        "chmod",
                        "fchmod",
                        "fchmodat",
                        "umask",
                        "mkdir",
                        "mkfifo",
                        "mkdirat",
                        "mkfifoat",
                        "mknod",
                        "mknodat",
                        "futimens",
                        "utimensat",
                        }
                    },
                    { "sys/statvfs.h",
                      new[] {
                        "statvfs",
                        "fstatvfs",
                        }
                    },
                    { new CIncludes("termios.h", true),
                      new[] {
                        "cfgetospeed",
                        "cfgetispeed",
                        "cfsetospeed",
                        "cfsetispeed",
                        "tcgetattr",
                        "tcsetattr",
                        "tcsendbreak",
                        "tcdrain",
                        "tcflush",
                        "tcflow",
                        "tcgetsid" }
                    },
                    { new CIncludes("sys/mount.h", true),
                        new[] {
                            "mount",
                            "umount",
                            "umount2" }
                    },
                    { new CIncludes(new[] { "poll.h", "signal.h" /* sigset_t */ }, true),
                        new[] {
                            "poll",
                            "ppoll" }
                    },
                    { new CIncludes("sys/mman.h", true),
                        new[] {
                            "mmap",
                            "munmap",
                            "mprotect",
                            "msync",
                            "mlock",
                            "munlock",
                            "mlockall",
                            "munlockall" }
                    }
                };
    }
}
