using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public unsafe static partial class LibC
    {
        [DllImport(libc, SetLastError = true)]
        public static extern void* mmap(void* addr, size_t length, int prot, int flags, int fd, off_t offset);
    }
}