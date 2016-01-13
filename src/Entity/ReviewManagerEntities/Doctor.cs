using Entity.Validations;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Entity.ReviewManagerEntities
{
    public class Doctor
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string Source { get; set; }
        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }

    public class Doctora
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string Source { get; set; }
        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}