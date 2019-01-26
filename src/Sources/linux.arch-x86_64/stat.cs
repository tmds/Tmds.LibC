namespace Tmds.LibC
{
    public unsafe struct stat
    {
        public dev_t st_dev;
        public ino_t st_ino;
        public nlink_t st_nlink;
        public mode_t st_mode;
        public uid_t st_uid;
        public gid_t st_gid;
        private uint  __pad0;
        public dev_t st_rdev;
        public off_t st_size;
        public blksize_t st_blksize;
        public blkcnt_t st_blocks;
        public timespec st_atim;
        public timespec st_mtim;
        public timespec st_ctim;
        private fixed long __unused[3];
    }
}