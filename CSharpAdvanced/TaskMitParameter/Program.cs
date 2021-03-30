using System;
using System.Threading.Tasks;

namespace TaskMitParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new Katze();
            

            Task<string> task = Task.Factory.StartNew(GibtDatumMitInput, katze);

            //Run - Methode mit Parameter 
            Task<string> task1 = Task.Run(() => GibtDatumMitInput(katze));

            //dritte alternative in Verwendung mit der Task.Start() - Methode
            Task<string> easyTask = new Task<string>(() => GibtDatumMitInput(katze));
            easyTask.Start();


            task.Wait();
            Console.Write(task.Result); //Das Ergebnis steckt dann in task.Result

            Console.WriteLine("Hello World!");
        }


        private static string GibtDatumMitInput(object input)
        {
            Katze katze = null;

            if (input is Katze)
                katze = (Katze)input;

            Console.WriteLine(katze.Name);

            //int dauer = (int)input;

            //Thread.Sleep(dauer);
            return DateTime.Now.ToLongDateString();
        }
    }


    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}
