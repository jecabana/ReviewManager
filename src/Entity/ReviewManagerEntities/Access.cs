using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ReviewManagerEntities
{
    public class Access
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Rol> Roles { get; set; }        
    }
}
