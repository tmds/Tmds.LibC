using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public unsafe struct pollfd
    {
        public int fd { get; set; }
        public short events { get; set; }
        public short revents { get; set; }
    }

    public static unsafe partial class LibC
    {
        public static short POLLIN => 0x001;
        public static short POLLPRI => 0x002;
        public static short POLLOUT => 0x004;
        public static short POLLERR => 0x008;
        public static short POLLHUP => 0x010;
        public static short POLLNVAL => 0x020;
        public static short POLLMSG => 0x400;
        public static short POLLRDHUP => 0x2000;

        [DllImport(libc)]
        public static extern int poll(pollfd* fds, ulong_t nfds, int timeout);
        [DllImport(libc)]
        public static extern int ppoll(pollfd* fds, ulong_t nfds, timespec* timeout, sigset_t* sigmask);
    }
}