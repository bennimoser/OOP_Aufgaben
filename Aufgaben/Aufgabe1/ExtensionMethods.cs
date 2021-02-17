using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe1
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> FilterSame<T>(this IEnumerable<T> self, IEnumerable<T> filter) where T : IEquatable<T>
        {
            foreach (var item in self)
                foreach (var result in filter.Where(filterItem => item.Equals(filterItem)))
                    yield return result;
        }

        public static T MyElementAt<T>(this IEnumerable<T> objects, int index)
        {
            IEnumerator<T> enumerator = objects.GetEnumerator();
            for (int i = 0; i <= index; i++)
            {
                enumerator.MoveNext();
            }
            return enumerator.Current;
        }

        public static int MyCount<T>(this IEnumerable<T> objects)
        {
            int counter = 0;
            foreach(var element in objects)
            {
                counter++;
            }
            return counter;
        }
    }
}
