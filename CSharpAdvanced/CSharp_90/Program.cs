using System;

namespace CSharp_90
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new(11, "Hannes");
            int hashCode = person.GetHashCode(); // GetHashCode -> ausimplementiert per Default
            Console.WriteLine(hashCode.ToString());

            if (person.Equals(new Person(11, "Hannes")))
                Console.WriteLine("Records sind gleich");
            else
                Console.WriteLine("Records sind ungleich");


            ClassPerson classPerson = new(11, "Hannes");
            hashCode = classPerson.GetHashCode();
            Console.WriteLine(hashCode.ToString());

            if (classPerson.Equals(new ClassPerson(11, "Hannes")))
                Console.WriteLine("Klassen sind gleich");
            else
                Console.WriteLine("Klassen sind ungleich");


            Person person1 = new(11, "Hannes");

            if (person == person1)
                Console.WriteLine("ist gleich");


            Person brother = person with { Name = "Andreas" }; //Kopiere Record + Ändere Variable ab 



            Console.ReadKey();
        }
    }

    public class ClassPerson
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public ClassPerson(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Methode()
        {
            //Machwas
        }

        public override bool Equals(object obj)
        {
            if (obj is not ClassPerson)
                return false;

            ClassPerson toCheck = (ClassPerson)obj;

            if (this.Id != toCheck.Id)
                return false;

            if (this.Name != toCheck.Name)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public record Person
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name; 
        }

        public void Methode()
        {
            //Machwas
        }
    }
}
