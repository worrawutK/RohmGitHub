using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Rohm.Common.CellController
{
    [DataContract()]
    public class JigInfomation
    {

        private int c_Id;
        [DataMember()]
        public int Id
        {
            get { return c_Id; }
            set { c_Id = value; }
        }

        private string c_Name;
        [DataMember()]
        public string Name
        {
            get { return c_Name; }
            set { c_Name = value; }
        }

        private int c_Count;
        [DataMember()]
        public int Count
        {
            get { return c_Count; }
            set { c_Count = value; }
        }

        private JigUsageCountUnits c_CountUnit;
        [DataMember()]
        public JigUsageCountUnits CountUnit
        {
            get { return c_CountUnit; }
            set { c_CountUnit = value; }
        }

        private int c_CountWarning;
        [DataMember()]
        public int CountWarning
        {
            get { return c_CountWarning; }
            set { c_CountWarning = value; }
        }

        private int c_CountLimit;
        [DataMember()]
        public int CountLimit
        {
            get { return c_CountLimit; }
            set { c_CountLimit = value; }
        }

    }

    [DataContract()]
    public enum JigUsageCountUnits
    {
        [EnumMember()]
        Lot = 0,
        [EnumMember()]
        Piece = 1,
        [EnumMember()]
        Frame = 2,
        [EnumMember()]
        Magazine = 3
    }

}
