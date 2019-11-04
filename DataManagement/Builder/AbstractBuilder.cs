using DataManagement.QueryBuilder;
using DBLibrary;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.Builder
{
    public abstract class AbstractBuilder : IBuilder
    {
        protected CommandBuilder builder;

        public abstract DbCommand CreateCommand<T>(T request);

        public AbstractBuilder(bool isOracleDatabase)
        {
            builder = new CommandBuilder(isOracleDatabase);
        }

        protected void BuildQuery(string query)
        {

            builder.WithQuery(query);

        }

        protected void BuildStoredProc(string storedProc)
        {  
            builder.WithStoredProcedure(storedProc);
        }

        protected void BuildParam(string key, object value)
        {
            builder.WithParameter(key, value);
        }
    }
}
