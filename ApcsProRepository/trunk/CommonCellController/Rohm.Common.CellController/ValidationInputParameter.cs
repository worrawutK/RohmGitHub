using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Rohm.Common.Model;

namespace Rohm.Common.CellController
{
    [DataContract()]
    public class ValidationInputParameter
    {

        private Machine c_Machine;
        [DataMember()]
        public Machine Machine
        {
            get { return c_Machine; }
            set { c_Machine = value; }
        }

        private string c_EmployeeCode;
        [DataMember()]
        public string EmployeeCode
        {
            get { return c_EmployeeCode; }
            set { c_EmployeeCode = value; }
        }

        private object c_InputArguments;
        [DataMember()]
        public object InputArguments
        {
            get { return c_InputArguments; }
            set { c_InputArguments = value; }
        }

    }
}
