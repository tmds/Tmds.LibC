using System.Runtime.InteropServices;

namespace Tmds.LibC
{
    public static partial class Definitions
    {
        public static unsafe int errno
            // use the value captured by DllImport
            => Marshal.GetLastWin32Error();
    }
}