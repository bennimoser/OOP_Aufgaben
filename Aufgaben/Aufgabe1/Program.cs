using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstList = new List<string>() { "Hund", "Katze", "Maus" };
            List<string> secondList = new List<string>() { "Hase", "Rind", "Hund" };
            var same = firstList.FilterSame(secondList).ToList();
        }
    }
}
