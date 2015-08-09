using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Readers_Writers {
    class Writer {
        private string path;
        private Supervisor supervisor;

        public Writer(string P, Supervisor S) {
            path = P;
            supervisor = S;
        }

        public void Write() {
            string k = "Thread " + Thread.CurrentThread.ManagedThreadId + "  writed to the file\n";
            Console.WriteLine("Thread {0} writed to the file", Thread.CurrentThread.ManagedThreadId);
            File.AppendAllText(path,k );
            supervisor.SubmitWriter();
        }
    }
}
