using System.Linq;

namespace Tmds.LibC.Tests
{
    public static class CType
    {

        // no need to prepend these with the 'struct' keyword
        private static string[] s_typedefs = new [] {
            "epoll_data_t",
            "size_t",
            "ssize_t",
            "sa_family_t",
            "pid_t",
            "uid_t",
            "gid_t",
            "socklen_t",
            "off_t",
            "time_t",
            "mode_t",
            "syscall_arg",
            "long_t",
            "cpu_set_t",
            "stack_t",
            "siginfo_t",
            "sigset_t",
            "pthread_t",
            "clock_t",
            "sigevent_t",
            "Dl_info",
            "dev_t",
            "ino_t",
            "nlink_t",
            "blksize_t",
            "blkcnt_t"
        };

        private static bool IsUnion(string name)
        {
            if (name == "sigval")
            {
                return true;
            }
            return false;
        }

        public static string GetName(string dotnetName)
        {
            switch (dotnetName)
            {
                case "Void": return "void";
                case "SByte": return "int8_t";
                case "Byte": return "uint8_t";
                case "Int16": return "int16_t";
                case "UInt16": return "uint16_t";
                case "Int32": return "int32_t";
                case "UInt32": return "uint32_t";
                case "Int64": return "int64_t";
                case "UInt64": return "uint64_t";
                case "long_t": return "long";
                case "syscall_arg": return "long";
            }

            if (s_typedefs.Contains(dotnetName))
            {
                return dotnetName;
            }

            return IsUnion(dotnetName) ? $"union {dotnetName}" : $"struct {dotnetName}";
        }
    }
}