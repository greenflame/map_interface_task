using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap
{
    public class LinkedMap<K, V> : IMap<K, V>
    {
        private List<Entry<K, V>> list_;

        public LinkedMap()
        {
            list_ = new List<Entry<K,V>>();
        }

        private int indexOf(K key)
        {
            for (int i = 0; i < list_.Count; i++)
            {
                if (list_[i].Key.Equals(key))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Put(K key, V value)
        {
            if (ContainsKey(key))
                throw new MapException("Key already exists.");

            list_.Add(new Entry<K, V>(key, value));
        }

        public void Clear()
        {
            list_.Clear(); ;
        }

        public bool ContainsKey(K key)
        {
            for (int i = 0; i < list_.Count; i++)
            {
                if (list_[i].Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsValue(V value)
        {
            for (int i = 0; i < list_.Count; i++)
            {
                if (list_[i].Value.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public void Remove(K key)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return list_.Count; }
        }

        public bool isEmpty
        {
            get { return list_.Count == 0; }
        }

        public V this[K key]
        {
            get
            {
                int index = indexOf(key);

                if (index == -1)
                    throw new MapException("Key doesn't exists.");

                return list_[index].Value;
            }
            set
            {
                int index = indexOf(key);

                if (index == -1)
                    throw new MapException("Key doesn't exists.");

                list_[index].Value = value;
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                List<K> tmp = new List<K>();
                foreach (Entry<K, V> e in list_)
                    tmp.Add(e.Key);
                
                return tmp;
            }
        }

        public IEnumerable<V> Values
        {
            get
            {
                List<V> tmp = new List<V>();
                foreach (Entry<K, V> e in list_)
                    tmp.Add(e.Value);
                
                return tmp;
            }
        }

        public IEnumerator<IEntry<K, V>> GetEnumerator()
        {
            return list_.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
