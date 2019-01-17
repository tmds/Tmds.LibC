
using System;
using System.Runtime.InteropServices;
using static Tmds.LibC.LibraryNames;

namespace Tmds.LibC
{
    public unsafe struct msghdr
    {
        public void* msg_name { get; set; }
        public socklen_t msg_namelen { get; set; }
        public iovec* msg_iov { get; set; }
        private ssize_t _msg_iovlen;
        public int msg_iovlen { get => _msg_iovlen.ToInt32(); set => _msg_iovlen = value; }
        public void* msg_control { get; set; }
        private size_t _msg_controllen;
        public socklen_t msg_controllen { get => _msg_controllen.ToUInt32(); set => _msg_controllen = (uint)value; }
        public int msg_flags { get; set; }
    }

    public struct cmsghdr
    {
        private size_t _cmsg_len;
        public socklen_t cmsg_len { get => _cmsg_len.ToUInt32(); set => _cmsg_len = (uint)value; }
        public int cmsg_level { get; set; }
        public int cmsg_type { get; set; }
    }

    public struct ucred
    {
        public pid_t pid { get; set; }
        public uid_t uid { get; set; }
        public gid_t gid { get; set; }
    };

    public struct mmsghdr
    {
        public msghdr msg_hdr { get; set; }
        public uint msg_len { get; set; }
    };

    public struct linger
    {
        public int l_onoff { get; set; }
        public int l_linger { get; set; }
    }

    public unsafe struct sockaddr
    {
        public sa_family_t sa_family { get; set; }
        private fixed byte _sa_data[14];
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct sockaddr_storage
    {
        [FieldOffset(0)]
        private void* __ss_align;
        [FieldOffset(0)]
        private fixed byte __ss_size[128];
        [FieldOffset(0)]
        private sa_family_t __ss_family;

        public sa_family_t ss_family { get => __ss_family; set => __ss_family = value; }
    }

    public static unsafe partial class Definitions
    {
        public static int SHUT_RD => 0;
        public static int SHUT_WR => 1;
        public static int SHUT_RDWR => 2;
        public static int SOCK_RAW => 3;
        public static int SOCK_RDM => 4;
        public static int SOCK_SEQPACKET => 5;
        public static int SOCK_DCCP => 6;
        public static int SOCK_PACKET => 10;
        public static sa_family_t PF_UNSPEC => 0;
        public static sa_family_t PF_LOCAL => 1;
        public static sa_family_t PF_UNIX => PF_LOCAL;
        public static sa_family_t PF_FILE => PF_LOCAL;
        public static sa_family_t PF_INET => 2;
        public static sa_family_t PF_AX25 => 3;
        public static sa_family_t PF_IPX => 4;
        public static sa_family_t PF_APPLETALK => 5;
        public static sa_family_t PF_NETROM => 6;
        public static sa_family_t PF_BRIDGE => 7;
        public static sa_family_t PF_ATMPVC => 8;
        public static sa_family_t PF_X25 => 9;
        public static sa_family_t PF_INET6 => 10;
        public static sa_family_t PF_ROSE => 11;
        public static sa_family_t PF_DECnet => 12;
        public static sa_family_t PF_NETBEUI => 13;
        public static sa_family_t PF_SECURITY => 14;
        public static sa_family_t PF_KEY => 15;
        public static sa_family_t PF_NETLINK => 16;
        public static sa_family_t PF_ROUTE => PF_NETLINK;
        public static sa_family_t PF_PACKET => 17;
        public static sa_family_t PF_ASH => 18;
        public static sa_family_t PF_ECONET => 19;
        public static sa_family_t PF_ATMSVC => 20;
        public static sa_family_t PF_RDS => 21;
        public static sa_family_t PF_SNA => 22;
        public static sa_family_t PF_IRDA => 23;
        public static sa_family_t PF_PPPOX => 24;
        public static sa_family_t PF_WANPIPE => 25;
        public static sa_family_t PF_LLC => 26;
        public static sa_family_t PF_IB => 27;
        public static sa_family_t PF_MPLS => 28;
        public static sa_family_t PF_CAN => 29;
        public static sa_family_t PF_TIPC => 30;
        public static sa_family_t PF_BLUETOOTH => 31;
        public static sa_family_t PF_IUCV => 32;
        public static sa_family_t PF_RXRPC => 33;
        public static sa_family_t PF_ISDN => 34;
        public static sa_family_t PF_PHONET => 35;
        public static sa_family_t PF_IEEE802154 => 36;
        public static sa_family_t PF_CAIF => 37;
        public static sa_family_t PF_ALG => 38;
        public static sa_family_t PF_NFC => 39;
        public static sa_family_t PF_VSOCK => 40;
        public static sa_family_t PF_KCM => 41;
        public static sa_family_t PF_QIPCRTR => 42;
        public static sa_family_t PF_SMC => 43;

        public static sa_family_t AF_UNSPEC => PF_UNSPEC;
        public static sa_family_t AF_LOCAL => PF_LOCAL;
        public static sa_family_t AF_UNIX => AF_LOCAL;
        public static sa_family_t AF_FILE => AF_LOCAL;
        public static sa_family_t AF_INET => PF_INET;
        public static sa_family_t AF_AX25 => PF_AX25;
        public static sa_family_t AF_IPX => PF_IPX;
        public static sa_family_t AF_APPLETALK => PF_APPLETALK;
        public static sa_family_t AF_NETROM => PF_NETROM;
        public static sa_family_t AF_BRIDGE => PF_BRIDGE;
        public static sa_family_t AF_ATMPVC => PF_ATMPVC;
        public static sa_family_t AF_X25 => PF_X25;
        public static sa_family_t AF_INET6 => PF_INET6;
        public static sa_family_t AF_ROSE => PF_ROSE;
        public static sa_family_t AF_DECnet => PF_DECnet;
        public static sa_family_t AF_NETBEUI => PF_NETBEUI;
        public static sa_family_t AF_SECURITY => PF_SECURITY;
        public static sa_family_t AF_KEY => PF_KEY;
        public static sa_family_t AF_NETLINK => PF_NETLINK;
        public static sa_family_t AF_ROUTE => PF_ROUTE;
        public static sa_family_t AF_PACKET => PF_PACKET;
        public static sa_family_t AF_ASH => PF_ASH;
        public static sa_family_t AF_ECONET => PF_ECONET;
        public static sa_family_t AF_ATMSVC => PF_ATMSVC;
        public static sa_family_t AF_RDS => PF_RDS;
        public static sa_family_t AF_SNA => PF_SNA;
        public static sa_family_t AF_IRDA => PF_IRDA;
        public static sa_family_t AF_PPPOX => PF_PPPOX;
        public static sa_family_t AF_WANPIPE => PF_WANPIPE;
        public static sa_family_t AF_LLC => PF_LLC;
        public static sa_family_t AF_IB => PF_IB;
        public static sa_family_t AF_MPLS => PF_MPLS;
        public static sa_family_t AF_CAN => PF_CAN;
        public static sa_family_t AF_TIPC => PF_TIPC;
        public static sa_family_t AF_BLUETOOTH => PF_BLUETOOTH;
        public static sa_family_t AF_IUCV => PF_IUCV;
        public static sa_family_t AF_RXRPC => PF_RXRPC;
        public static sa_family_t AF_ISDN => PF_ISDN;
        public static sa_family_t AF_PHONET => PF_PHONET;
        public static sa_family_t AF_IEEE802154 => PF_IEEE802154;
        public static sa_family_t AF_CAIF => PF_CAIF;
        public static sa_family_t AF_ALG => PF_ALG;
        public static sa_family_t AF_NFC => PF_NFC;
        public static sa_family_t AF_VSOCK => PF_VSOCK;
        public static sa_family_t AF_KCM => PF_KCM;
        public static sa_family_t AF_QIPCRTR => PF_QIPCRTR;
        public static sa_family_t AF_SMC => PF_SMC;

        public static int SO_SECURITY_AUTHENTICATION => 22;
        public static int SO_SECURITY_ENCRYPTION_TRANSPORT => 23;
        public static int SO_SECURITY_ENCRYPTION_NETWORK => 24;
        public static int SO_BINDTODEVICE => 25;
        public static int SO_ATTACH_FILTER => 26;
        public static int SO_DETACH_FILTER => 27;
        public static int SO_GET_FILTER => SO_ATTACH_FILTER;
        public static int SO_PEERNAME => 28;
        public static int SO_TIMESTAMP => 29;
        public static int SCM_TIMESTAMP => SO_TIMESTAMP;

        public static int SO_PASSSEC => 34;
        public static int SO_TIMESTAMPNS => 35;
        public static int SCM_TIMESTAMPNS => SO_TIMESTAMPNS;
        public static int SO_MARK => 36;
        public static int SO_TIMESTAMPING => 37;
        public static int SCM_TIMESTAMPING => SO_TIMESTAMPING;
        public static int SO_RXQ_OVFL => 40;
        public static int SO_WIFI_STATUS => 41;
        public static int SCM_WIFI_STATUS => SO_WIFI_STATUS;
        public static int SO_PEEK_OFF => 42;
        public static int SO_NOFCS => 43;
        public static int SO_LOCK_FILTER => 44;
        public static int SO_SELECT_ERR_QUEUE => 45;
        public static int SO_BUSY_POLL => 46;
        public static int SO_MAX_PACING_RATE => 47;
        public static int SO_BPF_EXTENSIONS => 48;
        public static int SO_INCOMING_CPU => 49;
        public static int SO_ATTACH_BPF => 50;
        public static int SO_DETACH_BPF => SO_DETACH_FILTER;
        public static int SO_ATTACH_REUSEPORT_CBPF => 51;
        public static int SO_ATTACH_REUSEPORT_EBPF => 52;
        public static int SO_CNX_ADVICE => 53;
        public static int SCM_TIMESTAMPING_OPT_STATS => 54;
        public static int SO_MEMINFO => 55;
        public static int SO_INCOMING_NAPI_ID => 56;
        public static int SO_COOKIE => 57;
        public static int SCM_TIMESTAMPING_PKTINFO => 58;
        public static int SO_PEERGROUPS => 59;
        public static int SO_ZEROCOPY => 60;
        public static int SOL_IP => 0;
        public static int SOL_IPV6 => 41;
        public static int SOL_ICMPV6 => 58;
        public static int SOL_RAW => 255;
        public static int SOL_DECNET => 261;
        public static int SOL_X25 => 262;
        public static int SOL_PACKET => 263;
        public static int SOL_ATM => 264;
        public static int SOL_AAL => 265;
        public static int SOL_IRDA => 266;
        public static int SOL_NETBEUI => 267;
        public static int SOL_LLC => 268;
        public static int SOL_DCCP => 269;
        public static int SOL_NETLINK => 270;
        public static int SOL_TIPC => 271;
        public static int SOL_RXRPC => 272;
        public static int SOL_PPPOL2TP => 273;
        public static int SOL_BLUETOOTH => 274;
        public static int SOL_PNPIPE => 275;
        public static int SOL_RDS => 276;
        public static int SOL_IUCV => 277;
        public static int SOL_CAIF => 278;
        public static int SOL_ALG => 279;
        public static int SOL_NFC => 280;
        public static int SOL_KCM => 281;
        public static int SOL_TLS => 282;

        public static int SOMAXCONN => 128;

        public static int MSG_OOB => 1;
        public static int MSG_PEEK => 2;
        public static int MSG_DONTROUTE => 4;
        public static int MSG_CTRUNC => 8;
        public static int MSG_PROXY => 0x10;
        public static int MSG_TRUNC => 0x20;
        public static int MSG_DONTWAIT => 0x40;
        public static int MSG_EOR => 0x80;
        public static int MSG_WAITALL => 0x100;
        public static int MSG_FIN => 0x200;
        public static int MSG_SYN => 0x400;
        public static int MSG_CONFIRM => 0x800;
        public static int MSG_RST => 0x1000;
        public static int MSG_ERRQUEUE => 0x2000;
        public static int MSG_NOSIGNAL => 0x4000;
        public static int MSG_MORE => 0x8000;
        public static int MSG_WAITFORONE => 0x10000;
        public static int MSG_BATCH => 0x40000;
        public static int MSG_ZEROCOPY => 0x4000000;
        public static int MSG_FASTOPEN => 0x20000000;
        public static int MSG_CMSG_CLOEXEC => 0x40000000;
        public static int SCM_RIGHTS => 1;
        public static int SCM_CREDENTIALS => 2;

        public static int SOCK_STREAM => 1;
        public static int SOCK_DGRAM => 2;
        public static int SOCK_CLOEXEC => 0x80000;
        public static int SOCK_NONBLOCK => 0x800;
        public static int SO_DEBUG => 1;
        public static int SO_REUSEADDR => 2;
        public static int SO_TYPE => 3;
        public static int SO_ERROR => 4;
        public static int SO_DONTROUTE => 5;
        public static int SO_BROADCAST => 6;
        public static int SO_SNDBUF => 7;
        public static int SO_RCVBUF => 8;
        public static int SO_KEEPALIVE => 9;
        public static int SO_OOBINLINE => 10;
        public static int SO_NO_CHECK => 11;
        public static int SO_PRIORITY => 12;
        public static int SO_LINGER => 13;
        public static int SO_BSDCOMPAT => 14;
        public static int SO_REUSEPORT => 15;
        public static int SO_PASSCRED => 16;
        public static int SO_PEERCRED => 17;
        public static int SO_RCVLOWAT => 18;
        public static int SO_SNDLOWAT => 19;
        public static int SO_RCVTIMEO => 20;
        public static int SO_SNDTIMEO => 21;
        public static int SO_ACCEPTCONN => 30;
        public static int SO_PEERSEC => 31;
        public static int SO_SNDBUFFORCE => 32;
        public static int SO_RCVBUFFORCE => 33;
        public static int SO_PROTOCOL => 38;
        public static int SO_DOMAIN => 39;
        public static int SOL_SOCKET => 1;

        [DllImport(libc, SetLastError = true)]
        public static extern int socket(int domain, int type, int protocol);
        [DllImport(libc, SetLastError = true)]
        public static extern int socketpair(int domain, int type, int protocol, int* sv);
        [DllImport(libc, SetLastError = true)]
        public static extern int shutdown(int socket, int how);
        [DllImport(libc, SetLastError = true)]
        public static extern int bind(int socket, sockaddr* address, socklen_t address_len);
        [DllImport(libc, SetLastError = true)]
        public static extern int connect(int socket, sockaddr* address, socklen_t address_len);
        [DllImport(libc, SetLastError = true)]
        public static extern int listen(int socket, int backlog);
        [DllImport(libc, SetLastError = true)]
        public static extern int accept(int socket, sockaddr* address, socklen_t* address_len);
        [DllImport(libc, SetLastError = true)]
        public static extern int accept4(int socket, sockaddr* address, socklen_t* address_len, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int getsockname(int socket, sockaddr* address, socklen_t* address_len);
        [DllImport(libc, SetLastError = true)]
        public static extern int getpeername(int socket, sockaddr* address, socklen_t* address_len);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t send(int socket, void* buf, size_t len, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t recv(int socket, void* buf, size_t len, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t sendto(int socket, void* buf, size_t len, int flags, sockaddr* address, socklen_t address_len);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t recvfrom(int socket, void* buffer, size_t len, int flags, sockaddr* address, socklen_t* address_len);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t sendmsg(int socket, msghdr* msg, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t recvmsg(int socket, msghdr* msg, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int getsockopt(int socket, int level, int optname, void* optval, socklen_t* optlen);
        [DllImport(libc, SetLastError = true)]
        public static extern int setsockopt(int socket, int level, int optname, void* optval, socklen_t optlen);

        public static unsafe byte* CMSG_DATA(cmsghdr* cmsg) => (byte*)(cmsg + 1);

        public static unsafe cmsghdr* CMSG_NXTHDR(msghdr* mhdr, cmsghdr* cmsg)
        {
            if (cmsg->cmsg_len < SizeOf.cmsghdr ||
                __CMSG_LEN(cmsg) + SizeOf.cmsghdr >= __MHDR_END(mhdr) - (byte*)(cmsg))
            {
                return null;
            }
            else
            {
                return (cmsghdr*)__CMSG_NEXT(cmsg);
            }
        }

        public static unsafe cmsghdr* CMSG_FIRSTHDR(msghdr* mhdr)
        {
            if (mhdr->msg_controllen >= SizeOf.cmsghdr)
            {
                return (cmsghdr*)mhdr->msg_control;
            }
            else
            {
                return null;
            }
        }

        public static int CMSG_LEN(int len)
        {
            return CMSG_ALIGN(SizeOf.cmsghdr + len);
        }

        public static int CMSG_ALIGN(int len)
        {
            return (len + SizeOf.size_t - 1) & ~(SizeOf.size_t - 1);
        }

        public static int CMSG_SPACE(int len)
        {
            return CMSG_ALIGN(len) + CMSG_ALIGN(SizeOf.cmsghdr);
        }

        private static unsafe byte* __CMSG_NEXT(cmsghdr* cmsg)
        {
            return (byte*)cmsg + __CMSG_LEN(cmsg);
        }

        private static unsafe byte* __MHDR_END(msghdr* mhdr)
        {
            return (byte*)mhdr->msg_control + mhdr->msg_controllen;
        }

        private static unsafe int __CMSG_LEN(cmsghdr* cmsg)
        {
            return CMSG_ALIGN((int)cmsg->cmsg_len);
        }
    }
}