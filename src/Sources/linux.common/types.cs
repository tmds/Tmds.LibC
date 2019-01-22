
namespace Tmds.LibC
{
    public partial struct size_t
    {
        public static implicit operator ulong(size_t arg) => arg.ToUInt64();
        public static explicit operator size_t(ulong arg) => new size_t(arg);

        public static explicit operator uint(size_t arg) => arg.ToUInt32();
        public static implicit operator size_t(uint arg) => new size_t(arg);

        // .NET uses 'int' mostly to for lengths.
        public static implicit operator size_t(int arg) => new size_t((uint)arg);
        public static explicit operator int(size_t arg) => (int)arg._value;
    }

    public partial struct ssize_t
    {
        public static implicit operator long(ssize_t arg) => arg.ToInt64();
        public static explicit operator ssize_t(long arg) => new ssize_t(arg);

        public static explicit operator int(ssize_t arg) => arg.ToInt32();
        public static implicit operator ssize_t(int arg) => new ssize_t(arg);
    }

    public struct syscall_arg
    {
        private ssize_t _value;

        private unsafe syscall_arg(size_t value) => _value = *(ssize_t*)&value;
        private syscall_arg(ssize_t value) => _value = value;

        public static implicit operator syscall_arg(size_t arg) => new syscall_arg(arg);
        public static implicit operator syscall_arg(ssize_t arg) => new syscall_arg(arg);
        public static implicit operator syscall_arg(long_t arg) => new syscall_arg(arg._value);

        public static implicit operator syscall_arg(uint arg) => new syscall_arg(new size_t(arg));
        public static implicit operator syscall_arg(int arg) => new syscall_arg(new ssize_t(arg));

        public unsafe static implicit operator syscall_arg(void* arg) => new syscall_arg(new size_t(arg));

        public static implicit operator ssize_t(syscall_arg arg) => arg._value;
        public static explicit operator int(syscall_arg arg) => (int)arg._value;
    }

    public struct sa_family_t
    {
        private ushort _value;

        private sa_family_t(int value) => _value = (ushort)value;

        public static implicit operator int(sa_family_t arg) => arg._value;
        public static implicit operator sa_family_t(int arg) => new sa_family_t(arg);
    }

    public struct pid_t
    {
        private int _value;

        private pid_t(int value) => _value = value;

        public static implicit operator int(pid_t arg) => arg._value;
        public static implicit operator pid_t(int arg) => new pid_t(arg);
    }

    public struct uid_t
    {
        private uint _value;

        private uid_t(uint value) => _value = value;

        public static implicit operator uint(uid_t arg) => arg._value;
        public static implicit operator uid_t(uint arg) => new uid_t(arg);
    }

    public struct gid_t
    {
        private uint _value;

        private gid_t(uint value) => _value = value;

        public static implicit operator uint(gid_t arg) => arg._value;
        public static implicit operator gid_t(uint arg) => new gid_t(arg);
    }

    public struct socklen_t
    {
        private uint _value;

        private socklen_t(uint value) => _value = value;

        public static implicit operator uint(socklen_t arg) => arg._value;
        public static implicit operator socklen_t(uint arg) => new socklen_t(arg);

        // .NET uses 'int' mostly to for lengths.
        public static implicit operator socklen_t(int arg) => new socklen_t((uint)arg);
        public static explicit operator int(socklen_t arg) => (int)arg._value;
        // Make unambiguous implicit int vs uint
        public static implicit operator socklen_t(ushort arg) => new socklen_t(arg);

        public static bool operator==(socklen_t lhs, socklen_t rhs) => lhs._value == rhs._value;
        public static bool operator<=(socklen_t lhs, socklen_t rhs) => lhs._value <= rhs._value;
        public static bool operator>=(socklen_t lhs, socklen_t rhs) => lhs._value >= rhs._value;
        public static bool operator!=(socklen_t lhs, socklen_t rhs) => lhs._value != rhs._value;
        public static bool operator>(socklen_t lhs, socklen_t rhs) => lhs._value > rhs._value;
        public static bool operator<(socklen_t lhs, socklen_t rhs) => lhs._value < rhs._value;
    }

    public struct off_t
    {
        private long _value;

        private off_t(long value) => _value = value;

        public static implicit operator long(off_t arg) => arg._value;
        public static implicit operator off_t(long arg) => new off_t(arg);
    }

    public struct time_t
    {
        // 32-bit values overflow in 2038: https://sourceware.org/glibc/wiki/Y2038ProofnessDesign
        private ssize_t _value;

        internal time_t(long arg) => _value = new ssize_t(arg);

        public static implicit operator long(time_t arg) => (long)arg._value;

        public static implicit operator time_t(long arg) => new time_t(arg);
    }

    public struct timespec
    {
        public time_t tv_sec;
        public long_t tv_nsec;
    }

    public struct long_t
    {
        internal ssize_t _value;

        private long_t(ssize_t value) => _value = value;

        public static implicit operator long(long_t arg) => (long)arg._value;
        public static explicit operator long_t(long arg) => new long_t(new ssize_t(arg));

        public static explicit operator int(long_t arg) => (int)arg._value;
        public static implicit operator long_t(int arg) => new long_t(arg);
    }
}