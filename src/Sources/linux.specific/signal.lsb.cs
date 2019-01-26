using System.Runtime.InteropServices;
using static Tmds.LibC.LibraryNames;

namespace Tmds.LibC
{
    public static unsafe partial class Definitions
    {
        public static int sigpause(int sig)
            => __xpg_sigpause(sig);

        [DllImport(libc, SetLastError = true)]
        private static extern int __xpg_sigpause(int sig);
    }
}