using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap
{
    public interface IEntry<K, V>
    {
        K Key { get; set; }
        V Value { get; set; }
    }
}
