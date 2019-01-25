
using System;
using System.Runtime.InteropServices;
using static Tmds.LibC.LibraryNames;

namespace Tmds.LibC
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct cpu_set_t
    {
        [FieldOffset(0)]
        private IntPtr __align;
        [FieldOffset(0)]
        private fixed byte __data[128];
    }

    public static unsafe partial class Definitions
    {
        [DllImport(libc, SetLastError = true)]
        public static extern int sched_get_priority_max(int policy);
        [DllImport(libc, SetLastError = true)]
        public static extern int sched_get_priority_min(int policy);
        [DllImport(libc, SetLastError = true)]
        public static extern int sched_getscheduler(pid_t pid);
        [DllImport(libc, SetLastError = true)]
        public static extern int sched_rr_get_interval(pid_t pid, timespec* tp);
        [DllImport(libc, SetLastError = true)]
        public static extern int sched_yield();

        public static int SCHED_OTHER => 0;
        public static int SCHED_FIFO => 1;
        public static int SCHED_RR => 2;
        public static int SCHED_BATCH => 3;
        public static int SCHED_IDLE => 5;
        public static int SCHED_DEADLINE => 6;
        public static int SCHED_RESET_ON_FORK => 0x40000000;

        public static int CSIGNAL => 0x000000ff;
        public static int CLONE_VM => 0x00000100;
        public static int CLONE_FS => 0x00000200;
        public static int CLONE_FILES => 0x00000400;
        public static int CLONE_SIGHAND => 0x00000800;
        public static int CLONE_PTRACE => 0x00002000;
        public static int CLONE_VFORK => 0x00004000;
        public static int CLONE_PARENT => 0x00008000;
        public static int CLONE_THREAD => 0x00010000;
        public static int CLONE_NEWNS => 0x00020000;
        public static int CLONE_SYSVSEM => 0x00040000;
        public static int CLONE_SETTLS => 0x00080000;
        public static int CLONE_PARENT_SETTID => 0x00100000;
        public static int CLONE_CHILD_CLEARTID => 0x00200000;
        public static int CLONE_DETACHED => 0x00400000;
        public static int CLONE_UNTRACED => 0x00800000;
        public static int CLONE_CHILD_SETTID => 0x01000000;
        public static int CLONE_NEWCGROUP => 0x02000000;
        public static int CLONE_NEWUTS => 0x04000000;
        public static int CLONE_NEWIPC => 0x08000000;
        public static int CLONE_NEWUSER => 0x10000000;
        public static int CLONE_NEWPID => 0x20000000;
        public static int CLONE_NEWNET => 0x40000000;
        public static int CLONE_IO => unchecked((int)0x80000000);

        [DllImport(libc, SetLastError = true)]
        public static extern int clone(void* fn, void* child_stack, int flags, void* arg, pid_t* ptid = null, void* newtls = null, pid_t* ctid = null);
        [DllImport(libc, SetLastError = true)]
        public static extern int unshare(int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int setns(int fd, int nstype);
        [DllImport(libc, SetLastError = true)]
        public static extern int sched_getcpu();
        [DllImport(libc, SetLastError = true)]
        public static extern int sched_getaffinity(pid_t pid, size_t cpusetsize, cpu_set_t* mask);
        [DllImport(libc, SetLastError = true)]
        public static extern int sched_setaffinity(pid_t pid, size_t cpusetsize, cpu_set_t* mask);

        public static void CPU_SET_S(int cpu, size_t cpusetsize, cpu_set_t* set)
        {
            if (cpu / 8 < (int)cpusetsize)
            {
                if (SizeOf.size_t == 4)
                {
                    ((uint*)set)[cpu / 8 / sizeof(uint)] |= 1U << (cpu % (8 * sizeof(uint)));
                }
                else if (SizeOf.size_t == 8)
                {
                    ((ulong*)set)[cpu / 8 / sizeof(ulong)] |= 1UL << (cpu % (8 * sizeof(ulong)));
                }
            }
        }

        public static void CPU_CLR_S(int cpu, size_t cpusetsize, cpu_set_t* set)
        {
            if (cpu / 8 < (int)cpusetsize)
            {
                if (SizeOf.size_t == 4)
                {
                    ((uint*)set)[cpu / 8 / sizeof(uint)] &= ~(1U << (cpu % (8 * sizeof(uint))));
                }
                else if (SizeOf.size_t == 8)
                {
                    ((ulong*)set)[cpu / 8 / sizeof(ulong)] &= ~(1UL << (cpu % (8 * sizeof(ulong))));
                }
            }
        }

        public static bool CPU_ISSET_S(int cpu, size_t cpusetsize, cpu_set_t* set)
        {
            if (cpu / 8 < (int)cpusetsize)
            {
                if (SizeOf.size_t == 4)
                {
                    uint value = (((uint*)set)[cpu / 8 / sizeof(uint)]) & (1U << (cpu % (8 * sizeof(uint))));
                    return value != 0;
                }
                else if (SizeOf.size_t == 8)
                {
                    ulong value = (((ulong*)set)[cpu / 8 / sizeof(ulong)]) & (1UL << (cpu % (8 * sizeof(ulong))));
                    return value != 0;
                }
            }
            return false;
        }

        public static void CPU_AND_S(size_t setsize, cpu_set_t* destset, cpu_set_t* srcset1, cpu_set_t* srcset2)
        {
            byte* dst = (byte*)destset;
            byte* src1 = (byte*)srcset1;
            byte* src2 = (byte*)srcset2;
            for (int i = 0; i < (int)setsize; i++)
            {
                dst[i] = (byte)(src1[i] & src2[i]);
            }
        }

        public static void CPU_OR_S(size_t setsize, cpu_set_t* destset, cpu_set_t* srcset1, cpu_set_t* srcset2)
        {
            byte* dst = (byte*)destset;
            byte* src1 = (byte*)srcset1;
            byte* src2 = (byte*)srcset2;
            for (int i = 0; i < (int)setsize; i++)
            {
                dst[i] = (byte)(src1[i] | src2[i]);
            }
        }

        public static void CPU_XOR_S(size_t setsize, cpu_set_t* destset, cpu_set_t* srcset1, cpu_set_t* srcset2)
        {
            byte* dst = (byte*)destset;
            byte* src1 = (byte*)srcset1;
            byte* src2 = (byte*)srcset2;
            for (int i = 0; i < (int)setsize; i++)
            {
                dst[i] = (byte)(src1[i] ^ src2[i]);
            }
        }

        public static int CPU_COUNT_S(size_t size, cpu_set_t* set)
        {
            byte* s = (byte*)set;
            uint count = 0;
            for (int i = 0; i < (int)size; i++)
            {
                uint n = s[i];
                while (n != 0)
                {
                    count += n & 1;
                    n >>= 1;
                }
            }
            return (int)count;
        }

        public static void CPU_ZERO_S(size_t size, cpu_set_t* set)
        {
            byte* s = (byte*)set;
            for (int i = 0; i < (int)size; i++)
            {
                s[i] = 0;
            }
        }

        public static bool CPU_EQUAL_S(size_t size, cpu_set_t* set1, cpu_set_t* set2)
        {
            byte* s1 = (byte*)set1;
            byte* s2 = (byte*)set2;
            for (int i = 0; i < (int)size; i++)
            {
                if (s1[i] != s2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static int CPU_SETSIZE => 1024;

        public static void CPU_SET(int cpu, cpu_set_t* set) => CPU_SET_S(cpu, SizeOf.cpu_set_t, set);
        public static void CPU_CLR(int cpu, cpu_set_t* set) => CPU_CLR_S(cpu, SizeOf.cpu_set_t, set);
        public static bool CPU_ISSET(int cpu, cpu_set_t* set) => CPU_ISSET_S(cpu, SizeOf.cpu_set_t, set);
        public static void CPU_AND(cpu_set_t* d, cpu_set_t* s1, cpu_set_t* s2) => CPU_AND_S(SizeOf.cpu_set_t, d, s1, s2);
        public static void CPU_OR(cpu_set_t* d, cpu_set_t* s1, cpu_set_t* s2) => CPU_OR_S(SizeOf.cpu_set_t, d, s1, s2);
        public static void CPU_XOR(cpu_set_t* d, cpu_set_t* s1, cpu_set_t* s2) => CPU_XOR_S(SizeOf.cpu_set_t, d, s1, s2);
        public static int CPU_COUNT(cpu_set_t* set) => CPU_COUNT_S(SizeOf.cpu_set_t, set);
        public static void CPU_ZERO(cpu_set_t* set) => CPU_ZERO_S(SizeOf.cpu_set_t, set);
        public static bool CPU_EQUAL(cpu_set_t* s1, cpu_set_t* s2) => CPU_EQUAL_S(SizeOf.cpu_set_t, s1, s2);
    }
}