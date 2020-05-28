using System.Runtime.InteropServices;

namespace Tmds.Linux
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct io_uring_sqe
    {
        [FieldOffset(0)]
        public byte opcode;
        [FieldOffset(1)]
        public byte flags;
        [FieldOffset(2)]
        public ushort ioprio;
        [FieldOffset(4)]
        public int fd;
        [FieldOffset(8)]
        public ulong off;
        [FieldOffset(8)]
        public ulong addr2;
        [FieldOffset(16)]
        public ulong addr;
        [FieldOffset(16)]
        public ulong splice_off_in;
        [FieldOffset(24)]
        public uint len;
        [FieldOffset(28)]
        public int rw_flags;
        [FieldOffset(28)]
        public uint fsync_flags;
        [FieldOffset(28)]
        public ushort poll_events;
        [FieldOffset(28)]
        public uint sync_range_flags;
        [FieldOffset(28)]
        public uint msg_flags;
        [FieldOffset(28)]
        public uint timeout_flags;
        [FieldOffset(28)]
        public uint accept_flags;
        [FieldOffset(28)]
        public uint cancel_flags;
        [FieldOffset(28)]
        public uint open_flags;
        [FieldOffset(28)]
        public uint statx_flags;
        [FieldOffset(28)]
        public uint fadvise_advice;
        [FieldOffset(28)]
        public uint splice_flags;
        [FieldOffset(32)]
        public ulong user_data;
        [FieldOffset(40)]
        public ushort buf_index;
        [FieldOffset(40)]
        public ushort buf_group;
        [FieldOffset(42)]
        public ushort personality;
        [FieldOffset(44)]
        public int splice_fd_in;
        [FieldOffset(40)]
        public fixed ulong __pad2[3];
    };

    public struct io_uring_cqe
    {
        public ulong user_data;
        public int res;
        public uint flags;
    };

    public struct io_sqring_offsets
    {
        public uint head;
        public uint tail;
        public uint ring_mask;
        public uint ring_entries;
        public uint flags;
        public uint dropped;
        public uint array;
        public uint resv1;
        public ulong resv2;
    };

    public unsafe struct io_cqring_offsets
    {
        public uint head;
        public uint tail;
        public uint ring_mask;
        public uint ring_entries;
        public uint overflow;
        public uint cqes;
        public fixed ulong resv[2];
    };

    public unsafe struct io_uring_params
    {
        public uint sq_entries;
        public uint cq_entries;
        public uint flags;
        public uint sq_thread_cpu;
        public uint sq_thread_idle;
        public uint features;
        public uint wq_fd;
        public fixed uint resv[3];
        public io_sqring_offsets sq_off;
        public io_cqring_offsets cq_off;
    };

    public struct io_uring_files_update
    {
        public uint offset;
        public uint resv;
        public ulong fds;
    };

    public struct io_uring_probe_op
    {
        public byte op;
        public byte resv;
        public ushort flags;
        public uint resv2;
    };

    public unsafe struct io_uring_probe
    {
        public byte last_op;
        public byte ops_len;
        public ushort resv;
        public fixed uint resv2[3];

        public static io_uring_probe_op* ops(io_uring_probe* probe)
            => (io_uring_probe_op*)(probe + 1);
    };

    public unsafe static partial class LibC
    {
        public static byte IOSQE_FIXED_FILE => (1 << 0);
        public static byte IOSQE_IO_DRAIN => (1 << 1);
        public static byte IOSQE_IO_LINK => (1 << 2);
        public static byte IOSQE_IO_HARDLINK => (1 << 3);
        public static byte IOSQE_ASYNC => (1 << 4);
        public static byte IOSQE_BUFFER_SELECT => (1 << 5);

        public static uint IORING_SETUP_IOPOLL => (1 << 0);
        public static uint IORING_SETUP_SQPOLL => (1 << 1);
        public static uint IORING_SETUP_SQ_AFF => (1 << 2);
        public static uint IORING_SETUP_CQSIZE => (1 << 3);
        public static uint IORING_SETUP_CLAMP => (1 << 4);
        public static uint IORING_SETUP_ATTACH_WQ => (1 << 5);

        public static byte IORING_OP_NOP => 0;
        public static byte IORING_OP_READV => 1;
        public static byte IORING_OP_WRITEV => 2;
        public static byte IORING_OP_FSYNC => 3;
        public static byte IORING_OP_READ_FIXED => 4;
        public static byte IORING_OP_WRITE_FIXED => 5;
        public static byte IORING_OP_POLL_ADD => 6;
        public static byte IORING_OP_POLL_REMOVE => 7;
        public static byte IORING_OP_SYNC_FILE_RANGE => 8;
        public static byte IORING_OP_SENDMSG => 9;
        public static byte IORING_OP_RECVMSG => 10;
        public static byte IORING_OP_TIMEOUT => 11;
        public static byte IORING_OP_TIMEOUT_REMOVE => 12;
        public static byte IORING_OP_ACCEPT => 13;
        public static byte IORING_OP_ASYNC_CANCEL => 14;
        public static byte IORING_OP_LINK_TIMEOUT => 15;
        public static byte IORING_OP_CONNECT => 16;
        public static byte IORING_OP_FALLOCATE => 17;
        public static byte IORING_OP_OPENAT => 18;
        public static byte IORING_OP_CLOSE => 19;
        public static byte IORING_OP_FILES_UPDATE => 20;
        public static byte IORING_OP_STATX => 21;
        public static byte IORING_OP_READ => 22;
        public static byte IORING_OP_WRITE => 23;
        public static byte IORING_OP_FADVISE => 24;
        public static byte IORING_OP_MADVISE => 25;
        public static byte IORING_OP_SEND => 26;
        public static byte IORING_OP_RECV => 27;
        public static byte IORING_OP_OPENAT2 => 28;
        public static byte IORING_OP_EPOLL_CTL => 29;
        public static byte IORING_OP_SPLICE => 30;
        public static byte IORING_OP_PROVIDE_BUFFERS => 31;
        public static byte IORING_OP_REMOVE_BUFFERS => 32;

        public static uint IORING_FSYNC_DATASYNC => (1 << 0);
        public static uint IORING_TIMEOUT_ABS => (1 << 0);
        public static uint SPLICE_F_FD_IN_FIXED => 0x80000000U;

        public static uint IORING_CQE_F_BUFFER => (1 << 0);
        public static int IORING_CQE_BUFFER_SHIFT => 16;

        public static ulong IORING_OFF_SQ_RING => 0;
        public static ulong IORING_OFF_CQ_RING => 0x8000000UL;
        public static ulong IORING_OFF_SQES => 0x10000000UL;

        public static uint IORING_SQ_NEED_WAKEUP => (1 << 0);

        public static uint IORING_ENTER_GETEVENTS => (1 << 0);
        public static uint IORING_ENTER_SQ_WAKEUP => (1 << 1);

        public static uint IORING_FEAT_SINGLE_MMAP => (1 << 0);
        public static uint IORING_FEAT_NODROP => (1 << 1);
        public static uint IORING_FEAT_SUBMIT_STABLE => (1 << 2);
        public static uint IORING_FEAT_RW_CUR_POS => (1 << 3);
        public static uint IORING_FEAT_CUR_PERSONALITY => (1 << 4);
        public static uint IORING_FEAT_FAST_POLL => (1 << 5);

        public static uint IORING_REGISTER_BUFFERS => 0;
        public static uint IORING_UNREGISTER_BUFFERS => 1;
        public static uint IORING_REGISTER_FILES => 2;
        public static uint IORING_UNREGISTER_FILES => 3;
        public static uint IORING_REGISTER_EVENTFD => 4;
        public static uint IORING_UNREGISTER_EVENTFD => 5;
        public static uint IORING_REGISTER_FILES_UPDATE => 6;
        public static uint IORING_REGISTER_EVENTFD_ASYNC => 7;
        public static uint IORING_REGISTER_PROBE => 8;
        public static uint IORING_REGISTER_PERSONALITY => 9;
        public static uint IORING_UNREGISTER_PERSONALITY => 10;

        public static ushort IO_URING_OP_SUPPORTED => (1 << 0);

        public static int io_uring_register(int fd, uint opcode, void* arg, uint nr_args)
        {
            return (int)syscall(__NR_io_uring_register, fd, opcode, arg, nr_args);
        }

        public static int io_uring_setup(uint entries, io_uring_params* p)
        {
            return (int)syscall(__NR_io_uring_setup, entries, p);
        }

        public static int io_uring_enter(int fd, uint to_submit, uint min_complete, uint flags, sigset_t* sig)
        {
            return (int)syscall(__NR_io_uring_enter, fd, to_submit, min_complete, flags, sig, NSIG / 8);
        }

        private static int __NR_io_uring_setup => 425;
        private static int __NR_io_uring_enter => 426;
        private static int __NR_io_uring_register => 427;
    }
}