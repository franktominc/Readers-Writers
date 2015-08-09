using System;
using System.IO;
using System.Threading;

namespace Readers_Writers {
    class Writer {
        private string path;
        private Supervisor supervisor;

        public Writer(string P, Supervisor S) {
            path = P;
            supervisor = S;
        }

        public void Write() {
            Console.WriteLine("Writer Thread {0} Started", Thread.CurrentThread.ManagedThreadId);
            string k = "Thread " + Thread.CurrentThread.ManagedThreadId + "  writed to the file\n";
            Console.WriteLine("Thread {0} wrote to the file", Thread.CurrentThread.ManagedThreadId);
            File.AppendAllText(path,k );
            supervisor.SubmitWriter();
        }
    }
}
