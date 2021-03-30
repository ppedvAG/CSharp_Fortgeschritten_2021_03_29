﻿using System;
using System.Collections;

namespace GenericWithConstraintsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataStore<string> store1 = new DataStore<string>();
            //DataStore<MyClass> store2 = new DataStore<MyClass>();

            //DataStore<IMyInterface> store3 = new DataStore<IMyInterface>();

            ////DataStore<MyStruct> store4 = new DataStore<MyStruct>(); -> Struct ist ein Wertetyp

            ////DataStore<int> store5 = new DataStore<int>(); // -> int ist ein Wertetyp

            //DataStore<ArrayList> store6 = new DataStore<ArrayList>();

            //DataStore<MyRecord> store7 = new DataStore<MyRecord>();




            ////DataStore1<T> where T : struct 

            //DataStore1<string> store7 = new DataStore1<string>();
            //DataStore1<MyClass> store8 = new DataStore1<MyClass>();
            //DataStore1<IMyInterface> store9 = new DataStore1<IMyInterface>();
            //DataStore1<MyStruct> store10 = new DataStore1<MyStruct>();
            //DataStore1<int> store11 = new DataStore1<int>();
            //DataStore1<MyRecord> store7 = new DataStore1<MyRecord>();
        }
    }



    class DataStore<T> where T : class
    {
        public T Data { get; set; }
    }

    class DataStore1<T, TT> 
        where T : struct
        where TT: class
    {
        public T Data { get; set; }
    }

    class DataStore2<T> where T : Animal
    {
        public T Data { get; set; }
    }

    public class Animal
    {
        public string Name { get; set; } = "R2D2";
    }

    public class Dog : Animal
    {
        public string Hunderasse { get; set; } = "Schäferhund";
    }

    public record MyRecord
    {

    }
    public class MyClass
    {

    }

    public interface IMyInterface
    {
    }

    public struct MyStruct
    {
        string Name { get; set; }
    }

    
}
