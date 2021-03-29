using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp_80
{
    class Program
    {
        static void Main(string[] args)
        {
            GebeZahlenAus();
            //using (Car car = new Car()) //objekte die mit using begleitet werden, benötigen das IDisposeable - Interface
            //{ 


            //}

            #region VerbatinString

            string consolenAusgabe = "Hallo Regina \n ich hoffe der Kurs bereitet Dir Freude"; //Text mit Escapezeichen
            string filePath1 = "C:\\Temp\\anyDirectory";
            string filePath2 = @"C:\Temp\anyDirectory";


            string stringMitVariable = $"text vor Variablenausgabe {filePath1} text dazwischen {filePath2} und hier kann ich auch noch etwas schreiben"; //Verkettung? ->Antwort: string.format()
            #endregion



            int? zahl = null;
#nullable enable

            int? zahl2 = GetValue();
            zahl = GetValue();

            int? zahl3 = null;
#nullable disable 


            New80Class new80Class = new New80Class();

            INew80Interface new80ClassB = new New80Class();

            new80ClassB.Hallo(); 

            Console.ReadKey();
        }

        public static int? GetValue()
        {
            return null; 
        }
        public static async IAsyncEnumerable<int> GeneriereZahlen()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;

                Console.WriteLine("Hallo Welt");
                // Gebe pro Schleifendurchlauf einen Wert nach dem Anderen heraus, bis die Schleife durchgelaufen ist. 
                // yield return sagt nicht, dass man eine Methode verlässt, wie bei einem einfachen Retun
            }
        }
        public static async void GebeZahlenAus()
        {
            await foreach (var zahl in GeneriereZahlen()) //foreach -> lese werte bis liste "leer" ist. 
            {
                Console.WriteLine(zahl);
            }
        }
    }

    public class Car : IDisposable
    {
        //ctor + tab + tab 
        public Car()
        {

        }

        public void Dispose()
        {
            //Räume auf und setze alles auf null 
        }
    }


    public interface IOldInterfaceRules
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    public interface INew80Interface
    {
        public void Hallo()
        {
            Console.WriteLine("Hallo Welt");
        }

        public virtual void GutenAbend()
        {
            Console.WriteLine("Hallo Welt");
        }

        public abstract void GutenMorgen();

        public void Wiederschauen();
    }

    public class New80Class : INew80Interface
    {
        public void GutenMorgen()
        {
           
        }

        public void Wiederschauen()
        {
            
        }

        public void TestMe()
        {
            INew80Interface myInterface = (INew80Interface)this;

            myInterface.Hallo();
            myInterface.GutenAbend();
            myInterface.GutenMorgen();
        }
    }
}
