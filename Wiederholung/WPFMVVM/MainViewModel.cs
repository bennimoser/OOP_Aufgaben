using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVM
{
    public class MainViewModel
    {
        public ObservableCollection<string> ProcessResult { get; set; }

        public MainViewModel()
        {
            this.ProcessResult = new ObservableCollection<string>();
            this.ProcessPath = Environment.CurrentDirectory + "/WPFMVVM.exe";
        }

        private string _processPath;

        public string ProcessPath
        {
            get
            {
                return _processPath;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (File.Exists(value))
                    {
                        this._processPath = value;
                    }
                    else
                    {
                        throw new Exception("This Path does not exist!");
                    }
                }
                else
                {
                    throw new Exception("This was not a valid Path!");
                }
            }
        }

        public Command startProcessCommand
        {
            get
            {
                return new Command((obj) =>
                {
                    this.StartProcess();
                });
            }
        }

        private void StartProcess()
        {
            if (!string.IsNullOrEmpty(this.ProcessPath))
            {
                Process process = new Process();
                process.StartInfo.FileName = this.ProcessPath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.OutputDataReceived += Process_OutputDataReceived;

                process.Start();
                process.BeginOutputReadLine();
            }
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                this.ProcessResult.Add(e.Data);
            });
        }
    }
}
