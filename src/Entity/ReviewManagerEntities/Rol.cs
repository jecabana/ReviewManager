using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ReviewManagerEntities
{
    public class Rol
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public virtual IList<Access> Accesses { get; set; }     
    }
}
