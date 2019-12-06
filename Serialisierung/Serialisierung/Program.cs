using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialisierung
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person
            {
                Vorname = "Max",
                Nachname = "Mustermann",
                Alter = 10,
                Kontostand = 10000000000090
            };


            // Serialisierer: Binär, XML, JSON

            // 1) Binär: (benötigt das [Serializable] - Attribut in der Klasse

            //BinaryFormatter formatter = new BinaryFormatter();
            //Stream stream = File.OpenWrite("Person.bin");
            //formatter.Serialize(stream, p1);
            //stream.Close();

            //stream = File.OpenRead("Person.bin");
            //Person geladenePerson = (Person)formatter.Deserialize(stream);
            //stream.Close();

            //Console.WriteLine(geladenePerson.Vorname);
            //Console.WriteLine(geladenePerson.Nachname);
            //Console.WriteLine(geladenePerson.Alter);
            //Console.WriteLine(geladenePerson.Kontostand);

            // 2) XML
            //XmlSerializer formatter = new XmlSerializer(typeof(Person));
            //Stream stream = File.OpenWrite("Person.xml");
            //formatter.Serialize(stream, p1);
            //stream.Close();

            //stream = File.OpenRead("Person.xml");
            //Person geladenePerson = (Person)formatter.Deserialize(stream);
            //stream.Close();

            // 3) JSON
            // NuGet Newtonsoft.JSON

            //string json = JsonConvert.SerializeObject(p1);
            //File.WriteAllText("Person.json", json);

            //Console.WriteLine(json);
            //Person personAusJSON = JsonConvert.DeserializeObject<Person>(json);

            //Console.WriteLine(personAusJSON.Vorname);


            // 4) CSV (Marke eigenbau ;) )

            CSVSerializer serializer = new CSVSerializer();

            // serializer.SerializePerson(p1, "person.csv");

            Person personAusCSV = serializer.DeserializePerson("person.csv");

            Console.WriteLine(personAusCSV.Vorname);
            Console.WriteLine(personAusCSV.Nachname);
            Console.WriteLine(personAusCSV.Alter);
            Console.WriteLine(personAusCSV.Kontostand);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
