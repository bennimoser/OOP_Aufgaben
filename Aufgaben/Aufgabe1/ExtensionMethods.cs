using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe1
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> FilterSame<T>(this IEnumerable<T> firstobjects, IEnumerable<T> secondObjects)
        {
            for (int i = 0; i < firstobjects.MyCount(); i++)
            {
                for (int j = 0; j < secondObjects.MyCount(); j++)
                {
                    if(firstobjects.MyElementAt(i).Equals(secondObjects.MyElementAt(j)))
                    {
                        yield return firstobjects.MyElementAt(i);
                    }
                }
            }
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
