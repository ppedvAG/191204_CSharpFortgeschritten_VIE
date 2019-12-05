using System;
using System.Text.RegularExpressions;

namespace SOLID_Taschenrechner
{
    class RegexParser : IParser
    {
        public Formel Parse(string input)
        {
            // Regex:
            Regex r = new Regex(@"^\s*(\d+)\s*(\D+?)\s*(\d+)\s*$");
            Match result = r.Match(input);
            if (result.Success)
            {
                Formel output = new Formel();
                // Gruppen: 0 == Alles, 1 = erste Gruppe ....
                output.Operand1 = Convert.ToInt32(result.Groups[1].Value);
                output.Operator = result.Groups[2].Value;
                output.Operand2 = Convert.ToInt32(result.Groups[3].Value);

                return output;
            }
            else
                throw new FormatException($"Die Formel '{input}' hat ein ungültiges Format.");
        }
    }

}
