using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entity.Validations
{
    public class Email : BaseAttribute
    {
        public Email()
        {
            ErrorMessage = "El campo {0} no es un correo válido";
        }
        public override bool IsValid(object element)
        {
            if (element == null) return true;
            if (string.IsNullOrEmpty(element.ToString()) || string.IsNullOrWhiteSpace(element.ToString())) return false;
            try
            {
                var m = new MailAddress(element.ToString());
                return true;
            }
            catch (FormatException)
            {
                return false;
            }

        }
    }
}
