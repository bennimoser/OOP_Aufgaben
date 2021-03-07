using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe13
{
    public static class Extension
    {
        public static IEnumerable<T> FilterType<T>(this IEnumerable<object> items)
        {
            foreach(var item in items)
            {
                if (item.GetType().Equals(typeof(T)))
                {
                    yield return (T)item;
                }
            }
        }
    }
}
