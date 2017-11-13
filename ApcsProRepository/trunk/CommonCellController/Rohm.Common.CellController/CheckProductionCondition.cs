using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Rohm.Common.CellController
{
    [DataContract()]
    public class CheckProductionCondition
    {

        private bool c_IsPass;
        [DataMember()]
        public bool IsPass
        {
            get { return c_IsPass; }
            set { c_IsPass = value; }
        }

        private int c_ErrorNo;
        [DataMember()]
        public int ErrorNo
        {
            get { return c_ErrorNo; }
            set { c_ErrorNo = value; }
        }

        private string c_ErrorMessage;
        [DataMember()]
        public string ErrorMessage
        {
            get { return c_ErrorMessage; }
            set { c_ErrorMessage = value; }
        }

    }
}
