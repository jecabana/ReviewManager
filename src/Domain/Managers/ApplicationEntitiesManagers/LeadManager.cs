using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Data;
using Entity.ReviewManagerEntities;

namespace Domain.Managers
{
    public class LeadManager : GenericManager<Lead>
    {
        public LeadManager(IRepository<Lead> repository, Manager manager)
            : base(repository, manager)
        {

        }
    }
}
