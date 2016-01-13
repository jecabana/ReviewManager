using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Validations
{
    public class Required : BaseAttribute
    {
        public Required()
        {
            ErrorMessage = "El campo {0} es obligatorio";
        }
        public override bool IsValid(object element)
        {
            if (element == null) return false;
            return !string.IsNullOrEmpty(element.ToString()) && !string.IsNullOrWhiteSpace(element.ToString());
        }
    }
}
