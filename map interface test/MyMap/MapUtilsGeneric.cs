using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap
{
    public class MapUtilsGeneric<K, V>
    {
        public delegate bool CheckDelegate(Entry<K, V> entry);
        public delegate void ActionDelegate(Entry<K, V> entry);
        
        public delegate IMap<K, V> MapConstructorDelegate();
                
        static MapUtilsGeneric()
        {
            ArrayMapConstructor = new MapConstructorDelegate(() => { return new ArrayMap<K, V>(); });
        }

        public static readonly MapConstructorDelegate ArrayMapConstructor;
        //todo ListCD
        //todo HashCD

        public static IMap<K, V> FindAll(IMap<K, V> map, CheckDelegate checkDelegate,
            MapConstructorDelegate mapConstructorDelegate)
        {
            IMap<K, V> result = mapConstructorDelegate();

            foreach (Entry<K, V> entry in map)
                if (checkDelegate(entry))
                {
                    result.Put(entry.Key, entry.Value);
                }

            return result;
        }

        public static bool Exists(IMap<K, V> map, CheckDelegate checkDelegate)
        {
            foreach (Entry<K, V> entry in map)
                if (checkDelegate(entry))
                    return true;
            return false;
        }

        public static bool CheckForAll(IMap<K, V> map, CheckDelegate checkDelegate) //todo ?
        {
            foreach (Entry<K, V> entry in map)
                if (!checkDelegate(entry))
                    return false;
            return true;
        }

        public static void ForEach(IMap<K, V> map, ActionDelegate actionDelegate)
        {
            foreach (Entry<K, V> entry in map)
                actionDelegate(entry);
        }

    }
}
