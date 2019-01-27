using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        [DllImport(libc)]
        public static extern int strerror_r(int errnum, byte* buf, size_t buflen);
    }
}