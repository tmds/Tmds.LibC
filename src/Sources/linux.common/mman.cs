using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        public static void* MAP_FAILED => ((void*)-1);

        public static int PROT_READ => 0x1;
        public static int PROT_WRITE => 0x2;
        public static int PROT_EXEC => 0x4;
        public static int PROT_SEM => 0x8;
        public static int PROT_NONE => 0x0;
        public static int PROT_GROWSDOWN => 0x01000000;
        public static int PROT_GROWSUP => 0x02000000;

        public static int MAP_TYPE => 0x0f;
        public static int MAP_FIXED => 0x10;
        public static int MAP_ANONYMOUS => 0x20;

        public static int MAP_POPULATE => 0x008000;
        public static int MAP_NONBLOCK => 0x010000;
        public static int MAP_STACK => 0x020000;
        public static int MAP_HUGETLB => 0x040000;
        public static int MAP_SYNC => 0x080000;
        public static int MAP_FIXED_NOREPLACE => 0x100000;

        public static int MAP_UNINITIALIZED => 0x4000000;

        public static int MLOCK_ONFAULT => 0x01;

        public static int MS_ASYNC => 1;
        public static int MS_INVALIDATE => 2;
        public static int MS_SYNC => 4;

        public static int MADV_NORMAL => 0;
        public static int MADV_RANDOM => 1;
        public static int MADV_SEQUENTIAL => 2;
        public static int MADV_WILLNEED => 3;
        public static int MADV_DONTNEED => 4;

        public static int MADV_FREE => 8;
        public static int MADV_REMOVE => 9;
        public static int MADV_DONTFORK => 10;
        public static int MADV_DOFORK => 11;
        public static int MADV_HWPOISON => 100;
        public static int MADV_SOFT_OFFLINE => 101;

        public static int MADV_MERGEABLE => 12;
        public static int MADV_UNMERGEABLE => 13;

        public static int MADV_HUGEPAGE => 14;
        public static int MADV_NOHUGEPAGE => 15;
        public static int MADV_DONTDUMP => 16;
        public static int MADV_DODUMP => 17;

        public static int MADV_WIPEONFORK => 18;
        public static int MADV_KEEPONFORK => 19;

        public static int MAP_FILE => 0;

        public static int PKEY_DISABLE_ACCESS => 0x1;
        public static int PKEY_DISABLE_WRITE => 0x2;
        public static int PKEY_ACCESS_MASK => PKEY_DISABLE_ACCESS | PKEY_DISABLE_WRITE;

        [DllImport(libc, SetLastError = true)]
        public static extern int munmap(void* addr, size_t length);

        [DllImport(libc, SetLastError = true)]
        public static extern int mprotect(void* addr, size_t len, int prot);

        [DllImport(libc, SetLastError = true)]
        public static extern int msync(void* addr, size_t len, int flags);

        [DllImport(libc, SetLastError = true)]
        public static extern int mlock(void* addr, size_t len);

        [DllImport(libc, SetLastError = true)]
        public static extern int mlock2(void* addr, size_t len, int flags);

        [DllImport(libc, SetLastError = true)]
        public static extern int munlock(void* addr, size_t len);

        [DllImport(libc, SetLastError = true)]
        public static extern int mlockall(int flags);

        [DllImport(libc, SetLastError = true)]
        public static extern int munlockall();
    }
}