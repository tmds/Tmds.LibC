namespace Tmds.LibC
{
    public partial struct size_t
    {
        private ulong _value;

        private size_t(ulong arg) { _value = arg; }
        private size_t(uint arg) { _value = arg; }

        private uint ToUInt32() => (uint)_value;
        private ulong ToUInt64() => _value;
    }
}