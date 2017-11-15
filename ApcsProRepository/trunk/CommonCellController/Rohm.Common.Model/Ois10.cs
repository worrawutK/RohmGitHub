﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rohm.Common.Model
{
  public   class Ois10
    {
        public string Header { get; set; }
        public string DeviceName { get; set; }
        public string InputRank { get; set; }
        public string ProcessFlow { get; set; }
        public string PackageName { get; set; }
        public string TesterType { get; set; }
        public string BoxName { get; set; }
        public string  ProgramName { get; set; }
        public string MultiNumber { get; set; }
        public string LayoutPattern { get; set; }

       public  void GetOis10(string qrData)
        {
            string[] ois;
           

            ois = qrData.ToUpper().Split(',');
            if (ois.Length == 10)
            {
                Header = ois[0];
               DeviceName = ois[1];
                InputRank = ois[2];
                ProcessFlow = ois[3];
                PackageName = ois[4];
                TesterType = ois[5];
                BoxName = ois[6];
                ProgramName = ois[7];
                MultiNumber = ois[8];
                LayoutPattern = ois[9];
            }
            else
            {
                throw new System.Exception("Data is invalid !");
            }
        }
    }
}