using System;
using System.Threading;

namespace Readers_Writers {
    internal class Program {
        private static void Main() {
            Supervisor sup = new Supervisor();
            sup.Process();

            Thread.Sleep(5000);
            Console.WriteLine("Final value of readers on sup is {0}", sup.Readers);
            Console.WriteLine("{0} writers was spawned", sup.writersSpawned);
            Console.WriteLine("{0} readers was spawned", sup.readersSpawned);

            Console.ReadKey();
        }

        private static void Run() {
            Console.WriteLine("Current Running on Thread {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}