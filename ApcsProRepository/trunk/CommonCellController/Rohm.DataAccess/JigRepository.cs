using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rohm.Common.Model;
using System.Data;

namespace Rohm.DataAccess
{
    public class JigRepository
    {
        JigData c_JigDb;

        public JigRepository()
        {
            c_JigDb = new JigData();
        }

        public Jig GetJigById(int id)
        {
            Jig ret = null;

            using (DataTable dt = c_JigDb.GetJigById(id))
            {
                if (dt.Rows.Count == 1)
                {
                    ret = new Jig();
                    
                }
            }

            return ret;
        }

        public Jig[] GetJigByMachineId(int machineId)
        {
            Jig[] jigArray = new Jig[2];

            jigArray[0] = new Jig();
            jigArray[1] = new Jig();

            return jigArray;
        }
    }
}
