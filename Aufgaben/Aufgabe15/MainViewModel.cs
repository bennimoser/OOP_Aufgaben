using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe15
{
    public class MainViewModel
    {
        public List<Person> Persons { get; set; }

        public MainViewModel()
        {
            this.Persons = new List<Person>();
            this.Persons.Add(new Person { Addresse = "asdasd", Firstname = "Benjamin", Lastname = "Moser" });
            this.Persons.Add(new Person { Addresse = "werwer", Firstname = "Marcus", Lastname = "Onisor" });
            this.Persons.Add(new Person { Addresse = "zuizui", Firstname = "Lukas", Lastname = "Jörg" });
        }
    }

    public class Person
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Addresse { get; set; }
    }
}
