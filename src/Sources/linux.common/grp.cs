using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public unsafe struct group
    {
        public byte* gr_name;
        public byte* gr_passwd;
        public gid_t gr_gid;
        public byte **gr_mem;
    }

    public unsafe static partial class LibC
    {
        [DllImport(libc)]
        public static extern int getgrnam_r(byte* name, group* grp, byte* buffer, size_t buflen, group** result);
    }
}
