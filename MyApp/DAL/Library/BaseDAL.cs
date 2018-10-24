using CommonLib.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Library
{
    public class BaseDAL
    {
        
        protected async Task<SqlConnection> CreateConnectionAsync()
        {
            SqlConnection conn = new SqlConnection(AppSettings.MainDBConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }
            return conn;
        }
    }
}
