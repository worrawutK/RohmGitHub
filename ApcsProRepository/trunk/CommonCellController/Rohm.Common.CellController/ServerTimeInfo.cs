using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rohm.Common.CellController
{
    public class ServerTimeInfo
    {

        private string c_ServerName;
        public string ServerName
        {
            get { return c_ServerName; }
            set { c_ServerName = value; }
        }

        private DateTime m_ServerTime;
        public DateTime ServerTime
        {
            get { return m_ServerTime; }
            set { m_ServerTime = value; }
        }
    }
}
