using System;
using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public unsafe struct sockaddr_ll
    {
        public ushort sll_family { get; set; }
        public ushort sll_protocol { get; set; }
        public int sll_ifindex { get; set; }
        public ushort sll_hatype { get; set; }
        public byte sll_pkttype { get; set; }
        public byte sll_halen { get; set; }
        public fixed byte sll_addr[8];
    }

    public unsafe struct packet_mreq
    {
        public int mr_ifindex { get; set; }
        public ushort mr_type { get; set; }
        public ushort mr_alen { get; set; }
        public fixed byte mr_address[8];
    }

    public unsafe static partial class LibC
    {
        public static byte PACKET_HOST => 0;
        public static byte PACKET_BROADCAST => 1;
        public static byte PACKET_MULTICAST => 2;
        public static byte PACKET_OTHERHOST => 3;
        public static byte PACKET_OUTGOING => 4;
        public static byte PACKET_LOOPBACK => 5;
        public static byte PACKET_FASTROUTE => 6;

        public static int PACKET_ADD_MEMBERSHIP => 1;
        public static int PACKET_DROP_MEMBERSHIP => 2;
        public static int PACKET_RECV_OUTPUT => 3;
        public static int PACKET_RX_RING => 5;
        public static int PACKET_STATISTICS => 6;
        public static int PACKET_COPY_THRESH => 7;
        public static int PACKET_AUXDATA => 8;
        public static int PACKET_ORIGDEV => 9;
        public static int PACKET_VERSION => 10;
        public static int PACKET_HDRLEN => 11;
        public static int PACKET_RESERVE => 12;
        public static int PACKET_TX_RING => 13;
        public static int PACKET_LOSS => 14;
        public static int PACKET_VNET_HDR => 15;
        public static int PACKET_TX_TIMESTAMP => 16;
        public static int PACKET_TIMESTAMP => 17;
        public static int PACKET_FANOUT => 18;
        public static int PACKET_TX_HAS_OFF => 19;
        public static int PACKET_QDISC_BYPASS => 20;
        public static int PACKET_ROLLOVER_STATS => 21;
        public static int PACKET_FANOUT_DATA => 22;
        public static int PACKET_IGNORE_OUTGOING => 23;

        public static int PACKET_MR_MULTICAST => 0;
        public static int PACKET_MR_PROMISC => 1;
        public static int PACKET_MR_ALLMULTI => 2;
        public static int PACKET_MR_UNICAST => 3;
    }
}