using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialisierung
{
   //  [Serializable] // Für den BinaryFormatter
    public class Person // Für XML muss die Klasse "public" sein
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
    }
}
