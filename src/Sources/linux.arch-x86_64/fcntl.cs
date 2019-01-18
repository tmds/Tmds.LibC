namespace Tmds.LibC
{
    public static partial class Definitions
    {
        public static int O_CREAT => 0x40;
        public static int O_EXCL => 0x80;
        public static int O_NOCTTY => 0x100;
        public static int O_TRUNC => 0x200;
        public static int O_APPEND => 0x400;
        public static int O_NONBLOCK => 0x800;
        public static int O_DSYNC => 0x1000;
        public static int O_SYNC => 0x101000;
        public static int O_RSYNC => 0x101000;
        public static int O_DIRECTORY => 0x10000;
        public static int O_NOFOLLOW => 0x20000;
        public static int O_CLOEXEC => 0x80000;

        public static int O_ASYNC => 0x2000;
        public static int O_DIRECT => 0x4000;
        public static int O_LARGEFILE => 0;
        public static int O_NOATIME => 0x40000;
        public static int O_PATH => 0x200000;
        public static int O_TMPFILE => 0x410000;
        public static int O_NDELAY => O_NONBLOCK;

        public static int F_DUPFD => 0;
        public static int F_GETFD => 1;
        public static int F_SETFD => 2;
        public static int F_GETFL => 3;
        public static int F_SETFL => 4;

        public static int F_SETOWN => 8;
        public static int F_GETOWN => 9;
        public static int F_SETSIG => 10;
        public static int F_GETSIG => 11;

        public static int F_GETLK => 5;
        public static int F_SETLK => 6;
        public static int F_SETLKW => 7;

        public static int F_SETOWN_EX => 15;
        public static int F_GETOWN_EX => 16;

        public static int F_GETOWNER_UIDS => 17;
    }
}