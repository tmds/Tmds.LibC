using System.Runtime.InteropServices;
using static Tmds.LibC.LibraryNames;

namespace Tmds.LibC
{
    public static unsafe partial class Definitions
    {
        [DllImport(libc, SetLastError = true)]
        public static extern int ioctl(int fd, int request);

        [DllImport(libc, SetLastError = true)]
        public static extern int ioctl(int fd, int request, int arg);

        [DllImport(libc, SetLastError = true)]
        public static extern int ioctl(int fd, int request, void* arg);
    }
}