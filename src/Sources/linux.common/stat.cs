using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public struct statx_timestamp {
        public long tv_sec;
        public uint tv_nsec;
        private int __reserved;
    }

    public unsafe struct statx {
        public uint stx_mask;
        public uint stx_blksize;
        public ulong stx_attributes;
        public uint stx_nlink;
        public uint stx_uid;
        public uint stx_gid;
        public ushort stx_mode;
        private fixed ushort __spare0[1];
        public ulong stx_ino;
        public ulong stx_size;
        public ulong stx_blocks;
        public ulong stx_attributes_mask;
        public statx_timestamp stx_atime;
        public statx_timestamp stx_btime;
        public statx_timestamp stx_ctime;
        public statx_timestamp stx_mtime;
        public uint stx_rdev_major;
        public uint stx_rdev_minor;
        public uint stx_dev_major;
        public uint stx_dev_minor;
        private fixed ulong __spare2[14];
    }

    public static unsafe partial class LibC
    {
        public static mode_t S_IFMT => 0xf000;
        public static mode_t S_IFDIR => 0x4000;
        public static mode_t S_IFCHR => 0x2000;
        public static mode_t S_IFBLK => 0x6000;
        public static mode_t S_IFREG => 0x8000;
        public static mode_t S_IFIFO => 0x1000;
        public static mode_t S_IFLNK => 0xa000;
        public static mode_t S_IFSOCK => 0xc000;
        public static mode_t S_ISUID => 0x800;
        public static mode_t S_ISGID => 0x400;
        public static mode_t S_ISVTX => 0x200;
        public static mode_t S_IRUSR => 0x100;
        public static mode_t S_IWUSR => 0x80;
        public static mode_t S_IXUSR => 0x40;
        public static mode_t S_IRWXU => 0x1c0;
        public static mode_t S_IRGRP => 0x20;
        public static mode_t S_IWGRP => 0x10;
        public static mode_t S_IXGRP => 0x8;
        public static mode_t S_IRWXG => 0x38;
        public static mode_t S_IROTH => 0x4;
        public static mode_t S_IWOTH => 0x2;
        public static mode_t S_IXOTH => 0x1;
        public static mode_t S_IRWXO => 0x7;

        public static int UTIME_NOW => 0x3fffffff;
        public static int UTIME_OMIT => 0x3ffffffe;

        public static bool S_ISDIR(mode_t mode) => (((mode) & S_IFMT) == S_IFDIR);
        public static bool S_ISCHR(mode_t mode) => (((mode) & S_IFMT) == S_IFCHR);
        public static bool S_ISBLK(mode_t mode) => (((mode) & S_IFMT) == S_IFBLK);
        public static bool S_ISREG(mode_t mode) => (((mode) & S_IFMT) == S_IFREG);
        public static bool S_ISFIFO(mode_t mode) => (((mode) & S_IFMT) == S_IFIFO);
        public static bool S_ISLNK(mode_t mode) => (((mode) & S_IFMT) == S_IFLNK);
        public static bool S_ISSOCK(mode_t mode) => (((mode) & S_IFMT) == S_IFSOCK);

        public static uint STATX_TYPE => 0x1;
        public static uint STATX_MODE => 0x2;
        public static uint STATX_NLINK => 0x4;
        public static uint STATX_UID => 0x8;
        public static uint STATX_GID => 0x10;
        public static uint STATX_ATIME => 0x20;
        public static uint STATX_MTIME => 0x40;
        public static uint STATX_CTIME => 0x80;
        public static uint STATX_INO => 0x100;
        public static uint STATX_SIZE => 0x200;
        public static uint STATX_BLOCKS => 0x400;
        public static uint STATX_BASIC_STATS => 0x7ff;
        public static uint STATX_BTIME => 0x800;
        public static uint STATX_ALL => 0xfff;
        public static uint STATX__RESERVED => 0x80000000;

        [DllImport(libc, SetLastError = true)]
        public static extern int chmod(byte* path, mode_t mode);
        [DllImport(libc, SetLastError = true)]
        public static extern int fchmod(int fd, mode_t mode);
        [DllImport(libc, SetLastError = true)]
        public static extern int fchmodat(int dirfd, byte* path, mode_t mode, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern mode_t umask(mode_t mode);
        [DllImport(libc, SetLastError = true)]
        public static extern int mkdir(byte* path, mode_t mode);
        [DllImport(libc, SetLastError = true)]
        public static extern int mkfifo(byte* path, mode_t mode);
        [DllImport(libc, SetLastError = true)]
        public static extern int mkdirat(int dirfd, byte* path, mode_t mode);
        [DllImport(libc, SetLastError = true)]
        public static extern int mkfifoat(int dirfd, byte* path, mode_t mode);
        [DllImport(libc, SetLastError = true)]
        public static extern int futimens(int fd, timespec* times);
        [DllImport(libc, SetLastError = true)]
        public static extern int utimensat(int dirfd, byte* path, timespec* times, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int statx(int dirfd, byte* pathname, int flags, uint mask, statx* statxbuf);
    }
}