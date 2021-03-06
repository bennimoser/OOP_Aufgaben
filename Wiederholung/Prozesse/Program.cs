using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prozesse
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region Process Start and Kill

            Process process = new Process();

            process.StartInfo.FileName = "ping.exe";
            process.StartInfo.Arguments = "-4 -t 10.0.0.8";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.OutputDataReceived += Process_OutputDataReceived;

            process.Start();
            process.BeginOutputReadLine();

            Thread.Sleep(3000);
            Process[] array = Process.GetProcessesByName("Ping");
            foreach(var arrayprocess in array)
            {
                arrayprocess.Kill();
            }

            #endregion

            #region Filter Processes

            Process[] allProcesses = Process.GetProcesses().Where(t => t.ProcessName == "Chrome.exe").ToArray();
            Process idProcess = Process.GetProcessById(4);
            Process[] nameProcesses = Process.GetProcessesByName("Chrome.exe");
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.Kill();
            #endregion 
            Console.WriteLine("Hallo Das kommt danach!");
            Console.ReadKey();
        }

        private static void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }
    }
}
