using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        [DllImport(libc, SetLastError = true)]
        public static extern int ioctl(int fd, int request);

        [DllImport(libc, SetLastError = true)]
        public static extern int ioctl(int fd, int request, int arg);

        [DllImport(libc, SetLastError = true)]
        public static extern int ioctl(int fd, int request, void* arg);
    }
}