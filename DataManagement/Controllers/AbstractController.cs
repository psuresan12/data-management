using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataManagement.Controllers.SampleController
{
    public abstract class  AbstractController : ControllerBase
    {
        protected Boolean IsQueryInjected(string sqlQuery)
        {
            Boolean isQueryInjected = false;

            //Return if string is empty
            if (sqlQuery == null)
                return isQueryInjected;
            
            //Check for Injection
            var upperCaseSQLQuery = sqlQuery.ToUpper();
            if (upperCaseSQLQuery.Contains("DELETE") || upperCaseSQLQuery.Contains("TRUNCATE"))
                isQueryInjected = true;

            
            return isQueryInjected;
        }

    }
}