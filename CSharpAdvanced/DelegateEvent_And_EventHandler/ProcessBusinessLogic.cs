using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent_And_EventHandler
{
    public delegate void Notify(); //delegate

    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted; // Event

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");




            //Am Ende wird OnProcessCompleted ausgeführt. 
            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke(); //Hier springt er in die angehängte Methode rein -> Program.cs ->  private static void Pbl_ProcessCompleted()
        }
    }






}
