﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskContinueWithSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(() => // ()=> eine Anonyme Methode
            {
                Console.WriteLine("T1 gestartet");
                Thread.Sleep(800);
                throw new Exception();
                //Console.WriteLine("T1 fertig");
            });

            t1.ContinueWith(t => { Console.WriteLine("T1 Continue"); });
            t1.ContinueWith(t => { Console.WriteLine("T1 OK"); }, TaskContinuationOptions.OnlyOnRanToCompletion);
            t1.ContinueWith(t => { Console.WriteLine($"T1 ERROR {t.Exception.Message}"); }, TaskContinuationOptions.OnlyOnFaulted);
        }

        public static void Alternativ ()
        {
            Console.WriteLine("T1 gestartet");
            Thread.Sleep(800);
            //throw new Exception();
            Console.WriteLine("T1 fertig");
        }
    }
}
