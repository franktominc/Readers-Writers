using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readers_Writers {
    class Teste {
        public static void Main(string[] args)
        {
            FileStream fileStream = File.Open(@"C:\Users\frank\Desktop\Teste2.txt", FileMode.Open);

            fileStream.Lock(0, Int64.MaxValue);
            if()
                Console.WriteLine("I Cant");

            Console.ReadKey();
        }
    }
}
