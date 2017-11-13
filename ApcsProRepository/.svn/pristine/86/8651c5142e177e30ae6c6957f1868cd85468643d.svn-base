using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rohm.Common.Model;
using System.Windows.Forms;

namespace Rohm.Common.CellController
{
    public interface IOperatorPanel
    {
        CellControllerBase CellController { get; set; }

        void ShowErrorMessage(string message);
        string GetEmployeeCode();
        User GetUser();
        User GetUserWithPasswordCheck();
        AssySlip252 GetAssySlip252();
        AssySlip332 GetAssySlip332();
        DicingSlip254 GetDicingSlip254();
        DicingSlip276 GetDicingSlip276();
        Ois8 GetOis8();
        Ois10 GetOis10();
        int GetInputQty();
        Form ReportForm { get; set; }
        Form SpcialOperationForm { get; set; }

        Machine SelectMachine(Machine[] availableMachineArray);

    }
}
