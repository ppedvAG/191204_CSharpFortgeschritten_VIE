namespace SOLID_Taschenrechner
{
    class Addition : IRechenart
    {
        public string[] Operatoren => new string[] { "+", "Plus" };

        public int Berechne(Formel input) => input.Operand1 + input.Operand2;
    }

}
