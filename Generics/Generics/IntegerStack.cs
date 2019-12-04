using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class IntegerStack
    {
        public IntegerStack() : this(4) { }
        public IntegerStack(int capacity)
        {
            position = 0;
            data = new int[capacity];
        }

        private int[] data;
        private int position;

        public void Push(int item)
        {
            if (data.Length == position)
            {
                // Stack vergrößern:
                int[] newData = new int[data.Length * 2];
                Array.Copy(data, 0, newData, 0, data.Length);
                data = newData;
            }

            data[position] = item;
            position++;
        }

        public int Pop()
        {
            if (position == 0)
                throw new InvalidOperationException("Der Stack ist leer");
            position--;
            return data[position];
        }

    }
}
