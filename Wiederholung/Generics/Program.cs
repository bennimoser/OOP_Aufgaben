using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> list = new List<string>() { "Hund", "Katze", "Maus", "Schlange", "Maulwurf" };
            Console.WriteLine(list.FirstElement());
            list.AllExceptFirst().MyPrint();

            list.MyApplyFunction(item => item.ToUpper()).MyPrint();
        }
    }
}
