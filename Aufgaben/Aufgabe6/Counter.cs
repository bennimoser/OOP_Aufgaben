using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe6
{
    public class Counter : INotifyPropertyChanged
    {

        private int angle = 0;

        public int Angle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Angle)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
