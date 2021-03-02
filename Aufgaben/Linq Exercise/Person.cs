using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Exercise
{
    class Person
    {
        internal string Firstname;

        internal string Lastname;

        internal int Age;

        internal Person(string firstname, string lastname, int age)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Age = age;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.Firstname, this.Lastname, this.Age);
        }
    }
}
