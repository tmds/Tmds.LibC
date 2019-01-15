namespace Tmds.LibC
{
    public partial struct size_t
    {
        public static implicit operator ulong(size_t arg) => arg.ToUInt64();
        public static explicit operator size_t(ulong arg) => new size_t(arg);

        public static explicit operator uint(size_t arg) => arg.ToUInt32();
        public static implicit operator size_t(uint arg) => new size_t(arg);
    }
}