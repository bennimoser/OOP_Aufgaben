using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>() { "hallo", "du", "da" };
            var result = list.Apply(t => t.ToUpper()).ToList();
        }
    }
}
