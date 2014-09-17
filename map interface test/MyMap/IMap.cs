using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap
{
    public interface IMap<K, V> : IEnumerable<IEntry<K, V>>
    {
        void Put(K key, V value);
        void Clear();
        bool ContainsKey(K key);
        bool ContainsValue(V value);
        void Remove(K key);

        int Count { get; }
        bool isEmpty { get; }
        V this[K key] { get; set; }
        IEnumerable<K> Keys { get; }
        IEnumerable<V> Values { get; }
    }
}
