using Data;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Domain.Managers
{
    public class SurveyCustomerDbManager : GenericManager<Entity.PortalEntities.SurveyCustomer>
    {
        public SurveyCustomerDbManager(IRepository<Entity.PortalEntities.SurveyCustomer> repository, Manager manager)
            : base(repository, manager)
        {

        }
    }
}