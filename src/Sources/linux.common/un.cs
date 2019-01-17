namespace Tmds.LibC
{
    public unsafe struct sockaddr_un
    {
        public sa_family_t sun_family { get; set; }
        public fixed byte sun_path[108];
        public static int sun_path_length => 108;
        public static int sun_path_offset => 2;
    }
}