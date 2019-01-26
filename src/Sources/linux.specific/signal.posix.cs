using System.Runtime.InteropServices;
using System.Runtime.InteropServices;
using static Tmds.LibC.LibraryNames;

namespace Tmds.LibC
{
    public static unsafe partial class Definitions
    {
        [DllImport(libc, SetLastError = true)]
        public static extern int sigpause(int sig);
    }
}