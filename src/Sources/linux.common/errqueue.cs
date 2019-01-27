namespace Tmds.Linux
{
    public struct sock_extended_err
    {
        public uint ee_errno;
        public byte ee_origin;
        public byte ee_type;
        public byte ee_code;
        public byte ee_pad;
        public uint ee_info;
        public uint ee_data;
    }

    public unsafe struct scm_timestamping
    {
        public timespec ts0;
        public timespec ts1;
        public timespec ts2;
    }

    public unsafe static partial class LibC
    {
        public static byte SO_EE_ORIGIN_NONE => 0;
        public static byte SO_EE_ORIGIN_LOCAL => 1;
        public static byte SO_EE_ORIGIN_ICMP => 2;
        public static byte SO_EE_ORIGIN_ICMP6 => 3;
        public static byte SO_EE_ORIGIN_TXSTATUS => 4;
        public static byte SO_EE_ORIGIN_ZEROCOPY => 5;
        public static byte SO_EE_ORIGIN_TIMESTAMPING => SO_EE_ORIGIN_TXSTATUS;

        public static sockaddr* SO_EE_OFFENDER(sock_extended_err* ee) => ((sockaddr*)((ee) + 1));

        public static byte SO_EE_CODE_ZEROCOPY_COPIED => 1;

        public static uint SCM_TSTAMP_SND => 0;
        public static uint SCM_TSTAMP_SCHED => 1;
        public static uint SCM_TSTAMP_ACK => 2;
    }
}