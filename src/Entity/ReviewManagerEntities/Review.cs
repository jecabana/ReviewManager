using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ReviewManagerEntities
{
    public class Review
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }
        public string Source { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [StringLength(100)]
        public string Project { get; set; }

        [StringLength(100)]
        public string RelationCompany { get; set; }

        public bool RecommendBussiness { get; set; }

        public float Rating { get; set; }

        public int Like { get; set; }

        [StringLength(2000)]
        public string Text { get; set; }

        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int? ExpertId { get; set; }
        public virtual Expert Expert { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int? CenterId { get; set; }
        public virtual Center Center { get; set; }

        public Expert ParentReview { get; set; }     
    }
}
