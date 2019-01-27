using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        public static int strerror_r(int errnum, byte* buf, size_t buflen)
            => _strerror_r(errnum, buf, buflen);

        [DllImport(libc, EntryPoint="__xpg_strerror_r")]
        private static extern int _strerror_r(int errnum, byte* buf, size_t buflen);
    }
}