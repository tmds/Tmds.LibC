using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        public static int sigpause(int sig)
            => __xpg_sigpause(sig);

        [DllImport(libc, SetLastError = true)]
        private static extern int __xpg_sigpause(int sig);
    }
}