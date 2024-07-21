using System.Diagnostics;

namespace Bastion.Editor
{
    public class GitUtils
    {
        public static string GetCurrentTagVersion()
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

            return process.ExitCode == 0 ? output.Trim() :
                // The tag version couldn't be retrieved
                // Git may not be installed or the repository could not be not found
                string.Empty;
        }
    }
}