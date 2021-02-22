using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PingWPF_Übung.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.sucessfulList = new ObservableCollection<string>();
        }

        private ObservableCollection<string> sucessfulList;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> SucessfulList
        {
            get
            {
                return sucessfulList;
            }
            set
            {
                if(value != null)
                {
                    this.sucessfulList = value;
                    this.Notify(nameof(SucessfulList));
                }
            }
        }

        public ICommand startProcessCommand
        {
            get
            {
                return new Command((object parameters) =>
                {
                    this.StartProcess();
                });
            }
        }

        private void StartProcess()
        {
            Process process = new Process();
            ProcessStartInfo startinfo = new ProcessStartInfo()
            {
                FileName = "D:/Repos/OOP_Aufgaben/Aufgaben/Aufgabe3/bin/debug/Aufgabe3.exe",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            process.StartInfo = startinfo;
            process.OutputDataReceived += Process_OutputDataReceived;
            process.Start();
            process.BeginOutputReadLine();
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                this.SucessfulList.Add(e.Data);
            });
        }

        private void Notify(string propertyname)
        {
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
