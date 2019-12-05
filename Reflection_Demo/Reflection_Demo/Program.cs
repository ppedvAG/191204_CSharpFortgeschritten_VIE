using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Typeninformation zur Laufzeit holen:
            object o1 = 42;
            Type objectType = o1.GetType();
            Console.WriteLine(objectType);

            // DLL zur Laufzeit laden
            Assembly tr_dll = Assembly.LoadFrom("Taschenrechner.dll");

            // Rechner verwenden:

            Type tr_Type = tr_dll.GetType("Taschenrechner.Rechner");
            Console.WriteLine(tr_Type);

            // Rechner zur Laufzeit erstellen
            object taschenrechner = Activator.CreateInstance(tr_Type);

            // Methode zur Laufzeit ausführen:
            MethodInfo method = tr_Type.GetMethod("Add", new Type[] { typeof(int), typeof(int) });

            var erg = method.Invoke(taschenrechner, new object[] { 12, 3 });
            Console.WriteLine(erg);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
