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
    public class SurveyPossibleAnswerManager : GenericManager<SurveysPossibleAnswer>
    {
        public SurveyPossibleAnswerManager(IRepository<SurveysPossibleAnswer> repository, Manager manager)
            : base(repository, manager)
        {

        }
    }
}
