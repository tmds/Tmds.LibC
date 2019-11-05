using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        public static void* MAP_FAILED => ((void*)-1);

        public static int MAP_SHARED => 0x01;
        public static int MAP_PRIVATE => 0x02;
        public static int MAP_SHARED_VALIDATE => 0x03;
        public static int MAP_TYPE => 0x0f;
        public static int MAP_FIXED => 0x10;
        public static int MAP_ANON => 0x20;
        public static int MAP_ANONYMOUS => MAP_ANON;
        public static int MAP_NORESERVE => 0x4000;
        public static int MAP_GROWSDOWN => 0x0100;
        public static int MAP_DENYWRITE => 0x0800;
        public static int MAP_EXECUTABLE => 0x1000;
        public static int MAP_LOCKED => 0x2000;
        public static int MAP_POPULATE => 0x8000;
        public static int MAP_NONBLOCK => 0x10000;
        public static int MAP_STACK => 0x20000;
        public static int MAP_HUGETLB => 0x40000;
        public static int MAP_SYNC => 0x80000;
        public static int MAP_FIXED_NOREPLACE => 0x100000;
        public static int MAP_FILE => 0;

        public static int MAP_HUGE_SHIFT => 26;
        public static int MAP_HUGE_MASK => 0x3f;
        public static int MAP_HUGE_64KB => (16 << 26);
        public static int MAP_HUGE_512KB => (19 << 26);
        public static int MAP_HUGE_1MB => (20 << 26);
        public static int MAP_HUGE_2MB => (21 << 26);
        public static int MAP_HUGE_8MB => (23 << 26);
        public static int MAP_HUGE_16MB => (24 << 26);
        public static int MAP_HUGE_32MB => (25 << 26);
        public static int MAP_HUGE_256MB => (28 << 26);
        public static int MAP_HUGE_512MB => (29 << 26);
        public static int MAP_HUGE_1GB => (30 << 26);
        public static int MAP_HUGE_2GB => (31 << 26);
        public static int MAP_HUGE_16GB => unchecked((int)(34U << 26));

        public static int PROT_NONE => 0;
        public static int PROT_READ => 1;
        public static int PROT_WRITE => 2;
        public static int PROT_EXEC => 4;
        public static int PROT_GROWSDOWN => 0x01000000;
        public static int PROT_GROWSUP => 0x02000000;

        public static int MS_ASYNC => 1;
        public static int MS_INVALIDATE => 2;
        public static int MS_SYNC => 4;

        public static int MCL_CURRENT => 1;
        public static int MCL_FUTURE => 2;
        public static int MCL_ONFAULT => 4;

        public static int POSIX_MADV_NORMAL => 0;
        public static int POSIX_MADV_RANDOM => 1;
        public static int POSIX_MADV_SEQUENTIAL => 2;
        public static int POSIX_MADV_WILLNEED => 3;
        public static int POSIX_MADV_DONTNEED => 4;

        public static int MADV_NORMAL => 0;
        public static int MADV_RANDOM => 1;
        public static int MADV_SEQUENTIAL => 2;
        public static int MADV_WILLNEED => 3;
        public static int MADV_DONTNEED => 4;
        public static int MADV_FREE => 8;
        public static int MADV_REMOVE => 9;
        public static int MADV_DONTFORK => 10;
        public static int MADV_DOFORK => 11;
        public static int MADV_MERGEABLE => 12;
        public static int MADV_UNMERGEABLE => 13;
        public static int MADV_HUGEPAGE => 14;
        public static int MADV_NOHUGEPAGE => 15;
        public static int MADV_DONTDUMP => 16;
        public static int MADV_DODUMP => 17;
        public static int MADV_WIPEONFORK => 18;
        public static int MADV_KEEPONFORK => 19;
        public static int MADV_HWPOISON => 100;
        public static int MADV_SOFT_OFFLINE => 101;


        public static int MREMAP_MAYMOVE => 1;
        public static int MREMAP_FIXED => 2;

        public static int MLOCK_ONFAULT => 0x01;

        public static uint MFD_CLOEXEC => 0x0001U;
        public static uint MFD_ALLOW_SEALING => 0x0002U;
        public static uint MFD_HUGETLB => 0x0004U;


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

        [DllImport(libc, SetLastError = true)]
        public static extern void* mremap(void* old_address, size_t old_size, size_t new_size, int flags, void* new_address);
        [DllImport(libc, SetLastError = true)]
        public static extern int remap_file_pages(void* addr, size_t size, int prot, size_t pgoff, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int memfd_create(byte* name, uint flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int madvise(void* addr, size_t length, int advice);
        [DllImport(libc, SetLastError = true)]
        public static extern int mincore(void* addr, size_t length, byte* vec);
    }
}