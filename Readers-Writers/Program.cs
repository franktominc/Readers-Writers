using System;
using System.Threading;

namespace Readers_Writers
{
    internal class Program
    {
        private static void Main()
        {
            var t = new Thread(Run);

            ThreadPool.SetMaxThreads(5,1);
            var x = new Thread(Run);
            x.Start();
            t.Start();
            Console.ReadKey();
        }

        private static void Run()
        {
          Console.WriteLine("Current Running on Thread {0}", Thread.CurrentThread.ManagedThreadId);

        }
    }

}
