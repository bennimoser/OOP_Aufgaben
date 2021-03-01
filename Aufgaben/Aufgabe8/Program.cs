using Aufgabe8_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe8
{
    [Description("iwas lulululu")]
    public class Program
    {
        public static void Main(string[] args)
        {
            // Early Binding
            Type type = typeof(Person);
            IEnumerable<Attribute> attributes = type.GetCustomAttributes();
            foreach(DescriptionAttribute attribute in attributes)
            {
                //Wenn gemeint ist, der Inhalt des Property
                Console.WriteLine(attribute.Description);
            }

            // Late Binding
            Assembly asm = Assembly.LoadFrom("Aufgabe8_Library.dll");
            type = asm.GetType("Aufgabe8_Library.Person");
            attributes = type.GetCustomAttributes();
            foreach(dynamic attribute in attributes)
            {
                var atttype = attribute.GetType();                
                if(atttype.Name == "DescriptionAttribute")
                {
                    dynamic info = attribute.Description;
                    Console.WriteLine(info);
                }
            }         
            

            Console.ReadLine();
        }
    }
}
