using System;
using System.IO;
using System.Threading;

namespace Readers_Writers
{
    public class Reader
    {

        private Supervisor s;
        private string _path;

        public Reader(Supervisor supervisor, string path)
        {
            s = supervisor;
            _path = path;
        }
        public void Run()
        {
            var file = File.ReadAllText(_path);
            Console.WriteLine("Reader Thread Started");
            Console.WriteLine("Thread {0} have read the entire File",Thread.CurrentThread.ManagedThreadId);
            s.SubmitReader();
        }
    }
}