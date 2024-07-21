using System;
using System.Diagnostics;

namespace Bastion.Utilities
{
    public class GitUtils
    {
        public const string DefaultVersion = "v0.0.0";
        
        public static string GetCurrentTagVersion()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "git";
                process.StartInfo.Arguments = "describe --tags --abbrev=0";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return process.ExitCode == 0
                    ? output.Trim()
                    :
                    // The tag version couldn't be retrieved
                    // Git may not be installed or the repository could not be not found
                    DefaultVersion;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return DefaultVersion;
            }
        }
    }
}