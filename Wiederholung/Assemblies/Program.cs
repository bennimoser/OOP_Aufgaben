using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections;

namespace Assemblies
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region Create Dynamic Assembly

            AppDomain domain = AppDomain.CurrentDomain;
            AssemblyBuilder asmBuilder = domain.DefineDynamicAssembly(new AssemblyName("MyDynamicAssembly"), AssemblyBuilderAccess.Save);
            ModuleBuilder moduleBuilder = asmBuilder.DefineDynamicModule("MyDynamicAssembly", "MyDynamicAssembly.dll");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("MyClass", TypeAttributes.Public);
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("AddNumbers", MethodAttributes.Public, typeof(void), new Type[] { typeof(int), typeof(int) });


            ILGenerator generator = methodBuilder.GetILGenerator();

            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Ldarg_2);
            generator.Emit(OpCodes.Add);
            generator.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) }));
            generator.Emit(OpCodes.Ret);

            typeBuilder.CreateType();
            asmBuilder.Save("MyDynamicAssembly.dll");

            Assembly asm = Assembly.LoadFrom("MyDynamicAssembly.dll");
            Type type = asm.GetType("MyClass");
            object instance = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod("AddNumbers");
            method.Invoke(instance, new object[] { 4, 5 });

            #endregion

            #region Filter Interfaces / Classes

            Assembly loadedAssembly = Assembly.LoadFrom("C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.7.2/System.Data.dll");

            List<Type> typesWithList = loadedAssembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IList))).ToList();

            List<Type> typesAbtract = loadedAssembly.GetTypes().Where(t => t.IsAbstract).ToList();

            #endregion

            #region Attributewerte und Interfaces

            Assembly loadAssembly = Assembly.LoadFrom("D:/2.Semester/Wiederholung/Library/bin/Debug/Library.dll");
            Type[] types = loadAssembly.GetTypes().Where(t => t.GetInterface("IExecutable") != null).ToArray();
            foreach(var loadedtype in types)
            {
                List<Attribute> attributes = loadedtype.GetCustomAttributes().ToList();
                foreach(dynamic attribute in attributes)
                {
                    if(attribute.TypeId.Name == "DescriptionAttribute")
                    {
                        Console.WriteLine(attribute.Description);
                    }
                }
            }
            #endregion

        }
    }
}
