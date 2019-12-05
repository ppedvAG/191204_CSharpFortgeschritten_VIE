namespace SOLID_Taschenrechner
{
    class Division : IRechenart
    {
        public string[] Operatoren => new string[] { "/", ":", "Div" };

        public int Berechne(Formel input) => input.Operand1 / input.Operand2;
    }

}
