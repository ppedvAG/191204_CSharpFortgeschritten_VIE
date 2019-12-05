using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    class Program
    {
        // Bootstrapping -> Initialisieren der Software + Module
        static void Main(string[] args)
        {
            IParser parser = new RegexParser();
            IRechner rechner = new ModularerRechner(new Addition(), new Subtraktion(), new Division(), new Modulo());

            new KonsolenUI(parser,rechner).Start();
        }
    }
}
