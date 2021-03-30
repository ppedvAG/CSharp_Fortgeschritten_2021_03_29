using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(Zähle, Zähle, Zähle, Zähle); //Wird 4x gleichzeitig gestartet 

            List<string> text = new List<string>(new[] { "Dies", "ist", "ein", "Text" });
            text.ForEach(abc => Console.WriteLine(abc));

            Console.WriteLine("Ende");
            Console.ReadLine();
        }



        private static void Zähle()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]: {i}");
                //if (i > 7) Console.ReadKey();
            }
        }
    }
}
