using System;
using System.Linq;

namespace SOLID_Taschenrechner
{
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

}
