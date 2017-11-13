using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Rohm.DataAccess
{
    internal class AccessDatabase
    {
        public string GetConnectionString()
        {
            string ret=ConfigurationManager.ConnectionStrings["Rohm.DataAccess.APCSProDB"].ConnectionString;
            if (string.IsNullOrEmpty(ret))
            {
                throw new ConfigurationException("Rohm.DataAccess.APCSProDB connecitonstring was not found");
            }
            return ret;
        }

        protected DataTable ExecuteDataTable(string sqlStatement, CommandType cmdType,
            params SqlParameter[] sqlParamArray)
        {
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            using (SqlCommand cmd = con.CreateCommand())
            {
                con.Open();
                cmd.CommandText = sqlStatement;
                cmd.CommandType = cmdType;
                if (sqlParamArray != null)
                {
                    cmd.Parameters.AddRange(sqlParamArray);
                }
                table = new DataTable();
                table.Load(cmd.ExecuteReader());
            }
            return table;
        }
    }
}
