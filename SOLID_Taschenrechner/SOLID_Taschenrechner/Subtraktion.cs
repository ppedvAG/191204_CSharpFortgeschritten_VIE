namespace SOLID_Taschenrechner
{
    class Subtraktion : IRechenart
    {
        public string[] Operatoren => new string[] { "-","_", "Minus" };

        public int Berechne(Formel input) => input.Operand1 - input.Operand2;
    }

}
