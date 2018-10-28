using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Extencions
{
    public static class ShortExtencion
    {
        public static bool WithinRange(this short value, short min, short max)
        {
            if (min <= max) throw new ArgumentException("Min argument must be smaller or equal to Max argument.");

            return ((min <= value) && (value <= max)); 
        }

        public static bool OutOfRange(this short value, short min, short max) => !value.WithinRange(min, max);
    }
}
