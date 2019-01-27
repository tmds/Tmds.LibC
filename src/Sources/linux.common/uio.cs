using System;

namespace Tmds.Linux
{
    public unsafe struct iovec
    {
        public void* iov_base { get; set; }
        public size_t iov_len { get; set; }
    }
}