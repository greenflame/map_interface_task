using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap
{
    public class MapUtilsStatic
    {
        public delegate bool CheckDelegate<K, V>(Entry<K, V> entry);
        public delegate void ActionDelegate<K, V>(Entry<K, V> entry);
        public delegate IMap<K, V> MapConstructorDelegate<K, V>();

        public static MapConstructorDelegate<K, V> ArrayMapConstructor<K, V>()
        {
            return new MapConstructorDelegate<K, V>(
                    () => { return new ArrayMap<K, V>(); }
                );
        }
        //todo ListCD
        //todo HashCD

        public static bool Exists<K, V>(IMap<K, V> map, CheckDelegate<K, V> checkDelegate)
        {
            foreach (Entry<K, V> entry in map)
                if (checkDelegate(entry))
                    return true;
            return false;
        }

        public static bool CheckForAll<K, V>(IMap<K, V> map, CheckDelegate<K, V> checkDelegate) //todo ?
        {
            foreach (Entry<K, V> entry in map)
                if (!checkDelegate(entry))
                    return false;
            return true;
        }

        public static IMap<K, V> FindAll<K, V>(IMap<K, V> map, CheckDelegate<K, V> checkDelegate,
            MapConstructorDelegate<K, V> mapConstructorDelegate)
        {
            IMap<K, V> result = mapConstructorDelegate();

            foreach (Entry<K, V> entry in map)
                if (checkDelegate(entry))
                {
                    result.Put(entry.Key, entry.Value);
                }
            
            return result;
        }

        public static void ForEach<K, V>(IMap<K, V> map, ActionDelegate<K, V> actionDelegate)
        {
            foreach (Entry<K, V> entry in map)
                actionDelegate(entry);
        }
    }
}
