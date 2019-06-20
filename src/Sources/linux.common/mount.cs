using System;
using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        public static ulong_t MS_RDONLY => 1;

        public static ulong_t MS_NOSUID => 2;		

        public static ulong_t MS_NODEV => 4;			

        public static ulong_t MS_NOEXEC => 8;		

        public static ulong_t MS_SYNCHRONOUS => 16;		

        public static ulong_t MS_REMOUNT => 32;		

        public static ulong_t MS_MANDLOCK => 64;		

        public static ulong_t MS_DIRSYNC => 128;		

        public static ulong_t MS_NOATIME => 1024;		

        public static ulong_t MS_NODIRATIME => 2048;		

        public static ulong_t MS_BIND => 4096;		

        public static ulong_t MS_MOVE => 8192;

        public static ulong_t MS_REC => 16384;

        public static ulong_t MS_SILENT => 32768;

        public static ulong_t MS_POSIXACL => 1 << 16;	

        public static ulong_t MS_UNBINDABLE => 1 << 17;	

        public static ulong_t MS_PRIVATE => 1 << 18;		

        public static ulong_t MS_SLAVE => 1 << 19;		

        public static ulong_t MS_SHARED => 1 << 20;		

        public static ulong_t MS_RELATIME => 1 << 21;

        public static ulong_t MS_KERNMOUNT => 1 << 22;

        public static ulong_t MS_I_VERSION =>  1 << 23;

        public static ulong_t MS_STRICTATIME => 1 << 24;	

        public static ulong_t MS_ACTIVE => 1 << 30;

        public static ulong_t MS_NOUSER => 1U << 31;

        public static int MNT_FORCE => 1;
        
        public static int MNT_DETACH => 2;
        
        public static int MNT_EXPIRE => 4;
        
        public static int UMOUNT_NOFOLLOW => 8;
        
        [DllImport(libc, SetLastError = true)]
        public static extern int mount(byte* source, byte* target, byte* filesystemtype, ulong_t mountflags, void* data);
        
        [DllImport(libc, SetLastError = true)]
        public static extern int umount(byte* target);
        
        [DllImport(libc, SetLastError = true)]
        public static extern int umount2(byte* target, int flags);
    }
}