namespace Tmds.Linux
{
    public partial struct size_t
    {
        private uint __value;
        internal uint Value => __value;

        internal size_t(ulong arg) { __value = (uint)arg; }
        internal size_t(uint arg) { __value = arg; }
        unsafe internal size_t(void* arg) { __value = (uint)arg; }
        internal size_t(ssize_t arg) { __value = (uint)arg.Value; }

        internal uint ToUInt32() => Value;
        internal ulong ToUInt64() => Value;
    }

    public partial struct ssize_t
    {
        private int __value;
        internal int Value => __value;

        internal ssize_t(long arg) { __value = (int)arg; }
        internal ssize_t(int arg) { __value = arg; }

        internal int ToInt32() => Value;
        internal long ToInt64() => Value;
    }
}