Imports Rohm.Common.CellController

Public Class MockupApcsProService
    Implements IApcsProService

    Public Function CheckApplicationVersion(ByVal fileVersionArray() As FileVersion) As CheckApplicationResult Implements IApcsProService.CheckApplicationVersion
        Return New CheckApplicationResult() With {.IsMatch = True}
    End Function


    Public Function CheckMachineCondition(ByVal mc As Machine) As CheckMachineConditionResult Implements IApcsProService.CheckMachineCondition
        Return New CheckMachineConditionResult() With {.IsPass = True}
    End Function

    Public Function CheckQcInformation(ByVal input As QcInformationInputParameter) As CheckQcInformationResult Implements IApcsProService.CheckQcInformation
        Return New CheckQcInformationResult() With {.IsPermit = True}
    End Function

    Public Function CheckUserPermission(ByVal employee As String, ByVal functionName As String) As CheckUserPermissionResult Implements IApcsProService.CheckUserPermission
        Return New CheckUserPermissionResult() With {.IsPermit = True}
    End Function

    Public Function GetJigById(ByVal jigId As String) As JigInfomation Implements IApcsProService.GetJigById
        Return New JigInfomation()
    End Function

    Public Function GetJigsByMachine(ByVal mc As Machine) As JigInfomation() Implements IApcsProService.GetJigsByMachine

        Dim jigInfoList As List(Of JigInfomation) = New List(Of JigInfomation)
        jigInfoList.Add(New JigInfomation())
        Return jigInfoList.ToArray()
    End Function

    Public Function GetLaserRecipe(ByVal lotNo As String) As LaserRecipe Implements IApcsProService.GetLaserRecipe
        Return New LaserRecipe() With {.MarkTextLine1 = "Rohm", .MarkTextLine2 = "VQFP64", .MarkTextLine3 = "By X-Men"}
    End Function

    Public Function GetMachineRecipe(ByVal lotNo As String) As String Implements IApcsProService.GetMachineRecipe
        Return "UQTX01"
    End Function

    Public Function GetOsTesterRecipe(ByVal lotNo As String) As String Implements IApcsProService.GetOsTesterRecipe
        Return "AA4689 OA"
    End Function

    Public Function GetTesterRecipe(ByVal lotNo As String, ByVal testerType As String, ByVal testFlow As String) As String Implements IApcsProService.GetTesterRecipe
        Return "FD1234A"
    End Function

    Public Sub UpdateMachineStatus(ByVal mcInfo As MachineStatusInfo) Implements IApcsProService.UpdateMachineStatus
        'do nothing
    End Sub

    Public Function GetServerTime() As ServerTimeInfo Implements IApcsProService.GetServerTime
        Return New ServerTimeInfo() With {.ServerName = "Client-003", .ServerTime = Now}
    End Function

    Public Function LotEnd(ByVal lotEndParam As LotEndParameter) As LotEndInfo Implements IApcsProService.LotEnd
        Return New LotEndInfo()
    End Function

    Public Function LotStart(ByVal lotStartParam As LotStartParameter) As LotStartInfo Implements IApcsProService.LotStart
        Return New LotStartInfo()
    End Function

    Public Sub UpdateJig(ByVal jigInfo As JigInfomation) Implements IApcsProService.UpdateJig
        'do nothing
    End Sub

    Public Function CheckMaterialInfo(ByVal matInfo As MaterialInfo) As CheckMaterialResult Implements IApcsProService.CheckMaterialInfo
        Return New CheckMaterialResult()
    End Function

    Public Function CheckJig(ByVal info As JigInfomation, ByVal inputInfo As Rohm.Common.CellController.IInputArgument) As Rohm.Common.CellController.CheckJigResult Implements Rohm.Common.CellController.IApcsProService.CheckJig
        Return New CheckJigResult() With {.IsOk = True}
    End Function

    Public Function GetEnablePackageList() As Rohm.Common.CellController.Package() Implements Rohm.Common.CellController.IApcsProService.GetEnablePackageList
        Dim packageList As List(Of Package) = New List(Of Package)
        packageList.Add(New Package() With {.PackageId = 1, .PackageName = "TOS482"})
        Return packageList.ToArray()
    End Function
End Class
