using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Rohm.DataAccess
{
    class JigData
        :AccessDatabase
    {
        public DataTable GetJigById(int id)
        {
            return ExecuteDataTable("SELECT * FROM APCSProDB.dbo.JIG WHERE ID=@ID",
                System.Data.CommandType.Text, new SqlParameter("@ID", id));
        }
    }
}
