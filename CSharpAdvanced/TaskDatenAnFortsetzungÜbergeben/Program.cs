using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskDatenAnFortsetzungÜbergeben
{


    //    Fortsetzungsoptionen -> https://docs.microsoft.com/de-de/dotnet/standard/parallel-programming/chaining-tasks-by-using-continuation-tasks
    // Wenn Sie eine Fortsetzung einer einzelnen Aufgabe erstellen, können Sie eine ContinueWith -Überladung erstellen, die einen System.Threading.Tasks.TaskContinuationOptions -Enumerationswert annimmt,
    // um die Bedingungen anzugeben, unter denen die Vorgängeraufgabe die Fortsetzung startet.Sie können beispielsweise angeben, dass die Fortsetzung nur ausgeführt werden soll, wenn der Vorgänger erfolgreich abgeschlossen wird, oder nur, wenn er in einem Fehlerzustand abgeschlossen wird.
    // Wenn die Bedingung zu dem Zeitpunkt, zu dem der Vorgänger bereit ist, die Fortsetzung aufzurufen, nicht erfüllt ist, geht die Fortsetzung direkt in den Zustand TaskStatus.Canceled über und kann anschließend nicht mehr gestartet werden.
    // Eine Reihe von Fortsetzungsmethoden für mehrere Aufgaben, wie etwa Überladungen der Methode TaskFactory.ContinueWhenAll , beinhalten außerdem einen Parameter System.Threading.Tasks.TaskContinuationOptions.Allerdings ist nur eine Teilmenge aller Elemente der System.Threading.Tasks.TaskContinuationOptions -Enumeration gültig. Sie können System.Threading.Tasks.TaskContinuationOptions -Werte angeben, die Entsprechungen in der System.Threading.Tasks.TaskCreationOptions -Enumeration
    // aufweisen, wie etwa TaskContinuationOptions.AttachedToParent, TaskContinuationOptions.LongRunningund TaskContinuationOptions.PreferFairness.Wenn Sie für eine Fortsetzung mit mehreren Aufgaben die NotOn -Option oder die OnlyOn -Option angeben, wird zur Laufzeit eine ArgumentOutOfRangeException -Ausnahme ausgelöst.
    // Weitere Informationen zu den Optionen für die Fortsetzung von Aufgaben finden Sie im Thema TaskContinuationOptions.

    // https://docs.microsoft.com/de-de/dotnet/standard/parallel-programming/chaining-tasks-by-using-continuation-tasks#continuations-and-child-tasks
    class Program
    {
        public static async Task Main()
        {
            var task = Task.Run(DayTime);
             
            await task.ContinueWith(task => ShowDayTime(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);

        }

        public static string DayTime()
        {
            DateTime date = DateTime.Now;
            return date.Hour > 17
                 ? "evening"
                 : date.Hour > 12
                     ? "afternoon"
                     : "morning";
        }

        public static void ShowDayTime(string result)
        {
            Console.WriteLine($"Good {result}!");
            Console.WriteLine($"And how are you this fine {result}?");
        }


        //public static async Task Main()
        //{
        //    var task = Task.Run(
        //        () =>
        //        {
        //            DateTime date = DateTime.Now;
        //            return date.Hour > 17
        //           ? "evening"
        //           : date.Hour > 12
        //               ? "afternoon"
        //               : "morning";
        //        });

        //    await task.ContinueWith(
        //        antecedent =>
        //        {
        //            Console.WriteLine($"Good {antecedent.Result}!");
        //            Console.WriteLine($"And how are you this fine {antecedent.Result}?");
        //        }, TaskContinuationOptions.OnlyOnRanToCompletion);
        //}
    }
}
