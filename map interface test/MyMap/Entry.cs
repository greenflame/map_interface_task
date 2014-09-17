using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap
{
    public class Entry<K, V> : IEntry<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public override string ToString()
        {
            return Key.ToString() + ' ' + Value.ToString();
        }
    }
}
