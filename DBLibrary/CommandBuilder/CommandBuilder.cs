
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DBLibrary
{
    public class CommandBuilder
    {
        private bool _isOracleDatabase = false;
        private DbCommand command;

        public CommandBuilder(bool isOracleDatabase)
        {
            _isOracleDatabase = isOracleDatabase;

            if (_isOracleDatabase) command = new OracleCommand();
            else command = new SqlCommand();
        }


        public CommandBuilder WithQuery(string query)
        {
            command.CommandText = query;
            return this;
        }

        public CommandBuilder WithParameter(string name, object value)
        {
            DbParameter param;

            if (_isOracleDatabase) param = new OracleParameter();
            else param = new SqlParameter();

            param.ParameterName = name;
            param.Value = value;

            command.Parameters.Add(param);
            return this;
        }

        public CommandBuilder WithStoredProcedure(string query)
        {
            WithQuery(query);
            command.CommandType = CommandType.StoredProcedure;
           
            return this;
        }

        public DbCommand Build()
        {
            return command;
        }
    }
}
