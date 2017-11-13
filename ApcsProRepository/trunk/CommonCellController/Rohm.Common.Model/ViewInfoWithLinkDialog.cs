using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rohm.Common.Model
{
    class ViewInfoWithLinkDialog
    {
        private String c_AlarmTitle;
        public String AlarmTitle
        {
            get { return c_AlarmTitle; }
            set
            {
                c_AlarmTitle = value;
            }
        }
        private String c_AlarmMessage;
        public String AlarmMessage
        {
            get { return c_AlarmMessage; }
            set
            {
                c_AlarmMessage = value;
            }
        }
        private String c_OnePoint;
        public String OnePoint
        {
            get { return c_OnePoint; }
            set
            {
                c_OnePoint = value;
            }
        }
    }
}
