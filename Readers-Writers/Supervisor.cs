using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Threading;

namespace Readers_Writers {
    public class Supervisor {
        private readonly ConcurrentQueue<string> _cq;
       public int writersSpawned = 0;
        public int readersSpawned = 0;

        private string Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
            @"\Teste2.txt";

        private volatile bool isWriting = false;

        private volatile int readers;

        private Random random = new Random();

        public int Readers {
            get { return readers; }
            set { readers = value; }
        }



        public Supervisor() {
            _cq = new ConcurrentQueue<string>();
            int i = 0;
            while (i++ < 100) {
                int k = random.Next(0, 0x7ff);
                if(k%2 == 0)
                    _cq.Enqueue("Read");
                else {
                    _cq.Enqueue("Write");
                }
            }
            readers = 0;
        }

        public void Receive(string request) {
            _cq.Enqueue(request);
        }

        public void SubmitReader() {
            Interlocked.Decrement(ref readers);
        }

        public void SubmitWriter() {
            isWriting = false;
        }

    public void Read() {
            var r = new Reader(this, Path);
            var x = new Thread(r.Run);
            x.Start();
        }

        public void Process() {
            while (!_cq.IsEmpty) {
                string s;
                _cq.TryDequeue(out s);
                switch (s) {
                    case "Read":
                        while (isWriting) {
                            Console.WriteLine("Queue process thread is waiting for writer to finish");
                            Thread.SpinWait(2);
                        }
                        Interlocked.Increment(ref readers);
                        Interlocked.Increment(ref readersSpawned);
                        Read();
                        break;
                    case "Write":
                        while (readers != 0 || isWriting) {
                            Console.WriteLine("Queue process thread is waiting for readers or writer to finish");
                            Thread.SpinWait(2);
                            
                            
                        }
                        Interlocked.Increment(ref writersSpawned);
                        Write();
                        break;

                }
            }
        }

        public void Write() {
            isWriting = true;
            Writer writer =  new Writer(Path, this);
            Thread writeThread = new Thread(writer.Write);
            writeThread.Start();
        }

    }
}