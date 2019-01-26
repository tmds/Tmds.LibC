using System.Runtime.InteropServices;
using static Tmds.LibC.LibraryNames;

namespace Tmds.LibC
{
    public static unsafe partial class Definitions
    {
        public static int stat(byte* path, stat* stat)
            => _stat(0, path, stat);
        public static int fstat(int fd, stat* stat)
            => _fstat(0, fd, stat);
        public static int lstat(byte* path, stat* stat)
            => _lstat(0, path, stat);
        public static int fstatat(int dirfd, byte* path, stat* stat, int flags)
            => _fstatat(0, dirfd, path, stat, flags);
        public static int mknodat(int dirfd, byte* path, mode_t mode, dev_t dev)
            => _mknodat(0, dirfd, path, mode, &dev);
        public static int mknod(byte* path, mode_t mode, dev_t dev)
            => _mknod(0, path, mode, &dev);

        [DllImport(libc, SetLastError = true, EntryPoint="__xmknodat")]
        private static extern int _mknodat(int ver, int dirfd, byte * path, mode_t mode, dev_t* dev);
        [DllImport(libc, SetLastError = true, EntryPoint="__lxstat")]
        private static extern int _lstat(int ver, byte* path, stat * stat);
        [DllImport(libc, SetLastError = true, EntryPoint="__fxstatat")]
        private static extern int _fstatat (int ver, int fd, byte* path, stat* stat, int flags);
        [DllImport(libc, SetLastError = true, EntryPoint="__fxstat")]
        private static extern int _fstat (int ver, int fd, stat* stat);
        [DllImport(libc, SetLastError = true, EntryPoint="__xstat")]
        private static extern int _stat (int ver, byte* path, stat* stat);
        [DllImport(libc, SetLastError = true, EntryPoint="__xmknod")]
        private static extern int _mknod(int ver, byte* path, mode_t mode, dev_t* dev);
    }
}