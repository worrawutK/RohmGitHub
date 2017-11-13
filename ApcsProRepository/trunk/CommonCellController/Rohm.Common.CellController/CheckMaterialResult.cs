using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Rohm.Common.CellController
{
    [DataContract()]
    public class CheckMaterialResult
    {

        private bool c_IsOK;
        [DataMember()]
        public bool IsOK
        {
            get { return c_IsOK; }
            set { c_IsOK = value; }
        }

        private MaterialState c_Status;
        [DataMember()]
        public MaterialState Status
        {
            get { return c_Status; }
            set { c_Status = value; }
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

    [DataContract()]
    public enum MaterialState
    {
        [EnumMember()]
        Wait = 0,
        [EnumMember()]
        Usable = 1,
        [EnumMember()]
        Warning = 2,
        [EnumMember()]
        Expired = 3
    }
}
