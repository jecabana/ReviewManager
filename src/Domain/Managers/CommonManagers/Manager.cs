using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Data;
using Entity.PortalEntities;
using Entity.ReviewManagerEntities;
using Entity.CosmeticExpress;

namespace Domain.Managers
{
    public class Manager
    {
        public AccessManager AccessManager { get; set; }
        public RolManager RolManager { get; set; }

        public SurveyCustomerDbManager SurveyCustomerDbManager { get; set; }      
        public SurveyQuestionManager SurveyQuestionManager { get; set; }
        public SurveyPossibleAnswerManager SurveyPossibleAnswerManager { get; set; }
        public ReviewManager ReviewManager { get; set; }
        public ScheduleManager ScheduleManager { get; set; }

        public Manager(IRepository<Access> repository)
        {
            //var accessRepo = Kernel.Get<IRepository<Access>>();
            var accessRepo = repository;
            AccessManager = new AccessManager(accessRepo, this);

            var rolRepo = accessRepo.Clone<Rol>();
            RolManager = new RolManager(rolRepo, this);

            var surveyCustomerRepo = accessRepo.Clone<SurveyCustomer>();
           
            SurveyCustomerDbManager = new SurveyCustomerDbManager(surveyCustomerRepo, this);

                    
            var SurveyQuestionRepo = accessRepo.Clone<SurveyQuestion>();
            SurveyQuestionManager = new SurveyQuestionManager(SurveyQuestionRepo, this);

            var SurveyPossibleAnswerRepo = accessRepo.Clone<SurveysPossibleAnswer>();
            SurveyPossibleAnswerManager = new SurveyPossibleAnswerManager(SurveyPossibleAnswerRepo, this);

            var ReviewRepo = accessRepo.Clone<Review>();
            ReviewManager = new ReviewManager(ReviewRepo, this);

            var ScheduleRepo = accessRepo.Clone<Schedule>();
            ScheduleManager = new ScheduleManager(ScheduleRepo, this);
        }

        public GenericManager<T> GetManager<T>() where T : class
        {
            var property = GetType().GetProperties().FirstOrDefault(t =>
               t.PropertyType.IsSubclassOf(typeof(GenericManager<T>)));
            if (property != null)
                return property.GetMethod.Invoke(this, null) as GenericManager<T>;
            return null;
        }
    }
}
