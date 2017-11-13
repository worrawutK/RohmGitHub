using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Rohm.Common.CellController
{
    [DataContract()]
    public class LotStartInfo
    {

        private bool c_IsOk;
        [DataMember()]
        public bool IsOk
        {
            get { return c_IsOk; }
            set { c_IsOk = value; }
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

        private string c_LotNo;
        [DataMember()]
        public string LotNo
        {
            get { return c_LotNo; }
            set { c_LotNo = value; }
        }

        private string c_MachineNo;
        [DataMember()]
        public string MachineNo
        {
            get { return c_MachineNo; }
            set { c_MachineNo = value; }
        }

        private string c_UserId;
        [DataMember()]
        public string UserId
        {
            get { return c_UserId; }
            set { c_UserId = value; }
        }

        private int c_TicketId;
        [DataMember()]
        public int TicketId
        {
            get { return c_TicketId; }
            set { c_TicketId = value; }
        }

        private int c_OperationSequence;
        [DataMember()]
        public int OperationSequence
        {
            get { return c_OperationSequence; }
            set { c_OperationSequence = value; }
        }

        private int c_InputQty;
        [DataMember()]
        public int InputQty
        {
            get { return c_InputQty; }
            set { c_InputQty = value; }
        }

        private System.DateTime c_StartTime;
        [DataMember()]
        public System.DateTime StartTime
        {
            get { return c_StartTime; }
            set { c_StartTime = value; }
        }
    }
}
