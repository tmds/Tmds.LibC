using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Tmds.Linux.Tests
{
    static class ElfReader
    {
        public static HashSet<string> GetUndefinedSymbols(string elfFile)
        {
            var undefinedSymbols = new HashSet<string>();

            var psi = new ProcessStartInfo
            {
                FileName = "readelf",
                Arguments = $"-W -s {elfFile}",
                RedirectStandardOutput = true
            };

            var process = Process.Start(psi);
            while (true)
            {
                string line = process.StandardOutput.ReadLine();
                if (line == null)
                {
                    break;
                }
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 8)
                {
                    string ndx = parts[6];
                    string name = parts[7];
                    if (ndx == "UND")
                    {
                        name = name.Split('@', 2)[0];
                        undefinedSymbols.Add(name);
                    }
                }
            }
            process.WaitForExit();
            Assert.Equal(0, process.ExitCode);

            return undefinedSymbols;
        }
    }
}