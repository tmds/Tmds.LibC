using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
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
    }
}