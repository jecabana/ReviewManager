namespace Entity.CosmeticExpress
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VWCompleteSurgery
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScheduleID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime dtStart { get; set; }

        public int? PatientID { get; set; }

        public int? OfficeID { get; set; }

        public int? ProviderUserID { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string OfficeName { get; set; }
    }
}
