using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class BaseAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
        public abstract bool IsValid(Object element);

        public static Dictionary<string, List<string>> ValidateType<T>(T element)
        {
            var dic = new Dictionary<string, List<string>>();
            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var propertyName = propertyInfo.Name;
                var attributes = propertyInfo.GetCustomAttributes(typeof(BaseAttribute), true).Cast<BaseAttribute>();
                foreach (var propertyAttribute in attributes)
                {
                    var valid = propertyAttribute.IsValid(propertyInfo.GetValue(element));
                    if (valid) continue;
                    var errorMessage = propertyAttribute.ErrorMessage ?? "El campo {0} es inválido";
                    errorMessage = errorMessage.Replace("{0}", propertyName);
                    if (dic.ContainsKey(propertyName))
                        dic[propertyName].Add(errorMessage);
                    else
                        dic.Add(propertyName, new List<string>() { errorMessage });
                }
            }
            return dic;
        }
    }
}
