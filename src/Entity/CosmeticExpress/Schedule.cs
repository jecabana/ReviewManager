using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.CosmeticExpress
{
    [Table("Schedule")]
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public int OfficeID { get; set; }
        public int? ProviderUserID { get; set; }
        public DateTime dtStart { get; set; }
        public int PatientID { get; set; }
        public int ServiceID { get; set; }
    }
}
