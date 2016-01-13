using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Validations
{
    public class PhoneNumber : BaseAttribute
    {
        public PhoneNumber()
        {
            ErrorMessage = "El campo {0} es un número de teléfono válido";
        }
        public override bool IsValid(object element)
        {
            if (element == null) return true;
            if (string.IsNullOrEmpty(element.ToString()) || string.IsNullOrWhiteSpace(element.ToString())) return false;
            var text = element.ToString().Replace("+", "").Trim();
            return text.All( char.IsDigit);
        }
    }
}
