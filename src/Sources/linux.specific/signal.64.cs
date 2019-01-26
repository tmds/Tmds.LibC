using System.Runtime.InteropServices;

namespace Tmds.LibC
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct siginfo_t
    {
        [FieldOffset(0)] private fixed byte __size[128];

        // TODO errno and code swap on mips
        [FieldOffset(0)] public int si_signo;
        [FieldOffset(4)] public int si_code;
        [FieldOffset(8)] public int si_errno;
        [FieldOffset(16)] public pid_t si_pid;
        [FieldOffset(20)] public uid_t si_uid;
        [FieldOffset(24)] public int si_status;
        [FieldOffset(28)] public clock_t si_utime;
        [FieldOffset(32)] public clock_t si_stime;
        [FieldOffset(24)] public sigval si_value;
        [FieldOffset(16)] public void* si_addr;
        [FieldOffset(24)] public short si_addr_lsb;
        [FieldOffset(32)] public void* si_lower;
        [FieldOffset(40)] public void* si_upper;
        [FieldOffset(32)] public uint si_pkey;
        [FieldOffset(16)] public long_t si_band;
        [FieldOffset(24)] public int si_fd;
        [FieldOffset(16)] public int si_timerid;
        [FieldOffset(20)] public int si_overrun;
        [FieldOffset(24)] public void* si_ptr;
        [FieldOffset(24)] public int si_int;
        [FieldOffset(16)] public void* si_call_addr;
        [FieldOffset(24)] public int si_syscall;
        [FieldOffset(28)] public uint si_arch;
    }

    public unsafe struct sigevent_t
    {
        public sigval sigev_value;
        public int sigev_signo;
        public int sigev_notify;
        public void* sigev_notify_function;
        public void* sigev_notify_attributes;
        private fixed byte __pad[32];
    }
}