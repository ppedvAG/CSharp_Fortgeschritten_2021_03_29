using System;
using System.Threading;

namespace ThreadsBeenden
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(MachEtwas);
            t.Start();
            Thread.Sleep(3000);
            t.Interrupt(); // -> t.Abort(); 

            Console.WriteLine("fertig");
            Console.ReadKey();
        }

        private static void MachEtwas()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    Thread.Sleep(100);

                    Console.WriteLine("zZzZ");
                }
            }
            catch 
            {

            }
        }
    }
}
