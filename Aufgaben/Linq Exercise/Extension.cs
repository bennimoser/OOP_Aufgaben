using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Exercise
{
    //1. Print nochmals implementieren
    //2. Head(erstes Element)
    //3. Tail(erstes Element exkludiert)
    //4. Except(alles bis auf ein bestimmtes Element)
    //5. MinimumBy (kleinstes Element basierend auf einem Kriterium)
    //6. OrderItemsBy (aufsteigend sortieren basierend auf einem Kriterium)
    //7. Pick (jeweils ein Element herausnehmen und auch den Rest zurückgeben)
    //8. Permutation (alle Permutationen)

    public static class Extension
    {
        public static void MyPrint<T>(this IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static T Head<T>(this IEnumerable<T> items)
        {
            return items.MyElementAt(0);
        }

        public static T MyElementAt<T>(this IEnumerable<T> items, int index)
        {
            var enumerator = items.GetEnumerator();
            for (int i = 0; i <= index; i++)
            {
                enumerator.MoveNext();
            }
            return enumerator.Current;
        }

        public static IEnumerable<T> Tail<T>(this IEnumerable<T> items)
        {
            for (int i = 1; i < items.MyCount(); i++)
            {
                yield return items.MyElementAt(i);
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

        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, T except)
        {
            for (int i = 0; i < items.MyCount(); i++)
            {
                if(!items.MyElementAt(i).Equals(except))
                {
                    yield return items.MyElementAt(i);
                }
            }
        }
    }
}
