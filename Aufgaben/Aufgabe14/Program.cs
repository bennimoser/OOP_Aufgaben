using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe14
{
    class Program
    {
        public static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom("C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.7.2/System.dll");
            List<Type> interfaces = assembly.GetTypes().Where(t => t.IsInterface).ToList();
            foreach(Type iface in interfaces)
            {
                if (iface.IsNested)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(iface.FullName);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(iface.FullName);
                }
            }
        }
    }
}
