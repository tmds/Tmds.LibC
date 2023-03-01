using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;
using tcflag_t = System.UInt32;
using cc_t = System.Byte;
using speed_t = System.UInt32;

namespace Tmds.Linux
{
    public unsafe struct termios
    {
        private const int NCCS = 32; // note: 16 on powerpc/powerpc64

        public tcflag_t c_iflag;
        public tcflag_t c_oflag;
        public tcflag_t c_cflag;
        public tcflag_t c_lflag;
        public cc_t c_line;
        public fixed cc_t c_cc[NCCS];
        private speed_t __c_ispeed;
        private speed_t __c_ospeed;
    }

    public static unsafe partial class LibC
    {
        [DllImport(libc)]
        public static extern speed_t cfgetospeed(termios* p);
        [DllImport(libc)]
        public static extern speed_t cfgetispeed(termios* p);
        
        [DllImport(libc, SetLastError = true)]
        public static extern void cfmakeraw(termios* p);
        
        [DllImport(libc, SetLastError = true)]
        public static extern int cfsetospeed(termios* p, speed_t speed);
        [DllImport(libc, SetLastError = true)]
        public static extern int cfsetispeed(termios* p, speed_t speed);
        [DllImport(libc, SetLastError = true)]
        public static extern int tcgetattr(int fd, termios* p);
        [DllImport(libc, SetLastError = true)]
        public static extern int tcsetattr(int fd, int optional_actions, termios* p);
        [DllImport(libc, SetLastError = true)]
        public static extern int tcsendbreak(int fd, int duration);
        [DllImport(libc, SetLastError = true)]
        public static extern int tcdrain(int fd);
        [DllImport(libc, SetLastError = true)]
        public static extern int tcflush(int fd, int queue_selector);
        [DllImport(libc, SetLastError = true)]
        public static extern int tcflow(int fd, int action);
        [DllImport(libc, SetLastError = true)]
        public static extern pid_t tcgetsid(int fd);

        public static byte VINTR    =>  0;
        public static byte VQUIT    =>  1;
        public static byte VERASE   =>  2;
        public static byte VKILL    =>  3;
        public static byte VEOF     =>  4;
        public static int VTIME    =>  5;
        public static int VMIN     =>  6;
        public static byte VSWTC    =>  7;
        public static byte VSTART   =>  8;
        public static byte VSTOP    =>  9;
        public static byte VSUSP    => 10;
        public static byte VEOL     => 11;
        public static byte VREPRINT => 12;
        public static byte VDISCARD => 13;
        public static byte VWERASE  => 14;
        public static byte VLNEXT   => 15;
        public static byte VEOL2    => 16;

        public static uint IGNBRK  => 1;

        public static uint TCOOFF => 0;
        public static uint TCOON  => 1;
        public static uint TCIOFF => 2;
        public static uint TCION  => 3;

        public static uint TCIFLUSH  => 0;
        public static uint TCOFLUSH  => 1;
        public static uint TCIOFLUSH => 2;
        public static uint TCSANOW   => 0;
        public static uint TCSADRAIN => 1;
        public static uint TCSAFLUSH => 2;

        public static uint BRKINT => 2;
        public static uint IGNPAR => 4;
        public static uint PARMRK => 8;
        public static uint INPCK => 16;
        public static uint ISTRIP => 32;
        public static uint INLCR => 64;
        public static uint IGNCR => 128;
        public static uint ICRNL => 256;
        public static uint IUCLC => 512;
        public static uint IXON => 1024;
        public static uint IXANY => 2048;
        public static uint IXOFF => 4096;
        public static uint IMAXBEL => 8192;
        public static uint IUTF8 => 16384;
        public static uint OPOST => 1;
        public static uint OLCUC => 2;
        public static uint ONLCR => 4;
        public static uint OCRNL => 8;
        public static uint ONOCR => 16;
        public static uint ONLRET => 32;
        public static uint OFILL => 64;
        public static uint OFDEL => 128;
        public static uint NLDLY => 256;
        public static uint NL0 => 0;
        public static uint NL1 => 256;
        public static uint CRDLY => 1536;
        public static uint CR0 => 0;
        public static uint CR1 => 512;
        public static uint CR2 => 1024;
        public static uint CR3 => 1536;
        public static uint TABDLY => 6144;
        public static uint TAB0 => 0;
        public static uint TAB1 => 2048;
        public static uint TAB2 => 4096;
        public static uint TAB3 => 6144;
        public static uint BSDLY => 8192;
        public static uint BS0 => 0;
        public static uint BS1 => 8192;
        public static uint FFDLY => 32768;
        public static uint FF0 => 0;
        public static uint FF1 => 32768;
        public static uint VTDLY => 16384;
        public static uint VT0 => 0;
        public static uint VT1 => 16384;
        public static uint B0 => 0;
        public static uint B50 => 1;
        public static uint B75 => 2;
        public static uint B110 => 3;
        public static uint B134 => 4;
        public static uint B150 => 5;
        public static uint B200 => 6;
        public static uint B300 => 7;
        public static uint B600 => 8;
        public static uint B1200 => 9;
        public static uint B1800 => 10;
        public static uint B2400 => 11;
        public static uint B4800 => 12;
        public static uint B9600 => 13;
        public static uint B19200 => 14;
        public static uint B38400 => 15;
        public static uint B57600 => 4097;
        public static uint B115200 => 4098;
        public static uint B230400 => 4099;
        public static uint B460800 => 4100;
        public static uint B500000 => 4101;
        public static uint B576000 => 4102;
        public static uint B921600 => 4103;
        public static uint B1000000 => 4104;
        public static uint B1152000 => 4105;
        public static uint B1500000 => 4106;
        public static uint B2000000 => 4107;
        public static uint B2500000 => 4108;
        public static uint B3000000 => 4109;
        public static uint B3500000 => 4110;
        public static uint B4000000 => 4111;
        public static uint CSIZE => 48;
        public static uint CS5 => 0;
        public static uint CS6 => 16;
        public static uint CS7 => 32;
        public static uint CS8 => 48;
        public static uint CSTOPB => 64;
        public static uint CREAD => 128;
        public static uint PARENB => 256;
        public static uint PARODD => 512;
        public static uint HUPCL => 1024;
        public static uint CLOCAL => 2048;
        public static uint ISIG => 1;
        public static uint ICANON => 2;
        public static uint ECHO => 8;
        public static uint ECHOE => 16;
        public static uint ECHOK => 32;
        public static uint ECHONL => 64;
        public static uint NOFLSH => 128;
        public static uint TOSTOP => 256;
        public static uint IEXTEN => 32768;
        public static uint EXTA => 14;
        public static uint EXTB => 15;
        public static uint CBAUD => 4111;
        public static uint CBAUDEX => 4096;
        public static uint CIBAUD => 269418496;
        public static uint CMSPAR => 1073741824;
        public static uint CRTSCTS => 2147483648;
        public static uint XCASE => 4;
        public static uint ECHOCTL => 512;
        public static uint ECHOPRT => 1024;
        public static uint ECHOKE => 2048;
        public static uint FLUSHO => 4096;
        public static uint PENDIN => 16384;
        public static uint EXTPROC => 65536;
        public static uint XTABS => 6144;
    }
}