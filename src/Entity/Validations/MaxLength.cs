using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Validations
{
    public class MaxLength : BaseAttribute
    {
        public long Value { get; set; }

        public MaxLength(int value)
        {
            if (value < 1) throw new ArgumentOutOfRangeException("value", "El valor no puede ser menor que 1");
            ErrorMessage = "El campo {0} no puede tener una dimensión mayor a " + string.Format("{0}", value);
            Value = value;
        }
        public override bool IsValid(object element)
        {
            if (element == null) return true;
            if (string.IsNullOrEmpty(element.ToString()) || string.IsNullOrWhiteSpace(element.ToString())) return false;
            return element.ToString().Length <= Value;
        }
    }
}
