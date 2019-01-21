using long_t = Tmds.LibC.ssize_t;

namespace Tmds.LibC
{
    public struct io_event
    {
        public ulong data;
        public ulong obj;
        public long res;
        public long res2;
    }

    public struct iocb
    {
        public ulong aio_data;

        // TODO: these fields swap for big endian
        public uint aio_key;
        public int aio_rw_flags;

        public ushort aio_lio_opcode;
        public short aio_reqprio;
        public int aio_fildes;
        public ulong aio_buf;
        public ulong aio_nbytes;
        public long aio_offset;
        public ulong aio_reserved2;
        public uint  aio_flags;
        public uint aio_resfd;
    }

    public struct aio_ring
    {
        public uint id;
        public uint nr;
        public uint head;
        public uint tail;
        public uint magic;
        public uint compat_features;
        public uint incompat_features;
        public uint header_length;

        public unsafe static io_event* io_events(aio_ring* ring, int idx)
        {
            io_event* ev = (io_event*)(ring + 1);
            return ev + idx;
        }
    }

    public unsafe static partial class Definitions
    {
        public static ushort IOCB_CMD_PREAD => 0;
        public static ushort IOCB_CMD_PWRITE => 1;
        public static ushort IOCB_CMD_FSYNC => 2;
        public static ushort IOCB_CMD_FDSYNC => 3;
        public static ushort IOCB_CMD_NOOP => 6;
        public static ushort IOCB_CMD_PREADV => 7;
        public static ushort IOCB_CMD_PWRITEV => 8;

        public static int io_setup(int nr_events, aio_ring** ring)
        {
            int rv = (int)syscall(SYS_io_setup, nr_events, ring);

            if (rv == -1)
            {
                *ring = null;
            }

            return rv;
        }

        public static int io_destroy(aio_ring* ring)
        {
            int rv = (int)syscall(SYS_io_destroy, ring);

            return rv;
        }

        public static int io_submit(aio_ring* ring, int nr, iocb** iocbpp)
        {
            int rv = (int)syscall(SYS_io_submit, ring, nr, iocbpp);

            return rv;
        }

        public static int io_getevents(aio_ring* ring, int min_nr, int nr, io_event* events, timespec* timeout)
        {
            int rv = (int)syscall(SYS_io_getevents, ring, min_nr, nr, events, timeout);

            return rv;
        }
    }
}