using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct sigset_t
    {
        [FieldOffset(0)]
        private size_t __align;
        [FieldOffset(0)]
        private fixed byte __data[128];
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct sigval
    {
        [FieldOffset(0)]
        public int sigval_int;
        [FieldOffset(0)]
        public void* sigval_ptr;
    }

    public unsafe struct stack_t
    {
        public void* ss_sp;
        public int ss_flags;
        public size_t ss_size;
    }

    public unsafe struct sigaction
    {
        private void* __handler;
        public void* sa_handler { get => __handler; set => __handler = value; }
        public void* sa_sigaction { get => __handler; set => __handler = value; }
        public sigset_t sa_mask;
        public int sa_flags { get; set; }
        public void* sa_restorer { get; set; }
    }

    public static unsafe partial class LibC
    {
        public static int SIG_BLOCK => 0;
        public static int SIG_UNBLOCK => 1;
        public static int SIG_SETMASK => 2;

        public static int SI_ASYNCNL => (-60);
        public static int SI_TKILL => (-6);
        public static int SI_SIGIO => (-5);
        public static int SI_ASYNCIO => (-4);
        public static int SI_MESGQ => (-3);
        public static int SI_TIMER => (-2);
        public static int SI_QUEUE => (-1);
        public static int SI_USER => 0;
        public static int SI_KERNEL => 128;

        public static void* SIG_HOLD => (void*)2;

        public static int FPE_INTDIV => 1;
        public static int FPE_INTOVF => 2;
        public static int FPE_FLTDIV => 3;
        public static int FPE_FLTOVF => 4;
        public static int FPE_FLTUND => 5;
        public static int FPE_FLTRES => 6;
        public static int FPE_FLTINV => 7;
        public static int FPE_FLTSUB => 8;

        public static int ILL_ILLOPC => 1;
        public static int ILL_ILLOPN => 2;
        public static int ILL_ILLADR => 3;
        public static int ILL_ILLTRP => 4;
        public static int ILL_PRVOPC => 5;
        public static int ILL_PRVREG => 6;
        public static int ILL_COPROC => 7;
        public static int ILL_BADSTK => 8;

        public static int SEGV_MAPERR => 1;
        public static int SEGV_ACCERR => 2;
        public static int SEGV_BNDERR => 3;
        public static int SEGV_PKUERR => 4;

        public static int BUS_ADRALN => 1;
        public static int BUS_ADRERR => 2;
        public static int BUS_OBJERR => 3;
        public static int BUS_MCEERR_AR => 4;
        public static int BUS_MCEERR_AO => 5;

        public static int CLD_EXITED => 1;
        public static int CLD_KILLED => 2;
        public static int CLD_DUMPED => 3;
        public static int CLD_TRAPPED => 4;
        public static int CLD_STOPPED => 5;
        public static int CLD_CONTINUED => 6;

        public static int SIGEV_SIGNAL => 0;
        public static int SIGEV_NONE => 1;
        public static int SIGEV_THREAD => 2;

        public static int SIGRTMIN => _SIGRTMIN();
        public static int SIGRTMAX => _SIGRTMAX();

        [DllImport(libc, EntryPoint = "__libc_current_sigrtmin")]
        private static extern int _SIGRTMIN();
        [DllImport(libc, EntryPoint = "__libc_current_sigrtmax")]
        private static extern int _SIGRTMAX();

        [DllImport(libc, SetLastError = true)]
        public static extern int kill(pid_t pid, int signum);

        [DllImport(libc, SetLastError = true)]
        public static extern int sigemptyset(sigset_t* set);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigfillset(sigset_t* set);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigaddset(sigset_t* set, int signum);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigdelset(sigset_t* set, int signum);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigismember(sigset_t* set, int signum);

        [DllImport(libc, SetLastError = true)]
        public static extern int sigprocmask(int how, sigset_t* set, sigset_t* oldset);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigsuspend(sigset_t* set);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigaction(int signum, sigaction* act, sigaction* oldact);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigpending(sigset_t* set);
        [DllImport(libc)]
        public static extern int sigwait(sigset_t* set, int* sig);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigwaitinfo(sigset_t* set, siginfo_t* info);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigtimedwait(sigset_t* set, siginfo_t* info, timespec* timeout);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigqueue(pid_t pid, int sig, sigval value);

        [DllImport(libpthread)]
        public static extern int pthread_sigmask(int how, sigset_t* set, sigset_t* oldset);
        [DllImport(libpthread)]
        public static extern int pthread_kill(pthread_t thread, int sig);

        [DllImport(libc)]
        public static extern void psiginfo(siginfo_t* info, byte* s);
        [DllImport(libc)]
        public static extern void psignal(int sig, byte* s);

        [DllImport(libc, SetLastError = true)]
        public static extern int killpg(pid_t pid, int sig);

        [DllImport(libc, SetLastError = true)]
        public static extern int sigaltstack(stack_t* ss, stack_t* oldss);
        [DllImport(libc, SetLastError = true)]
        public static extern int sighold(int sig);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigignore(int sig);
        [DllImport(libc, SetLastError = true)]
        public static extern int siginterrupt(int sig, int flag);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigrelse(int sig);

        public static int TRAP_BRKPT => 1;
        public static int TRAP_TRACE => 2;
        public static int TRAP_BRANCH => 3;
        public static int TRAP_HWBKPT => 4;
        public static int POLL_IN => 1;
        public static int POLL_OUT => 2;
        public static int POLL_MSG => 3;
        public static int POLL_ERR => 4;
        public static int POLL_PRI => 5;
        public static int POLL_HUP => 6;
        public static int SS_ONSTACK => 1;
        public static int SS_DISABLE => 2;

        public static int SS_AUTODISARM => unchecked((int)0x80000000);
        public static int SS_FLAG_BITS => SS_AUTODISARM;

        [DllImport(libc, SetLastError = true)]
        public static extern int sigisemptyset(sigset_t* set);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigorset(sigset_t* set, sigset_t* set1, sigset_t* set2);
        [DllImport(libc, SetLastError = true)]
        public static extern int sigandset(sigset_t* set, sigset_t* set1, sigset_t* set2);

        public static int SA_NOMASK => SA_NODEFER;
        public static int SA_ONESHOT => SA_RESETHAND;

        public static void* SIG_ERR => (void*)-1;
        public static void* SIG_DFL => (void*)0;
        public static void* SIG_IGN => (void*)1;

        [DllImport(libc)]
        public static extern int raise(int sig);
    }
}