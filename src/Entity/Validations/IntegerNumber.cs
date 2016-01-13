using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Validations
{
    public class IntegerNumber : BaseAttribute
    {
        public IntegerNumber()
        {
            ErrorMessage = "El campo {0} es un número entero válido";
        }
        public override bool IsValid(object element)
        {
            if (element == null) return true;
            if (string.IsNullOrEmpty(element.ToString()) || string.IsNullOrWhiteSpace(element.ToString())) return false;
            long temp;
            if (long.TryParse(element.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out temp))
                return true;
            return false;

        }
    }
}
