using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rohm.Common.CellController
{
    public class TestProgramAutoloaderSecure : ITestProgramAutoloader
    {

        private ITestProgramAutoloader c_Loader;
        public TestProgramAutoloaderSecure(ITestProgramAutoloader loader)
        {
            c_Loader = loader;
        }

        private IApcsProService c_Service;
        public IApcsProService Service
        {
            get { return c_Service; }
            set { c_Service = value; }
        }

        private IOperatorPanel c_Panel;
        public IOperatorPanel Panel
        {
            get { return c_Panel; }
            set { c_Panel = value; }
        }

        private string c_FunctionName;
        public string FunctionName
        {
            get { return c_FunctionName; }
            set { c_FunctionName = value; }
        }



        public void WriteLoadInformation(string mcNo, string channel, string ftDevice, string testFlow, string packageName, string testerType, string programName, string lotNo, string channelFlag)
        {
            if (ValidateUser())
            {
                c_Loader.WriteLoadInformation(mcNo, channel, ftDevice, testFlow, packageName, testerType, programName, lotNo, channelFlag);
            }

        }

        private bool ValidateUser()
        {

            string employeeCode = c_Panel.GetEmployeeCode();

            CheckUserPermissionResult permission = c_Service.CheckUserPermission(employeeCode, c_FunctionName);
            if (!permission.IsPermit)
            {
                c_Panel.ShowErrorMessage(employeeCode + " was not permited to do Autoload");
            }

            return permission.IsPermit;

        }

    }
}
