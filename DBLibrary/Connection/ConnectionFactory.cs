using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using System.Data.SqlClient;

namespace DBLibrary
{
    class ConnectionFactory
    {
        public DbConnection GetDBConnection(DbContext dbContext)
        {
            using DbConnection db = dbContext.Database.GetDbConnection();
            return db;
        }
        
        public DbConnection GetDBConnection(string connectionString, bool isOracleConnection=false)
        {
            
            if (isOracleConnection)
                return new OracleConnection(connectionString);

            else
                return new SqlConnection(connectionString);  

        }




    }
}
