using Aufgabe8_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe8
{
    class Program
    {
        public static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom("Aufgabe8_Library.dll");
            Type type = asm.GetType("Aufgabe8_Library.Person");
            var attributes = type.GetCustomAttributes(true).Where(a => a is DescriptionAttribute);
            foreach(DescriptionAttribute attribute in attributes)
            {
                //Wenn gemeint ist, der Inhalt des Property
                Console.WriteLine(attribute.Description);

                //Wenn gemeint ist, nur die PropertyInfo ausgeben
                Type atttype = attribute.GetType();
                var properties = atttype.GetProperties();
                foreach (var property in properties)
                {
                    Console.WriteLine(property);
                }
            }

            Console.ReadLine();
        }
    }
}
