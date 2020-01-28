using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static partial class LibC
    {
        public static int EFD_CLOEXEC => 0x80000;
        public static int EFD_NONBLOCK => 0x800;
        public static int EFD_SEMAPHORE => 1;

        [DllImport(libc, SetLastError = true)]
        public static extern int eventfd(uint initval, int flags);
    }
}