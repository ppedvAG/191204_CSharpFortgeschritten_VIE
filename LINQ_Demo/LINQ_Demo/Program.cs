using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personen = new List<Person>
            {
                new Person{Vorname="Tom",Nachname="Ate",Alter=10,Kontostand=100},
                new Person{Vorname="Anna",Nachname="Nass",Alter=20,Kontostand=200},
                new Person{Vorname="Peter",Nachname="Silie",Alter=30,Kontostand=300000},
                new Person{Vorname="Franz",Nachname="Ose",Alter=40,Kontostand=-44444},
                new Person{Vorname="Klara",Nachname="Fall",Alter=50,Kontostand=5555},
                new Person{Vorname="Martha",Nachname="Pfahl",Alter=60,Kontostand=123456},
                new Person{Vorname="Rainer",Nachname="Zufall",Alter=70,Kontostand=-98765},
                new Person{Vorname="Albert",Nachname="Tross",Alter=80,Kontostand=-87654346889865},
                new Person{Vorname="Axel",Nachname="Schweiß",Alter=90,Kontostand=9999877655},
                new Person{Vorname="Anna",Nachname="Bolika",Alter=100,Kontostand=10000000000000000},
            };


            #region Variante ohne LINQ
            // Gib mit alle Vornamen von allen Personen in ein Array zurück

            //string[] alleVornamen = new string[personen.Count];
            //for (int i = 0; i < alleVornamen.Length; i++)
            //{
            //    alleVornamen[i] = personen[i].Vorname;
            //}

            // Gibt mir alle Vornamen von Personen, die Schulden haben

            //List<string> alleVornamenMitSchulden = new List<string>();
            //for (int i = 0; i < alleVornamen.Length; i++)
            //{
            //    if (personen[i].Kontostand < 0)
            //        alleVornamenMitSchulden.Add(personen[i].Vorname);
            //}

            // Gibt mir alle Personen über 60 mit Kontostand > 10.000 sortiert nach Alter absteigend

            #endregion

            // Variante mit LINQ:

            // SELECT -> Elemente herausnehmen

            // string[] alleVornamen = personen.Select(SelektorFunktion).ToArray();
            string[] alleVornamen = personen.Select(person => person.Vorname).ToArray();

            string[] alleVornamen2 = (from item in personen
                                      where item.Alter > 100
                                      select item.Vorname).ToArray();

            // WHERE -> Filtern

            string[] alleNamenMitSchulden = personen.Where(x => x.Kontostand < 0)
                                                    .Select(x => x.Vorname)
                                                    .ToArray();

            // ORDERBY / ORDERBYDESCENDING

            List<Person> allePersonenInRenteMitVielCash =
                                personen.Where(x => x.Alter >= 60 && x.Kontostand > 10000)
                                        .OrderByDescending(x => x.Kontostand)
                                        .ToList();
            // First / Last / Single

            Person reichstePerson = personen.OrderByDescending(x => x.Kontostand)
                                            .First();

            // Tatsächlicher Kontostand
            // Min / Max / Avarage / Sum ...

            decimal höchsteKontostand = personen.Max(x => x.Kontostand);
            decimal durchschnitt = personen.Average(x => x.Kontostand);

            // Obersten 1% 

            List<Person> reichsten3Personen = personen.OrderByDescending(x => x.Kontostand)
                                                      .Take(3)
                                                      .ToList();

            List<Person> AlleAusserDieReichsten3Personen = personen.OrderByDescending(x => x.Kontostand)
                                                                   .Skip(3) // lasse 3 aus, nimm den rest
                                                                   .ToList();

            // Für If prakisch:
            // Any / All

            if (personen.Any(x => x.Vorname == "Tom"))
                ; // Wenn irgendeiner Tom heißt, dann ....
            else if (personen.All(x => x.Kontostand > 0))
                ; // Wenn alle Positiv sind, dann ......

            
            
            // Übung:

            // LINQ - Queries erstellen für:

            // Durchschnittskontostand von allen Personen über 60
            // Die Person mit den meisten Schulden
            // Durchschnittsalter aller Personen mit Schulden



            Console.WriteLine("----ENDE----");
            Console.ReadKey();
        }
        private static bool FilterFunktion2(Person item) => item.Kontostand < 0;

        private static bool FilterFunktion(Person item)
        {
            return item.Kontostand < 0;
        }

        private static string SelectorFunktion2   (Person x) => x.Vorname;



        private static int Add(int z1, int z2)
        {
            return z1 + z2;
        }
        // Lambda-Ausdruck
        private static int Add2(int z1, int z2) => z1 + z2;

        private static string SelektorFunktion(Person item)
        {
            return item.Vorname;
        }

    }
}
