using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        [DllImport(libc, SetLastError = true)]
        public static extern off_t lseek(int fd, off_t offset, int whence);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t pread(int fd, void* buf, size_t count, off_t offset);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t pwrite(int fd, void* buf, size_t count, off_t offset);
        [DllImport(libc, SetLastError = true)]
        public static extern int truncate(byte* path, off_t length);
        [DllImport(libc, SetLastError = true)]
        public static extern int ftruncate(int fd, off_t length);
        [DllImport(libc, SetLastError = true)]
        public static extern int lockf(int fd, int cmd, off_t len);
    }
}