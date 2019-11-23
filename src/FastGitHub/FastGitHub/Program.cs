using System;
using System.IO;
using System.Linq;

namespace FastGitHub
{
    class Program
    {
        static void Main(string[] args)
        {
            var OSInfo = Environment.OSVersion;
            string pathpart = "hosts";
            if (OSInfo.Platform == PlatformID.Win32NT)
            {
                //is windows NT
                pathpart = "system32\\drivers\\etc\\hosts";
            }
            string hostfile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), pathpart);


            const string tales = "123.123.123.123 download.talesrunner.com";
            string[] lines = File.ReadAllLines(hostfile);

            if (lines.Any(s => s.Contains("download.talesrunner.com")))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("download.talesrunner.com"))
                        lines[i] = tales;
                }
                File.WriteAllLines(hostfile, lines);
            }
            else if (!lines.Contains(tales))
            {
                File.AppendAllLines(hostfile, new String[] { tales });
            }
        }
    }
}
