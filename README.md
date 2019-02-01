# Tmds.LibC

Raw bindings to Linux platform APIs for .NET Core.

## Raw bindings

The APIs provided by this package stay as close as possible to the native declarations.
Because the native APIs are different per platform (e.g. linux-arm64 vs linux-x64), the package contains separate assemblies for each platform.

.NET Core will use the appropriate assembly based on the [rid](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog).

## Supported platforms

* linux x64 glibc
* linux arm64 glibc
* linux arm32 glibc

## Using this package

NuGet.Config

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="tmds" value="https://www.myget.org/F/tmds/api/v3/index.json" />
  </packageSources>
</configuration>
```

console.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.1</TargetFramework>
    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Tmds.LibC" Version="0.1.0-*" />
  </ItemGroup>

</Project>
```

Program.cs

```cs
using System;
using System.Text;
using Tmds.Linux;
using static Tmds.Linux.LibC;

namespace console
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            var bytes = Encoding.UTF8.GetBytes("Hello world!");
            fixed (byte* buffer = bytes)
            {
                write(STDOUT_FILENO, buffer, bytes.Length);
            }
        }
    }
}
```

## Functions

The following functions are defined in the static class `Tmds.Linux.LibC`:

[_exit](http://man7.org/linux/man-pages/man2/_exit.2.html),
[accept](http://man7.org/linux/man-pages/man2/accept.2.html),
[accept4](http://man7.org/linux/man-pages/man2/accept4.2.html),
[access](http://man7.org/linux/man-pages/man2/access.2.html),
[acct](http://man7.org/linux/man-pages/man2/acct.2.html),
[alarm](http://man7.org/linux/man-pages/man2/alarm.2.html),
[bind](http://man7.org/linux/man-pages/man2/bind.2.html),
[brk](http://man7.org/linux/man-pages/man2/brk.2.html),
[chdir](http://man7.org/linux/man-pages/man2/chdir.2.html),
[chmod](http://man7.org/linux/man-pages/man2/chmod.2.html),
[chown](http://man7.org/linux/man-pages/man2/chown.2.html),
[chroot](http://man7.org/linux/man-pages/man2/chroot.2.html),
[clone](http://man7.org/linux/man-pages/man2/clone.2.html),
[close](http://man7.org/linux/man-pages/man2/close.2.html),
[confstr](http://man7.org/linux/man-pages/man3/confstr.3.html),
[connect](http://man7.org/linux/man-pages/man2/connect.2.html),
[creat](http://man7.org/linux/man-pages/man2/creat.2.html),
[ctermid](http://man7.org/linux/man-pages/man3/ctermid.3.html),
[daemon](http://man7.org/linux/man-pages/man3/daemon.3.html),
[dladdr](http://man7.org/linux/man-pages/man3/dladdr.3.html),
[dlclose](http://man7.org/linux/man-pages/man3/dlclose.3.html),
[dlerror](http://man7.org/linux/man-pages/man3/dlerror.3.html),
[dlinfo](http://man7.org/linux/man-pages/man3/dlinfo.3.html),
[dlopen](http://man7.org/linux/man-pages/man3/dlopen.3.html),
[dlsym](http://man7.org/linux/man-pages/man3/dlsym.3.html),
[dup](http://man7.org/linux/man-pages/man2/dup.2.html),
[dup2](http://man7.org/linux/man-pages/man2/dup2.2.html),
[dup3](http://man7.org/linux/man-pages/man2/dup3.2.html),
[eaccess](http://man7.org/linux/man-pages/man3/eaccess.3.html),
[epoll_create](http://man7.org/linux/man-pages/man2/epoll_create.2.html),
[epoll_create1](http://man7.org/linux/man-pages/man2/epoll_create1.2.html),
[epoll_ctl](http://man7.org/linux/man-pages/man2/epoll_ctl.2.html),
[epoll_pwait](http://man7.org/linux/man-pages/man2/epoll_pwait.2.html),
[epoll_wait](http://man7.org/linux/man-pages/man2/epoll_wait.2.html),
[euidaccess](http://man7.org/linux/man-pages/man3/euidaccess.3.html),
[execve](http://man7.org/linux/man-pages/man2/execve.2.html),
[faccessat](http://man7.org/linux/man-pages/man2/faccessat.2.html),
[fallocate](http://man7.org/linux/man-pages/man2/fallocate.2.html),
[fchdir](http://man7.org/linux/man-pages/man2/fchdir.2.html),
[fchmod](http://man7.org/linux/man-pages/man2/fchmod.2.html),
[fchmodat](http://man7.org/linux/man-pages/man2/fchmodat.2.html),
[fchown](http://man7.org/linux/man-pages/man2/fchown.2.html),
[fchownat](http://man7.org/linux/man-pages/man2/fchownat.2.html),
[fcntl](http://man7.org/linux/man-pages/man2/fcntl.2.html),
[fdatasync](http://man7.org/linux/man-pages/man2/fdatasync.2.html),
[fexecve](http://man7.org/linux/man-pages/man3/fexecve.3.html),
[fork](http://man7.org/linux/man-pages/man2/fork.2.html),
[fpathconf](http://man7.org/linux/man-pages/man3/fpathconf.3.html),
[fstat](http://man7.org/linux/man-pages/man2/fstat.2.html),
[fstatat](http://man7.org/linux/man-pages/man2/fstatat.2.html),
[fsync](http://man7.org/linux/man-pages/man2/fsync.2.html),
[ftruncate](http://man7.org/linux/man-pages/man2/ftruncate.2.html),
[futimens](http://man7.org/linux/man-pages/man3/futimens.3.html),
[getcwd](http://man7.org/linux/man-pages/man3/getcwd.3.html),
[getdomainname](http://man7.org/linux/man-pages/man2/getdomainname.2.html),
[getdtablesize](http://man7.org/linux/man-pages/man3/getdtablesize.3.html),
[getegid](http://man7.org/linux/man-pages/man2/getegid.2.html),
[geteuid](http://man7.org/linux/man-pages/man2/geteuid.2.html),
[getgid](http://man7.org/linux/man-pages/man2/getgid.2.html),
[getgroups](http://man7.org/linux/man-pages/man2/getgroups.2.html),
[gethostid](http://man7.org/linux/man-pages/man3/gethostid.3.html),
[gethostname](http://man7.org/linux/man-pages/man2/gethostname.2.html),
[getlogin](http://man7.org/linux/man-pages/man3/getlogin.3.html),
[getlogin_r](http://man7.org/linux/man-pages/man3/getlogin_r.3.html),
[getpagesize](http://man7.org/linux/man-pages/man2/getpagesize.2.html),
[getpeername](http://man7.org/linux/man-pages/man2/getpeername.2.html),
[getpgid](http://man7.org/linux/man-pages/man2/getpgid.2.html),
[getpgrp](http://man7.org/linux/man-pages/man2/getpgrp.2.html),
[getpid](http://man7.org/linux/man-pages/man2/getpid.2.html),
[getppid](http://man7.org/linux/man-pages/man2/getppid.2.html),
[getresgid](http://man7.org/linux/man-pages/man2/getresgid.2.html),
[getresuid](http://man7.org/linux/man-pages/man2/getresuid.2.html),
[getsid](http://man7.org/linux/man-pages/man2/getsid.2.html),
[getsockname](http://man7.org/linux/man-pages/man2/getsockname.2.html),
[getsockopt](http://man7.org/linux/man-pages/man2/getsockopt.2.html),
[getuid](http://man7.org/linux/man-pages/man2/getuid.2.html),
[htons](http://man7.org/linux/man-pages/man3/htons.3.html),
[io_destroy](http://man7.org/linux/man-pages/man2/io_destroy.2.html),
[io_getevents](http://man7.org/linux/man-pages/man2/io_getevents.2.html),
[io_setup](http://man7.org/linux/man-pages/man2/io_setup.2.html),
[io_submit](http://man7.org/linux/man-pages/man2/io_submit.2.html),
[ioctl](http://man7.org/linux/man-pages/man2/ioctl.2.html),
[isatty](http://man7.org/linux/man-pages/man3/isatty.3.html),
[kill](http://man7.org/linux/man-pages/man2/kill.2.html),
[killpg](http://man7.org/linux/man-pages/man3/killpg.3.html),
[lchown](http://man7.org/linux/man-pages/man2/lchown.2.html),
[link](http://man7.org/linux/man-pages/man2/link.2.html),
[linkat](http://man7.org/linux/man-pages/man2/linkat.2.html),
[listen](http://man7.org/linux/man-pages/man2/listen.2.html),
[lockf](http://man7.org/linux/man-pages/man3/lockf.3.html),
[lseek](http://man7.org/linux/man-pages/man2/lseek.2.html),
[lstat](http://man7.org/linux/man-pages/man2/lstat.2.html),
[mkdir](http://man7.org/linux/man-pages/man2/mkdir.2.html),
[mkdirat](http://man7.org/linux/man-pages/man2/mkdirat.2.html),
[mkfifo](http://man7.org/linux/man-pages/man3/mkfifo.3.html),
[mkfifoat](http://man7.org/linux/man-pages/man3/mkfifoat.3.html),
[mknod](http://man7.org/linux/man-pages/man2/mknod.2.html),
[mknodat](http://man7.org/linux/man-pages/man2/mknodat.2.html),
[name_to_handle_at](http://man7.org/linux/man-pages/man2/name_to_handle_at.2.html),
[nice](http://man7.org/linux/man-pages/man2/nice.2.html),
[ntohs](http://man7.org/linux/man-pages/man3/ntohs.3.html),
[open](http://man7.org/linux/man-pages/man2/open.2.html),
[open_by_handle_at](http://man7.org/linux/man-pages/man2/open_by_handle_at.2.html),
[openat](http://man7.org/linux/man-pages/man2/openat.2.html),
[pathconf](http://man7.org/linux/man-pages/man3/pathconf.3.html),
[pause](http://man7.org/linux/man-pages/man2/pause.2.html),
[pipe](http://man7.org/linux/man-pages/man2/pipe.2.html),
[pipe2](http://man7.org/linux/man-pages/man2/pipe2.2.html),
[posix_fadvise](http://man7.org/linux/man-pages/man2/posix_fadvise.2.html),
[posix_fallocate](http://man7.org/linux/man-pages/man3/posix_fallocate.3.html),
[pread](http://man7.org/linux/man-pages/man2/pread.2.html),
[psiginfo](http://man7.org/linux/man-pages/man3/psiginfo.3.html),
[psignal](http://man7.org/linux/man-pages/man3/psignal.3.html),
[pthread_kill](http://man7.org/linux/man-pages/man3/pthread_kill.3.html),
[pthread_sigmask](http://man7.org/linux/man-pages/man3/pthread_sigmask.3.html),
[pwrite](http://man7.org/linux/man-pages/man2/pwrite.2.html),
[raise](http://man7.org/linux/man-pages/man3/raise.3.html),
[read](http://man7.org/linux/man-pages/man2/read.2.html),
[readahead](http://man7.org/linux/man-pages/man2/readahead.2.html),
[readlink](http://man7.org/linux/man-pages/man2/readlink.2.html),
[readlinkat](http://man7.org/linux/man-pages/man2/readlinkat.2.html),
[recv](http://man7.org/linux/man-pages/man2/recv.2.html),
[recvfrom](http://man7.org/linux/man-pages/man2/recvfrom.2.html),
[recvmsg](http://man7.org/linux/man-pages/man2/recvmsg.2.html),
[rmdir](http://man7.org/linux/man-pages/man2/rmdir.2.html),
[sbrk](http://man7.org/linux/man-pages/man2/sbrk.2.html),
[sched_get_priority_max](http://man7.org/linux/man-pages/man2/sched_get_priority_max.2.html),
[sched_get_priority_min](http://man7.org/linux/man-pages/man2/sched_get_priority_min.2.html),
[sched_getaffinity](http://man7.org/linux/man-pages/man2/sched_getaffinity.2.html),
[sched_getcpu](http://man7.org/linux/man-pages/man3/sched_getcpu.3.html),
[sched_getscheduler](http://man7.org/linux/man-pages/man2/sched_getscheduler.2.html),
[sched_rr_get_interval](http://man7.org/linux/man-pages/man2/sched_rr_get_interval.2.html),
[sched_setaffinity](http://man7.org/linux/man-pages/man2/sched_setaffinity.2.html),
[sched_yield](http://man7.org/linux/man-pages/man2/sched_yield.2.html),
[send](http://man7.org/linux/man-pages/man2/send.2.html),
[sendmsg](http://man7.org/linux/man-pages/man2/sendmsg.2.html),
[sendto](http://man7.org/linux/man-pages/man2/sendto.2.html),
[setdomainname](http://man7.org/linux/man-pages/man2/setdomainname.2.html),
[setegid](http://man7.org/linux/man-pages/man2/setegid.2.html),
[seteuid](http://man7.org/linux/man-pages/man2/seteuid.2.html),
[setgid](http://man7.org/linux/man-pages/man2/setgid.2.html),
[setgroups](http://man7.org/linux/man-pages/man2/setgroups.2.html),
[sethostname](http://man7.org/linux/man-pages/man2/sethostname.2.html),
[setns](http://man7.org/linux/man-pages/man2/setns.2.html),
[setpgid](http://man7.org/linux/man-pages/man2/setpgid.2.html),
[setpgrp](http://man7.org/linux/man-pages/man2/setpgrp.2.html),
[setregid](http://man7.org/linux/man-pages/man2/setregid.2.html),
[setresgid](http://man7.org/linux/man-pages/man2/setresgid.2.html),
[setresuid](http://man7.org/linux/man-pages/man2/setresuid.2.html),
[setreuid](http://man7.org/linux/man-pages/man2/setreuid.2.html),
[setsid](http://man7.org/linux/man-pages/man2/setsid.2.html),
[setsockopt](http://man7.org/linux/man-pages/man2/setsockopt.2.html),
[setuid](http://man7.org/linux/man-pages/man2/setuid.2.html),
[shutdown](http://man7.org/linux/man-pages/man2/shutdown.2.html),
[sigaction](http://man7.org/linux/man-pages/man2/sigaction.2.html),
[sigaddset](http://man7.org/linux/man-pages/man3/sigaddset.3.html),
[sigaltstack](http://man7.org/linux/man-pages/man2/sigaltstack.2.html),
[sigandset](http://man7.org/linux/man-pages/man3/sigandset.3.html),
[sigdelset](http://man7.org/linux/man-pages/man3/sigdelset.3.html),
[sigemptyset](http://man7.org/linux/man-pages/man3/sigemptyset.3.html),
[sigfillset](http://man7.org/linux/man-pages/man3/sigfillset.3.html),
[sighold](http://man7.org/linux/man-pages/man3/sighold.3.html),
[sigignore](http://man7.org/linux/man-pages/man3/sigignore.3.html),
[siginterrupt](http://man7.org/linux/man-pages/man3/siginterrupt.3.html),
[sigisemptyset](http://man7.org/linux/man-pages/man3/sigisemptyset.3.html),
[sigismember](http://man7.org/linux/man-pages/man3/sigismember.3.html),
[sigorset](http://man7.org/linux/man-pages/man3/sigorset.3.html),
[sigpause](http://man7.org/linux/man-pages/man3/sigpause.3.html),
[sigpending](http://man7.org/linux/man-pages/man2/sigpending.2.html),
[sigprocmask](http://man7.org/linux/man-pages/man2/sigprocmask.2.html),
[sigqueue](http://man7.org/linux/man-pages/man3/sigqueue.3.html),
[sigrelse](http://man7.org/linux/man-pages/man3/sigrelse.3.html),
[sigsuspend](http://man7.org/linux/man-pages/man2/sigsuspend.2.html),
[sigtimedwait](http://man7.org/linux/man-pages/man2/sigtimedwait.2.html),
[sigwait](http://man7.org/linux/man-pages/man3/sigwait.3.html),
[sigwaitinfo](http://man7.org/linux/man-pages/man2/sigwaitinfo.2.html),
[sleep](http://man7.org/linux/man-pages/man3/sleep.3.html),
[socket](http://man7.org/linux/man-pages/man2/socket.2.html),
[socketpair](http://man7.org/linux/man-pages/man2/socketpair.2.html),
[splice](http://man7.org/linux/man-pages/man2/splice.2.html),
[stat](http://man7.org/linux/man-pages/man2/stat.2.html),
[strerror_r](http://man7.org/linux/man-pages/man3/strerror_r.3.html),
[symlink](http://man7.org/linux/man-pages/man2/symlink.2.html),
[symlinkat](http://man7.org/linux/man-pages/man2/symlinkat.2.html),
[sync](http://man7.org/linux/man-pages/man2/sync.2.html),
[sync_file_range](http://man7.org/linux/man-pages/man2/sync_file_range.2.html),
[syncfs](http://man7.org/linux/man-pages/man2/syncfs.2.html),
[syscall](http://man7.org/linux/man-pages/man2/syscall.2.html),
[sysconf](http://man7.org/linux/man-pages/man3/sysconf.3.html),
[tcgetpgrp](http://man7.org/linux/man-pages/man3/tcgetpgrp.3.html),
[tcsetpgrp](http://man7.org/linux/man-pages/man3/tcsetpgrp.3.html),
[tee](http://man7.org/linux/man-pages/man2/tee.2.html),
[truncate](http://man7.org/linux/man-pages/man2/truncate.2.html),
[ttyname](http://man7.org/linux/man-pages/man3/ttyname.3.html),
[ttyname_r](http://man7.org/linux/man-pages/man3/ttyname_r.3.html),
[ualarm](http://man7.org/linux/man-pages/man3/ualarm.3.html),
[umask](http://man7.org/linux/man-pages/man2/umask.2.html),
[unlink](http://man7.org/linux/man-pages/man2/unlink.2.html),
[unlinkat](http://man7.org/linux/man-pages/man2/unlinkat.2.html),
[unshare](http://man7.org/linux/man-pages/man2/unshare.2.html),
[usleep](http://man7.org/linux/man-pages/man3/usleep.3.html),
[utimensat](http://man7.org/linux/man-pages/man2/utimensat.2.html),
[vfork](http://man7.org/linux/man-pages/man2/vfork.2.html),
[vhangup](http://man7.org/linux/man-pages/man2/vhangup.2.html),
[vmsplice](http://man7.org/linux/man-pages/man2/vmsplice.2.html),
[write](http://man7.org/linux/man-pages/man2/write.2.html),


## Structs

The following structs are defined in the `Tmds.Linux` namespace:

aio_context_t,
aio_ring,
blkcnt_t,
blksize_t,
clock_t,
cmsghdr,
cpu_set_t,
dev_t,
Dl_info,
epoll_data_t,
epoll_event,
f_owner_ex,
file_handle,
flock,
gid_t,
group_filter,
group_req,
group_source_req,
in_addr,
in_pktinfo,
in6_addr,
in6_pktinfo,
ino_t,
io_event,
iocb,
iovec,
ip_mreq,
ip_mreq_source,
ip_mreqn,
ip_opts,
ip6_mtuinfo,
ipv6_mreq,
linger,
long_t,
mmsghdr,
mode_t,
msghdr,
nlink_t,
off_t,
pid_t,
pthread_t,
sa_family_t,
scm_timestamping,
sigaction,
sigevent_t,
siginfo_t,
sigset_t,
sigval,
size_t,
sock_extended_err,
sockaddr,
sockaddr_in,
sockaddr_in6,
sockaddr_storage,
sockaddr_un,
socklen_t,
ssize_t,
stack_t,
stat,
syscall_arg,
time_t,
timespec,
ucred,
uid_t,
winsize,


## Examples

This section shows some examples. The examples use a `PlatformException` class which is implemented as follows:

```c#
class PlatformException : Exception
{
    public PlatformException(int errno) :
        base(GetErrorMessage(errno))
    {
        HResult = errno;
    }

    public PlatformException() :
        this(LibC.errno)
    {}

    public unsafe static string GetErrorMessage(int errno)
    {
        int bufferLength = 1024;
        byte* buffer = stackalloc byte[bufferLength];

        int rv = strerror_r(errno, buffer, bufferLength);

        return rv == 0 ? Marshal.PtrToStringAnsi((IntPtr)buffer) : $"errno {errno}";
    }
}
```

### Example 1: Socket extension method to set raw socket options

```c#
static class SocketExtensions
{
    public static unsafe void SetRawSocketOption(this Socket socket, int level, int optname, int optval)
    {
        SafeHandle handle = socket.SafeHandle;
        bool refAdded = false;
        try
        {
            handle.DangerousAddRef(ref refAdded);
            int rv = setsockopt(handle.DangerousGetHandle().ToInt32(), level, optname, &optval, sizeof(int));
            if (rv != 0)
            {
                throw new PlatformException();
            }
        }
        finally
        {
            if (refAdded)
                handle.DangerousRelease();
        }
    }
}
```

This extension method can be used with the constants provided by `Tmds.LibC`, for example:
```c#
socket.SetRawSocketOption(SOL_SOCKET, SO_REUSEADDR, 1);
```

### Example 2: Process extension method to request termination

Unix processes can be requested to terminate using the `SIGTERM` signal. The following code adds an extension
method to the `Process` class to send that signal.

```c#
static class ProcessExtensions
{
    public static void Terminate(this Process process)
    {
        if (process.HasExited)
        {
            return;
        }
        int rv = kill(process.Handle.ToInt32(), SIGTERM);
        if (rv == -1 &&
            errno != ESRCH /* process does not exist, assume it exited */)
        {
            throw new PlatformException();
        }
    }
}
```

### Example 3: Creating a temporary directory that is only accessible by the user

```c#
static class FileUtils
{
    public unsafe static string CreatePrivateTempDirectory()
    {
        string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        fixed (byte* pathname = Encoding.UTF8.GetBytes(path))
        {
            int rv = mkdir(pathname, S_IRWXU);
            if (rv == -1)
            {
                throw new PlatformException();
            }
            else
            {
                return path;
            }
        }
    }
}
```
