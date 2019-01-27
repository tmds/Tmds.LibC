namespace Tmds.Linux
{
    public partial struct nlink_t
    {
        private ulong __value;
        internal ulong Value => __value;
        private nlink_t(ulong value) => __value = value;
    }

    public partial struct blksize_t
    {
        private long __value;
        internal long Value => __value;
        public blksize_t(long value) => __value = value;
    }
}