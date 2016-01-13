using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Entity;
using System.Data.Entity;
using Entity.CosmeticExpress;

namespace Data
{
    public class CosmeticExpressDbContext : DbContext
    { 
        public CosmeticExpressDbContext()
            : base("CosmeticExpressDB")
        {
         
        }

        public static CosmeticExpressDbContext Create()
        {
            return new CosmeticExpressDbContext();
        }       
        
        public DbSet<Office> Offices { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VWCompleteSurgery> VWCompleteSurgery { get; set; }
        public DbSet<Patient> Patient { get; set; }
    }
   
}
