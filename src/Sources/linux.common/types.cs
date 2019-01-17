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
}