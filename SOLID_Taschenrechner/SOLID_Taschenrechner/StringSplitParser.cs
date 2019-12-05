using System;

namespace SOLID_Taschenrechner
{
    class StringSplitParser : IParser
    {
        public Formel Parse(string input)
        {
            Formel output = new Formel();
            string[] parts = input.Split(); // automatisch nach leerzeichen

            output.Operand1 = Convert.ToInt32(parts[0]);
            output.Operator = parts[1];
            output.Operand2 = Convert.ToInt32(parts[2]);

            return output;
        }
    }

}
