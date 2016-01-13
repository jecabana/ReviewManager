﻿using Data;
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
    public class VWCompleteSurgeryManager : GenericManager<VWCompleteSurgery>
    {
        public VWCompleteSurgeryManager(IRepository<VWCompleteSurgery> repository, Manager manager)
            : base(repository, manager)
        {

        }
    }    
}