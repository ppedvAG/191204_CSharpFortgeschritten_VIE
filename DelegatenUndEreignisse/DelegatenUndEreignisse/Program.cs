using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Program
    {
        // Uralt:
        // Delegate-Type:

            // delegate RÜCKGABE BeliebigerName(MeineParameter)
        public delegate void MeinDelegate(); // Signatur: void, ohne Parameter 
        public delegate void MeinDelegate2(int zahl);// Signator: void, int-Paramter

        static void Main(string[] args)
        {
            #region Delegaten vor .NET 2.0
            //MeinDelegate del = new MeinDelegate(A);
            //del += B;
            //del();

            //MeinDelegate2 del2 = new MeinDelegate2(C);
            //del2 += A;
            //del2(123); 
            #endregion

            #region Action<T> und Func<T>
            //// Action<T> : für alles, was void ist
            //Action a1 = new Action(A);
            //a1 += B;

            //a1();

            //// Action<int> a2 = new Action<int>(C);
            //Action<int> a2 = C;

            //a2(123);

            //// Func<T> : für alles mit einer Rückgabe

            ////Func<int, int, int> rechner = new Func<int, int, int>(Add);
            //Func<int, int, int> rechner = Add;

            //int result = rechner(12, 3);
            #endregion

            Button b1 = new Button();

            b1.KlickEvent += MeineKlickLogik;
            b1.KlickEvent += Logger;

            b1.Klick();
            //b1.KlickEvent = null;       // absolut verboten
            b1.Klick();
            b1.Klick();
            b1.KlickEvent -= Logger;

            b1.Klick();
            b1.Klick();

            // b1.KlickEvent();        // verboten !

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void Logger()
        {
            Console.WriteLine($"[{DateTime.Now}]: Button wurde geklickt");
        }

        private static void MeineKlickLogik()
        {
            Console.Beep();
            Console.WriteLine("*click*");
        }

        static void A()
        {
            Console.WriteLine("A");
        }

        static void B()
        {
            Console.WriteLine("B");
        }

        static void C(int zahl)
        {
            Console.WriteLine("C"+zahl);
        }

        static int Add(int z1, int z2)
        {
            return z1 + z2;
        }

    }
}
