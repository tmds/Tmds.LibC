namespace Tmds.LibC
{
    public partial struct size_t
    {
        private ulong __value;
        internal ulong Value => __value;

        internal size_t(ulong arg) { __value = arg; }
        internal size_t(uint arg) { __value = arg; }
        unsafe internal size_t(void* arg) { __value = (ulong)arg; }

        internal uint ToUInt32() => (uint)Value;
        internal ulong ToUInt64() => Value;
    }

    public partial struct ssize_t
    {
        private long __value;
        internal long Value => __value;

        internal ssize_t(long arg) { __value = arg; }

        internal int ToInt32() => (int)Value;
        internal long ToInt64() => Value;
    }
}