
using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        public static int ST_RDONLY =>  1;
        public static int ST_NOSUID =>  2;
        public static int ST_NODEV  =>  4;
        public static int ST_NOEXEC =>  8;
        public static int ST_SYNCHRONOUS  => 16;
        public static int ST_MANDLOCK     => 64;
        public static int ST_WRITE      =>  128;
        public static int ST_APPEND     =>  256;
        public static int ST_IMMUTABLE  =>  512;
        public static int ST_NOATIME     => 1024;
        public static int ST_NODIRATIME  => 2048;
        public static int ST_RELATIME    => 4096;

        [DllImport(libc, SetLastError = true)]
        public static extern int statvfs(byte* path, statvfs* buf);
        [DllImport(libc, SetLastError = true)]
        public static extern int fstatvfs(int fd, statvfs* buf);
    }
}