using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Xunit;
using Tmds.LibC;

namespace Tmds.LibC.Tests
{
    class CProgram : IDisposable
    {
        private StringBuilder _program;
        private string _codeFilename;
        private string _elfFile;
        private bool _hasMain;

        public CProgram()
        {
            _program = new StringBuilder();
        }

        public void Include(string header)
        {
            _program.AppendLine($"#include <{header}>");
        }

        public void Include(string[] headers)
        {
            foreach (var header in headers)
            {
                _program.AppendLine($"#include <{header}>");
            }
        }

        public void Include(CIncludes includes)
        {
            if (includes.GnuSource)
            {
                Define("_GNU_SOURCE");
            }
            Include(includes.Headers);
        }

        public void Define(string symbol)
        {
            _program.AppendLine($"#define {symbol}");
        }

        public void IfDef(string symbol)
        {
            _program.AppendLine($"#ifdef {symbol}");
        }

        public void Endif()
        {
            _program.AppendLine("#endif");
        }

        public void StaticAssert(string condition, string message)
        {
            _program.AppendLine($"_Static_assert({condition}, \"{message}\");");
        }

        public void BeginMain()
        {
            if (_hasMain)
            {
                throw new InvalidOperationException("Program already has main function");
            }
            _hasMain = true;
            _program.AppendLine("int main(int argc, char* argv[]) {");
        }

        public void EndMain()
        {
            _program.AppendLine("return 0;");
            _program.AppendLine("}");
        }

        public override string ToString() => _program.ToString();

        internal void AppendLine(string line)
        {
            _program.AppendLine(line);
        }

        public void Dispose()
        {
            if (_codeFilename != null)
            {
                File.Delete(_codeFilename);
            }
            if (_elfFile != null)
            {
                File.Delete(_elfFile);
            }
        }

        public string Compile()
        {
            if (_elfFile != null)
            {
                throw new InvalidOperationException("Already compiled");
            }
            if (!_hasMain)
            {
                BeginMain();
                EndMain();
            }

            _codeFilename = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".c");
            _elfFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".o");

            File.WriteAllText(_codeFilename, _program.ToString());

            string offset64 = IntPtr.Size == 4 ? "-D_FILE_OFFSET_BITS=64" : "";

            using (Process process = Process.Start(new ProcessStartInfo  {
                FileName = "gcc",
                Arguments = $"{_codeFilename} -Werror {offset64} -o {_elfFile} -lpthread -ldl",
                RedirectStandardError = true }))
            {
                StringBuilder errorOut = new StringBuilder();
                do
                {
                    string errorLine = process.StandardError.ReadLine();
                    if (errorLine == null)
                    {
                        break;
                    }
                    errorOut.AppendLine(errorLine);
                } while (true);
                process.WaitForExit();
                Assert.True(process.ExitCode == 0, errorOut.ToString());
            }

            return _elfFile;
        }

        internal void AddCall(string returnArgument, string functionName, List<string> callArguments)
        {
            if (returnArgument == null)
            {
                _program.AppendLine($"{functionName}({string.Join(", ", callArguments)});");
            }
            else
            {
                _program.AppendLine($"{returnArgument} = {functionName}({string.Join(", ", callArguments)});");
            }
        }
    }
}