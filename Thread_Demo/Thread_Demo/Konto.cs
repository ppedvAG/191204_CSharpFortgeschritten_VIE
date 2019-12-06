using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread_Demo
{
    class Konto
    {
        public decimal Kontostand { get; set; }

        private object lockObject = new object(); // irgendeine Instanz, NICHT VERÄNDERN !!!!

        public void Einzahlen(decimal betrag)
        {
            lock (lockObject)
            {
                Console.WriteLine($"Kontostand vor dem Einzahlen: {Kontostand}");
                Kontostand += betrag;
                Console.WriteLine($"Kontostand nach dem Einzahlen: {Kontostand}");
            }

        }
        public void Abheben(decimal betrag)
        {
            lock (lockObject)
            {
                Console.WriteLine($"Kontostand vor dem Abheben: {Kontostand}");
                Kontostand -= betrag;
                Console.WriteLine($"Kontostand nach dem Abheben: {Kontostand}");
            }
        }
    }
}
