using PersonManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PersonManager.ViewModel
{
    public class SettingArgsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly SettingArgs settingArgs;

        public SettingArgsVM()
        {
            this.settingArgs = new SettingArgs();
        }

        public string FilePath
        {
            get { return this.settingArgs.FilePath; }
            set
            {
                if (this.settingArgs.FilePath != value)
                {
                    this.settingArgs.FilePath = value;
                    this.Notify();
                }
            }
        }

        public Serializers Serializer
        {
            get { return this.settingArgs.Serializer; }
            set
            {
                if (this.settingArgs.Serializer != value)
                {
                    this.settingArgs.Serializer = value;
                    this.Notify();
                }
            }
        }

        protected void Notify([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}