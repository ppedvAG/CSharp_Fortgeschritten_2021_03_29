using System;

namespace DelegatesAsActions
{
    class Program
    {
        //delegate int NumbChange(int n); //Zeiger auf einer Methode/Funktion 
        static void Main(string[] args)
        {
            //NumbChange nc1 = new NumbChange(AddNum);
            //nc1(12); -> Ruft AddNum auf

            Action a1 = new Action(A); //Initialisiere und hänge Methode A dran
            a1 += B; //Hänge Methode B dran 

            Action<int>  a2 = C;
            a2(222); //aufruf der Methode C 

            Action<int, int, int> a3 = AddNums;
            a3(123, 456, 222); // Aufruf der Methode AddNums 

            //Letztes int ist Rückgabewert 
            Func<int, int, int> rechner = Add;
            int result = rechner(33, 66);

            Console.ReadKey();


        }
        public static int Add(int z1, int z2)
        {
            return z1 + z2;
        }


        public static void A()
        {
            Console.WriteLine("A");
        }

        public static void B()
        {
            Console.WriteLine("B");
        }

        static void C(int zahl)
        {
            Console.WriteLine("C" + zahl);
        }

        public static void AddNums(int a, int b, int c)
        {
            int result = a + b + c;

            Console.WriteLine($"{result}");
        }
    }
}
