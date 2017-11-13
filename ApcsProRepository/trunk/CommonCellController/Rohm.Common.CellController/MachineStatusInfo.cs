using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Rohm.Common.CellController
{
    [DataContract()]
    public class MachineStatusInfo
    {

        private string c_MachineNo;
        [DataMember()]
        public string MachineNo
        {
            get { return c_MachineNo; }
            set { c_MachineNo = value; }
        }

        private int c_StatusId;
        [DataMember()]
        public int StatusId
        {
            get { return c_StatusId; }
            set { c_StatusId = value; }
        }

        private int c_SenderPiority;
        [DataMember()]
        public int SenderPiority
        {
            get { return c_SenderPiority; }
            set { c_SenderPiority = value; }
        }

        private int c_AlarmId;
        [DataMember()]
        public int AlarmId
        {
            get { return c_AlarmId; }
            set { c_AlarmId = value; }
        }

        private string[] c_LotNoArray;
        [DataMember()]
        public string[] LotNoArray
        {
            get { return c_LotNoArray; }
            set { c_LotNoArray = value; }
        }

    }
}
