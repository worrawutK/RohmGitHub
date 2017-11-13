using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rohm.Common.CellController;

namespace iLibrary
{
    public class ApcsProService
        :IApcsProService 
    {
        #region IApcsProService Members

        public CheckApplicationResult CheckApplicationVersion(FileVersion[] fileVersionArray)
        {
            throw new NotImplementedException();
        }

        public CheckUserPermissionResult CheckUserPermission(string employee, string functionName)
        {
            throw new NotImplementedException();
        }

        public CheckMachineConditionResult CheckMachineCondition(Rohm.Common.Model.Machine mc)
        {
            throw new NotImplementedException();
        }

        public JigInfomation[] GetJigsByMachine(Rohm.Common.Model.Machine mc)
        {
            throw new NotImplementedException();
        }

        public JigInfomation GetJigById(string jigId)
        {
            throw new NotImplementedException();
        }

        public CheckJigResult CheckJig(JigInfomation info, IInputArgument inputInfo)
        {
            throw new NotImplementedException();
        }

        public CheckQcInformationResult CheckQcInformation(QcInformationInputParameter input)
        {
            throw new NotImplementedException();
        }

        public string GetMachineRecipe(string lotNo)
        {
            throw new NotImplementedException();
        }

        public string GetTesterRecipe(string lotNo, string testerType, string testFlow)
        {
            throw new NotImplementedException();
        }

        public string GetOsTesterRecipe(string lotNo)
        {
            throw new NotImplementedException();
        }

        public LaserRecipe GetLaserRecipe(string lotNo)
        {
            throw new NotImplementedException();
        }

        public void UpdateMachineStatus(MachineStatusInfo mcInfo)
        {
            throw new NotImplementedException();
        }

        public void UpdateJig(JigInfomation jigInfo)
        {
            throw new NotImplementedException();
        }

        public LotStartInfo LotStart(LotStartParameter lotStartParam)
        {
            throw new NotImplementedException();
        }

        public LotEndInfo LotEnd(LotEndParameter lotEndParam)
        {
            throw new NotImplementedException();
        }

        public ServerTimeInfo GetServerTime()
        {
            throw new NotImplementedException();
        }

        public CheckMaterialResult CheckMaterialInfo(MaterialInfo matInfo)
        {
            throw new NotImplementedException();
        }

        public Package[] GetEnablePackageList()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
