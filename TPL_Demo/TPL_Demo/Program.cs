using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tasks erstellen
            //// Tasks erstellen
            //Task t1 = new Task(IchMacheEtwasImTask);
            //t1.Start();

            //Task t2 = Task.Factory.StartNew(IchMacheEtwasImTask2); // Startet sofort
            //Task t3 = Task.Run(IchMacheEtwasImTask3);              // Startet sofort

            //// Task.Run macht in Wirklichkeit:
            //// Task.Factory.StartNew(IchMacheEtwasImTask, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default); 
            #endregion

            #region Ergebnis von einem Task
            //Task<string> t4 = Task.Factory.StartNew(GibtDatumMitInput,15000);
            //Console.WriteLine("Das Datum ist:" + t4.Result); 
            #endregion

            #region Beenden von Tasks
            //CancellationTokenSource cts = new CancellationTokenSource();
            //Task t1 = Task.Factory.StartNew(MeineMethodeMitAbbrechen, cts);


            //Thread.Sleep(10000);
            //Console.WriteLine("Jetzt wird der Task geschlossen:");
            //cts.Cancel(); 
            #endregion

            // Exception im Task
            Task t1 = null, t2 = null, t3 = null;
            try
            {
                t1 = new Task(MachEinenFehler1);
                t1.Start();

                t2 = Task.Factory.StartNew(MachEinenFehler2);
                t3 = Task.Run(MachEinenFehler3);

                Console.WriteLine("Ich warte auf einen Fehler ..... ");

                // 1) Man bekommt Exceptions auf einem anderen Kern NICHT MIT !!!!
                // 2) AUSSER man wartet auf den Task bzw fragt das Resultat ab

                Task.WaitAll(t1, t2, t3);
            }
            catch (AggregateException ex) // <-- Spezial-Exception nur für Tasks
            {
                foreach (var einzelException in ex.InnerExceptions)
                {
                    Console.WriteLine(einzelException.Message);
                }
            }

            // genauer nachschauen:
            if (t3.IsCompleted)
                Console.WriteLine("Task 3 ist fertig");
            if (t3.IsFaulted)
            {
                Console.WriteLine("Task 3 hatte einen Fehler:");
                Console.WriteLine(t3.Exception.Message);
            }
            if (t3.IsCanceled)
            {
                Console.WriteLine("Task 3 wurde abgebrochen");
            }

            Console.WriteLine("---ANFANG---");
            Console.ReadKey();
        }
        private static void MachEinenFehler1()
        {
            Thread.Sleep(3000);
            throw new DivideByZeroException();
        }

        private static void MachEinenFehler2()
        {
            Thread.Sleep(5000);
            throw new StackOverflowException();
        }

        private static void MachEinenFehler3()
        {
            Thread.Sleep(8000);
            throw new OutOfMemoryException();
        }


        private static void MeineMethodeMitAbbrechen(object param)
        {
            CancellationTokenSource source = (CancellationTokenSource)param;

            while(true)
            {
                Console.Write("zZzZ...");
                Thread.Sleep(50);

                if (source.IsCancellationRequested)
                    break; // Schleife mit break beenden
            }
          
        }

        private static string GibDatum()
        {
            Thread.Sleep(8000);
            return DateTime.Now.ToLongDateString();
        }

        private static string GibtDatumMitInput(object input)
        {
            int dauer = (int)input;

            Thread.Sleep(dauer);
            return DateTime.Now.ToLongDateString();
        }

        private static void IchMacheEtwasImTask()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("#");
            }
        }
        private static void IchMacheEtwasImTask2()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("-");
            }
        }
        private static void IchMacheEtwasImTask3()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("/");
            }
        }
    }
}
