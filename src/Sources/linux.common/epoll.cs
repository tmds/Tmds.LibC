using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Tmds.LibC.LibraryNames;

namespace Tmds.LibC
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct epoll_data_t
    {
        [FieldOffset(0)]
        public void* ptr;
        [FieldOffset(0)]
        public int fd;
        [FieldOffset(0)]
        public uint u32;
        [FieldOffset(0)]
        public ulong u64;
    }

    public static unsafe partial class Definitions
    {
        public static int EPOLL_CLOEXEC => O_CLOEXEC;

        public static int EPOLLIN => 0x001;
        public static int EPOLLPRI => 0x002;
        public static int EPOLLOUT => 0x004;
        public static int EPOLLRDNORM => 0x040;
        public static int EPOLLRDBAND => 0x080;
        public static int EPOLLWRNORM => 0x100;
        public static int EPOLLWRBAND => 0x200;
        public static int EPOLLMSG => 0x400;
        public static int EPOLLERR => 0x008;
        public static int EPOLLHUP => 0x010;
        public static int EPOLLRDHUP => 0x2000;
        public static int EPOLLEXCLUSIVE => (1 << 28);
        public static int EPOLLWAKEUP => (1 << 29);
        public static int EPOLLONESHOT => (1 << 30);
        public static int EPOLLET => unchecked((int)(1U << 31));

        public static int EPOLL_CTL_ADD => 1;
        public static int EPOLL_CTL_DEL => 2;
        public static int EPOLL_CTL_MOD => 3;

        [DllImport(libc, SetLastError = true)]
        public static extern int epoll_create(int size);
        [DllImport(libc, SetLastError = true)]
        public static extern int epoll_create1(int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int epoll_ctl(int epfd, int op, int fd, epoll_event* ev);
        [DllImport(libc, SetLastError = true)]
        public static extern  int epoll_wait(int epfd, epoll_event* events, int maxevents, int timeout);
        // TODO : add when sigset_t
        // [DllImport(libc, SetLastError = true)] public static extern  int epoll_pwait(int epfd, epoll_event * events, int maxevents, int timeout, sigset_t * sigmask);
    }
}
