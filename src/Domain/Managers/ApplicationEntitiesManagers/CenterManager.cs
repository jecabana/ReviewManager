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
    public class CenterManager : GenericManager<Center>
    {
        public CenterManager(IRepository<Center> repository, Manager manager)
            : base(repository, manager)
        {

        }
    }
}
