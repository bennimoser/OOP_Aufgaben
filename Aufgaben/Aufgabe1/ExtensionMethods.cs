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
    }
}
