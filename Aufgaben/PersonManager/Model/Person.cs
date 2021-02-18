using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PersonManager.Model
{
    public class Person
    {
        private string firstName;

        private string lastName;

        private DateTime birthday;

        private int height;

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid first name");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid last name");
                }

                this.lastName = value;
            }
        }

        public DateTime Birthday
        {
            get { return this.birthday; }
            set
            {
                if(value > DateTime.Now)
                {
                    throw new Exception("To young");
                }

                this.birthday = value;
            }
        }

        public int Height
        {
            get { return this.height; }
            set
            {
                int minHeight = 60;
                int maxHeight = 250;

                if (value < minHeight || value > maxHeight)
                {
                    throw new Exception("Invalid height");
                }

                this.height = value;
            }
        }
    }
}
