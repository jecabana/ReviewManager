using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Data;
using Entity.PortalEntities;

namespace Domain.Managers
{
    public class SurveyGeneralAnswerManager : GenericManager<SurveysGeneralAnswer>
    {
        public SurveyGeneralAnswerManager(IRepository<SurveysGeneralAnswer> repository, Manager manager)
            : base(repository, manager)
        {

        }
    }
}
