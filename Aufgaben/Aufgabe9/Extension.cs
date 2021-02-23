using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe9
{
    public static class Extension
    {
        public static IEnumerable<T> Mix<T>(this IEnumerable<T> elements, params IEnumerable<T>[] objects) where T: IEquatable<T>
        {
            List<T> list = new List<T>();
            list.AddRange(elements);
            foreach(var collection in objects)
            {
                list.AddRange(collection);
            }

            return list.Distinct();
        }
    }
}
