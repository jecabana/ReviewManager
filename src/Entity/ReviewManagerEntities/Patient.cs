using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Entity.ReviewManagerEntities
{
    public partial class Patient
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }

        public string Source { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}
