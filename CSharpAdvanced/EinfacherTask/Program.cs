using System;
using System.Threading;
using System.Threading.Tasks; //ab .NET 4.0 

namespace EinfacherTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task easyTask = new Task(IchMacheEtwasImTask);
            easyTask.Start();
            easyTask.Wait();

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("*");
            }
            Console.ReadKey();
        }


        private static void IchMacheEtwasImTask()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("#");
            }
        }
    }
}
