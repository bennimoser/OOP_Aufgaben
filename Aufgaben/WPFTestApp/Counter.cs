using System;
using System.ComponentModel;
using System.Timers;

namespace WPFTestApp
{
    public class Counter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Counter()
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Now)));
        }

        public DateTime Now

        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
