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
            // return items.ElementAt(0);
            var enumerator = items.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current;
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
            //for (int i = 1; i < items.MyCount(); i++)
            //{
            //    yield return items.MyElementAt(i);
            //}

            var enumerator = items.GetEnumerator();
            enumerator.MoveNext();

            while (enumerator.MoveNext())
                yield return enumerator.Current;
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
            // return self.Where((element) => ( !element.Equals(toExtract) ));

            for (int i = 0; i < items.MyCount(); i++)
            {
                if(!items.MyElementAt(i).Equals(except))
                {
                    yield return items.MyElementAt(i);
                }
            }
        }

        internal static T MinimumBy<T, TKey>(this IEnumerable<T> self, Func<T, TKey> predicate)
            where TKey : IComparable<TKey>
        {
            var current = self.First();

            foreach (var item in self)
            {
                if (predicate(item).CompareTo(predicate(current)) < 0)
                    current = item;
            }

            return current;
        }

        internal static IEnumerable<T> OrderItemsBy<T, TKey>(this IEnumerable<T> self, Func<T, TKey> predicate)
            where TKey : IComparable<TKey>
        {
            // return self.OrderBy(p => predicate(p));

            // Bubblesort
            var sortedList = self.ToList(); ;

            for (int n = sortedList.Count(); n > 1; --n)
                for (int i = 0; i < n - 1; ++i)
                    if (predicate(sortedList.ElementAt(i)).CompareTo(predicate(sortedList.ElementAt(i + 1))) > 0)
                    {
                        Swap(i, i + 1);
                    }

            return sortedList;

            // Swaps two elements of the list.
            void Swap(int i, int j)
            {
                var temp = sortedList.ElementAt(i);
                sortedList[i] = sortedList.ElementAt(j);
                sortedList[j] = temp;
            }
        }

        internal static IEnumerable<(T, IEnumerable<T>)> Pick<T>(this IEnumerable<T> self)
        {
            for (int i = 0; i < self.Count(); ++i)
            {
                yield return (self.ElementAt(i), self.Except(self.ElementAt(i)));
            }
        }
    }
}
