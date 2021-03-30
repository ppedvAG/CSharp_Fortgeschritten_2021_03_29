using System;

namespace Delegates_Events
{
    class Program
    {
        delegate int NumberChange(int n); //NumberChange ist ein neuer Delegate-Datentyp 
        static int num = 10;

        static void Main(string[] args)
        {
            NumberChange nc1 = new NumberChange(AddNum);
            nc1(12); //Aufruf der Methode int AddNum(int p)


            Console.WriteLine("2ter Call mit 2 angehängten Methoden");
            nc1 += MultNum; // Füge zusätzlich eine weitere Methode hinzu
            nc1(25);


            nc1 -= AddNum; //Lösche AddNum Methode aus Methoden-Liste
            nc1(13); // Ruft nur MultNum auf
            Console.ReadKey();
        }


        public static int AddNum(int p)
        {
            num += p;
            Console.WriteLine("AddNum is called");
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            Console.WriteLine("MultNum is called");
            return num;
        }
    }
}
