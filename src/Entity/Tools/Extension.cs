using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Tools
{
   public static class Extension
    {
        public static double Round(this double number, int decimals = 2)
        {
            return Math.Round(number, decimals, MidpointRounding.AwayFromZero);
        }
    }
}
