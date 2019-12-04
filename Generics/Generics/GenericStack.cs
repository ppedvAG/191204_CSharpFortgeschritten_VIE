using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class GenericStack<T>
    {
        public GenericStack() : this(4) { }
        public GenericStack(int capacity)
        {
            position = 0;
            data = new T[capacity];
        }

        private T[] data;
        private int position;

        public void Push(T item)
        {
            if (data.Length == position)
            {
                // Stack vergrößern:
                T[] newData = new T[data.Length * 2];
                Array.Copy(data, 0, newData, 0, data.Length);
                data = newData;
            }

            data[position] = item;
            position++;
        }

        public T Pop()
        {
            if (position == 0)
                throw new InvalidOperationException("Der Stack ist leer");
            position--;
            return data[position];
        }

    }
}
