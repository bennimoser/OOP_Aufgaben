using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe10
{
    class Program
    {
        public static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom(@"C:\Windows\assembly\GAC_MSIL\System\2.0.0.0__b77a5c561934e089\System.dll");
            var types = asm.GetTypes().Where(type => type.GetInterfaces().Contains(typeof(IList))).ToList();
            foreach(var type in types)
            {
                Console.WriteLine(type.FullName);
            }

            Console.ReadLine();
        }
    }
}
