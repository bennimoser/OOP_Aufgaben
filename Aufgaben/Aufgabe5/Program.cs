using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var processes = Process.GetProcesses();

            //Important! Buildoptions: 32 bit bevorzugen entwählen!!!
            //Get Modules
            List<ProcessModuleCollection> list = new List<ProcessModuleCollection>();
            foreach(var process in processes)
            {
                try
                {
                    var modules = process.Modules;
                    list.Add(modules);
                }
                catch (Exception e)
                {
                }
            }

            //Check on .Net Assembly
            foreach (var modules in list)
            {
                for (int i = 0; i < modules.Count; i++)
                {
                    var module = modules[i];
                    try
                    {
                        Assembly assembly = Assembly.LoadFrom(module.FileName);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(module.ModuleName + "is an .Net Assembly");
                    }
                    catch(BadImageFormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(module.FileName + "is not an .Net Assembly");
                    }
                    catch(FileNotFoundException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(module.FileName + "! File not found!");
                    }
                }
            }
        }
    }
}
