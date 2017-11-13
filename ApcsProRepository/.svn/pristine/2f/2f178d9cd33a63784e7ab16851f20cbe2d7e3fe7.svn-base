using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Rohm.Common.Model;

namespace Rohm.Common.CellController
{
    [ServiceContract()]
    public interface IApcsProService
    {
        [OperationContract()]
        CheckApplicationResult CheckApplicationVersion(FileVersion[] fileVersionArray);

        [OperationContract()]
        CheckUserPermissionResult CheckUserPermission(string employee, string functionName);

        [OperationContract()]
        CheckMachineConditionResult CheckMachineCondition(Machine mc);

        [OperationContract()]
        JigInfomation[] GetJigsByMachine(Machine mc);

        [OperationContract()]
        JigInfomation GetJigById(string jigId);

        [OperationContract()]
        CheckJigResult CheckJig(JigInfomation info, IInputArgument inputInfo);

        [OperationContract()]
        CheckQcInformationResult CheckQcInformation(QcInformationInputParameter input);

        [OperationContract()]
        string GetMachineRecipe(string lotNo);

        [OperationContract()]
        string GetTesterRecipe(string lotNo, string testerType, string testFlow);

        [OperationContract()]
        string GetOsTesterRecipe(string lotNo);

        [OperationContract()]
        LaserRecipe GetLaserRecipe(string lotNo);

        [OperationContract()]
        void UpdateMachineStatus(MachineStatusInfo mcInfo);

        [OperationContract()]
        void UpdateJig(JigInfomation jigInfo);

        [OperationContract()]
        LotStartInfo LotStart(LotStartParameter lotStartParam);

        [OperationContract()]
        LotEndInfo LotEnd(LotEndParameter lotEndParam);

        [OperationContract()]
        ServerTimeInfo GetServerTime();

        [OperationContract()]
        CheckMaterialResult CheckMaterialInfo(MaterialInfo matInfo);

        [OperationContract()]
        Package[] GetEnablePackageList();

    }
}
