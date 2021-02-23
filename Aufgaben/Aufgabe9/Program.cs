using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe9
{
    class Program
    {
        public static void Main(string[] args)
        {
            var list1 = new List<int>() { 1, 2, 3, 8 };
            var list2 = new List<int>() { 1, 2, 4, 5 };
            var list3 = new List<int>() { 4, 6, 7, 8 };
            var collection = new IEnumerable<int>[] { list2, list3};
            var result = list1.Mix(collection).ToList();
        }
    }
}
