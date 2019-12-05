using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    class Program
    {
        // Bootstrapping -> Initialisieren der Software + Module
        static void Main(string[] args)
        {
            IParser parser = new RegexParser();
            IRechner rechner = new ModularerRechner(new Addition(), new Subtraktion(), new Division(), new Modulo()); ;

            new KonsolenUI(parser,rechner).Start();
        }
    }


    struct Formel
    {
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public string Operator { get; set; }
    }


    interface IParser
    {
        Formel Parse(string input);
    }

    class StringSplitParser : IParser
    {
        public Formel Parse(string input)
        {
            Formel output = new Formel();
            string[] parts = input.Split(); // automatisch nach leerzeichen

            output.Operand1 = Convert.ToInt32(parts[0]);
            output.Operator = parts[1];
            output.Operand2 = Convert.ToInt32(parts[2]);

            return output;
        }
    }

    class RegexParser : IParser
    {
        public Formel Parse(string input)
        {
            // Regex:
            Regex r = new Regex(@"^\s*(\d+)\s*(\D+?)\s*(\d+)\s*$");
            Match result = r.Match(input);
            if (result.Success)
            {
                Formel output = new Formel();
                // Gruppen: 0 == Alles, 1 = erste Gruppe ....
                output.Operand1 = Convert.ToInt32(result.Groups[1].Value);
                output.Operator = result.Groups[2].Value;
                output.Operand2 = Convert.ToInt32(result.Groups[3].Value);

                return output;
            }
            else
                throw new FormatException($"Die Formel '{input}' hat ein ungültiges Format.");
        }
    }

    interface IRechner
    {
        int Berechne(Formel input);
    }

    class SimplerRechner : IRechner
    {
        public int Berechne(Formel input)
        {
            if (input.Operator == "+")
                return input.Operand1 + input.Operand2;
            else if (input.Operator == "-")
                return input.Operand1 - input.Operand2;
            else
                throw new InvalidOperationException($"Der Operator '{input.Operator}' wird nicht unterstützt");
        }
    }

    class ModularerRechner : IRechner
    {
        public ModularerRechner(params IRechenart[] unterstützteRechenarten)
        {
            this.unterstützteRechenarten = unterstützteRechenarten;
        }

        private IRechenart[] unterstützteRechenarten;

        public int Berechne(Formel formel)
        {
            // Sucher in der Liste die erste Rechenart, die den Operator kann
            // IRechenart ra = unterstützteRechenarten.FirstOrDefault(x => x.Operatoren.Contains(input.Operator));
            foreach (var rechenart in unterstützteRechenarten)
            {
                if (rechenart.Operatoren.Contains(formel.Operator))
                    //berechnung ausführen
                    return rechenart.Berechne(formel);
            }
            // wenn wir hier landen: Operator wird nicht unterstüzt
            throw new InvalidOperationException($"Der Operator '{formel.Operator}' wird nicht unterstützt");
        }
    }

    interface IRechenart
    {
        string[] Operatoren { get;}
        int Berechne(Formel input);
    }

    class Addition : IRechenart
    {
        public string[] Operatoren => new string[] { "+", "Plus" };

        public int Berechne(Formel input) => input.Operand1 + input.Operand2;
    }
    class Subtraktion : IRechenart
    {
        public string[] Operatoren => new string[] { "-","_", "Minus" };

        public int Berechne(Formel input) => input.Operand1 - input.Operand2;
    }
    class Division : IRechenart
    {
        public string[] Operatoren => new string[] { "/", ":", "Div" };

        public int Berechne(Formel input) => input.Operand1 / input.Operand2;
    }

    class Modulo : IRechenart
    {
        public string[] Operatoren => new string[] { "mod", "%" };

        public int Berechne(Formel input) => input.Operand1 % input.Operand2;
    }

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
