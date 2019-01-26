namespace Tmds.LibC
{
    public unsafe struct stat
    {
        public dev_t st_dev;
        public ino_t st_ino;
        public mode_t st_mode;
        public nlink_t st_nlink;
        public uid_t st_uid;
        public gid_t st_gid;
        public dev_t st_rdev;
        private ulong  __pad0;
        public off_t st_size;
        public blksize_t st_blksize;
        private int  __pad2;
        public blkcnt_t st_blocks;
        public timespec st_atim;
        public timespec st_mtim;
        public timespec st_ctim;
        private fixed uint __unused[2];
    }
}