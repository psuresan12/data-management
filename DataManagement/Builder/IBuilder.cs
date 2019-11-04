using DataManagement.Models.ViewModel;
using DataManagement.Request;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.QueryBuilder
{
    interface IBuilder
    {
        DbCommand CreateCommand<T>(T request);
    }
}
