using System;
using System.IO.IsolatedStorage;
using System.Threading;

namespace Readers_Writers
{

    internal class Program
    {
        private static void Main()
        {
            Supervisor sup = new Supervisor();
            sup.process();
            
            Thread.Sleep(5000);
           Console.WriteLine("Final value on sup is {0}", sup.Readers);
           
           Console.ReadKey();
        }

        private static void Run()
        {
            Console.WriteLine("Current Running on Thread {0}", Thread.CurrentThread.ManagedThreadId);

        }
    }
}
