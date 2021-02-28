using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessExercise
{
    class Program
    {
        public static void Main(string[] args)
        {
            Process process = new Process();
            process.StartInfo.FileName = "ping";
            process.StartInfo.Arguments = "-4 10.0.0.2";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;

            process.Start();
            process.WaitForExit();

            Console.WriteLine(process.StandardOutput.ReadToEnd());
        }
    }
}
