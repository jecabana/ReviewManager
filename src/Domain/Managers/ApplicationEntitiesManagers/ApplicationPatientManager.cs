using Data;
using Entity.ReviewManagerEntities;
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
    public class ApplicationPatientManager : GenericManager<Patient>
    {
        public ApplicationPatientManager(IRepository<Patient> repository, Manager manager)
            : base(repository, manager)
        {

        }
    }
}