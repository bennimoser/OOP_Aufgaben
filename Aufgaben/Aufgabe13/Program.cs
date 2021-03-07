using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe13
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<object> myItems = new List<object>();
            myItems.Add(1);
            myItems.Add(new List<string>());
            myItems.Add("Hallo");
            List<string> strings = myItems.FilterType<string>().ToList();

        }
    }
}
