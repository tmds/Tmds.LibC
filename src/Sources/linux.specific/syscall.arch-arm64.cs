namespace Tmds.Linux
{
    public static partial class LibC
    {
        public static int SYS_io_destroy => 1;
        public static int SYS_io_getevents => 4;
        public static int SYS_io_setup => 0;
        public static int SYS_io_submit => 2;
    }
}