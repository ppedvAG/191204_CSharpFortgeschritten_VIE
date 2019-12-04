using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class MyDictionary<TKey,TValue> 
        where TKey : struct 
        where TValue: class
    {
        public MyDictionary()
        {
            keys = new TKey[4];
            values = new TValue[4];
            position = 0;
        }

        // Zuordnung per "position"
        private TKey[] keys;
        private TValue[] values;
        private int position;

        public void Add(TKey key, TValue value)
        {
            if (keys.Contains(key))
                throw new InvalidOperationException("Key bereits vorhanden !");

            keys[position] = key;
            values[position] = value;

            position++;
        }

        public TValue this[TKey key]
        {
            get 
            {
                if (! keys.Contains(key))
                    throw new InvalidOperationException("Key nicht vorhanden !");

                int positionOfKey = Array.IndexOf(keys, key);
                return values[positionOfKey];
            }
            set { /* set the specified index to value here */ }
        }
    }
}
