using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rohm.Common.CellController
{
    public class LotSettingUp
    {

        private bool c_Cancel;
        public bool Cancel
        {
            get { return c_Cancel; }
            set { c_Cancel = value; }
        }

        private IInputArgument c_InputArguments;
        public IInputArgument InputArgument
        {
            get { return c_InputArguments; }
            set { c_InputArguments = value; }
        }

    }
}
