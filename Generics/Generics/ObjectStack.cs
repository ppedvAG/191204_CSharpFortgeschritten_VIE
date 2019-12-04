using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class ObjectStack 
    {
        public ObjectStack() : this(4){}
        public ObjectStack(int capacity)
        {
            position = 0;
            data = new object[capacity];
        }

        private object[] data;
        private int position;

        public void Push(object item)
        {
            if(data.Length == position)
            {
                // Stack vergrößern:
                object[] newData = new object[data.Length * 2];
                Array.Copy(data, 0, newData, 0, data.Length);
                data = newData;
            }

            data[position] = item;
            position++;
        }

        public object Pop()
        {
            if (position == 0)
                throw new InvalidOperationException("Der Stack ist leer");
            position--;
            return data[position];
        }

    }
}
