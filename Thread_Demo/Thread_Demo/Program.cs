using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Thread starten
            //Thread t1 = new Thread(MachEtwasInEinemThread);
            //Thread t2 = new Thread(MachEtwasInEinemThread2);

            //t1.Start();
            //t2.Start();  
            #endregion

            #region Threads beenden
            //Thread t1 = new Thread(MachEtwasSehrLange);
            //t1.Start();

            //Console.WriteLine("Ich warte mal 5 sec:");
            //Thread.Sleep(5000);

            ////Console.WriteLine("Thread wird jetzt beendet");
            ////t1.Abort(); // Bricht den Thread ab 
            #endregion

            #region Auf Threads warten
            //Console.WriteLine("Ich warte bis der Thread komplett fertig ist");
            //t1.Join(); // Wartet bis der Thread fertig ist
            //Console.WriteLine("Thread ist fertig :) "); 
            #endregion

            // Surround With ( STRG + K  STRG + S)

            ThreadPool.QueueUserWorkItem(MachWasImPool1);
            ThreadPool.QueueUserWorkItem(MachWasImPool2);
            ThreadPool.QueueUserWorkItem(MachWasImPool3);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void MachWasImPool3(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.Write("#");
            }
        }

        private static void MachWasImPool2(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.Write("-");
            }
        }

        private static void MachWasImPool1(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.Write("*");
            }
        }

        private static void MachEtwasSehrLange()
        {
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    Thread.Sleep(250);
                    Console.WriteLine("zZzZ...");
                }
                catch (ThreadAbortException)
                {
                    // Trick ;)
                    Thread.ResetAbort(); // Abort verhindern

                    Console.WriteLine("Es wurde Abort() ausgelöst: Thread wird ordentlich beendet");
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write("X");
                    }
                    //return; 
                }
 
            }
        }

        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(250); // 1/4 von einer Sekunde (250ms)
                Console.Write("*");
            }
        }
        private static void MachEtwasInEinemThread2()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(500);
                Console.Write("#");
            }
        }
    }
}
