using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Entity.ReviewManagerEntities;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ReviewManagerDB", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }       
       
        public DbSet<Center> Centers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Lead> Leads { get; set; }      
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Center>().HasMany(d => d.Reviews).WithRequired().HasForeignKey(r => r.CenterId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Doctor>().HasMany(d => d.Reviews).WithRequired().HasForeignKey(r => r.DoctorId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Expert>().HasMany(d => d.Reviews).WithRequired().HasForeignKey(r => r.ExpertId).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
   
}
