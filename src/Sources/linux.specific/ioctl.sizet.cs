using System.Runtime.InteropServices;
using static Tmds.LibC.LibraryNames;

namespace Tmds.LibC
{
    public static unsafe partial class Definitions
    {
        public static int ioctl(int fd, int request)
            => _ioctl(fd, unchecked((uint)request), 0);

        public static int ioctl(int fd, int request, int arg)
            => _ioctl(fd, unchecked((uint)request), arg);

        public static int ioctl(int fd, int request, void* arg)
            => _ioctl(fd, unchecked((uint)request), arg);

        [DllImport(libc, SetLastError = true, EntryPoint = "ioctl")]
        private static extern int _ioctl(int fd, syscall_arg request, syscall_arg arg);
    }
}