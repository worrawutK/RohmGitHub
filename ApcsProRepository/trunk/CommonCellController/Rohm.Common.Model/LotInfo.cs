﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rohm.Common.Model
{
    public class LotInfo
    {

        private string c_LotNo;
        public string LotNo
        {
            get { return c_LotNo; }
            set { c_LotNo = value; }
        }

        private string c_Package;
        public string Package
        {
            get { return c_Package; }
            set { c_Package = value; }
        }
        private string c_AssyDeviceName;
        public string AssyDeviceName
        {
            get { return c_AssyDeviceName; }
            set { c_AssyDeviceName = value; }
        }
        private string c_RohmChipName;
        public string RohmChipName
        {
            get { return c_RohmChipName; }
            set { c_RohmChipName = value; }
        }

        private string c_WaferLotNo;
        public string WaferLotNo
        {
            get { return c_WaferLotNo; }
            set { c_WaferLotNo = value; }
        }
        private string c_RecipeName;
        public string RecipeName
        {
            get { return c_RecipeName; }
            set { c_RecipeName = value; }
        }


        private string c_MachineNo;
        public string MachineNo
        {
            get { return c_MachineNo; }
            set { c_MachineNo = value; }
        }

        //lock or not or running
        private string c_Status;
        public string Status
        {
            get { return c_Status; }
            set { c_Status = value; }
        }

        private DateTime c_LastUpdateTime;
        public DateTime LastUpdateTime
        {
            get { return c_LastUpdateTime; }
            set { c_LastUpdateTime = value; }
        }

        private bool c_IsAutomotive;
        public bool IsAutomotive
        {
            get { return c_IsAutomotive; }
            set { c_IsAutomotive = value; }
        }

        private bool c_IsMultiChip;
        public bool IsMultiChip
        {
            get { return c_IsMultiChip; }
            set { c_IsMultiChip = value; }
        }

        private string m_CurrentProcess;
        public string CurrentProcess
        {
            get { return m_CurrentProcess; }
            set { m_CurrentProcess = value; }
        }

        private int c_TotalGood;
        public int TotalGood
        {
            get { return c_TotalGood; }
            set { c_TotalGood = value; }
        }

        private int c_TotalNg;
        public int TotalNg
        {
            get { return c_TotalNg; }
            set { c_TotalNg = value; }
        }

        private int c_StartMode;
        public int StartMode
        {
            get { return c_StartMode; }
            set { c_StartMode = value; }
        }

        private int c_EndMode;
        public int EndMode
        {
            get { return c_EndMode; }
            set { c_EndMode = value; }
        }

        private DateTime c_StartTime;
        public DateTime StartTime
        {
            get { return c_StartTime; }
            set { c_StartTime = value; }
        }

        private DateTime c_EndTime;
        public DateTime EndTime
        {
            get { return c_EndTime; }
            set { c_EndTime = value; }
        }

        private string c_StartEmployeeCode;
        public string StartEmployeeCode
        {
            get { return c_StartEmployeeCode; }
            set { c_StartEmployeeCode = value; }
        }

        private string c_EndEmployeeCode;
        public string EndEmployeeCode
        {
            get { return c_EndEmployeeCode; }
            set { c_EndEmployeeCode = value; }
        }


        private bool c_HasDoneFirstInspection;
        public bool HasDoneFirstInspection
        {
            get { return c_HasDoneFirstInspection; }
            set { c_HasDoneFirstInspection = value; }
        }

        private bool c_HasDoneFinalInspection;
        public bool HasDoneFinalInspection
        {
            get { return c_HasDoneFinalInspection; }
            set { c_HasDoneFinalInspection = value; }
        }

        private bool c_IsFirstJudgementPass;
        public bool IsFirstJudgementPass
        {
            get { return c_IsFirstJudgementPass; }
            set { c_IsFirstJudgementPass = value; }
        }

        private bool c_IsFinalJudgementPass;
        public bool IsFinalJudgementPass
        {
            get { return c_IsFinalJudgementPass; }
            set { c_IsFinalJudgementPass = value; }
        }
        private string c_ProgressLot;
        public string ProgressLot
        {
            get { return c_ProgressLot; }
            set { c_ProgressLot = value; }
        }
    }
}
