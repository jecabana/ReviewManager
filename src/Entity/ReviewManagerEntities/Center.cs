using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.ReviewManagerEntities
{
    public class Center
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }
    }
}