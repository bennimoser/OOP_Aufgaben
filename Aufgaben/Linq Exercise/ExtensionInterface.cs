using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Exercise
{
    public interface ExtensionInterface<T>
    {
        T Add(T value1, T value2);
        T Subtract(T value1, T value2);
    }
}
