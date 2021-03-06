using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Generics
{
    public static class Extension
    {
        public static T FirstElement<T>(this IEnumerable<T> items)
        {
            IEnumerator<T> enumerator = items.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current;
        }

        public static IEnumerable<T> AllExceptFirst<T>(this IEnumerable<T> items)
        {
            IEnumerator<T> enumerator = items.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 1; i < items.MyCount(); i++)
            {
                enumerator.MoveNext();
                yield return enumerator.Current;
            }
        }

        public static int MyCount<T>(this IEnumerable<T> items)
        {
            int counter = 0;
            foreach(var item in items)
            {
                counter++;
            }
            return counter;
        }

        public static void MyPrint(this IEnumerable<string> items) 
        {
            foreach(var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<U> MyApplyFunction<T,U>(this IEnumerable<T> items, Func<T,U> function) where T:U
        {
            foreach(var item in items)
            {
                yield return function.Invoke(item);
            }
        } 


    }
}
