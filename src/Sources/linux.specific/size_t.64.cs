namespace Tmds.LibC
{
    public partial struct size_t
    {
        private ulong _value;

        private size_t(ulong arg) { _value = arg; }
        private size_t(uint arg) { _value = arg; }

        internal uint ToUInt32() => (uint)_value;
        internal ulong ToUInt64() => _value;
    }

    public partial struct ssize_t
    {
        private long _value;

        private ssize_t(long arg) { _value = arg; }

        internal int ToInt32() => (int)_value;
        internal long ToInt64() => _value;
    }
}