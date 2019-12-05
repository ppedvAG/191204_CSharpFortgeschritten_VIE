using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Bitte geben Sie Ihre Formel ein:"); 
            string eingabe = Console.ReadLine(); // "2 + 2"

            string[] parts = eingabe.Split(); // automatisch nach leerzeichen

            int z1 = Convert.ToInt32(parts[0]);
            string op = parts[1];
            int z2 = Convert.ToInt32(parts[2]);

            int erg = 0;
            if (op == "+")
                erg = z1 + z2;
            else if (op == "-")
                erg = z1 - z2; // "2+2"
            else if (op == "/" || op == ":")
                erg = z1 / z2;
            // ....

            Console.WriteLine($"Das Ergebnis ist {erg}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
