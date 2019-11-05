namespace Tmds.Linux
{
    public struct winsize
    {
        public ushort ws_row;
        public ushort ws_col;
        public ushort ws_xpixel;
        public ushort ws_ypixel;
    }

    public static unsafe partial class LibC
    {
        public static int TCGETS => 0x5401;
        public static int TCSETS => 0x5402;
        public static int TCSETSW => 0x5403;
        public static int TCSETSF => 0x5404;
        public static int TCGETA => 0x5405;
        public static int TCSETA => 0x5406;
        public static int TCSETAW => 0x5407;
        public static int TCSETAF => 0x5408;
        public static int TCSBRK => 0x5409;
        public static int TCXONC => 0x540A;
        public static int TCFLSH => 0x540B;
        public static int TIOCEXCL => 0x540C;
        public static int TIOCNXCL => 0x540D;
        public static int TIOCSCTTY => 0x540E;
        public static int TIOCGPGRP => 0x540F;
        public static int TIOCSPGRP => 0x5410;
        public static int TIOCOUTQ => 0x5411;
        public static int TIOCSTI => 0x5412;
        public static int TIOCGWINSZ => 0x5413;
        public static int TIOCSWINSZ => 0x5414;
        public static int TIOCMGET => 0x5415;
        public static int TIOCMBIS => 0x5416;
        public static int TIOCMBIC => 0x5417;
        public static int TIOCMSET => 0x5418;
        public static int TIOCGSOFTCAR => 0x5419;
        public static int TIOCSSOFTCAR => 0x541A;
        public static int FIONREAD => 0x541B;
        public static int TIOCINQ => FIONREAD;
        public static int TIOCLINUX => 0x541C;
        public static int TIOCCONS => 0x541D;
        public static int TIOCGSERIAL => 0x541E;
        public static int TIOCSSERIAL => 0x541F;
        public static int TIOCPKT => 0x5420;
        public static int FIONBIO => 0x5421;
        public static int TIOCNOTTY => 0x5422;
        public static int TIOCSETD => 0x5423;
        public static int TIOCGETD => 0x5424;
        public static int TCSBRKP => 0x5425;
        public static int TIOCSBRK => 0x5427;
        public static int TIOCCBRK => 0x5428;
        public static int TIOCGSID => 0x5429;
        public static int TIOCGRS485 => 0x542E;
        public static int TIOCSRS485 => 0x542F;
        public static int TIOCGPTN => unchecked((int)0x80045430);
        public static int TIOCSPTLCK => 0x40045431;
        public static int TIOCGDEV => unchecked((int)0x80045432);
        public static int TCGETX => 0x5432;
        public static int TCSETX => 0x5433;
        public static int TCSETXF => 0x5434;
        public static int TCSETXW => 0x5435;
        public static int TIOCSIG => 0x40045436;
        public static int TIOCVHANGUP => 0x5437;
        public static int TIOCGPKT => unchecked((int)0x80045438);
        public static int TIOCGPTLCK => unchecked((int)0x80045439);
        public static int TIOCGEXCL => unchecked((int)0x80045440);
        public static int TIOCGPTPEER => 0x5441;

        public static int FIONCLEX => 0x5450;
        public static int FIOCLEX => 0x5451;
        public static int FIOASYNC => 0x5452;
        public static int TIOCSERCONFIG => 0x5453;
        public static int TIOCSERGWILD => 0x5454;
        public static int TIOCSERSWILD => 0x5455;
        public static int TIOCGLCKTRMIOS => 0x5456;
        public static int TIOCSLCKTRMIOS => 0x5457;
        public static int TIOCSERGSTRUCT => 0x5458;
        public static int TIOCSERGETLSR => 0x5459;
        public static int TIOCSERGETMULTI => 0x545A;
        public static int TIOCSERSETMULTI => 0x545B;

        public static int TIOCMIWAIT => 0x545C;
        public static int TIOCGICOUNT => 0x545D;

        public static int TIOCPKT_DATA => 0;
        public static int TIOCPKT_FLUSHREAD => 1;
        public static int TIOCPKT_FLUSHWRITE => 2;
        public static int TIOCPKT_STOP => 4;
        public static int TIOCPKT_START => 8;
        public static int TIOCPKT_NOSTOP => 16;
        public static int TIOCPKT_DOSTOP => 32;
        public static int TIOCPKT_IOCTL => 64;

        public static int TIOCSER_TEMT => 0x01;

        public static int TIOCM_LE => 0x001;
        public static int TIOCM_DTR => 0x002;
        public static int TIOCM_RTS => 0x004;
        public static int TIOCM_ST => 0x008;
        public static int TIOCM_SR => 0x010;
        public static int TIOCM_CTS => 0x020;
        public static int TIOCM_CAR => 0x040;
        public static int TIOCM_RNG => 0x080;
        public static int TIOCM_DSR => 0x100;
        public static int TIOCM_CD => TIOCM_CAR;
        public static int TIOCM_RI => TIOCM_RNG;
        public static int TIOCM_OUT1 => 0x2000;
        public static int TIOCM_OUT2 => 0x4000;
        public static int TIOCM_LOOP => 0x8000;

        public static int N_TTY => 0;
        public static int N_SLIP => 1;
        public static int N_MOUSE => 2;
        public static int N_PPP => 3;
        public static int N_STRIP => 4;
        public static int N_AX25 => 5;
        public static int N_X25 => 6;
        public static int N_6PACK => 7;
        public static int N_MASC => 8;
        public static int N_R3964 => 9;
        public static int N_PROFIBUS_FDL => 10;
        public static int N_IRDA => 11;
        public static int N_SMSBLOCK => 12;
        public static int N_HDLC => 13;
        public static int N_SYNC_PPP => 14;
        public static int N_HCI => 15;

        public static int FIOSETOWN => 0x8901;
        public static int SIOCSPGRP => 0x8902;
        public static int FIOGETOWN => 0x8903;
        public static int SIOCGPGRP => 0x8904;
        public static int SIOCATMARK => 0x8905;

        // https://github.com/torvalds/linux/commit/0768e17073dc527ccd18ed5f96ce85f9985e9115
        // public static int SIOCGSTAMP => 0x8906;
        // public static int SIOCGSTAMPNS => 0x8907;

        public static int SIOCADDRT => 0x890B;
        public static int SIOCDELRT => 0x890C;
        public static int SIOCRTMSG => 0x890D;

        public static int SIOCGIFNAME => 0x8910;
        public static int SIOCSIFLINK => 0x8911;
        public static int SIOCGIFCONF => 0x8912;
        public static int SIOCGIFFLAGS => 0x8913;
        public static int SIOCSIFFLAGS => 0x8914;
        public static int SIOCGIFADDR => 0x8915;
        public static int SIOCSIFADDR => 0x8916;
        public static int SIOCGIFDSTADDR => 0x8917;
        public static int SIOCSIFDSTADDR => 0x8918;
        public static int SIOCGIFBRDADDR => 0x8919;
        public static int SIOCSIFBRDADDR => 0x891a;
        public static int SIOCGIFNETMASK => 0x891b;
        public static int SIOCSIFNETMASK => 0x891c;
        public static int SIOCGIFMETRIC => 0x891d;
        public static int SIOCSIFMETRIC => 0x891e;
        public static int SIOCGIFMEM => 0x891f;
        public static int SIOCSIFMEM => 0x8920;
        public static int SIOCGIFMTU => 0x8921;
        public static int SIOCSIFMTU => 0x8922;
        public static int SIOCSIFNAME => 0x8923;
        public static int SIOCSIFHWADDR => 0x8924;
        public static int SIOCGIFENCAP => 0x8925;
        public static int SIOCSIFENCAP => 0x8926;
        public static int SIOCGIFHWADDR => 0x8927;
        public static int SIOCGIFSLAVE => 0x8929;
        public static int SIOCSIFSLAVE => 0x8930;
        public static int SIOCADDMULTI => 0x8931;
        public static int SIOCDELMULTI => 0x8932;
        public static int SIOCGIFINDEX => 0x8933;
        public static int SIOGIFINDEX => SIOCGIFINDEX;
        public static int SIOCSIFPFLAGS => 0x8934;
        public static int SIOCGIFPFLAGS => 0x8935;
        public static int SIOCDIFADDR => 0x8936;
        public static int SIOCSIFHWBROADCAST => 0x8937;
        public static int SIOCGIFCOUNT => 0x8938;

        public static int SIOCGIFBR => 0x8940;
        public static int SIOCSIFBR => 0x8941;

        public static int SIOCGIFTXQLEN => 0x8942;
        public static int SIOCSIFTXQLEN => 0x8943;

        public static int SIOCDARP => 0x8953;
        public static int SIOCGARP => 0x8954;
        public static int SIOCSARP => 0x8955;

        public static int SIOCDRARP => 0x8960;
        public static int SIOCGRARP => 0x8961;
        public static int SIOCSRARP => 0x8962;

        public static int SIOCGIFMAP => 0x8970;
        public static int SIOCSIFMAP => 0x8971;

        public static int SIOCADDDLCI => 0x8980;
        public static int SIOCDELDLCI => 0x8981;

        public static int SIOCDEVPRIVATE => 0x89F0;
        public static int SIOCPROTOPRIVATE => 0x89E0;
    }
}