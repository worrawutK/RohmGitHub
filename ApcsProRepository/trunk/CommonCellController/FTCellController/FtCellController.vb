Imports Rohm.Common.CellController

Public Class FtCellController
    Inherits CellControllerBase

    Protected Overrides Function GetCellControllerFileVersions() As FileVersion()
        Dim fileVersionList As List(Of FileVersion) = New List(Of FileVersion)

        Dim versionChecker As FileVersionChecker = New FileVersionChecker()

        fileVersionList.Add(versionChecker.GetFileVersion("FTCellController.exe"))
        fileVersionList.Add(versionChecker.GetFileVersion("Rohm.Common.CellController.dll"))


        Return fileVersionList.ToArray()
    End Function

    Protected Overrides Function GetLotSettingUpData() As LotSettingUp

        Dim input As LotSettingUp = New LotSettingUp()
        Dim ftInput As FtInputArgument = New FtInputArgument()

        input.InputArgument = ftInput

        OperatorPanel.GetOis8()

        'ftInput.WorkSlip = OperatorPanel.GetAssySlip252()
        'If ftInput.WorkSlip Is Nothing Then
        '    input.Cancel = True
        '    Return input
        'End If

        'ftInput.Ois = OperatorPanel.GetOis8()
        'If ftInput.Ois Is Nothing Then
        '    input.Cancel = True
        '    Return input
        'End If

        'ftInput.InputQty = OperatorPanel.GetInputQty()
        'If ftInput.InputQty = 0 Then
        '    input.Cancel = True
        '    Return input
        'End If

        input.Cancel = False
        Return input

    End Function

    Protected Overrides Function GetSetupFunctionName() As String
        Return "FT-SetupLot"
    End Function

    Protected Overrides Sub SendRecipe()
        Dim mcRecipe As String = Service.GetMachineRecipe("")

        Dim testerRecipe As String = Service.GetTesterRecipe("", "", "")

        'send recipe to machine

        'send recipe to tester

        Dim a As ICollection(Of String) = New List(Of String)
        a = New Queue(Of String)
        Dim b As IEnumerable(Of String) = New Queue(Of String)



    End Sub

    Protected Overrides Function ValidateInputData(ByVal validationInput As ValidationInputParameter) As ValidationInputDataResult
        Dim input As FtInputArgument = CType(validationInput.InputArguments, FtInputArgument)
        Dim validationResult As ValidationInputDataResult = New ValidationInputDataResult()

        Return validationResult
    End Function

    Protected Overrides Sub Initialize()
        'load machine from data base
    End Sub

    Protected Overrides Sub OnSetupCompleted()

    End Sub
End Class
