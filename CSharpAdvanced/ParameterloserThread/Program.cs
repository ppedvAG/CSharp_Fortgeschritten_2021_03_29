using System;
using System.Threading;

namespace ParameterloserThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(MacheEtwasRechenintensives);

            thread.Start(123); // Thread wird gestartet

            thread.Join();  // Warten bis Thread fertig ist. 

            for (int i = 0; i < 10000; i++)
                Console.WriteLine("+");

            Console.ReadKey();
        }

        static void MacheEtwasRechenintensives(object testzahl)
        {
            for (int i = 0; i < 10000; i++)
                Console.WriteLine("#");
        }
    }
}
