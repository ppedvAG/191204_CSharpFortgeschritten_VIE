using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System;

namespace SOLID_Taschenrechner
{
    class Program
    {
        // Bootstrapping -> Initialisieren der Software + Module
        static void Main(string[] args)
        {
            IParser parser;
            IRechner rechner;
            string user;

            do
            {
                Console.WriteLine("Bitte geben Sie Ihren Usernamen ein (Beenden mit 'q'):");
                user = Console.ReadLine();

                if (user == "Michi")
                {
                    parser = new StringSplitParser();
                    rechner = new SimplerRechner();

                    do
                    {
                        new KonsolenUI(parser, rechner).Start();
                        Console.WriteLine("Neustart (n), Beenden (q), Logout (l)");
                        string eingabe = Console.ReadLine();
                        if (eingabe == "q")
                            return; // Programm beenden;
                        else if (eingabe == "l")
                            break;
                    } while (true); // Solange eingeloggt
                }
                else if (user == "Marco")
                {
                    parser = new RegexParser();
                    rechner = new ModularerRechner(new Addition(), new Subtraktion());

                    do
                    {
                        new KonsolenUI(parser, rechner).Start();
                        Console.WriteLine("Neustart (n), Beenden (q), Logout (l)");
                        string eingabe = Console.ReadLine();
                        if (eingabe == "q")
                            return; // Programm beenden;
                        else if (eingabe == "l")
                            break;
                    } while (true); // Solange eingeloggt
                }
                else if (user == "Anna")
                {
                    parser = new RegexParser();
                    rechner = new ModularerRechner(new Addition(), new Subtraktion(), new Division(), new Modulo());

                    do
                    {
                        new KonsolenUI(parser, rechner).Start();
                        Console.WriteLine("Neustart (n), Beenden (q), Logout (l)");
                        string eingabe = Console.ReadLine();
                        if (eingabe == "q")
                            return; // Programm beenden;
                        else if (eingabe == "l")
                            break;
                    } while (true); // Solange eingeloggt
                }
                else
                {
                    Console.WriteLine("Ungültiger Username");
                }
            } while (user != "q");

            //IParser parser = new RegexParser();
            //IRechner rechner = new ModularerRechner(new Addition(), new Subtraktion(), new Division(), new Modulo());

            //new KonsolenUI(parser,rechner).Start();
        }
    }
}
