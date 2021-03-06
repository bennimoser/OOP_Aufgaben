using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    public class Program
    {
        public delegate int BinaryOperation(int x, int y);

        public static void Main(string[] args)
        {
            BinaryOperation operation = new BinaryOperation(Add);
            var result = operation.BeginInvoke(3, 4, new AsyncCallback(CallBack), "Hallo du da");
            while (!result.IsCompleted)
            {
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static void CallBack(IAsyncResult result)
        {
            AsyncResult endresult = (AsyncResult)result;
            BinaryOperation operation = (BinaryOperation)endresult.AsyncDelegate;
            Console.WriteLine(result.AsyncState);
            Console.WriteLine("Ergebnis ist: " + operation.EndInvoke(result));
        }
    }
}
