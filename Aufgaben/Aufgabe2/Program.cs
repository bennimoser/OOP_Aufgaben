using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;
namespace Aufgabe2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Erstellung der Assembly
            AppDomain domain = AppDomain.CurrentDomain;
            AssemblyName asmName = new AssemblyName("MyDynamicAssembly") { Version = new Version("1.0.0.0") };
            AssemblyBuilder asmBuilder = domain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Save);
            ModuleBuilder moduleBuilder = asmBuilder.DefineDynamicModule("MyDynamicAssembly", "MyDynamicAssembly.dll");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("Class1");
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("AddNumbers", MethodAttributes.Public, typeof(int), new Type[] { typeof(int), typeof(int) });
            ILGenerator gen = methodBuilder.GetILGenerator();

            //Code hinter der erstellten Methode
            gen.Emit(OpCodes.Ldarg_1);
            gen.Emit(OpCodes.Ldarg_2);
            gen.Emit(OpCodes.Add);
            gen.Emit(OpCodes.Ret);

            //Speichern der Assembly
            typeBuilder.CreateType();
            asmBuilder.Save("MyDynamicAssembly.dll");

            //Testen der Assembly auf Funktion
            Assembly asm = Assembly.LoadFrom("MyDynamicAssembly.dll");
            Type type = asm.GetType("Class1");
            MethodInfo info = type.GetMethod("AddNumbers");
            var instance = Activator.CreateInstance(type, new object[0]);
            Console.WriteLine("Das Ergebnis ist" + info.Invoke(instance, new object[] { 1, 2 }));
        }
    }
}
