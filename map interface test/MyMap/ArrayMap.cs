using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap
{
    public class ArrayMap<K, V> : IMap<K, V>
    {
        private IEntry<K, V>[] array_;

        public ArrayMap()
        {
            array_ = new Entry<K, V>[0];
        }

        private int indexOf(K key)
        {
            for (int i = 0; i < array_.Length; i++)
                if (array_[i].Key.Equals(key))
                    return i;
            return -1;
        }

        public void Put(K key, V value)
        {
            if (indexOf(key) == -1) //key doesn't exist
            {
                Array.Resize(ref array_, array_.Length + 1);
                array_[array_.Length - 1] = new Entry<K, V>() { Key = key, Value = value };
            }
            else
            {
                throw new MapException("Cann't put new key. Key already exists.");
            }
        }

        public void Clear()
        {
            Array.Resize(ref array_, 0);
        }

        public bool ContainsKey(K key)
        {
            if (indexOf(key) != -1)
                return true;
            return false;
        }

        public bool ContainsValue(V value)
        {
            for (int i = 0; i < array_.Length; i++)
                if (array_[i].Value.Equals(value))
                    return true;
            return false;
        }

        public void Remove(K key)
        {
            int index = indexOf(key);
            
            if (index == -1)
                throw new MapException("Cann't remove key. Key does't exist.");
            
            for (int i = index; i < array_.Length - 1; i++)
            {
                array_[i] = array_[i + 1];
            }

            Array.Resize(ref array_, array_.Length - 1);
        }

        public int Count
        {
            get
            {
                return array_.Length;
            }
        }

        public bool isEmpty
        {
            get
            {
                return array_.Length == 0;
            }
        }

        public V this[K key]
        {
            get
            {
                int index = indexOf(key);

                if (index == -1)
                    throw new MapException("Key doesn't exist.");

                return array_[index].Value;
            }
            set
            {
                int index = indexOf(key);

                if (index == -1)
                    throw new MapException("Key doesn't exist.");

                array_[index].Value = value;
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                K[] keys = new K[array_.Length];

                for (int i = 0; i < array_.Length; i++)
                    keys[i] = array_[i].Key;
                
                return keys;
            }
        }

        public IEnumerable<V> Values
        {
            get
            {
                V[] values = new V[array_.Length];

                for (int i = 0; i < array_.Length; i++)
                    values[i] = array_[i].Value;

                return values;
            }
        }

        public IEnumerator<IEntry<K, V>> GetEnumerator()
        {
            return ((IEnumerable<IEntry<K, V>>)array_).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
