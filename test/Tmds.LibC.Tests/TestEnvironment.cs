using System;
using System.IO;
using System.Linq;

namespace Tmds.Linux.Tests
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
            if (rid == "fedora-32")
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
                        "IOCB_CMD_PWRITEV",
                        "TIOCM_OUT1",
                        "TIOCM_OUT2",
                        "TIOCM_LOOP",
                        "TRAP_BRANCH",
                        "TRAP_HWBKPT",
                        "SS_AUTODISARM",
                        "SS_FLAG_BITS",
                        "IOSQE_FIXED_FILE",
                        "IOSQE_IO_DRAIN",
                        "IOSQE_IO_LINK",
                        "IORING_SETUP_IOPOLL",
                        "IORING_SETUP_SQPOLL",
                        "IORING_SETUP_SQ_AFF",
                        "IORING_OP_NOP",
                        "IORING_OP_READV",
                        "IORING_OP_WRITEV",
                        "IORING_OP_FSYNC",
                        "IORING_OP_READ_FIXED",
                        "IORING_OP_WRITE_FIXED",
                        "IORING_OP_POLL_ADD",
                        "IORING_OP_POLL_REMOVE",
                        "IORING_OP_SYNC_FILE_RANGE",
                        "IORING_OP_SENDMSG",
                        "IORING_OP_RECVMSG",
                        "IORING_FSYNC_DATASYNC",
                        "IORING_OFF_SQ_RING",
                        "IORING_OFF_CQ_RING",
                        "IORING_OFF_SQES",
                        "IORING_SQ_NEED_WAKEUP",
                        "IORING_ENTER_GETEVENTS",
                        "IORING_ENTER_SQ_WAKEUP",
                        "IORING_REGISTER_BUFFERS",
                        "IORING_UNREGISTER_BUFFERS",
                        "IORING_REGISTER_FILES",
                        "IORING_UNREGISTER_FILES",
                        "IORING_REGISTER_EVENTFD",
                        "IORING_UNREGISTER_EVENTFD",
                        "IOSQE_IO_HARDLINK",
                        "IOSQE_ASYNC",
                        "IOSQE_BUFFER_SELECT",
                        "IORING_SETUP_CQSIZE",
                        "IORING_SETUP_CLAMP",
                        "IORING_SETUP_ATTACH_WQ",
                        "IORING_OP_TIMEOUT",
                        "IORING_OP_TIMEOUT_REMOVE",
                        "IORING_OP_ACCEPT",
                        "IORING_OP_ASYNC_CANCEL",
                        "IORING_OP_LINK_TIMEOUT",
                        "IORING_OP_CONNECT",
                        "IORING_OP_FALLOCATE",
                        "IORING_OP_OPENAT",
                        "IORING_OP_CLOSE",
                        "IORING_OP_FILES_UPDATE",
                        "IORING_OP_STATX",
                        "IORING_OP_READ",
                        "IORING_OP_WRITE",
                        "IORING_OP_FADVISE",
                        "IORING_OP_MADVISE",
                        "IORING_OP_SEND",
                        "IORING_OP_RECV",
                        "IORING_OP_OPENAT2",
                        "IORING_OP_EPOLL_CTL",
                        "IORING_OP_SPLICE",
                        "IORING_OP_PROVIDE_BUFFERS",
                        "IORING_OP_REMOVE_BUFFERS",
                        "IORING_TIMEOUT_ABS",
                        "SPLICE_F_FD_IN_FIXED",
                        "IORING_CQE_F_BUFFER",
                        "IORING_CQE_BUFFER_SHIFT",
                        "IORING_FEAT_SINGLE_MMAP",
                        "IORING_FEAT_NODROP",
                        "IORING_FEAT_SUBMIT_STABLE",
                        "IORING_FEAT_RW_CUR_POS",
                        "IORING_FEAT_CUR_PERSONALITY",
                        "IORING_FEAT_FAST_POLL",
                        "IORING_REGISTER_FILES_UPDATE",
                        "IORING_REGISTER_EVENTFD_ASYNC",
                        "IORING_REGISTER_PROBE",
                        "IORING_REGISTER_PERSONALITY",
                        "IORING_UNREGISTER_PERSONALITY",
                        "IO_URING_OP_SUPPORTED",
                    },
                    unsupportedHeaders: new string[]
                    { },
                    unsupportedFunctions: new string[]
                    { });
            }
            else if (rid == "ubuntu-16.04") // Travis
            {
                Current = new TestEnvironment(
                    unsupportedStructs: new string[]
                    {
                        "statx_timestamp",
                        "statx"
                    },
                    unsupportedConstants: null,
                    unsupportedHeaders: new string[]
                    {
                        "linux/openat2.h"
                    },
                    unsupportedFunctions: new string[]
                    {
                        "mlock2",
                        "memfd_create",
                        "statx"
                    });
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