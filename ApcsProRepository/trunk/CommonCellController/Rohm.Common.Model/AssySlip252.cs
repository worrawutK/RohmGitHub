using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rohm.Common.Model
{
   public class AssySlip252
    {
        public void ReadFromQrString(string fullQrCode)
        {
            if (fullQrCode.Length != 252)
            {
                throw new Exception("Invalid Data");
            }
            string tempFullQrCode = fullQrCode.ToUpper();
            this.FullCode = tempFullQrCode;
            this.PackageName = tempFullQrCode.Substring(0, 10).Trim();
            this.DeviceName = tempFullQrCode.Substring(10, 20).Trim();
            this.LotNo = tempFullQrCode.Substring(30, 10).Trim();
            this.FrameType = tempFullQrCode.Substring(40, 16).Trim();
            this.FaSet = tempFullQrCode.Substring(56, 4).Trim();
            this.CodeNo = tempFullQrCode.Substring(60, 10).Trim();
            this.WaferLotNo = tempFullQrCode.Substring(70, 12).Trim();
            this.TpRank = tempFullQrCode.Substring(82, 3).Trim();
            this.MarkType = tempFullQrCode.Substring(85, 1).Trim();
            this.MarkingSpec1 = tempFullQrCode.Substring(86, 10).Trim();
            this.MarkingSpec2 = tempFullQrCode.Substring(96, 10).Trim();
            this.MarkingSpec3 = tempFullQrCode.Substring(106, 10).Trim();
            this.MarkingStep = tempFullQrCode.Substring(116, 1).Trim();
            this.OsFtChange = tempFullQrCode.Substring(117, 1).Trim();
            this.OsProgram = tempFullQrCode.Substring(118, 12).Trim();
            this.ResinType = tempFullQrCode.Substring(130, 16).Trim();
            this.NewPackageName = tempFullQrCode.Substring(146, 20).Trim();
            this.FtDevice = tempFullQrCode.Substring(166, 20).Trim();
            this.MarkNo = tempFullQrCode.Substring(186, 10).Trim();
            this.PbFree = tempFullQrCode.Substring(196, 1).Trim();
            this.UlMark = tempFullQrCode.Substring(197, 1).Trim();
            this.ReelCount = tempFullQrCode.Substring(198, 5).Trim();
            this.ProvisionalIndication = tempFullQrCode.Substring(203, 4).Trim();
            this.SubRank = tempFullQrCode.Substring(207, 3).Trim();
            this.Mask = tempFullQrCode.Substring(210, 2).Trim();
            this.LabelDevice = tempFullQrCode.Substring(212, 20).Trim();
            this.CustomerDevice = tempFullQrCode.Substring(232, 20).Trim();
        }

        public string FullCode { get; set; }
        public string LotNo { get; set; }
        public string PackageName { get; set; }
        public string DeviceName { get; set; }
        public string FrameType { get; set; }
        public string FaSet { get; set; }
        public string CodeNo { get; set; }
        public string WaferLotNo { get; set; }
        public string TpRank { get; set; }
        public string MarkType { get; set; }
        public string MarkingSpec1 { get; set; }
        public string MarkingSpec2 { get; set; }
        public string MarkingSpec3 { get; set; }
        public string MarkingStep { get; set; }
        public string CustomerDevice { get; set; }
        public string OsFtChange { get; set; }
        public string OsProgram { get; set; }
        public string ResinType { get; set; }
        public string NewPackageName { get; set; }
        public string FtDevice { get; set; }
        public string MarkNo { get; set; }
        public string PbFree { get; set; }
        public string UlMark { get; set; }
        public string ReelCount { get; set; }
        public string ProvisionalIndication { get; set; }
        public string SubRank { get; set; }
        public string Mask { get; set; }
        public string LabelDevice { get; set; }

    }
}
