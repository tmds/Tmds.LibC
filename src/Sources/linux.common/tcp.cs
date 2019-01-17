namespace Tmds.LibC
{
    public static partial class Definitions
    {
        public static int TCP_NODELAY => 1;
        public static int TCP_MAXSEG => 2;
        public static int TCP_CORK => 3;
        public static int TCP_KEEPIDLE => 4;
        public static int TCP_KEEPINTVL => 5;
        public static int TCP_KEEPCNT => 6;
        public static int TCP_SYNCNT => 7;
        public static int TCP_LINGER2 => 8;
        public static int TCP_DEFER_ACCEPT => 9;
        public static int TCP_WINDOW_CLAMP => 10;
        public static int TCP_INFO => 11;
        public static int TCP_QUICKACK => 12;
        public static int TCP_CONGESTION => 13;
        public static int TCP_MD5SIG => 14;
        public static int TCP_THIN_LINEAR_TIMEOUTS => 16;
        public static int TCP_THIN_DUPACK => 17;
        public static int TCP_USER_TIMEOUT => 18;
        public static int TCP_REPAIR => 19;
        public static int TCP_REPAIR_QUEUE => 20;
        public static int TCP_QUEUE_SEQ => 21;
        public static int TCP_REPAIR_OPTIONS => 22;
        public static int TCP_FASTOPEN => 23;
        public static int TCP_TIMESTAMP => 24;
        public static int TCP_NOTSENT_LOWAT => 25;
        public static int TCP_CC_INFO => 26;
        public static int TCP_SAVE_SYN => 27;
        public static int TCP_SAVED_SYN => 28;
        public static int TCP_REPAIR_WINDOW => 29;
        public static int TCP_FASTOPEN_CONNECT => 30;
        public static int TCP_ULP => 31;
        public static int TCP_MD5SIG_EXT => 32;
        public static int TCP_FASTOPEN_KEY => 33;
        public static int TCP_FASTOPEN_NO_COOKIE => 34;
        public static int SOL_TCP => 6;
    }
}