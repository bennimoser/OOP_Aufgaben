using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe7
{
    public static class Extension
    {
        public static IEnumerable<V> Apply<T,V>(this IEnumerable<T> objects, Func<T,V> function)
        {
             return objects.Select(function).ToList().OrderBy(x => x).ToList();
        }
    }
}
