using System;

namespace SOLID_Taschenrechner
{
    class KonsolenUI
    {
        public KonsolenUI(IParser parser, IRechner rechner)
        {
            this.parser = parser;
            this.rechner = rechner;
        }

        private IParser parser;
        private IRechner rechner;

        public void Start()
        {
            // I/O
            Console.WriteLine("Bitte geben Sie Ihre Formel ein:");
            string eingabe = Console.ReadLine(); // "2 + 2"

            // Parsen+
            Formel f;
            try
            {
                f = parser.Parse(eingabe);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return; //Methode beenden
            }

            // Berechnung + Entscheidung welche Berechnung genommen wird
            int erg = 0;
            try
            {
                erg = rechner.Berechne(f);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return; //Methode beenden
            }

            //  I/O
            Console.WriteLine($"Das Ergebnis ist {erg}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

}
