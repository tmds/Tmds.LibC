namespace Tmds.Linux
{
    public partial struct nlink_t
    {
        private uint __value;
        internal uint Value => __value;
        private nlink_t(ulong value) => __value = (uint)value;
    }

    public partial struct blksize_t
    {
        private int __value;
        internal int Value => __value;
        private blksize_t(long value) => __value = (int)value;
    }
}