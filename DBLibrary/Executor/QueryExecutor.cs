using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace DBLibrary
{
    public class QueryExecutor : IExecutor
    {
        private DbConnection db;


        public QueryExecutor(DbContext context)
        {
            db = new ConnectionFactory()
                         .GetDBConnection(context);
        }


        public QueryExecutor(String connectionString, bool isOracleConnection = false)
        {
            db = new ConnectionFactory()
                        .GetDBConnection(connectionString,isOracleConnection);
        }


        public List<Dictionary<string,string>> Execute(DbCommand command)
        {
            List<Dictionary<string,string>> result = new List<Dictionary<string,string>>();

            using (db)
            {
                command.Connection = db;
                db.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var rowResult = new Dictionary<string,string>();
                    for (int column = 0; column < reader.FieldCount; column++)
                    {
                        rowResult.Add(
                                reader.GetName(column), reader.GetValue(column).ToString());
                    }
                    result.Add(rowResult);
                }
            }

            return result;
        }

        public List<Dictionary<string,string>> Execute(DbConnection connection, DbCommand command)
        {
            db = connection;
            return Execute(command);
        }
    }
}
