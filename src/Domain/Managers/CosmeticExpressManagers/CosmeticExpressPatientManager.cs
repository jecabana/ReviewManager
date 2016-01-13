using Data;
using Entity.CosmeticExpress;
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
    public class CosmeticExpressPatientManager : GenericManager<Patient>
    {
        public CosmeticExpressPatientManager(IRepository<Patient> repository, Manager manager)
            : base(repository, manager)
        {

        }
    }    
}