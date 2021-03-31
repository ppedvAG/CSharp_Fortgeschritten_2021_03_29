﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAndLambdaSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> persons = new List<Person>()
            {
                new Person { Id=1, Age=40, Vorname="Kevin", Nachname="Winter"},
                new Person { Id=2, Age=43, Vorname="Petra", Nachname="Musterfrau"},
                new Person { Id=3, Age=19, Vorname="Pascal", Nachname="Neugierig"},
                new Person { Id=4, Age=53, Vorname="Matthias", Nachname="Trump"},
                new Person { Id=4, Age=53, Vorname="Matthias2", Nachname="Trump2"},
                new Person { Id=5, Age=23, Vorname="Denise", Nachname="Muster"},
                new Person { Id=6, Age=39, Vorname="Steffi", Nachname="Schuhmacher"},
                new Person { Id=7, Age=41, Vorname="Heike", Nachname="Müller"},
                new Person { Id=8, Age=29, Vorname="Peter", Nachname="Mustermann"}
            };


            //Linq Expression
            IList<Person> result1 = (from p in persons
                                     where p.Age < 40 && p.Age >= 30
                                     orderby p.Nachname
                                     select p).ToList();

            //Linq Functions with Lamda Expressions

            IList<Person> result2 = persons.Where(p => p.Age < 40 && p.Age >= 30)
                                           .OrderBy(o => o.Nachname)
                                           .ToList();


            var personQuery = from p in persons select new { p.Id , p.Vorname };

            foreach (var v in personQuery)
            {
                Console.WriteLine("Color={0}, Price={1}", v.Vorname, v.Id);
            }




        }
    }


    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }

    }
}
