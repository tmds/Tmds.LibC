using System;
using System.IO;
using System.Linq;

namespace Tmds.LibC.Tests
{
    class TestEnvironment
    {
        private string[] _unsupportedStructs;
        private string[] _unsupportedConstants;
        private string[] _unsupportedFunctions;
        private string[] _unsupportedHeaders;

        private TestEnvironment(
            string[] unsupportedStructs = null,
            string[] unsupportedConstants = null,
            string[] unsupportedFunctions = null,
            string[] unsupportedHeaders = null)
        {
            _unsupportedConstants = unsupportedConstants;
            _unsupportedStructs = unsupportedStructs;
            _unsupportedFunctions = unsupportedFunctions;
            _unsupportedHeaders = unsupportedHeaders;
        }

        public bool? SupportsHeaders(string[] headers)
        {
            if (_unsupportedHeaders == null)
            {
                return null;
            }
            foreach (var header in headers)
            {
                if (_unsupportedHeaders.Contains(header))
                {
                    return false;
                }
            }
            return true;
        }

        public bool? SupportsHeader(string name)
        {
            if (_unsupportedHeaders == null)
            {
                return null;
            }
            return !_unsupportedHeaders.Contains(name);
        }

        public bool? SupportsStruct(string name)
        {
            if (_unsupportedStructs == null)
            {
                return null;
            }
            return !_unsupportedStructs.Contains(name);
        }

        public bool? SupportsConstant(string name)
        {
            if (_unsupportedConstants == null)
            {
                return null;
            }
            return !_unsupportedConstants.Contains(name);
        }

        public bool? SupportsFunction(string name)
        {
            if (_unsupportedFunctions == null)
            {
                return null;
            }
            return !_unsupportedFunctions.Contains(name);
        }

        static TestEnvironment()
        {
            string rid = GetRid();
            Console.WriteLine($"Test Environment: {rid}");
            if (rid == "fedora-29")
            {
                Current = new TestEnvironment(
                    unsupportedStructs: new string[]
                    { },
                    unsupportedConstants: new string[]
                    {
                        "F_CANCELLK",
                        "F_OWNER_TID",
                        "F_OWNER_PID",
                        "F_OWNER_PGRP",
                        "F_OWNER_GID",
                        "IPPORT_RESERVED",
                        "IPPROTO_MAX",
                        "IPV6_PREFER_SRC_TMP",
                        "IPV6_PREFER_SRC_PUBLIC",
                        "IPV6_PREFER_SRC_PUBTMP_DEFAULT",
                        "IPV6_PREFER_SRC_COA",
                        "IPV6_PREFER_SRC_HOME",
                        "IPV6_PREFER_SRC_CGA",
                        "IPV6_PREFER_SRC_NONCGA",
                        "F_GETOWNER_UIDS",
                        "SCM_TSTAMP_SND",
                        "SCM_TSTAMP_SCHED",
                        "SCM_TSTAMP_ACK",
                        "IOCB_CMD_PREAD",
                        "IOCB_CMD_PWRITE",
                        "IOCB_CMD_FSYNC",
                        "IOCB_CMD_FDSYNC",
                        "IOCB_CMD_NOOP",
                        "IOCB_CMD_PREADV",
                        "IOCB_CMD_PWRITEV"
                    },
                    unsupportedHeaders: new string[]
                    { },
                    unsupportedFunctions: new string[]
                    { });
            }
            else if (rid == "ubuntu-14.04") // Travis
            {
                Current = new TestEnvironment(
                    unsupportedStructs: new string[]
                    {
                        "scm_timestamping"
                    },
                    unsupportedConstants: null,
                    unsupportedHeaders: null,
                    unsupportedFunctions: null);
            }
            else
            {
                Current = new TestEnvironment();
            }
        }

        private static string GetRid()
        {
            string[] lines = File.ReadAllLines("/etc/os-release");
            string id = string.Empty;
            string version = string.Empty;
            foreach (string line in lines)
            {
                string[] split = line.Split('=', 2);
                if (split[0] == "ID")
                {
                    id = split[1];
                }
                else if (split[0] == "VERSION_ID")
                {
                    version = split[1].Trim('\"');
                }
            }
            return $"{id}-{version}";
        }

        public static TestEnvironment Current { get; private set; }
    }
}