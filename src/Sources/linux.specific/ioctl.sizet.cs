using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        public static int ioctl(int fd, int request)
            => _ioctl(fd, request, 0);

        public static int ioctl(int fd, int request, int arg)
            => _ioctl(fd, request, arg);

        public static int ioctl(int fd, int request, void* arg)
            => _ioctl(fd, request, arg);

        [DllImport(libc, SetLastError = true, EntryPoint = "ioctl")]
        private static extern int _ioctl(int fd, syscall_arg request, syscall_arg arg);
    }
}