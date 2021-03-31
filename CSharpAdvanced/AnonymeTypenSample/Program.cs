using System;
using System.Dynamic;

namespace AnonymeTypenSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Anonyme Typen können zur Designzeit alle Variablen anbieten (bzw. Intellisense arbeitet mit) 
            var anonymClass = new { ID = 1, Name = "Kevin", Alter = 123, Tier="Hund" };


            //Dynamische Typen -> Intellisense fällt weg, weil zur Design-Zeit nicht bekannt ist, wie der dynamische Typ aufgebaut ist. 
            dynamic stud = new ExpandoObject();
            stud.Variable1 = 123;
            stud.StringVariable = "hallo";
            stud.Farbe = "grau";

        }
    }
}
