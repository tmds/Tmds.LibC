using in_port_t = System.UInt16;
using in_addr_t = System.UInt32;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Tmds.Linux
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct in_addr
    {
        [FieldOffset(0)]
        private in_addr_t __align;
        [FieldOffset(0)]
        public fixed byte s_addr[4];
    }

    public unsafe struct sockaddr_in
    {
        public sa_family_t sin_family { get; set; }
        public in_port_t sin_port { get; set; }
        public in_addr sin_addr;
        private fixed byte __sin_zero[8];
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct in6_addr
    {
        [FieldOffset(0)]
        private uint __align;
        [FieldOffset(0)]
        public fixed byte s6_addr[16];
    }

    public struct sockaddr_in6
    {
        public sa_family_t sin6_family { get; set; }
        public in_port_t sin6_port { get; set; }
        public uint sin6_flowinfo { get; set; }
        public in6_addr sin6_addr;
        public uint sin6_scope_id { get; set; }
    }

    public struct ipv6_mreq
    {
        public in6_addr ipv6mr_multiaddr;
        public uint ipv6mr_interface { get; set; }
    }

    public unsafe struct ip_opts
    {
        public in_addr ip_dst;
        public fixed byte ip_opts_[40];
    }

    public struct ip_mreq
    {
        public in_addr imr_multiaddr;
        public in_addr imr_interface;
    }

    public struct ip_mreqn
    {
        public in_addr imr_multiaddr;
        public in_addr imr_address;
        public int imr_ifindex { get; set; }
    }

    public struct ip_mreq_source
    {
        public in_addr imr_multiaddr;
        public in_addr imr_interface;
        public in_addr imr_sourceaddr;
    }

    public struct group_req
    {
        public uint gr_interface;
        public sockaddr_storage gr_group;
    }

    public struct group_source_req
    {
        public uint gsr_interface;
        public sockaddr_storage gsr_group;
        public sockaddr_storage gsr_source;
    };

    public unsafe struct group_filter
    {
        public uint gf_interface;
        public sockaddr_storage gf_group;
        public uint gf_fmode;
        public uint gf_numsrc;
        private sockaddr_storage _gf_slist;
        public static sockaddr_storage* gf_slist(group_filter* gf)
            => &gf->_gf_slist;
    }

    public struct in_pktinfo
    {
        public int ipi_ifindex { get; set; }
        public in_addr ipi_spec_dst;
        public in_addr ipi_addr;
    }

    public struct in6_pktinfo
    {
        public in6_addr ipi6_addr;
        public uint ipi6_ifindex { get; set; }
    }

    public struct ip6_mtuinfo
    {
        public sockaddr_in6 ip6m_addr;
        public uint ip6m_mtu;
    }

    public static unsafe partial class LibC
    {
        public static int INET_ADDRSTRLEN => 16;
        public static int INET6_ADDRSTRLEN => 46;

        public static int IPPORT_RESERVED => 1024;

        public static int IPPROTO_IP => 0;
        public static int IPPROTO_HOPOPTS => 0;
        public static int IPPROTO_ICMP => 1;
        public static int IPPROTO_IGMP => 2;
        public static int IPPROTO_IPIP => 4;
        public static int IPPROTO_TCP => 6;
        public static int IPPROTO_EGP => 8;
        public static int IPPROTO_PUP => 12;
        public static int IPPROTO_UDP => 17;
        public static int IPPROTO_IDP => 22;
        public static int IPPROTO_TP => 29;
        public static int IPPROTO_DCCP => 33;
        public static int IPPROTO_IPV6 => 41;
        public static int IPPROTO_ROUTING => 43;
        public static int IPPROTO_FRAGMENT => 44;
        public static int IPPROTO_RSVP => 46;
        public static int IPPROTO_GRE => 47;
        public static int IPPROTO_ESP => 50;
        public static int IPPROTO_AH => 51;
        public static int IPPROTO_ICMPV6 => 58;
        public static int IPPROTO_NONE => 59;
        public static int IPPROTO_DSTOPTS => 60;
        public static int IPPROTO_MTP => 92;
        public static int IPPROTO_BEETPH => 94;
        public static int IPPROTO_ENCAP => 98;
        public static int IPPROTO_PIM => 103;
        public static int IPPROTO_COMP => 108;
        public static int IPPROTO_SCTP => 132;
        public static int IPPROTO_MH => 135;
        public static int IPPROTO_UDPLITE => 136;
        public static int IPPROTO_MPLS => 137;
        public static int IPPROTO_RAW => 255;
        public static int IPPROTO_MAX => 256;

        public static int IN_LOOPBACKNET => 127;

        public static int IP_TOS => 1;
        public static int IP_TTL => 2;
        public static int IP_HDRINCL => 3;
        public static int IP_OPTIONS => 4;
        public static int IP_ROUTER_ALERT => 5;
        public static int IP_RECVOPTS => 6;
        public static int IP_RETOPTS => 7;
        public static int IP_PKTINFO => 8;
        public static int IP_PKTOPTIONS => 9;
        public static int IP_PMTUDISC => 10;
        public static int IP_MTU_DISCOVER => 10;
        public static int IP_RECVERR => 11;
        public static int IP_RECVTTL => 12;
        public static int IP_RECVTOS => 13;
        public static int IP_MTU => 14;
        public static int IP_FREEBIND => 15;
        public static int IP_IPSEC_POLICY => 16;
        public static int IP_XFRM_POLICY => 17;
        public static int IP_PASSSEC => 18;
        public static int IP_TRANSPARENT => 19;
        public static int IP_ORIGDSTADDR => 20;
        public static int IP_RECVORIGDSTADDR => IP_ORIGDSTADDR;
        public static int IP_MINTTL => 21;
        public static int IP_NODEFRAG => 22;
        public static int IP_CHECKSUM => 23;
        public static int IP_BIND_ADDRESS_NO_PORT => 24;
        public static int IP_RECVFRAGSIZE => 25;
        public static int IP_MULTICAST_IF => 32;
        public static int IP_MULTICAST_TTL => 33;
        public static int IP_MULTICAST_LOOP => 34;
        public static int IP_ADD_MEMBERSHIP => 35;
        public static int IP_DROP_MEMBERSHIP => 36;
        public static int IP_UNBLOCK_SOURCE => 37;
        public static int IP_BLOCK_SOURCE => 38;
        public static int IP_ADD_SOURCE_MEMBERSHIP => 39;
        public static int IP_DROP_SOURCE_MEMBERSHIP => 40;
        public static int IP_MSFILTER => 41;
        public static int IP_MULTICAST_ALL => 49;
        public static int IP_UNICAST_IF => 50;

        public static int IP_RECVRETOPTS => IP_RETOPTS;

        public static int IP_PMTUDISC_DONT => 0;
        public static int IP_PMTUDISC_WANT => 1;
        public static int IP_PMTUDISC_DO => 2;
        public static int IP_PMTUDISC_PROBE => 3;
        public static int IP_PMTUDISC_INTERFACE => 4;
        public static int IP_PMTUDISC_OMIT => 5;

        public static int IP_DEFAULT_MULTICAST_TTL => 1;
        public static int IP_DEFAULT_MULTICAST_LOOP => 1;
        public static int IP_MAX_MEMBERSHIPS => 20;
        public static int MCAST_JOIN_GROUP => 42;
        public static int MCAST_BLOCK_SOURCE => 43;
        public static int MCAST_UNBLOCK_SOURCE => 44;
        public static int MCAST_LEAVE_GROUP => 45;
        public static int MCAST_JOIN_SOURCE_GROUP => 46;
        public static int MCAST_LEAVE_SOURCE_GROUP => 47;
        public static int MCAST_MSFILTER => 48;

        public static int MCAST_EXCLUDE => 0;
        public static int MCAST_INCLUDE => 1;

        public static int IPV6_ADDRFORM => 1;
        public static int IPV6_2292PKTINFO => 2;
        public static int IPV6_2292HOPOPTS => 3;
        public static int IPV6_2292DSTOPTS => 4;
        public static int IPV6_2292RTHDR => 5;
        public static int IPV6_2292PKTOPTIONS => 6;
        public static int IPV6_CHECKSUM => 7;
        public static int IPV6_2292HOPLIMIT => 8;
        public static int IPV6_NEXTHOP => 9;
        public static int IPV6_AUTHHDR => 10;
        public static int IPV6_UNICAST_HOPS => 16;
        public static int IPV6_MULTICAST_IF => 17;
        public static int IPV6_MULTICAST_HOPS => 18;
        public static int IPV6_MULTICAST_LOOP => 19;
        public static int IPV6_JOIN_GROUP => 20;
        public static int IPV6_LEAVE_GROUP => 21;
        public static int IPV6_ROUTER_ALERT => 22;
        public static int IPV6_MTU_DISCOVER => 23;
        public static int IPV6_MTU => 24;
        public static int IPV6_RECVERR => 25;
        public static int IPV6_V6ONLY => 26;
        public static int IPV6_JOIN_ANYCAST => 27;
        public static int IPV6_LEAVE_ANYCAST => 28;
        public static int IPV6_IPSEC_POLICY => 34;
        public static int IPV6_XFRM_POLICY => 35;
        public static int IPV6_HDRINCL => 36;

        public static int IPV6_RECVPKTINFO => 49;
        public static int IPV6_PKTINFO => 50;
        public static int IPV6_RECVHOPLIMIT => 51;
        public static int IPV6_HOPLIMIT => 52;
        public static int IPV6_RECVHOPOPTS => 53;
        public static int IPV6_HOPOPTS => 54;
        public static int IPV6_RTHDRDSTOPTS => 55;
        public static int IPV6_RECVRTHDR => 56;
        public static int IPV6_RTHDR => 57;
        public static int IPV6_RECVDSTOPTS => 58;
        public static int IPV6_DSTOPTS => 59;
        public static int IPV6_RECVPATHMTU => 60;
        public static int IPV6_PATHMTU => 61;
        public static int IPV6_DONTFRAG => 62;
        public static int IPV6_RECVTCLASS => 66;
        public static int IPV6_TCLASS => 67;
        public static int IPV6_AUTOFLOWLABEL => 70;
        public static int IPV6_ADDR_PREFERENCES => 72;
        public static int IPV6_MINHOPCOUNT => 73;
        public static int IPV6_ORIGDSTADDR => 74;
        public static int IPV6_RECVORIGDSTADDR => IPV6_ORIGDSTADDR;
        public static int IPV6_TRANSPARENT => 75;
        public static int IPV6_UNICAST_IF => 76;
        public static int IPV6_RECVFRAGSIZE => 77;
        public static int IPV6_FREEBIND => 78;

        public static int IPV6_ADD_MEMBERSHIP => IPV6_JOIN_GROUP;
        public static int IPV6_DROP_MEMBERSHIP => IPV6_LEAVE_GROUP;
        public static int IPV6_RXHOPOPTS => IPV6_HOPOPTS;
        public static int IPV6_RXDSTOPTS => IPV6_DSTOPTS;

        public static int IPV6_PMTUDISC_DONT => 0;
        public static int IPV6_PMTUDISC_WANT => 1;
        public static int IPV6_PMTUDISC_DO => 2;
        public static int IPV6_PMTUDISC_PROBE => 3;
        public static int IPV6_PMTUDISC_INTERFACE => 4;
        public static int IPV6_PMTUDISC_OMIT => 5;

        public static int IPV6_PREFER_SRC_TMP => 0x0001;
        public static int IPV6_PREFER_SRC_PUBLIC => 0x0002;
        public static int IPV6_PREFER_SRC_PUBTMP_DEFAULT => 0x0100;
        public static int IPV6_PREFER_SRC_COA => 0x0004;
        public static int IPV6_PREFER_SRC_HOME => 0x0400;
        public static int IPV6_PREFER_SRC_CGA => 0x0008;
        public static int IPV6_PREFER_SRC_NONCGA => 0x0800;

        public static int IPV6_RTHDR_LOOSE => 0;
        public static int IPV6_RTHDR_STRICT => 1;

        public static int IPV6_RTHDR_TYPE_0 => 0;

        public static in_port_t htons(in_port_t port)
        {
            if (Endian.IsBigEndian)
            {
                return port;
            }
            else
            {
                return (in_port_t)(port << 8 | port >> 8);
            }
        }

        public static in_port_t ntohs(in_port_t port)
            => htons(port);

        public static int GROUP_FILTER_SIZE(int numsrc) =>
            SizeOf.group_filter - SizeOf.sockaddr_storage
                + numsrc * SizeOf.sockaddr_storage;
    }
}