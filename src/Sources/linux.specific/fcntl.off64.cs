using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public unsafe static partial class LibC
    {
        [DllImport(libc, SetLastError = true)]
        public static extern int creat(byte* pathname, mode_t mode);
        [DllImport(libc, SetLastError = true)]
        public static extern int open(byte* pathname, int flags, mode_t mode = default(mode_t));
        [DllImport(libc, SetLastError = true)]
        public static extern int openat(int dirfd, byte* pathname, int flags, mode_t mode = default(mode_t));
        [DllImport(libc, SetLastError = true)]
        public static extern int posix_fadvise(int fd, off_t offset, off_t length, int advice);
        [DllImport(libc, SetLastError = true)]
        public static extern int posix_fallocate(int fd, off_t offset, off_t length);
        [DllImport(libc, SetLastError = true)]
        public static extern int fallocate(int fd, int mode, off_t offset, off_t length);
    }
}