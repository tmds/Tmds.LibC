using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public unsafe struct Dl_info
    {
        public byte* dli_fname { get; set; }
        public void* dli_fbase { get; set; }
        public byte* dli_sname { get; set; }
        public void* dli_saddr { get; set; }
    }

    public static unsafe partial class LibC
    {
        public static int RTLD_LAZY => 1;
        public static int RTLD_NOW => 2;
        public static int RTLD_NOLOAD => 4;
        public static int RTLD_NODELETE => 4096;
        public static int RTLD_GLOBAL => 256;
        public static int RTLD_LOCAL => 0;

        public static void* RTLD_NEXT => ((void*)-1);
        public static void* RTLD_DEFAULT => ((void*)0);

        [DllImport(libdl)]
        public static extern int dlclose(void* handle);
        [DllImport(libdl)]
        public static extern byte* dlerror();
        [DllImport(libdl)]
        public static extern void* dlopen(byte* filename, int flags);
        [DllImport(libdl)]
        public static extern void* dlsym(void* handle, byte* symbol);
        [DllImport(libdl)]
        public static extern void* dlvsym(void* handle, byte* symbol, byte* version);
        [DllImport(libdl)]
        public static extern int dladdr(void* addr, Dl_info* info);
        [DllImport(libdl)]
        public static extern int dlinfo(void* handle, int request, void* info);
    }
}