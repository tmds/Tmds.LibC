
namespace Tmds.LibC
{
    public partial struct size_t
    {
        public static implicit operator ulong(size_t arg) => arg.ToUInt64();
        public static explicit operator size_t(ulong arg) => new size_t(arg);

        public static explicit operator uint(size_t arg) => arg.ToUInt32();
        public static implicit operator size_t(uint arg) => new size_t(arg);
        public static implicit operator size_t(ushort arg) => new size_t(arg);

        // .NET uses 'int' mostly to for lengths.
        public static implicit operator size_t(int arg) => new size_t((uint)arg);
        public static explicit operator int(size_t arg) => (int)arg.Value;

        public override string ToString() => Value.ToString();
    }

    public partial struct ssize_t
    {
        public static implicit operator long(ssize_t arg) => arg.ToInt64();
        public static explicit operator ssize_t(long arg) => new ssize_t(arg);

        public static explicit operator int(ssize_t arg) => arg.ToInt32();
        public static implicit operator ssize_t(int arg) => new ssize_t(arg);

        public override string ToString() => Value.ToString();
    }

    public struct syscall_arg
    {
        private ssize_t __value;
        internal ssize_t Value => __value;

        private unsafe syscall_arg(size_t value) => __value = *(ssize_t*)&value;
        private syscall_arg(ssize_t value) => __value = value;

        public static implicit operator syscall_arg(size_t arg) => new syscall_arg(arg);
        public static implicit operator syscall_arg(ssize_t arg) => new syscall_arg(arg);
        public static implicit operator syscall_arg(long_t arg) => new syscall_arg(arg.Value);

        public static implicit operator syscall_arg(uint arg) => new syscall_arg(new size_t(arg));
        public static implicit operator syscall_arg(int arg) => new syscall_arg(new ssize_t(arg));

        public unsafe static implicit operator syscall_arg(void* arg) => new syscall_arg(new size_t(arg));

        public static implicit operator ssize_t(syscall_arg arg) => arg.Value;
        public static explicit operator int(syscall_arg arg) => (int)arg.Value;

        public override string ToString() => Value.ToString();
    }

    public struct sa_family_t
    {
        private ushort __value;
        internal ushort Value => __value;

        private sa_family_t(int value) => __value = (ushort)value;

        public static implicit operator int(sa_family_t arg) => arg.Value;
        public static implicit operator sa_family_t(int arg) => new sa_family_t(arg);

        public override string ToString() => Value.ToString();
    }

    public struct pid_t
    {
        private int __value;
        internal int Value => __value;

        private pid_t(int value) => __value = value;

        public static implicit operator int(pid_t arg) => arg.Value;
        public static implicit operator pid_t(int arg) => new pid_t(arg);

        public override string ToString() => Value.ToString();
    }

    public struct uid_t
    {
        private uint __value;
        internal uint Value => __value;

        private uid_t(uint value) => __value = value;

        public static implicit operator uint(uid_t arg) => arg.Value;
        public static implicit operator uid_t(uint arg) => new uid_t(arg);

        public override string ToString() => Value.ToString();
    }

    public struct gid_t
    {
        private uint __value;
        internal uint Value => __value;

        private gid_t(uint value) => __value = value;

        public static implicit operator uint(gid_t arg) => arg.Value;
        public static implicit operator gid_t(uint arg) => new gid_t(arg);

        public override string ToString() => Value.ToString();
    }

    public struct socklen_t
    {
        private uint __value;
        internal uint Value => __value;

        private socklen_t(uint value) => __value = value;

        public static implicit operator uint(socklen_t arg) => arg.Value;
        public static implicit operator socklen_t(uint arg) => new socklen_t(arg);

        // .NET uses 'int' mostly to for lengths.
        public static implicit operator socklen_t(int arg) => new socklen_t((uint)arg);
        public static explicit operator int(socklen_t arg) => (int)arg.Value;
        // Make unambiguous implicit int vs uint
        public static implicit operator socklen_t(ushort arg) => new socklen_t(arg);

        public static bool operator==(socklen_t lhs, socklen_t rhs) => lhs.Value == rhs.Value;
        public static bool operator<=(socklen_t lhs, socklen_t rhs) => lhs.Value <= rhs.Value;
        public static bool operator>=(socklen_t lhs, socklen_t rhs) => lhs.Value >= rhs.Value;
        public static bool operator!=(socklen_t lhs, socklen_t rhs) => lhs.Value != rhs.Value;
        public static bool operator>(socklen_t lhs, socklen_t rhs) => lhs.Value > rhs.Value;
        public static bool operator<(socklen_t lhs, socklen_t rhs) => lhs.Value < rhs.Value;

        public override string ToString() => Value.ToString();
    }

    public struct off_t
    {
        // always use 64-bit (-D_FILE_OFFSET_BITS=64 on 32-bit)
        private long __value;
        internal long Value => __value;

        private off_t(long value) => __value = value;

        public static implicit operator long(off_t arg) => arg.Value;
        public static implicit operator off_t(long arg) => new off_t(arg);

        public override string ToString() => Value.ToString();
    }

    public struct time_t
    {
        // 32-bit values overflow in 2038: https://sourceware.org/glibc/wiki/Y2038ProofnessDesign
        private ssize_t __value;
        internal ssize_t Value => __value;

        internal time_t(long arg) => __value = new ssize_t(arg);

        public static implicit operator long(time_t arg) => (long)arg.Value;

        public static implicit operator time_t(long arg) => new time_t(arg);

        public override string ToString() => Value.ToString();
    }

    public struct timespec
    {
        public time_t tv_sec;
        public long_t tv_nsec;
    }

    public struct long_t
    {
        internal ssize_t __value;
        internal ssize_t Value => __value;

        private long_t(ssize_t value) => __value = value;

        public static implicit operator long(long_t arg) => (long)arg.Value;
        public static explicit operator long_t(long arg) => new long_t(new ssize_t(arg));

        public static explicit operator int(long_t arg) => (int)arg.Value;
        public static implicit operator long_t(int arg) => new long_t(arg);

        public override string ToString() => Value.ToString();
    }

    public struct mode_t
    {
        private uint __value;
        internal uint Value => __value;

        private mode_t(uint value) => __value = value;

        public static implicit operator mode_t(ushort value) => new mode_t(value);

        public static mode_t operator&(mode_t lhs, mode_t rhs) => new mode_t(lhs.Value & rhs.Value);

        public static bool operator==(mode_t lhs, mode_t rhs) => lhs.Value == rhs.Value;

        public static bool operator!=(mode_t lhs, mode_t rhs) => lhs.Value != rhs.Value;

        public override string ToString() => Value.ToString();
    }
}