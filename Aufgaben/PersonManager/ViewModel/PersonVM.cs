using PersonManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.ViewModel
{
    public class PersonVM : INotifyPropertyChanged
    {
        private readonly Person person;

        public PersonVM()
        {
            this.person = new Person();
        }

        public PersonVM(Person person)
        {
            this.person = person ?? throw new ArgumentNullException(nameof(person));
        }

        public string FirstName
        {
            get { return this.person.FirstName; }
            set
            {
                if (this.person.FirstName != value)
                {
                    this.person.FirstName = value;
                    this.Notify();
                }
            }
        }

        public string LastName
        {
            get { return this.person.LastName; }
            set
            {
                if (this.person.LastName != value)
                {
                    this.person.LastName = value;
                    this.Notify();
                }
            }
        }

        public DateTime Birthday
        {
            get { return this.person.Birthday; }
            set
            {
                if (this.person.Birthday != value)
                {
                    this.person.Birthday = value;
                    this.Notify();
                }
            }
        }

        public int Height
        {
            get { return this.person.Height; }
            set
            {
                if (this.person.Height != value)
                {
                    this.person.Height = value;
                    this.Notify();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
