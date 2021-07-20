namespace Tmds.Linux
{
    public struct sockaddr_hci
    {
        public sa_family_t hci_family;
        public ushort hci_dev;
        public ushort hci_channel;
    }

    public static unsafe partial class LibC
    {
        public static ushort HCI_DEV_NONE => 0xffff;

        public static ushort HCI_CHANNEL_RAW => 0;
        public static ushort HCI_CHANNEL_MONITOR => 2;
        public static ushort HCI_CHANNEL_CONTROL => 3;
    }
}
