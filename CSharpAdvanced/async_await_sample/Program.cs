using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace async_await_sample
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //Task task = MethodOld();
            //task.Wait();

            // await Method1();


            List<int> resultList = await AsyncWithParameter();
        }

        public static Task MethodOld()
        {
            Task myTask = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    // Do something
                    Task.Delay(100).Wait();
                }
            });

            return myTask;
        }


        public static async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    // Do something
                    Task.Delay(100).Wait();
                }
            });
        }


        public static async Task<List<int>> AsyncWithParameter()
        {
            List<int> retList = new List<int>();
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    retList.Add(i);
                    // Do something
                    //Task.Delay(100).Wait();
                }
            });

            return retList;
        }




    }
}
