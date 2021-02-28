using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPLExample
{
    class Program
    {
        public delegate int BinaryOperation(int x, int y);

        public static void Main(string[] args)
        {
            BinaryOperation operation = new BinaryOperation(Add);
            Console.WriteLine("Method was called on Thread " + Thread.CurrentThread.ManagedThreadId);
            IAsyncResult asyncresult = operation.BeginInvoke(3, 4, new AsyncCallback(ExtractResult), new int[] { 3, 4 });
            while (!asyncresult.IsCompleted)
            {
                Console.WriteLine("Still working on the Operation");
                Thread.Sleep(1000);
            }


            Console.WriteLine();
            Console.WriteLine("That was it with Delegates and IAsyncCallback");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Timers");




            Timer timer = new Timer(new TimerCallback(TimerCallBack), "Hallihallo! Es ist : ", new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 1));
            Thread.Sleep(10000);
            timer.Dispose();



            Console.WriteLine();
            Console.WriteLine("That was it with timers");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Parallel");

            int lowerBoundary = 0;
            int upperBoundary = 10;

            DateTime startTime = DateTime.Now;
            CalculateSingle(lowerBoundary, upperBoundary);
            Console.WriteLine(DateTime.Now.Subtract(startTime).TotalMilliseconds);


            startTime = DateTime.Now;
            CalculateParallel(lowerBoundary, upperBoundary);
            Console.WriteLine(DateTime.Now.Subtract(startTime).TotalMilliseconds);


            Console.WriteLine();
            Console.WriteLine("That was it with Parallel");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Tasks");

            Task myTask = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Do something in the task, it is" + DateTime.Now.ToLongTimeString());
            });
            Console.WriteLine("Do something in the task, it is" + DateTime.Now.ToLongTimeString());

            myTask.Wait();
        }

        public static int Add(int x, int y)
        {
            Console.WriteLine("Method was executed on Thread " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(10000);
            return x + y;
        }

        public static void ExtractResult(IAsyncResult asresult)
        {
            AsyncResult ar = (AsyncResult)asresult;
            BinaryOperation binary = (BinaryOperation)ar.AsyncDelegate;
            int result = binary.EndInvoke(ar);
            int[] array = (int[])ar.AsyncState;
            Console.WriteLine("Its finished! The Result of " + array[0] + " + " + array[1] + ": " + result);
        }

        public static void TimerCallBack(object state)
        {
            Console.WriteLine("Method was called on Thread Nr. " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine((string)state + DateTime.Now.ToLongTimeString());
        }

        public static void CalculateSingle(int lowerBoundary, int upperBoundary)
        {
            for (int i = lowerBoundary; i < upperBoundary; i++)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
            }
        }

        public static void CalculateParallel(int lowerBoundary, int upperBoundary)
        {
            Parallel.For(lowerBoundary, upperBoundary, i =>
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
            });
        }
    }

}
