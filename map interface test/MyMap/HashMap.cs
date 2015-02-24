using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap
{
    public class HashMap<K, V> : IMap<K, V>
    {
        private List<IEntry<K, V>>[] data_;
        private const int hashElementsCount_ = 100;

        public HashMap()
        {
            data_ = new List<IEntry<K, V>>[hashElementsCount_];

            for (int i = 0; i < data_.Length; i++)
            {
                data_[i] = new List<IEntry<K,V>>();
            }
        }

        public void Put(K key, V value)
        {
            if (ContainsKey(key))
            {
                throw new MapException("Key already exists.");
            }

            int hash = Math.Abs(key.GetHashCode() % data_.Length);
            data_[hash].Add(new Entry<K, V>(key, value));
        }

        public void Clear()
        {
            for (int i = 0; i < data_.Length; i++)
            {
                data_[i].Clear();
            }
        }

        public bool ContainsKey(K key)
        {
            int hash = Math.Abs(key.GetHashCode() % data_.Length);

            foreach (IEntry<K, V> e in data_[hash])
            {
                if (e.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsValue(V value)
        {
            foreach (List<IEntry<K, V>> leaf in data_)
            {
                foreach (IEntry<K, V> e in leaf)
                {
                    if (e.Value.Equals(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Remove(K key)
        {
            if (ContainsKey(key))
            {
                int hash = Math.Abs(key.GetHashCode() % data_.Length);
                data_[hash].RemoveAll(e => e.Key.Equals(key));
            }
            else
            {
                throw new MapException("Mr. Sychev can't find key to delete.");
            }
        }

        public int Count
        {
            get
            {
                int result = 0;

                for (int i = 0; i < data_.Length; i++)
                {
                    result += data_[i].Count;
                }
                
                return result;
            }
        }

        public bool isEmpty
        {
            get
            {
                return Count == 0;
            }
        }

        public V this[K key]
        {
            get
            {
                int hash = Math.Abs(key.GetHashCode() % data_.Length);

                for (int i = 0; i < data_[hash].Count; i++)
                {
                    if (data_[hash][i].Key.Equals(key))
                    {
                        return data_[hash][i].Value;
                    }
                }

                throw new MapException("Key not found.");
            }
            set
            {
                int hash = Math.Abs(key.GetHashCode() % data_.Length);

                for (int i = 0; i < data_[hash].Count; i++)
                {
                    if (data_[hash][i].Key.Equals(key))
                    {
                        data_[hash][i].Value = value;
                    }
                }

                throw new MapException("Key not found.");
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                List<K> tmp = new List<K>();

                for (int i = 0; i < data_.Length; i++ )
                {
                    for (int j = 0; j < data_[i].Count; j++)
                    {
                        tmp.Add(data_[i][j].Key);
                    }
                }

                return tmp;
            }
        }

        public IEnumerable<V> Values
        {
            get
            {
                List<V> tmp = new List<V>();

                for (int i = 0; i < data_.Length; i++)
                {
                    for (int j = 0; j < data_[i].Count; j++)
                    {
                        tmp.Add(data_[i][j].Value);
                    }
                }

                return tmp;
            }
        }

        public IEnumerator<IEntry<K, V>> GetEnumerator()
        {
            List<IEntry<K, V>> tmp = new List<IEntry<K,V>>();

            for (int i = 0; i < data_.Length; i++ )
            {
                tmp.AddRange(data_[i]);
            }

            return tmp.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
