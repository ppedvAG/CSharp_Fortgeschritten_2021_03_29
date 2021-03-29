using System;

namespace CSharp_70
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Out-Variable Beispiel 1:
            Console.Write("Bitte geben Sie ein Zahl ein: ");
            string eingabe = Console.ReadLine();
            int ausgabe;

            if (int.TryParse(eingabe, out ausgabe))
            {
                Console.WriteLine("Die Umwandlung hat geklappt");
            }
            else
            {
                Console.WriteLine("Die Umwandlung hat nicht geklappt");
            }
            #endregion
            #region Out-Variable Beispiel 2
            int count = 0;
            ChangeNumberNormal(count); // Count bleibt weiterhin auf 0
            Console.WriteLine($"Die Ausgabe von ChangeNumberNormal ist: {count}"); //0

            //Bein Aufruf muss expliziet out mit in den Aufruf geschreiben werden. 
            ChangeNumberWithOut(out count);
            Console.WriteLine($"Die Ausgabe von ChangeNumberWithOut ist: {count}"); //222
            Console.ReadKey();
            #endregion


            #region PatternMatching
            PatternMatchingSample("Hallo");
            PatternMatchingSample(123);
            PatternMatchingSample(null);
            #endregion


            #region Tupel
            Person person = new Person("Max", "Mustermann");

            (string, string) value = person.VolleNamensAusgabe();
            var value1 = person.VolleNamensAusgabe1();

            (string fn, string ln) value2 = person.VolleNamensAusgabe1();

            var (firstname, lastname) = person;

            string vorundnachname;
            //Variablen Definition von firstname, lastname und vorundnachname 
             (firstname, lastname,  vorundnachname) = person;

            #endregion


            #region Variablen und Werte-Zuweisungen 
            int ganzeZahl = 0xFFFFFFF;

            decimal money = 123123m;

            Console.WriteLine(money.ToString());
            #endregion




            #region Rückgabe per Referenz 
            //aus 777 wird 1000000! 
            int[] zahlen = { 5, 7, 444, 555, 666, 777, 888, 999 };
            ref int position = ref Zahlensuche(777, zahlen);

            position = 1000000;
            Console.WriteLine(zahlen[5]);

            foreach (int current in zahlen)
            {
                Console.WriteLine($"{current}");
            }
            Console.ReadKey();
            #endregion
        }


        static void ChangeNumberNormal(int number)
        {
            number = 111; // Wert 111 gilt nur in dieser Methode - Verhalten wir eine Wertkopie
        }
        static void ChangeNumberWithOut(out int number)
        {
            number = 222;
        }
        public static void PatternMatchingSample(object anyObj)
        {
            if (anyObj is null)
                throw new ArgumentException();

            //Wenn anyObj ein integer repräsentiert, wird hier gemacht und zusätzlich wird der Wert von anyObj direkt in die i gecastet
            if (anyObj is int i)
            {
                //Variable i gilt nur innerhalb des Codeblocks
                Console.WriteLine($"Variable i  wird als integer behandelt und ausgegeben{i}");
            }
            if (anyObj is string str) //geht auch mit string
                Console.WriteLine(str);
        }


        #region Rückgabe per Referenz

        public static ref int Zahlensuche(int gesuchteZahl, int[] zahlen)
        {
            for (int i = 0; i < zahlen.Length; i++)
            {
                if (zahlen[i] == gesuchteZahl)
                    return ref zahlen[i];
            }
            throw new IndexOutOfRangeException();
        }

        #endregion


        int zahl1 = 123;
        string wort = "test";

        //var tupel = (zahl1, wort);
    }


    public class Person
    {
        public Person() => Firstname = Lastname = string.Empty;

        //public Person()
        //{
        //    Firstname = string.Empty;
        //    Lastname = string.Empty;
        //}

        public Person(string firstName, string nachName)
        {
            this.Firstname = firstName;
            this.Lastname = nachName;
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public (string, string) VolleNamensAusgabe() // var returnValues = person.VolleNamensAusgabe(); returnValues.Item1 / returnValues.Item2
        {
            return (Firstname, Lastname);
        }

        public (string Vorname, string Nachname) VolleNamensAusgabe1() // var returnValues = person.VolleNamensAusgabe(); returnValues.Item1 / returnValues.Item2
        {
            return (Firstname, Lastname);
        }






        public void Deconstruct(out string firstname, out string lastname)
        {
            firstname = Firstname;
            lastname = Lastname;
        }

        public void Deconstruct(out string firstname, out string lastname, out string vorundnachname)
        {
            firstname = Firstname;
            lastname = Lastname;
            vorundnachname = firstname + " " + lastname;
        }
    }
}
