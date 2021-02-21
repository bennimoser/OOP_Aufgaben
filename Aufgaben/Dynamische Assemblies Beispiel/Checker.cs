using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dynamische_Assemblies_Beispiel
{
    public class Checker
    {
        public void CheckAssembly()
        {
            Assembly asm = Assembly.LoadFrom("MyDynamicAssembly.dll");
        }
    }
}
