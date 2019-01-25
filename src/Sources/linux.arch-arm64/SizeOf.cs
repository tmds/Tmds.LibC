namespace Tmds.LibC
{
    public static class SizeOf
    {
        public static ushort iovec => 16;
        public static ushort ucred => 12;
        public static ushort mmsghdr => 64;
        public static ushort linger => 8;
        public static ushort sockaddr => 16;
        public static ushort sockaddr_storage => 128;
        public static ushort sockaddr_in => 16;
        public static ushort sockaddr_in6 => 28;
        public static ushort ipv6_mreq => 20;
        public static ushort ip_opts => 44;
        public static ushort ip_mreq => 8;
        public static ushort ip_mreqn => 12;
        public static ushort ip_mreq_source => 12;
        public static ushort group_req => 136;
        public static ushort in_pktinfo => 12;
        public static ushort in6_pktinfo => 20;
        public static ushort ip6_mtuinfo => 32;
        public static ushort size_t => 8;
        public static ushort cmsghdr => 16;
        public static ushort msghdr => 56;
        public static ushort group_source_req => 264;
        public static ushort group_filter => 272;
        public static ushort sockaddr_un => 110;
        public static ushort sock_extended_err => 16;
        public static ushort epoll_data_t => 8;
        public static ushort epoll_event => 16;
        public static ushort flock => 32;
        public static ushort file_handle => 8;
        public static ushort f_owner_ex => 8;
        public static ushort scm_timestamping => 48;
        public static ushort in_addr => 4;
        public static ushort in6_addr => 16;
        public static ushort ssize_t => size_t;
        public static ushort sa_family_t => 2;
        public static ushort pid_t => 4;
        public static ushort uid_t => 4;
        public static ushort gid_t => 4;
        public static ushort socklen_t => 4;
        public static ushort off_t => 8;
        public static ushort time_t => 8;
        public static ushort mode_t => 4;
        public static ushort timespec => 16;
        public static ushort long_t => size_t;
        public static ushort syscall_arg => size_t;
        public static ushort winsize => 8;
        public static ushort cpu_set_t => 128;
    }
}