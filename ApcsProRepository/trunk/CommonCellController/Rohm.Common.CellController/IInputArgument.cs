using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rohm.Common.CellController
{
    public interface IInputArgument
    {

        string GetMCNo();
        string GetLotNo();
        string GetLotType();
        int GetInputQty();
        string GetInputUnit();
        string GetEmployeeCode();

    }
}
