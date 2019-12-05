namespace SOLID_Taschenrechner
{
    class Modulo : IRechenart
    {
        public string[] Operatoren => new string[] { "mod", "%" };

        public int Berechne(Formel input) => input.Operand1 % input.Operand2;
    }

}
