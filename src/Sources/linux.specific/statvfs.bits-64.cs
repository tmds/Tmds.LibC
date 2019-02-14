namespace Tmds.Linux
{
    // TODO: this is little endian specific
    public unsafe struct statvfs
    {
        public ulong_t f_bsize;
        public ulong_t f_frsize;
        public fsblkcnt_t f_blocks;
        public fsblkcnt_t f_bfree;
        public fsblkcnt_t f_bavail;
        public fsfilcnt_t f_files;
        public fsfilcnt_t f_ffree;
        public fsfilcnt_t f_favail;
        public ulong_t f_fsid;
        public ulong_t f_flag;
        public ulong_t f_namemax;
        private unsafe fixed int __reserved[6];
    };
}