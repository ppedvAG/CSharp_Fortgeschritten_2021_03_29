using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> strList = new List<string>();
            strList.Add("eins");
            strList.Add("zwei");


            Hashtable hashtable = new Hashtable();

            hashtable.Add(1, new List<string>());
            hashtable.Add(2, 123);

            foreach (object obj in hashtable)
            {
                if (obj is List<string>)
                {

                }
            }

            #region Dictionary
            IDictionary<Guid, string> dictionary = new Dictionary<Guid, string>();
            
            DoSomethingsGood(dictionary);

            //IDictionary<string, string> dictionary1 = new Dictionary<string, string>();
            
            dictionary.Add(Guid.NewGuid(), "ABC");

            KeyValuePair<Guid, string> keyValuePair = new KeyValuePair<Guid, string>(Guid.Empty, "Hallo");
            dictionary.Add(keyValuePair);

            if (dictionary.ContainsKey(Guid.Empty))
            {
                string value = dictionary[Guid.Empty];
            }

            foreach (KeyValuePair<Guid, string> currentItem in dictionary)
            {
                Guid anyGuid = currentItem.Key;
                string value = currentItem.Value;
            }//scope muss hier zuende sein

            KeyValuePair<Guid, string> currentItem1 = dictionary.Single(n => n.Key == Guid.Empty);
            #endregion

            Console.WriteLine("Hello World!");

            DataStore<Guid> data = new DataStore<Guid>();
            DataStore<int> data1 = new DataStore<int>();
            data.DisplayDefaultOf<string>();
        }

        

        static void DoSomethingsGood(IDictionary<Guid,string> dict)
        {

        }

        static void DoSomethingsBad(Dictionary<Guid, string> dict)
        {

        }
    }

    public class DataStore<T>
    {
        private T[] _data = new T[10]; //Klassen Variable oder auch Member-Variable genannt 

        public T[] Data // Property regelt den Zugriff auf Variable 
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public T GetData(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T);
        }
        public void DisplayDefaultOf3<DD>() //Generische Methode
        {
            DD item = default(DD);
            Console.WriteLine($"Default value of {typeof(DD)} is {(item == null ? "null" : item.ToString())}.");
        }
        public void DisplayDefaultOf2<TT>() //Generische Methode
        {
            TT item = default(TT);
            Console.WriteLine($"Default value of {typeof(TT)} is {(item == null ? "null" : item.ToString())}.");
        }

        public void DisplayDefaultOf<TT>()
        {
            var val = default(TT);
            Console.WriteLine($"Default value of {typeof(TT)} is {(val == null ? "null" : val.ToString())}.");
        }

    }

    
}
