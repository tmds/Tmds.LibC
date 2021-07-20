namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        public static int BTPROTO_L2CAP => 0;
        public static int BTPROTO_HCI => 1;
        public static int BTPROTO_SCO => 2;
        public static int BTPROTO_RFCOMM => 3;
        public static int BTPROTO_BNEP => 4;
        public static int BTPROTO_CMTP => 5;
        public static int BTPROTO_HIDP => 6;
        public static int BTPROTO_AVDTP => 7;

        public static int SOL_HCI => 0;
        public static int SOL_L2CAP => 6;
        public static int SOL_SCO => 17;
        public static int SOL_RFCOMM => 18;

        public static byte BDADDR_BREDR => 0x00;
        public static byte BDADDR_LE_PUBLIC => 0x01;
        public static byte BDADDR_LE_RANDOM => 0x02;
    }
}
