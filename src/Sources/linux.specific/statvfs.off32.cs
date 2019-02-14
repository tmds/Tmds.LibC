using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        [DllImport(libc, SetLastError = true, EntryPoint = "statvfs64")]
        public static extern int statvfs(byte* path, statvfs* buf);
        [DllImport(libc, SetLastError = true, EntryPoint = "fstatvfs64")]
        public static extern int fstatvfs(int fd, statvfs* buf);
    }
}