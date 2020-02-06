using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static partial class LibC
    {
        public static int EFD_CLOEXEC => O_CLOEXEC;
        public static int EFD_NONBLOCK => O_NONBLOCK;
        public static int EFD_SEMAPHORE => 1;

        [DllImport(libc, SetLastError = true)]
        public static extern int eventfd(uint initval, int flags);
    }
}