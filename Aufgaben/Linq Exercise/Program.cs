using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Exercise
{
    class Program
    {
        //1. Print nochmals implementieren
        //2. Head(erstes Element)
        //3. Tail(erstes Element exkludiert)
        //4. Except(alles bis auf ein bestimmtes Element)
        public static void Main(string[] args)
        {
            List<string> testList = new List<string>() { "Hallo", "du", "da", "ich", "will", "essen" };
            testList.MyPrint();
            Console.WriteLine(testList.Head());
            testList.Tail().ToList().MyPrint();
            testList.Except("ich").ToList().MyPrint();
        }
    }
}
