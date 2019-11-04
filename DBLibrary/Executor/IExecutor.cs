using System.Collections.Generic;
using System.Data.Common;

namespace DBLibrary
{
    public interface IExecutor
    {
        List<Dictionary<string,string>> Execute(DbCommand command);
        List<Dictionary<string,string>> Execute(DbConnection connection, DbCommand command);
    }
}