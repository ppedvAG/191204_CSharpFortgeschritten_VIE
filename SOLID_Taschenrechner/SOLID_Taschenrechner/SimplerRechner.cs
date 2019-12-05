using System;

namespace SOLID_Taschenrechner
{
    class SimplerRechner : IRechner
    {
        public int Berechne(Formel input)
        {
            if (input.Operator == "+")
                return input.Operand1 + input.Operand2;
            else if (input.Operator == "-")
                return input.Operand1 - input.Operand2;
            else
                throw new InvalidOperationException($"Der Operator '{input.Operator}' wird nicht unterstützt");
        }
    }

}
