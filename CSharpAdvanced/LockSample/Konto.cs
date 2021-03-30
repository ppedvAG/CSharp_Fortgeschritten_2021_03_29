using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockSample
{
    public class Konto
    {
        public decimal Kontostand { get; set; }

        private object lockObject = new object();

        public void Einzahlen(decimal betrag)
        {
            try
            {
                lock(lockObject)
                {
                    Console.WriteLine($"Kontostand vor dem Einzahlen: {Kontostand}");
                    Kontostand += betrag; //Ressource wird bearbeitet
                    Console.WriteLine($"Kontostand nach dem Einzahlen: {Kontostand}");
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void Abheben(decimal betrag)
        {
            //lock (lockObject)
            //{


            try
            {
                Console.WriteLine($"Kontostand vor dem Abheben: {Kontostand}");
                Kontostand -= betrag; //Ressource wird bearbeitet
                Console.WriteLine($"Kontostand nach dem Abheben: {Kontostand}");
            }
            catch (Exception ex)
            {

            }

                
            //}
        }
    }
}
