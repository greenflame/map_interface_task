using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMap;

namespace map_interface_test
{
    class Program
    {
        static void Main(string[] args)
        {
            IMap<string, int> map = new ArrayMap<string, int>();

            map.Put("yellow", 1);
            map.Put("blue", 10);
            map.Put("red", 67);

            while(true)
            {
                string[] command = Console.ReadLine().Split(' ');
                try
                {
                    switch (command[0].ToLower())
                    {
                        case "clear":
                            map.Clear();
                            break;
                        case "put":
                            map.Put(command[1], Convert.ToInt32(command[2]));
                            break;
                        case "remove":
                            map.Remove(command[1]);
                            break;
                        case "containskey":
                            Console.WriteLine(map.ContainsKey(command[1]));
                            break;
                        case "containsvalue":
                            Console.WriteLine(map.ContainsValue(Convert.ToInt32(command[1])));
                            break;
                        case "list":
                            foreach (IEntry<string, int> e in map)
                                Console.WriteLine(e.ToString());
                            break;
                        case "keys":
                            foreach (string s in map.Keys)
                                Console.WriteLine(s);
                            break;
                        case "values":
                            foreach (int i in map.Values)
                                Console.WriteLine(i.ToString());
                            break;

                        case "testum":  //test
                            UnmutableMap<string, int> um = new UnmutableMap<string, int>(map);
                            Console.WriteLine(um["red"].ToString());
                            um["red"] = 3;
                            break;

                        case "testfind":
                            map = MapUtilsGeneric<string, int>.FindAll(map,
                                new MapUtilsGeneric<string, int>.CheckDelegate( (Entry<string, int> e) => { return e.Key[0] == 'r'; } ),
                                MapUtilsGeneric<string, int>.ArrayMapConstructor);
                            break;

                        default:
                            throw new Exception("Unknown command.");
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType().ToString() + ": " + ex.Message);
                }
            }
        }
    }
}
