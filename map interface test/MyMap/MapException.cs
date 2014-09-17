using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap
{
    public class MapException : Exception
    {
        public MapException() : base() { }
        public MapException(string m) : base(m) { }
    }
}
