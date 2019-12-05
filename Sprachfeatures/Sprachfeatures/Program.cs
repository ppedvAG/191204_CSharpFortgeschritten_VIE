using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprachfeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Strings
            //// cw + TAB + TAB für Console.WriteLine()

            //int zahl1 = 5;
            //int zahl2 = 10;
            //int erg = zahl1 + zahl2;


            //Console.WriteLine("Die Summe von " + zahl1 + " und " + zahl2 + " ist " + erg);

            //// String.Format (in Console.WriteLine eingebaut)
            //Console.WriteLine("Die Summe von {0:F1} und {1:F1} ist {2:F1}", zahl1,zahl2,erg);

            //// C# 6 : String Interpolation
            //Console.WriteLine($"Die Summe von {zahl1:F1} und {zahl2:F1} ist {zahl1 + zahl2:F1}"); 
            #endregion

            #region Is - Operator
            //object demo = new object();

            //if(demo is String str)
            //{
            //    //string echtesDing = (string)demo; // casten
            //    Console.WriteLine(str);
            //}
            //else if(demo is int zahl)
            //{
            //    Console.WriteLine(zahl * 2);
            //} 
            #endregion

            int? zahl = 5;
            zahl = null; // Nullable Valuetypes

            int zahl2 = 10;

            zahl = zahl2; // ok

            // zahl2 = zahl; // es könnte ja null sein
            // Lösung:
            zahl2 = zahl ?? 0 ; // nimm zahl, aber wenn Zahl "null" ist, nimm 0

            double? doubleMitNull = 12345.4444;

            // Alternative für "If-Else"
            string text = (zahl > 50) ? "zahl ist größer" : "zahl ist kleiner";

            for (int i = 0; i < 10000000; i++)
            {

            }
            for (int i = 0; i < 10000000; i++)
            {

            }

            int demoZahl = default;

            Console.WriteLine(demoZahl);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

    }
}
