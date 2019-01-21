using System.Runtime.InteropServices;
using static Tmds.LibC.LibraryNames;
using long_t = Tmds.LibC.ssize_t;

namespace Tmds.LibC
{
    public static unsafe partial class Definitions
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