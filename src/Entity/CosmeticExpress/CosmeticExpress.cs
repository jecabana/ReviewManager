namespace Entity.CosmeticExpress
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CosmeticExpress : DbContext
    {
        public CosmeticExpress()
            : base("name=CosmeticExpress")
        {
        }

        public virtual DbSet<VWCompleteSurgery> VWCompleteSurgeries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VWCompleteSurgery>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<VWCompleteSurgery>()
                .Property(e => e.OfficeName)
                .IsUnicode(false);
        }
    }
}
