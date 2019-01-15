using System.Runtime.InteropServices;
using static Tmds.LibC.LibraryNames;

namespace Tmds.LibC
{
    public static unsafe partial class Definitions
    {
        public static int strerror_r(int errnum, byte* buf, size_t buflen)
            => _strerror_r(errnum, buf, buflen);

        [DllImport(libc, EntryPoint="__xpg_strerror_r")]
        private static extern int _strerror_r(int errnum, byte* buf, size_t buflen);
    }
}