using System.Runtime.InteropServices;
using static Tmds.LibC.LibraryNames;

namespace Tmds.LibC
{
    public static unsafe partial class Definitions
    {
        [DllImport(libc)]
        public static extern int strerror_r(int errnum, byte* buf, size_t buflen);
    }
}