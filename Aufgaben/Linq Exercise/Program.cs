using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Exercise
{
    class Program
    {
        public static void Main(string[] args)
        {
            var p1 = new Person("Sarah", "Huber", 35);
            var p2 = new Person("Christine", "Muserfrau", 50);
            var p3 = new Person("Rainer", "Zufall", 24);
            var p4 = new Person("Max", "Meier", 60);
            var p5 = new Person("Kristina", "Auer", 32);

            var people = new List<Person>
            {
                p1, p2, p3, p4, p5,
            };

            // "Head" yields the first element.
            // Result: Sarah Huber.
            Console.WriteLine(people.Head());

            // "Tail" yields all elements except the first.
            // Result: Christine Muserfrau, Rainer Zufall, Max Meier, Kristina Auer
            people.Tail().MyPrint();


            // "Except" extracts a specific element from the enumarable.
            // Result: Sarah Huber, Max Meier, Kristina Auer
            people.Except(p2).Except(p3).MyPrint();


            // "MinimumBy" searches the minimum element according to a selection criteria.
            // Result: Rainer Zufall
            Console.WriteLine(people.MinimumBy(p => p.Age));


            // "OrderItemsBy" sort elements according to a seletion criteraia.
            // Result: Kristina Auer, Sarah Huber, Max Maier, Christina Musterfrau, Rainer Zufall
            people.OrderItemsBy(p => p.Lastname).MyPrint();


            // Prints all permutations of all elements.
            //Console.WriteLine("-----");
            //foreach (var permuation in people.Permutate())
            //    permuation.MyPrint();


            // "Pick" takes one element at a time and yields the element and the rest as a tuple.
            // Result:
            // (Sarah Huber,                 {               Christine Musterfrau,   Rainer Zufall,  Max Meier,  Kristina Auer})
            // (Christine Musterfrau,        {Sarah Huber,                           Rainer Zufall,  Max Meier,  Kristina Auer})
            // (Rainer Zufall,               {Sarah Huber,   Christine Musterfrau,                   Max Meier,  Kristina Auer})
            // (Max Meier,                   {Sarah Huber,   Christine Musterfrau,   Rainer Zufall               Kristina Auer})
            // (Kristina Auer,               {Sarah Huber,   Christine Musterfrau,   Rainer Zufall,  Max Meier,               })

            foreach ((var pickElement, var pickResult) in people.Pick())
            {
                Console.WriteLine($"{pickElement}       {string.Join(",", pickResult)}");
            }


            Extensionclass<string>.SomeMethod("hallo");

            Console.ReadLine();
        }
    }
}
