using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Rohm.Common.Forms;
using Rohm.Common.Model;
namespace Rohm.Common.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBData aa = new DBData() ;
            aa.MCType = "IDBW";
            aa.MCNo = "MX-99";
            aa.InputQty = 999;
            aa.PasteType = DBData.DBPasteType.Solder;
            aa.AlarmBonder = 112;
            aa.LotStartTime = DateTime.Now;
            Application.Run(new EditWBDataDialog());
        }
    }
}
