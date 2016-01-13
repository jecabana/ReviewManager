using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.PortalEntities
{
    public class SurveyCustomer
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(15)]
        public string MobilePhone { get; set; }
        public int ExternalId { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastAction { get; set; }
        public virtual ICollection<SurveysGeneralAnswer> SurveysTemplateAnswer { get; set; }
    }
}
