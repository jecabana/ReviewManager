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
    public class ReviewManager : GenericManager<Review>
    {
        public ReviewManager(IRepository<Review> repository, Manager manager)
            : base(repository, manager)
        {

        }
    }
}
