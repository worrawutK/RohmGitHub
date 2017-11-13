using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Rohm.Common.CellController
{
    [DataContract()]
    public class CheckApplicationResult
    {

        private bool c_IsMatch;
        [DataMember()]
        public bool IsMatch
        {
            get { return c_IsMatch; }
            set { c_IsMatch = value; }
        }

        private bool c_ErrorNo;
        [DataMember()]
        public bool ErrorNo
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
