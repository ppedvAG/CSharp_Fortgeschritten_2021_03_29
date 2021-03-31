using System;
using System.Reflection;

namespace HelloReflections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lade DLL 
            Assembly geladeneDll = Assembly.LoadFrom("TrumpTaschenrechner.dll");

            //Laden der Klasse
            Type trumpTaschenrechnerTyp = geladeneDll.GetType("TrumpTaschenrechner.Taschenrechner");

            object tr = Activator.CreateInstance(trumpTaschenrechnerTyp);

            MethodInfo addInfo = trumpTaschenrechnerTyp.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32) });
            var result = addInfo.Invoke(tr, new object[] { 6, 4 });


            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
