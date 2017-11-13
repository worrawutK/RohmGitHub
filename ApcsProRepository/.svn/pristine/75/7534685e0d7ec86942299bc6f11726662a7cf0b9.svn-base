namespace Rohm.Common.Model
{
    public class DicingSlip254
    {
        //    Public Sub New(ByVal qrcode As String)
        //    FullCode = qrcode
        //End Sub
        public DicingSlip254(string qrcode)
        {
            FullCode = qrcode;
        }
        void SeperateData(string wfSlip)
        {
            if (wfSlip.Length == 254)
            {
                WaferQty = int.Parse(wfSlip.Substring(32, 2));//Convert.ToInt32(wfSlip.Substring(32, 2));//wfSlip.Substring(32, 2)
                ChipName = wfSlip.Substring(0, 20).Trim();
                WaferLotNo = wfSlip.Substring(20, 12).Trim();
                DeviceName = wfSlip.Substring(234, 20).Trim();
                            
                WaferNo1 = wfSlip.Substring(34, 2).Trim();
                WaferNo2 = wfSlip.Substring(42, 2).Trim();
                WaferNo3 = wfSlip.Substring(50, 2).Trim();
                WaferNo4 = wfSlip.Substring(58, 2).Trim();
                WaferNo5 = wfSlip.Substring(66, 2).Trim();
                WaferNo6 = wfSlip.Substring(74, 2).Trim();
                WaferNo7 = wfSlip.Substring(82, 2).Trim();
                WaferNo8 = wfSlip.Substring(90, 2).Trim();
                WaferNo9 = wfSlip.Substring(98, 2).Trim();
                WaferNo10 = wfSlip.Substring(106, 2).Trim();
                WaferNo11 = wfSlip.Substring(114, 2).Trim();
                WaferNo12 = wfSlip.Substring(122, 2).Trim();
                WaferNo13 = wfSlip.Substring(130, 2).Trim();
                WaferNo14 = wfSlip.Substring(138, 2).Trim();
                WaferNo15 = wfSlip.Substring(146, 2).Trim();
                WaferNo16 = wfSlip.Substring(154, 2).Trim();
                WaferNo17 = wfSlip.Substring(162, 2).Trim();
                WaferNo18 = wfSlip.Substring(170, 2).Trim();
                WaferNo19 = wfSlip.Substring(178, 2).Trim();
                WaferNo20 = wfSlip.Substring(186, 2).Trim();
                WaferNo21 = wfSlip.Substring(194, 2).Trim();
                WaferNo22 = wfSlip.Substring(202, 2).Trim();
                WaferNo23 = wfSlip.Substring(210, 2).Trim();
                WaferNo24 = wfSlip.Substring(218, 2).Trim();
                WaferNo25 = wfSlip.Substring(226, 2).Trim();

                WaferQtyNo1 = int.Parse(wfSlip.Substring(36, 6));
                WaferQtyNo2 = int.Parse(wfSlip.Substring(44, 6));
                WaferQtyNo3 = int.Parse(wfSlip.Substring(52, 6));
                WaferQtyNo4 = int.Parse(wfSlip.Substring(60, 6));
                WaferQtyNo5 = int.Parse(wfSlip.Substring(68, 6));
                WaferQtyNo6 = int.Parse(wfSlip.Substring(76, 6));
                WaferQtyNo7 = int.Parse(wfSlip.Substring(84, 6));
                WaferQtyNo8 = int.Parse(wfSlip.Substring(92, 6));
                WaferQtyNo9 = int.Parse(wfSlip.Substring(100, 6));
                WaferQtyNo10 = int.Parse(wfSlip.Substring(108, 6));
                WaferQtyNo11 = int.Parse(wfSlip.Substring(116, 6));
                WaferQtyNo12 = int.Parse(wfSlip.Substring(124, 6));
                WaferQtyNo13 = int.Parse(wfSlip.Substring(132, 6));
                WaferQtyNo14 = int.Parse(wfSlip.Substring(140, 6));
                WaferQtyNo15 = int.Parse(wfSlip.Substring(148, 6));
                WaferQtyNo16 = int.Parse(wfSlip.Substring(156, 6));
                WaferQtyNo17 = int.Parse(wfSlip.Substring(164, 6));
                WaferQtyNo18 = int.Parse(wfSlip.Substring(172, 6));
                WaferQtyNo19 = int.Parse(wfSlip.Substring(180, 6));
                WaferQtyNo20 = int.Parse(wfSlip.Substring(188, 6));
                WaferQtyNo21 = int.Parse(wfSlip.Substring(196, 6));
                WaferQtyNo22 = int.Parse(wfSlip.Substring(204, 6));
                WaferQtyNo23 = int.Parse(wfSlip.Substring(212, 6));
                WaferQtyNo24 = int.Parse(wfSlip.Substring(220, 6));
                WaferQtyNo25 = int.Parse(wfSlip.Substring(228, 6));

                WaferLotNo = GetWaferNo(WaferQty);
                //WaferNo = GetWaferNo(Wafer)
            }
        }

        private string GetWaferNo(int waferQty)
        {
            string ret = null;
            switch (waferQty)
            {
                case 1: ret = WaferNo1; break;
                case 2: ret = WaferNo1 + " - " + WaferNo2; break;
                case 3: ret = WaferNo1 + " - " + WaferNo3; break;
                case 4: ret = WaferNo1 + " - " + WaferNo4; break;
                case 5: ret = WaferNo1 + " - " + WaferNo5; break;
                case 6: ret = WaferNo1 + " - " + WaferNo6; break;
                case 7: ret = WaferNo1 + " - " + WaferNo7; break;
                case 8: ret = WaferNo1 + " - " + WaferNo8; break;
                case 9: ret = WaferNo1 + " - " + WaferNo9; break;
                case 10: ret = WaferNo1 + " - " + WaferNo10; break;
                case 11: ret = WaferNo1 + " - " + WaferNo11; break;
                case 12: ret = WaferNo1 + " - " + WaferNo12; break;
                case 13: ret = WaferNo1 + " - " + WaferNo13; break;
                case 14: ret = WaferNo1 + " - " + WaferNo14; break;
                case 15: ret = WaferNo1 + " - " + WaferNo15; break;
                case 16: ret = WaferNo1 + " - " + WaferNo16; break;
                case 17: ret = WaferNo1 + " - " + WaferNo17; break;
                case 18: ret = WaferNo1 + " - " + WaferNo18; break;
                case 19: ret = WaferNo1 + " - " + WaferNo19; break;
                case 20: ret = WaferNo1 + " - " + WaferNo20; break;
                case 21: ret = WaferNo1 + " - " + WaferNo21; break;
                case 22: ret = WaferNo1 + " - " + WaferNo22; break;
                case 23: ret = WaferNo1 + " - " + WaferNo23; break;
                case 24: ret = WaferNo1 + " - " + WaferNo24; break;
                case 25: ret = WaferNo1 + " - " + WaferNo25; break;
            }
            return ret;
        }

   

 
        #region Property
       // public string FullCode { get; set; }
        private string c_FullCode;
        public string FullCode
        {
            get { return c_FullCode; }
            set
            {
                c_FullCode = value;
                SeperateData(value);
            }
        }
      

        public string ChipName { get; set; }
        public string WaferLotNo { get; set; }
        public int WaferQty { get; set; }
        public string DeviceName { get; set; }
       
       
       
        
        public string WaferNo1 { get; set; }
        public string WaferNo2 { get; set; }
        public string WaferNo3 { get; set; }
        public string WaferNo4 { get; set; }
        public string WaferNo5 { get; set; }
        public string WaferNo6 { get; set; }
        public string WaferNo7 { get; set; }
        public string WaferNo8 { get; set; }
        public string WaferNo9 { get; set; }
        public string WaferNo10 { get; set; }
        public string WaferNo11 { get; set; }
        public string WaferNo12 { get; set; }
        public string WaferNo13 { get; set; }
        public string WaferNo14 { get; set; }
        public string WaferNo15 { get; set; }
        public string WaferNo16 { get; set; }
        public string WaferNo17 { get; set; }
        public string WaferNo18 { get; set; }
        public string WaferNo19 { get; set; }
        public string WaferNo20 { get; set; }
        public string WaferNo21 { get; set; }
        public string WaferNo22 { get; set; }
        public string WaferNo23 { get; set; }
        public string WaferNo24 { get; set; }
        public string WaferNo25 { get; set; }
        public int WaferQtyNo1 { get; set; }
        public int WaferQtyNo2 { get; set; }
        public int WaferQtyNo3 { get; set; }
        public int WaferQtyNo4 { get; set; }
        public int WaferQtyNo5 { get; set; }
        public int WaferQtyNo6 { get; set; }
        public int WaferQtyNo7 { get; set; }
        public int WaferQtyNo8 { get; set; }
        public int WaferQtyNo9 { get; set; }
        public int WaferQtyNo10 { get; set; }
        public int WaferQtyNo11 { get; set; }
        public int WaferQtyNo12 { get; set; }
        public int WaferQtyNo13 { get; set; }
        public int WaferQtyNo14 { get; set; }
        public int WaferQtyNo15 { get; set; }
        public int WaferQtyNo16 { get; set; }
        public int WaferQtyNo17 { get; set; }
        public int WaferQtyNo18 { get; set; }
        public int WaferQtyNo19 { get; set; }
        public int WaferQtyNo20 { get; set; }
        public int WaferQtyNo21 { get; set; }
        public int WaferQtyNo22 { get; set; }
        public int WaferQtyNo23 { get; set; }
        public int WaferQtyNo24 { get; set; }
        public int WaferQtyNo25 { get; set; }
        #endregion

    }
}
