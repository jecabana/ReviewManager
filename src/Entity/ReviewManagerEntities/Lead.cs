using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Entity.ReviewManagerEntities
{
    public class Lead
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string IpAddress { get; set; }
        public int CenterId { get; set; }
        public virtual Center Center { get; set; }
        public string Url { get; set; }
        public string UserAgent { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientEmail { get; set; }
        public string ClientMessage { get; set; }
        public bool Readed { get; set; }
    }
}