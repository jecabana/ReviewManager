using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.PortalEntities
{
    public class TypeSurveyTemplate
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
    }
}

