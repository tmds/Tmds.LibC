
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Tmds.Linux.LibraryNames;

namespace Tmds.Linux
{
    [StructLayout(LayoutKind.Explicit, Pack = 4)]
    public struct epoll_event
    {
        [FieldOffset(0)]
        public int events;
        [FieldOffset(4)]
        public epoll_data_t data;
    }
}