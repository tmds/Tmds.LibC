using System.Runtime.InteropServices;
using static Tmds.LibC.LibraryNames;

namespace Tmds.LibC
{
    public static unsafe partial class Definitions
    {
        [DllImport(libc, SetLastError = true)]
        public static extern int stat(byte* path, stat* stat);
        [DllImport(libc, SetLastError = true)]
        public static extern int fstat(int fd, stat* stat);
        [DllImport(libc, SetLastError = true)]
        public static extern int lstat(byte* path, stat* stat);
        [DllImport(libc, SetLastError = true)]
        public static extern int fstatat(int dirfd, byte* path, stat* stat, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int mknodat(int dirfd, byte* path, mode_t mode, dev_t dev);
        [DllImport(libc, SetLastError = true)]
        public static extern int mknod(byte* path, mode_t mode, dev_t dev);
    }
}