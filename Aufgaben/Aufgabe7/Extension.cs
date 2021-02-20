using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe7
{
    public static class Extension
    {
        public static IEnumerable<T> Apply<T>(this IEnumerable<T> objects, Func<T, T> function)
        {
            foreach(var item in objects){
                yield return function.Invoke(item);
            }
        }
    }
}
