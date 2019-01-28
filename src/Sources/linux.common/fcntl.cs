using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public struct flock
    {
        public short l_type;
        public short l_whence;
        public off_t l_start;
        public off_t l_len;
        public pid_t l_pid;
    }

    public unsafe struct file_handle
    {
        public uint handle_bytes;
        public int handle_type;

        public static byte* f_handle(file_handle* fh)
            => (byte*)(fh + 1);
    }

    public struct f_owner_ex
    {
        public int type;
        public pid_t pid;
    }

    public unsafe static partial class LibC
    {
        public static int O_ACCMODE => 3;
        public static int O_RDONLY => 0;
        public static int O_WRONLY => 1;
        public static int O_RDWR => 2;

        public static int F_OFD_GETLK => 36;
        public static int F_OFD_SETLK => 37;
        public static int F_OFD_SETLKW => 38;

        public static int F_DUPFD_CLOEXEC => 1030;

        public static int F_RDLCK => 0;
        public static int F_WRLCK => 1;
        public static int F_UNLCK => 2;

        public static int FD_CLOEXEC => 1;

        public static int AT_FDCWD => (-100);
        public static int AT_SYMLINK_NOFOLLOW => 0x100;
        public static int AT_REMOVEDIR => 0x200;
        public static int AT_SYMLINK_FOLLOW => 0x400;
        public static int AT_EACCESS => 0x200;

        public static int POSIX_FADV_NORMAL => 0;
        public static int POSIX_FADV_RANDOM => 1;
        public static int POSIX_FADV_SEQUENTIAL => 2;
        public static int POSIX_FADV_WILLNEED => 3;
        public static int POSIX_FADV_DONTNEED => 4;
        public static int POSIX_FADV_NOREUSE => 5;


        public static int AT_NO_AUTOMOUNT => 0x800;
        public static int AT_EMPTY_PATH => 0x1000;

        public static int FAPPEND => O_APPEND;
        public static int FFSYNC => O_SYNC;
        public static int FASYNC => O_ASYNC;
        public static int FNONBLOCK => O_NONBLOCK;
        public static int FNDELAY => O_NDELAY;

        public static int F_SETLEASE => 1024;
        public static int F_GETLEASE => 1025;
        public static int F_CANCELLK => 1029;
        public static int F_SETPIPE_SZ => 1031;
        public static int F_GETPIPE_SZ => 1032;
        public static int F_ADD_SEALS => 1033;
        public static int F_GET_SEALS => 1034;

        public static int F_SEAL_SEAL => 0x0001;
        public static int F_SEAL_SHRINK => 0x0002;
        public static int F_SEAL_GROW => 0x0004;
        public static int F_SEAL_WRITE => 0x0008;

        public static int F_GET_RW_HINT => 1035;
        public static int F_SET_RW_HINT => 1036;
        public static int F_GET_FILE_RW_HINT => 1037;
        public static int F_SET_FILE_RW_HINT => 1038;

        public static int RWF_WRITE_LIFE_NOT_SET => 0;
        public static int RWH_WRITE_LIFE_NONE => 1;
        public static int RWH_WRITE_LIFE_SHORT => 2;
        public static int RWH_WRITE_LIFE_MEDIUM => 3;
        public static int RWH_WRITE_LIFE_LONG => 4;
        public static int RWH_WRITE_LIFE_EXTREME => 5;

        public static int F_OWNER_TID => 0;
        public static int F_OWNER_PID => 1;
        public static int F_OWNER_PGRP => 2;
        public static int F_OWNER_GID => 2;

        public static int FALLOC_FL_KEEP_SIZE => 1;
        public static int FALLOC_FL_PUNCH_HOLE => 2;
        public static int MAX_HANDLE_SZ => 128;
        public static int SYNC_FILE_RANGE_WAIT_BEFORE => 1;
        public static int SYNC_FILE_RANGE_WRITE => 2;
        public static int SYNC_FILE_RANGE_WAIT_AFTER => 4;
        public static int SPLICE_F_MOVE => 1;
        public static int SPLICE_F_NONBLOCK => 2;
        public static int SPLICE_F_MORE => 4;
        public static int SPLICE_F_GIFT => 8;

        [DllImport(libc, SetLastError = true)]
        public static extern int name_to_handle_at(int dirfd, byte* pathname, file_handle* handle, int* mount_id, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int open_by_handle_at(int mount_fd, file_handle* handle, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t readahead(int fd, off_t pos, size_t len);
        [DllImport(libc, SetLastError = true)]
        public static extern int sync_file_range(int fd, off_t pos, off_t len, uint flags);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t vmsplice(int fd, iovec* iov, size_t count, uint flags);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t splice(int fd, off_t* off_in, int fd_out, off_t* off_out, size_t len, uint flags);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t tee(int src, int desg, size_t len, uint flags);

        [DllImport(libc, SetLastError = true)]
        public static extern int fcntl(int fd, int cmd);
        [DllImport(libc, SetLastError = true)]
        public static extern int fcntl(int fd, int cmd, int arg);
        [DllImport(libc, SetLastError = true)]
        public static extern int fcntl(int fd, int cmd, void* arg);
    }
}