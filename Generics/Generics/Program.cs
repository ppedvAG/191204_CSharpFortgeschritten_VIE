using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Stack - Erklärung
            //Stack<int> zahlenStack = new Stack<int>();

            //zahlenStack.Push(12);
            //zahlenStack.Push(9);
            //zahlenStack.Push(3);


            //Console.WriteLine(zahlenStack.Pop());
            //Console.WriteLine(zahlenStack.Pop());
            //Console.WriteLine(zahlenStack.Pop());
            #endregion

            #region ObjectStack und IntegerStack
            //ObjectStack os = new ObjectStack();
            //os.Push(12);
            //os.Push(3);
            //os.Push("Hallo Welt");
            //os.Push(new ObjectStack());

            //os.Push(999);


            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());

            ////Console.WriteLine(os.Pop()); // Exception


            //IntegerStack istack = new IntegerStack();

            //istack.Push(123);
            //istack.Push(123);
            //istack.Push(123); 
            #endregion

            #region GenericStack
            //GenericStack<int> intStack = new GenericStack<int>();
            //GenericStack<string> stringStack = new GenericStack<string>();

            //intStack.Push(123);
            //stringStack.Push("Hallo Welt");

            //intStack.Push(456);

            //stringStack.Push("Demo 12345 Ich bin Michi");

            //Console.WriteLine(intStack.Pop());
            //Console.WriteLine(intStack.Pop());

            //Console.WriteLine(stringStack.Pop());
            //Console.WriteLine(stringStack.Pop()); 
            #endregion

            //MachEtwas(12);
            //MachEtwas("Hallo Welt");
            //MachEtwas(new GenericStack<double>());

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        public static void MachEtwas<T>(T item)  where T : GenericStack<double>
        {
            if(item is string)
                Console.WriteLine("Ich mache etwas mit einem String: " + item);
            else if (item is int)
                Console.WriteLine("Ich mache etwas mit einem Int32: " + item);
            else
                Console.WriteLine("Ich mache etwas mit:" + item);
        }
    }
}
