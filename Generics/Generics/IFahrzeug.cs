using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    interface IFahrzeug
    {
        int Geschwindigkeit { get; set; }
        int AnzahlPassagiere { get; set; }
    }

    interface IKraftfahrzeug : IFahrzeug
    {
        int Kilometerstand { get; set; }
        void Fahren(int stunden);
    }

    interface ISchiff : IFahrzeug
    {
        int Betriebsstunden { get; set; }
        int Tiefe { get; set; }

        void Fahren(int stunden);
    }

    class Amphibienfahrzeug : IKraftfahrzeug, ISchiff
    {
        public int Kilometerstand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Geschwindigkeit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int AnzahlPassagiere { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Betriebsstunden { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Tiefe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        void IKraftfahrzeug.Fahren(int stunden)
        {
            throw new NotImplementedException();
        }

        void ISchiff.Fahren(int stunden)
        {
            throw new NotImplementedException();
        }

        //public void Fahren(int stunden)
        //{
        //    // Kein Problem:

        //    Amphibienfahrzeug fz = new Amphibienfahrzeug();
        //    fz.Fahren(1234); // nimmt das definierte Fahren -> Kein Problem

        //    // Problem:
        //    ISchiff fz2 = new Amphibienfahrzeug();
        //    fz2.Fahren(5); // Schiff-Version vom Fahren 

        //    IKraftfahrzeug fz3 = new Amphibienfahrzeug();
        //    fz3.Fahren(2); // Kraftfahrzeug-Version vom Fahren

        //}
    }

}
