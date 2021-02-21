using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using VehicleLibrary;

namespace Dynamische_Assemblies_Beispiel
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            AppDomain secondDomain = AppDomain.CreateDomain("SecondDomain");

            secondDomain.Load("VehicleLibrary");

            ListAssemblies(currentDomain);
            ListAssemblies(secondDomain);

            secondDomain.DomainUnload += (o, s) => Console.WriteLine("Domain {0} was unloaded", o);
            AppDomain.Unload(secondDomain);

            new SportsCar();
            new SportsCarTS();

            // ----------------------------------

            AppDomain app = AppDomain.CurrentDomain;

            AssemblyName asmName = new AssemblyName("MyDynamicAssembly") { Version = new Version("1.0.0.0") };

            AssemblyBuilder asmBuilder = app.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Save);

            ModuleBuilder modBuilder = asmBuilder.DefineDynamicModule("MyDynamicAssembly", "MyDynamicAssembly.dll");

            TypeBuilder classBuilder = modBuilder.DefineType("MyDynamicAssembly.TestClass", TypeAttributes.Public);

            FieldBuilder fieldBuilder = classBuilder.DefineField("message", typeof(string), FieldAttributes.Public);

            ConstructorBuilder consBuilder = classBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[] { typeof(string) });

            ILGenerator gen = consBuilder.GetILGenerator();

            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Call, typeof(object).GetConstructor(new Type[0]));
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldarg_1);
            gen.Emit(OpCodes.Stfld, fieldBuilder);
            gen.Emit(OpCodes.Ret);

            MethodBuilder methBuilder = classBuilder.DefineMethod("Print", MethodAttributes.Public);
            gen = methBuilder.GetILGenerator();

            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldfld, fieldBuilder);
            gen.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
            gen.Emit(OpCodes.Ret);

            classBuilder.CreateType();

            asmBuilder.Save("MyDynamicAssembly.dll");

            Checker checker = new Checker();
            checker.CheckAssembly();

            Console.ReadLine();
        }

        static void ListAssemblies(AppDomain domain)
        {
            Console.WriteLine("--- Assemblies loaded in domain {0}: ---", domain.FriendlyName);

            foreach(var asm in domain.GetAssemblies())
            {
                var name = asm.GetName();
                Console.WriteLine("- Name : {0}, Version: {1}", name, name.Version);
            }
        }
    }
}
