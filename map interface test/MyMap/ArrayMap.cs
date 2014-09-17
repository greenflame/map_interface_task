using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap
{
    public class ArrayMap<K, V> : IMap<K, V>
    {
        private Entry<K, V>[] _array;

        public ArrayMap()
        {
            _array = new Entry<K, V>[0];
        }

        private int indexOf(K key)
        {
            for (int i = 0; i < _array.Length; i++)
                if (_array[i].Key.Equals(key))
                    return i;
            return -1;
        }

        public void Put(K key, V value)
        {
            if (indexOf(key) == -1) //key doesn't exist
            {
                Array.Resize(ref _array, _array.Length + 1);
                _array[_array.Length - 1] = new Entry<K, V>() { Key = key, Value = value };
            }
            else
            {
                throw new MapException("Cann't put new key. Key already exists.");
            }
        }

        public void Clear()
        {
            Array.Resize<Entry<K, V>>(ref _array, 0);
        }

        public bool ContainsKey(K key)
        {
            if (indexOf(key) != -1)
                return true;
            return false;
        }

        public bool ContainsValue(V value)
        {
            for (int i = 0; i < _array.Length; i++)
                if (_array[i].Value.Equals(value))
                    return true;
            return false;
        }

        public void Remove(K key)
        {
            int index = indexOf(key);
            
            if (index == -1)
                throw new MapException("Cann't remove key. Key does't exist.");
            
            for (int i = index; i < _array.Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            Array.Resize<Entry<K, V>>(ref _array, _array.Length - 1);
        }

        public int Count
        {
            get
            {
                return _array.Length;
            }
        }

        public bool isEmpty
        {
            get
            {
                return _array.Length == 0;
            }
        }

        public V this[K key]
        {
            get
            {
                int index = indexOf(key);

                if (index == -1)
                    throw new MapException("Key doesn't exist.");

                return _array[index].Value;
            }
            set
            {
                int index = indexOf(key);

                if (index == -1)
                    throw new MapException("Key doesn't exist.");

                _array[index].Value = value;
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                K[] keys = new K[_array.Length];

                for (int i = 0; i < _array.Length; i++)
                    keys[i] = _array[i].Key;
                
                return keys;
            }
        }

        public IEnumerable<V> Values
        {
            get
            {
                V[] values = new V[_array.Length];

                for (int i = 0; i < _array.Length; i++)
                    values[i] = _array[i].Value;

                return values;
            }
        }

        public IEnumerator<IEntry<K, V>> GetEnumerator()
        {
            foreach(Entry<K, V> item in _array)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
