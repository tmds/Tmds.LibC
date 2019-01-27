using System.Runtime.InteropServices;

namespace Tmds.Linux
{
    public static partial class LibC
    {
        public static unsafe int errno
            // use the value captured by DllImport
            => Marshal.GetLastWin32Error();
    }
}