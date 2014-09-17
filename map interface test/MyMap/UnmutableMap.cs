using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap
{
    public class UnmutableMap<K, V> : IMap<K, V>
    {

        private readonly IMap<K, V> _map;

        public UnmutableMap(IMap<K, V> map)
        {
            _map = map;
        }


        public void Put(K key, V value)
        {
            throw new MapException();
        }

        public void Clear()
        {
            throw new MapException();
        }

        public bool ContainsKey(K key)
        {
            return _map.ContainsKey(key);
        }

        public bool ContainsValue(V value)
        {
            return _map.ContainsValue(value);
        }

        public void Remove(K key)
        {
            throw new MapException();
        }

        public int Count
        {
            get { return _map.Count; }
        }

        public bool isEmpty
        {
            get { return _map.isEmpty; }
        }

        public V this[K key]
        {
            get
            {
                return _map[key];
            }
            set
            {
                throw new MapException();
            }
        }

        public IEnumerable<K> Keys
        {
            get { return _map.Keys; }
        }

        public IEnumerable<V> Values
        {
            get { return _map.Values; }
        }

        public IEnumerator<IEntry<K, V>> GetEnumerator()
        {
            return _map.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _map.GetEnumerator();
        }
    }
}
