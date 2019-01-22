namespace Tmds.LibC
{
    public partial struct size_t
    {
        private ulong _value;

        internal size_t(ulong arg) { _value = arg; }
        internal size_t(uint arg) { _value = arg; }
        unsafe internal size_t(void* arg) { _value = (ulong)arg; }

        internal uint ToUInt32() => (uint)_value;
        internal ulong ToUInt64() => _value;
    }

    public partial struct ssize_t
    {
        private long _value;

        internal ssize_t(long arg) { _value = arg; }

        internal int ToInt32() => (int)_value;
        internal long ToInt64() => _value;
    }
}