using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Description("Das ist eine coole Testklasse")]
    public class TestClass : IExecutable
    {
        public void ExecuteAction(int param1)
        {
            Console.WriteLine("Das ist eine super coole und wichtige Operation : " + param1);
        }
    }
}
