using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Rohm.Common.CellController
{
    [DataContract()]
    public class FileVersion
    {

        private string c_FileName;
        public string FileName
        {
            get { return c_FileName; }
            set { c_FileName = value; }
        }

        private string c_CheckSum;
        public string CheckSum
        {
            get { return c_CheckSum; }
            set { c_CheckSum = value; }
        }

    }
}
