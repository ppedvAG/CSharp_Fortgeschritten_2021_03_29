using System;

namespace Delegate_mit_Callback
{
    class Program
    {
        public delegate void Del(string message);
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            // Berechne etwas komplexes


            //letzte Zeile, wenn alles fertig abgearbeitet wurde, senden wir ein "Wir-Sind-Fertig-Signal".
            callback("The numer is " + (param1 + param2).ToString());
        }


        static void Main(string[] args)
        {
            Del handler = new Del(DelegateMethod);

            
            MethodWithCallback(12, 33, handler);

        }
    }
}
