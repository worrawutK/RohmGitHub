using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rohm.Common.Model;

namespace Rohm.Common.CellController
{
    public abstract class CellControllerBase
    {

        public CellControllerBase()
        {
            c_MachineList = new List<Machine>();
            c_LotInfoList = new List<LotInfo>();
        }

        private IApcsProService c_Service;
        public IApcsProService Service
        {
            get { return c_Service; }
            set { c_Service = value; }
        }

        private IOperatorPanel c_OperatorPanel;
        public IOperatorPanel OperatorPanel
        {
            get { return c_OperatorPanel; }
            set { c_OperatorPanel = value; }
        }

        private List<Machine> c_MachineList;
        public List<Machine> MachineList
        {
            get { return c_MachineList; }
            set { c_MachineList = value; }
        }

        private List<LotInfo> c_LotInfoList;
        public List<LotInfo> LotInfoList
        {
            get { return c_LotInfoList; }
            set { c_LotInfoList = value; }
        }

        private List<MaterialInfo> c_MaterialList;
        public List<MaterialInfo> MaterialList
        {
            get { return c_MaterialList; }
            set { c_MaterialList = value; }
        }

        //1.) Operator push setup button. and Call Setup function of CellController
        public void Setup()
        {
            //2.) C/C check application version by compare check sum to the registered data on server.
            FileVersion[] fileVersionArray = GetCellControllerFileVersions();

            CheckApplicationResult checkAppResult = c_Service.CheckApplicationVersion(fileVersionArray);
            if (!checkAppResult.IsMatch)
            {
                //show error to use
                c_OperatorPanel.ShowErrorMessage("");
                return;
            }

            //3.) Operator input employee code.
            string employeeCode = c_OperatorPanel.GetEmployeeCode();
            if (string.IsNullOrEmpty(employeeCode))
            {
                return;
            }

            //4.) C/C check user permission. { user + function}
            CheckUserPermissionResult checkPermissionResult = c_Service.CheckUserPermission(employeeCode, GetSetupFunctionName());
            if (!checkPermissionResult.IsPermit)
            {
                c_OperatorPanel.ShowErrorMessage("");
                return;
            }

            //5.) Operator select machine for setting up.
            Machine selectedMachine = c_OperatorPanel.SelectMachine(c_MachineList.ToArray());
            if (selectedMachine == null)
            {
                return;
            }

            //6.) C/C check machine condition.
            //   6.1) Check machine status.
            //   6.2) Check machine permit {by QC, Andon, BM, etc..}
            //   6.3) Check equipment if already setup or not?
            //   6.4) Check material on machine.
            CheckMachineConditionResult mcConditionResult = c_Service.CheckMachineCondition(selectedMachine);
            if (!mcConditionResult.IsPass)
            {
                c_OperatorPanel.ShowErrorMessage("");
                return;
            }

            //7.) Operator input production data {WS, OIS, Input Quantity, Material,..}
            LotSettingUp settingUp = GetLotSettingUpData();
            if (settingUp.Cancel)
            {
                return;
            }

            //8) C/C check production condition
            //   8.1) Check Input Data are match o not?
            //   8.2) Check needed equipment and material are match with prepared
            //	    equipment and material or not? and include Autotive checking
            ValidationInputParameter validationInput = new ValidationInputParameter();
            validationInput.Machine = selectedMachine;
            validationInput.EmployeeCode = employeeCode;
            validationInput.InputArguments = settingUp.InputArgument;
            ValidationInputDataResult validationResult = ValidateInputData(validationInput);
            if (!validationResult.IsValid)
            {
                c_OperatorPanel.ShowErrorMessage("");
                return;
            }

            IInputArgument input = settingUp.InputArgument;

            //9.) Check Jig and Material lifetime forecast by current lifetime plus with input quantity will over limit or not?
            JigInfomation[] jigInfoArray = c_Service.GetJigsByMachine(selectedMachine);
            CheckJigResult cjResult = default(CheckJigResult);
            foreach (JigInfomation info in jigInfoArray)
            {
                cjResult = c_Service.CheckJig(info, input);
                //*********** need input qty
                if (!cjResult.IsOk)
                {
                    c_OperatorPanel.ShowErrorMessage("");
                    return;
                }
            }

            //10.) C/C get QC Information by input parameter such as MCNo, OPNo, LotNo, Event(Before-After)
            QcInformationInputParameter qcInfoInput = new QcInformationInputParameter();

            qcInfoInput.LotNo = input.GetLotNo();
            qcInfoInput.MCNo = input.GetMCNo();
            qcInfoInput.EmployeeCode = input.GetEmployeeCode();
            qcInfoInput.EventName = "BeforeStart";

            CheckQcInformationResult qcResult = c_Service.CheckQcInformation(qcInfoInput);
            if (!qcResult.IsPermit)
            {
                c_OperatorPanel.ShowErrorMessage("");
                return;
            }

            //11.) C/C get recipe and send machine
            //   11.1) Machine’s recipe.
            //   11.2) Tester’s recipe
            //   11.3) OS Tester’s recipe
            //   11.4) Laser mark’s recipe
            SendRecipe();

            //12.) setup completed
            OnSetupCompleted();

        }

        protected abstract void Initialize();
        protected abstract FileVersion[] GetCellControllerFileVersions();
        protected abstract string GetSetupFunctionName();
        protected abstract LotSettingUp GetLotSettingUpData();
        protected abstract ValidationInputDataResult ValidateInputData(ValidationInputParameter validationInput);
        protected abstract void SendRecipe();
        protected abstract void OnSetupCompleted();

        public void StartProduction()
        {
            //1. Check user permission
            //2. check machine status
            //   if something has changed, check ProductionCondition again
            //   because if someone change equipment after setup lot
            //3. Update Lot status to start !!!
            //4.) Display Result of StartProduction
        }

        public void EndProduction()
        {
            //#in case of Manual Start
            //1. Show production data edit form
            //2. Save to database *user require

            //#in case of Auto Start
            //1. Update machine data to LotData
            //2. Show Production data eidt form
            //3. Save to database  *user require 
        }

        public void LoadRecipe()
        {
        }

        public void StartCellController()
        {
            Initialize();
        }

    }

    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //Conversion powered by NRefactory.
    //Twitter: @telerik
    //Facebook: facebook.com/telerik
    //=======================================================

}
