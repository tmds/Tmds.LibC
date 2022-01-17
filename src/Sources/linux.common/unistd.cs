using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    public static unsafe partial class LibC
    {
        public static int STDIN_FILENO => 0;
        public static int STDOUT_FILENO => 1;
        public static int STDERR_FILENO => 2;

        public static int SEEK_SET => 0;
        public static int SEEK_CUR => 1;
        public static int SEEK_END => 2;

        [DllImport(libc, SetLastError = true)]
        public static extern int pipe(int* pipefd);
        [DllImport(libc, SetLastError = true)]
        public static extern int pipe2(int* pipefd, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int close(int fd);
        [DllImport(libc, SetLastError = true)]
        public static extern int dup(int oldfd);
        [DllImport(libc, SetLastError = true)]
        public static extern int dup2(int oldfd, int newfd);
        [DllImport(libc, SetLastError = true)]
        public static extern int dup3(int oldfd, int newfd, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int fsync(int fd);
        [DllImport(libc, SetLastError = true)]
        public static extern int fdatasync(int fd);

        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t read(int fd, void* buf, size_t count);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t write(int fd, void* buf, size_t count);

        [DllImport(libc, SetLastError = true)]
        public static extern int chown(byte* path, uid_t owner, gid_t group);
        [DllImport(libc, SetLastError = true)]
        public static extern int fchown(int fd, uid_t owner, gid_t group);
        [DllImport(libc, SetLastError = true)]
        public static extern int lchown(byte* path, uid_t owner, gid_t group);
        [DllImport(libc, SetLastError = true)]
        public static extern int fchownat(int dirfd, byte* path, uid_t owner, gid_t group, int flags);

        [DllImport(libc, SetLastError = true)]
        public static extern int link(byte* oldpath, byte* newpath);
        [DllImport(libc, SetLastError = true)]
        public static extern int linkat(int olddirfd, byte* oldpath, int newdirfd, byte* newpath, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int symlink(byte* target, byte* linkpath);
        [DllImport(libc, SetLastError = true)]
        public static extern int symlinkat(byte* target, int newdirfd, byte* linkpath);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t readlink(byte* pathname, byte* buf, size_t bufsize);
        [DllImport(libc, SetLastError = true)]
        public static extern ssize_t readlinkat(int dirfd, byte* pathname, byte* buf, size_t bufsize);
        [DllImport(libc, SetLastError = true)]
        public static extern int unlink(byte* pathname);
        [DllImport(libc, SetLastError = true)]
        public static extern int unlinkat(int dirfd, byte* pathname, int flags);
        [DllImport(libc, SetLastError = true)]
        public static extern int rmdir(byte* pathname);

        public static int F_OK => 0;
        public static int R_OK => 4;
        public static int W_OK => 2;
        public static int X_OK => 1;

        [DllImport(libc, SetLastError = true)]
        public static extern int access(byte* pathname, int mode);
        [DllImport(libc, SetLastError = true)]
        public static extern int faccessat(int dirfd, byte* pathname, int mode, int flags);

        [DllImport(libc, SetLastError = true)]
        public static extern int chdir(byte* path);
        [DllImport(libc, SetLastError = true)]
        public static extern int fchdir(int fd);
        [DllImport(libc, SetLastError = true)]
        public static extern byte* getcwd(byte* buf, size_t size);

        [DllImport(libc)]
        public static extern uint alarm(uint seconds);
        [DllImport(libc)]
        public static extern uint sleep(uint seconds);
        [DllImport(libc, SetLastError = true)]
        public static extern int pause();

        [DllImport(libc, SetLastError = true)]
        public static extern pid_t fork();

        [DllImport(libc, SetLastError = true)]
        public static extern int execve(byte* filename, byte** arg, byte** env);
        [DllImport(libc, SetLastError = true)]
        public static extern int fexecve(int fd, byte** arg, byte** env);

        [DllImport(libc)]
        public static extern void _exit(int status);

        [DllImport(libc)]
        public static extern pid_t getpid();
        [DllImport(libc)]
        public static extern pid_t getppid();
        [DllImport(libc)]
        public static extern pid_t getpgrp();
        [DllImport(libc, SetLastError = true)]
        public static extern pid_t getpgid(pid_t pid);
        [DllImport(libc, SetLastError = true)]
        public static extern int setpgid(pid_t pid, pid_t pgid);
        [DllImport(libc, SetLastError = true)]
        public static extern pid_t setsid();
        [DllImport(libc, SetLastError = true)]
        public static extern pid_t getsid(pid_t pid);
        [DllImport(libc, SetLastError = true)]
        public static extern byte* ttyname(int fd);
        [DllImport(libc)]
        public static extern int ttyname_r(int fd, byte* but, size_t buflen);
        [DllImport(libc, SetLastError = true)]
        public static extern int isatty(int fd);
        [DllImport(libc, SetLastError = true)]
        public static extern pid_t tcgetpgrp(int fd);
        [DllImport(libc, SetLastError = true)]
        public static extern int tcsetpgrp(int fd, pid_t pgrp);

        [DllImport(libc)]
        public static extern uid_t getuid();
        [DllImport(libc)]
        public static extern uid_t geteuid();
        [DllImport(libc)]
        public static extern gid_t getgid();
        [DllImport(libc)]
        public static extern gid_t getegid();
        [DllImport(libc, SetLastError = true)]
        public static extern int getgroups(int size, gid_t* list);
        [DllImport(libc, SetLastError = true)]
        public static extern int setuid(uid_t uid);
        [DllImport(libc, SetLastError = true)]
        public static extern int seteuid(uid_t uid);
        [DllImport(libc, SetLastError = true)]
        public static extern int setgid(gid_t gid);
        [DllImport(libc, SetLastError = true)]
        public static extern int setegid(gid_t gid);

        [DllImport(libc, SetLastError = true)]
        public static extern byte* getlogin();
        [DllImport(libc)]
        public static extern int getlogin_r(byte* buf, size_t bufsize);
        [DllImport(libc, SetLastError = true)]
        public static extern int gethostname(byte* name, size_t len);
        [DllImport(libc)]
        public static extern byte* ctermid(byte* s);

        [DllImport(libc, SetLastError = true)]
        public static extern long_t pathconf(byte* path, int name);
        [DllImport(libc, SetLastError = true)]
        public static extern long_t fpathconf(int fd, int name);

        public static int _SC_ARG_MAX => 0;
        public static int _SC_CHILD_MAX => 1;
        public static int _SC_HOST_NAME_MAX => 180;
        public static int _SC_LOGIN_NAME_MAX => 71;
        public static int _SC_NGROUPS_MAX => 3;
        public static int _SC_CLK_TCK => 2;
        public static int _SC_OPEN_MAX => 4;
        public static int _SC_PAGESIZE => 30;
        public static int _SC_PAGE_SIZE => 30;
        public static int _SC_RE_DUP_MAX => 44;
        public static int _SC_STREAM_MAX => 5;
        public static int _SC_SYMLOOP_MAX => 173;
        public static int _SC_TTY_NAME_MAX => 72;
        public static int _SC_TZNAME_MAX => 6;
        public static int _SC_VERSION => 29;
        public static int _SC_BC_BASE_MAX => 36;
        public static int _SC_BC_DIM_MAX => 37;
        public static int _SC_BC_SCALE_MAX => 38;
        public static int _SC_BC_STRING_MAX => 39;
        public static int _SC_COLL_WEIGHTS_MAX => 40;
        public static int _SC_EXPR_NEST_MAX => 42;
        public static int _SC_LINE_MAX => 43;
        public static int _SC_2_VERSION => 46;
        public static int _SC_2_C_DEV => 48;
        public static int _SC_2_FORT_DEV => 49;
        public static int _SC_2_FORT_RUN => 50;
        public static int _SC_2_LOCALEDEF => 52;
        public static int _SC_2_SW_DEV => 51;
        public static int _SC_PHYS_PAGES => 85;
        public static int _SC_AVPHYS_PAGES => 86;
        public static int _SC_NPROCESSORS_CONF => 83;
        public static int _SC_NPROCESSORS_ONLN => 84;
        public static int _SC_AIO_LISTIO_MAX => 23;
        public static int _SC_AIO_MAX => 24;
        public static int _SC_AIO_PRIO_DELTA_MAX => 25;
        public static int _SC_DELAYTIMER_MAX => 26;
        public static int _SC_MQ_OPEN_MAX => 27;
        public static int _SC_MQ_PRIO_MAX => 28;
        public static int _SC_RTSIG_MAX => 31;
        public static int _SC_SEM_NSEMS_MAX => 32;
        public static int _SC_SEM_VALUE_MAX => 33;
        public static int _SC_SIGQUEUE_MAX => 34;
        public static int _SC_TIMER_MAX => 35;
        public static int _SC_ASYNCHRONOUS_IO => 12;
        public static int _SC_FSYNC => 15;
        public static int _SC_JOB_CONTROL => 7;
        public static int _SC_MAPPED_FILES => 16;
        public static int _SC_MEMLOCK => 17;
        public static int _SC_MEMLOCK_RANGE => 18;
        public static int _SC_MEMORY_PROTECTION => 19;
        public static int _SC_MESSAGE_PASSING => 20;
        public static int _SC_PRIORITIZED_IO => 13;
        public static int _SC_REALTIME_SIGNALS => 9;
        public static int _SC_SAVED_IDS => 8;
        public static int _SC_SEMAPHORES => 21;
        public static int _SC_SHARED_MEMORY_OBJECTS => 22;
        public static int _SC_SYNCHRONIZED_IO => 14;
        public static int _SC_TIMERS => 11;
        public static int _SC_GETGR_R_SIZE_MAX => 69;
        public static int _SC_GETPW_R_SIZE_MAX => 70;
        public static int _SC_THREAD_DESTRUCTOR_ITERATIONS => 73;
        public static int _SC_THREAD_KEYS_MAX => 74;
        public static int _SC_THREAD_STACK_MIN => 75;
        public static int _SC_THREAD_THREADS_MAX => 76;
        public static int _SC_THREADS => 67;
        public static int _SC_THREAD_ATTR_STACKADDR => 77;
        public static int _SC_THREAD_ATTR_STACKSIZE => 78;
        public static int _SC_THREAD_PRIORITY_SCHEDULING => 79;
        public static int _SC_THREAD_PRIO_INHERIT => 80;
        public static int _SC_THREAD_PROCESS_SHARED => 82;
        public static int _SC_THREAD_SAFE_FUNCTIONS => 68;

        [DllImport(libc, SetLastError = true)]
        public static extern long_t sysconf(int name);

        [DllImport(libc, SetLastError = true)]
        public static extern size_t confstr(int name, byte* buf, size_t len);

        public static int F_ULOCK => 0;
        public static int F_LOCK => 1;
        public static int F_TLOCK => 2;
        public static int F_TEST => 3;

        [DllImport(libc, SetLastError = true)]
        public static extern int setreuid(uid_t ruid, uid_t euid);
        [DllImport(libc, SetLastError = true)]
        public static extern int setregid(gid_t rgid, gid_t egid);
        [DllImport(libc)]
        public static extern long_t gethostid();
        [DllImport(libc, SetLastError = true)]
        public static extern int nice(int inc);
        [DllImport(libc, SetLastError = true)]
        public static extern void sync();
        [DllImport(libc, SetLastError = true)]
        public static extern pid_t setpgrp();
        [DllImport(libc, SetLastError = true)]
        public static extern int usleep(uint usec);
        [DllImport(libc)]
        public static extern uint ualarm(uint usec, uint interval);

        public static int L_SET => 0;
        public static int L_INCR => 1;
        public static int L_XTND => 2;

        [DllImport(libc, SetLastError = true)]
        public static extern int brk(void* addr);
        [DllImport(libc, SetLastError = true)]
        public static extern void* sbrk(size_t increment);
        [DllImport(libc, SetLastError = true)]
        public static extern pid_t vfork();
        [DllImport(libc, SetLastError = true)]
        public static extern int vhangup();
        [DllImport(libc, SetLastError = true)]
        public static extern int chroot(byte* path);
        [DllImport(libc)]
        public static extern int getpagesize();
        [DllImport(libc, SetLastError = true)]
        public static extern int getdtablesize();
        [DllImport(libc, SetLastError = true)]
        public static extern int sethostname(byte* name, size_t len);
        [DllImport(libc, SetLastError = true)]
        public static extern int getdomainname(byte* name, size_t len);
        [DllImport(libc, SetLastError = true)]
        public static extern int setdomainname(byte* name, size_t len);
        [DllImport(libc, SetLastError = true)]
        public static extern int setgroups(size_t size, gid_t* list);
        [DllImport(libc, SetLastError = true)]
        public static extern int daemon(int nochdir, int noclose);
        [DllImport(libc, SetLastError = true)]
        public static extern int acct(byte* filename);

        [DllImport(libc, SetLastError = true)]
        public static extern int setresuid(uid_t ruid, uid_t euid, uid_t suid);
        [DllImport(libc, SetLastError = true)]
        public static extern int setresgid(gid_t rgid, gid_t egid, gid_t sgid);
        [DllImport(libc, SetLastError = true)]
        public static extern int getresuid(uid_t* ruid, uid_t* euid, uid_t* suid);
        [DllImport(libc, SetLastError = true)]
        public static extern int getresgid(gid_t* rgid, gid_t* egid, gid_t* sgid);
        [DllImport(libc, SetLastError = true)]
        public static extern int syncfs(int fd);
        [DllImport(libc, SetLastError = true)]
        public static extern int euidaccess(byte* pathname, int mode);
        [DllImport(libc, SetLastError = true)]
        public static extern int eaccess(byte* pathname, int mode);

        [DllImport(libc, SetLastError = true)]
        public static extern syscall_arg syscall(syscall_arg number);
        [DllImport(libc, SetLastError = true)]
        public static extern syscall_arg syscall(syscall_arg number, syscall_arg arg1);
        [DllImport(libc, SetLastError = true)]
        public static extern syscall_arg syscall(syscall_arg number, syscall_arg arg1, syscall_arg arg2);
        [DllImport(libc, SetLastError = true)]
        public static extern syscall_arg syscall(syscall_arg number, syscall_arg arg1, syscall_arg arg2, syscall_arg arg3);
        [DllImport(libc, SetLastError = true)]
        public static extern syscall_arg syscall(syscall_arg number, syscall_arg arg1, syscall_arg arg2, syscall_arg arg3, syscall_arg arg4);
        [DllImport(libc, SetLastError = true)]
        public static extern syscall_arg syscall(syscall_arg number, syscall_arg arg1, syscall_arg arg2, syscall_arg arg3, syscall_arg arg4, syscall_arg arg5);
        [DllImport(libc, SetLastError = true)]
        public static extern syscall_arg syscall(syscall_arg number, syscall_arg arg1, syscall_arg arg2, syscall_arg arg3, syscall_arg arg4, syscall_arg arg5, syscall_arg arg6);
        [DllImport(libc, SetLastError = true)]
        public static extern syscall_arg syscall(syscall_arg number, syscall_arg arg1, syscall_arg arg2, syscall_arg arg3, syscall_arg arg4, syscall_arg arg5, syscall_arg arg6, syscall_arg arg7);
    }
}