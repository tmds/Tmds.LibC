namespace Tmds.Linux
{
    public unsafe struct sockaddr_l2
    {
        public sa_family_t l2_family;
        public ushort l2_psm;
        public fixed byte l2_bdaddr[6];
        public ushort l2_cid;
        public byte l2_bdaddr_type;
    }
}
