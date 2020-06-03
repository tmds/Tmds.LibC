using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Tmds.Linux.Tests
{
    public class ConstantsTests
    {
        [Fact]
        public unsafe void Constants()
        {
            using (var program = new CProgram())
            {
                program.Define("_GNU_SOURCE");
                foreach (string header in new[] {
                    "errno.h",
                    "sys/socket.h",
                    "netinet/in.h",
                    "fcntl.h",
                    "dlfcn.h",
                    "netinet/tcp.h",
                    "sys/epoll.h",
                    "linux/errqueue.h",
                    "sys/syscall.h",
                    "unistd.h",
                    "sys/ioctl.h",
                    "sched.h",
                    "signal.h",
                    "sys/statvfs.h",
                    "termios.h",
                    "sys/mount.h",
                    "poll.h",
                    "linux/if_packet.h",
                    "sys/mman.h",
                    "linux/mman.h",
                    "sys/eventfd.h",
                    "linux/stat.h",
                    "linux/openat2.h"
                })
                {
                    if (TestEnvironment.Current.SupportsHeader(header) == false)
                    {
                        continue;
                    }
                    program.Include(header);
                }

                PropertyInfo[] properties = typeof(LibC).GetProperties();
                foreach (var property in properties)
                {
                    string name = property.Name;

                    // these aren't constants, the are tested in FunctionsTests
                    if (name == "MS_NOUSER" || // glibc defines it as 1 << 31, while it should be 1U << 31.
                        name == "errno" ||
                        name == "SIGRTMAX" ||
                        name == "SIGRTMIN")
                    {
                        continue;
                    }

                    MethodInfo getMethod = property.GetGetMethod();
                    object o = getMethod.Invoke(null, null);
                    string value;
                    if (o is System.Reflection.Pointer pointer)
                    {
                        IntPtr ptr = new IntPtr(System.Reflection.Pointer.Unbox(o));
                        value = $"(void*){ptr.ToInt32()}";
                    }
                    else
                    {
                        if (o is int i && i < 0)
                        {
                            value = "0x" + string.Format("{0:x}", i);
                        }
                        else
                        {
                            value = o.ToString();
                        }
                    }

                    program.IfDef(name);
                    string condition = $"{name} == {value}";
                    program.StaticAssert(condition, $"{name} has unexpected value");
                    bool? supported = TestEnvironment.Current.SupportsConstant(name);
                    if (supported == true)
                    {
                        program.AppendLine("#else");
                        program.AppendLine($"#error Unknown constant: {name}");
                    }
                    program.Endif();
                }

                program.Compile();
            }
        }
    }
}
