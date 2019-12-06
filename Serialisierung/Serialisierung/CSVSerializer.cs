using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialisierung
{
    class CSVSerializer
    {

        public void SerializePerson(Person p, string path)
        {
            File.WriteAllText(path,$"{p.Vorname};{p.Nachname};{p.Alter};{p.Kontostand}");
        }

        public Person DeserializePerson(string path)
        {
            string content = File.ReadAllText(path);
            Person newPerson = new Person();

            string[] csvParts = content.Split(';');
            newPerson.Vorname = csvParts[0];
            newPerson.Nachname = csvParts[1];
            newPerson.Alter = Convert.ToByte(csvParts[2]);
            newPerson.Kontostand = Convert.ToDecimal(csvParts[3]);

            return newPerson;
        }

    }
}
