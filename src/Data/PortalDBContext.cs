using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Entity;
using System.Data.Entity;
using Entity.PortalEntities;

namespace Data
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext()
            : base("PortalDB")
        {
           
        }
        public static PortalDbContext Create()
        {
            return new PortalDbContext();
        }

        public DbSet<SurveyCustomer> SurveyCustomer { get; set; }
        public DbSet<SurveysGeneralAnswer> SurveysGeneralAnswer { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestion { get; set; }
        public DbSet<SurveysAnswer> SurveysAnswer { get; set; }
        public DbSet<SurveysPossibleAnswer> SurveysPossibleAnswer { get; set; }
        public DbSet<SurveyTemplate> SurveyTemplate { get; set; }
        public DbSet<TypeSurveyTemplate> TypeSurveyTemplate { get; set; }  
    }


}
