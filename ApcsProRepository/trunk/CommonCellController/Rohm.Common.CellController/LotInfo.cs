using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Rohm.Common.CellController
{
    [DataContract()]
    public class LotInfo
    {

        private string c_LotNo;
        [DataMember()]
        public string LotNo
        {
            get { return c_LotNo; }
            set { c_LotNo = value; }
        }

        private string c_Package;
        [DataMember()]
        public string Package
        {
            get { return c_Package; }
            set { c_Package = value; }
        }

        private string c_AssyDeviceName;
        [DataMember()]
        public string AssyDeviceName
        {
            get { return c_AssyDeviceName; }
            set { c_AssyDeviceName = value; }
        }

        private string c_RohmChipName;
        [DataMember()]
        public string RohmChipName
        {
            get { return c_RohmChipName; }
            set { c_RohmChipName = value; }
        }

        private string c_WaferLotNo;
        [DataMember()]
        public string WaferLotNo
        {
            get { return c_WaferLotNo; }
            set { c_WaferLotNo = value; }
        }

        private string c_RecipeName;
        [DataMember()]
        public string RecipeName
        {
            get { return c_RecipeName; }
            set { c_RecipeName = value; }
        }

        private string c_MachineNo;
        [DataMember()]
        public string MachineNo
        {
            get { return c_MachineNo; }
            set { c_MachineNo = value; }
        }

        //lock or not or running
        private string c_Status;
        [DataMember()]
        public string Status
        {
            get { return c_Status; }
            set { c_Status = value; }
        }

        private DateTime c_LastUpdateTime;
        [DataMember()]
        public DateTime LastUpdateTime
        {
            get { return c_LastUpdateTime; }
            set { c_LastUpdateTime = value; }
        }

        private bool c_IsAutomotive;
        [DataMember()]
        public bool IsAutomotive
        {
            get { return c_IsAutomotive; }
            set { c_IsAutomotive = value; }
        }

        private bool c_IsMultiChip;
        [DataMember()]
        public bool IsMultiChip
        {
            get { return c_IsMultiChip; }
            set { c_IsMultiChip = value; }
        }

        private string m_CurrentProcess;
        [DataMember()]
        public string CurrentProcess
        {
            get { return m_CurrentProcess; }
            set { m_CurrentProcess = value; }
        }

        private int c_TotalGood;
        [DataMember()]
        public int TotalGood
        {
            get { return c_TotalGood; }
            set { c_TotalGood = value; }
        }

        private int c_TotalNg;
        [DataMember()]
        public int TotalNg
        {
            get { return c_TotalNg; }
            set { c_TotalNg = value; }
        }

        private int c_StartMode;
        [DataMember()]
        public int StartMode
        {
            get { return c_StartMode; }
            set { c_StartMode = value; }
        }

        private int c_EndMode;
        [DataMember()]
        public int EndMode
        {
            get { return c_EndMode; }
            set { c_EndMode = value; }
        }

        private DateTime c_StartTime;
        [DataMember()]
        public DateTime StartTime
        {
            get { return c_StartTime; }
            set { c_StartTime = value; }
        }

        private DateTime c_EndTime;
        [DataMember()]
        public DateTime EndTime
        {
            get { return c_EndTime; }
            set { c_EndTime = value; }
        }

        private string c_StartEmployeeCode;
        [DataMember()]
        public string StartEmployeeCode
        {
            get { return c_StartEmployeeCode; }
            set { c_StartEmployeeCode = value; }
        }

        private string c_EndEmployeeCode;
        [DataMember()]
        public string EndEmployeeCode
        {
            get { return c_EndEmployeeCode; }
            set { c_EndEmployeeCode = value; }
        }

        private bool c_HasDoneFirstInspection;
        [DataMember()]
        public bool HasDoneFirstInspection
        {
            get { return c_HasDoneFirstInspection; }
            set { c_HasDoneFirstInspection = value; }
        }

        private bool c_HasDoneFinalInspection;
        [DataMember()]
        public bool HasDoneFinalInspection
        {
            get { return c_HasDoneFinalInspection; }
            set { c_HasDoneFinalInspection = value; }
        }

        private bool c_IsFirstJudgementPass;
        [DataMember()]
        public bool IsFirstJudgementPass
        {
            get { return c_IsFirstJudgementPass; }
            set { c_IsFirstJudgementPass = value; }
        }

        private bool c_IsFinalJudgementPass;
        [DataMember()]
        public bool IsFinalJudgementPass
        {
            get { return c_IsFinalJudgementPass; }
            set { c_IsFinalJudgementPass = value; }
        }

        private string c_ProgressLot;
        [DataMember()]
        public string ProgressLot
        {
            get { return c_ProgressLot; }
            set { c_ProgressLot = value; }
        }

    }
}
