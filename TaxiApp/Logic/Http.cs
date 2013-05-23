using System;
using System.Threading;

namespace ThreadPoolTest
{
    internal class MainApp
    {
        private static void Main()
        {
            WaitCallback callBack;

            callBack = new WaitCallback(PooledFunc);
            ThreadPool.QueueUserWorkItem(callBack,
               "Is there any screw left?");
            ThreadPool.QueueUserWorkItem(callBack,
               "How much is a 40W bulb?");
            ThreadPool.QueueUserWorkItem(callBack,
               "Decrease stock of monkey wrench");
            Console.ReadLine();
        }

        private static void PooledFunc(object state)
        {
            Console.WriteLine("Processing request '{0}'", (string)state);

            // Simulation of processing time
            Thread.Sleep(2000);
            Console.WriteLine("Request processed");
        }
    }
}