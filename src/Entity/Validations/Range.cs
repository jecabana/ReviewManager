using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Validations
{
    public class Range : BaseAttribute
    {
        public long Min { get; set; }
        public long Max { get; set; }

        public Range(long min,long max)
        {
            if(min>max)throw new ArgumentOutOfRangeException("min","El valor de min no puede ser mayor que el de max");
            ErrorMessage = "El campo {0} debe estar entre " + string.Format("{0} y {1}",min,max);
            Min = min;
            Max = max;
        }
        public override bool IsValid(object element)
        {
            if (element == null) return true;
            if (string.IsNullOrEmpty(element.ToString()) || string.IsNullOrWhiteSpace(element.ToString())) return false;
            long temp;
            //ErrorMessage = ErrorMessage.Replace("{min}", Min.ToString()).Replace("{max}", Max.ToString());
            if (long.TryParse(element.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out temp))
                return temp <= Max && temp >= Min;
            return false;
        }
    }
}
