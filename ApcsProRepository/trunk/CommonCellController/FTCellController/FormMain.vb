Imports Rohm.Common.CellController
Imports Rohm.Common.Forms
Imports Rohm.Common.Model
Imports Rohm.DataAccess
Imports System.Text.RegularExpressions

Public Class FormMain
    Implements IOperatorPanel

    Private c_CellController As CellControllerBase
    Public Property CellController() As Rohm.Common.CellController.CellControllerBase Implements Rohm.Common.CellController.IOperatorPanel.CellController
        Get
            Return c_CellController
        End Get
        Set(ByVal value As Rohm.Common.CellController.CellControllerBase)
            c_CellController = value
        End Set
    End Property

    Public Function GetAssySlip252() As Rohm.Common.Model.AssySlip252 Implements Rohm.Common.CellController.IOperatorPanel.GetAssySlip252
        Dim ret As AssySlip252 = Nothing
        Using input As InputAssySlip252Dialog = New InputAssySlip252Dialog()
            If input.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ret = input.InputValue
            End If
        End Using
        Return ret
    End Function

    Public Function GetEmployeeCode() As String Implements Rohm.Common.CellController.IOperatorPanel.GetEmployeeCode
        Dim code As String = InputBox("Please input user code:")
        Return code
    End Function

    Public Function GetInputQty() As Integer Implements Rohm.Common.CellController.IOperatorPanel.GetInputQty
        Return CInt(InputBox("please input Qty"))
    End Function

    Public Function GetOis8() As Rohm.Common.Model.Ois8 Implements Rohm.Common.CellController.IOperatorPanel.GetOis8

        Dim ret As Ois8 = Nothing

        Using frm As InputOis8Dialog = New InputOis8Dialog()
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ret = frm.InputValue
            End If
        End Using

        Return ret
    End Function

    Public Sub ShowErrorMessage(ByVal message As String) Implements Rohm.Common.CellController.IOperatorPanel.ShowErrorMessage
        MsgBox(message)
    End Sub

    Private c_MachineRepository As MachineRepository

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        c_MachineRepository = New MachineRepository("")

        c_CellController = New FtCellController()
        c_CellController.OperatorPanel = Me

        Dim machineArray As Machine() = c_MachineRepository.GetMachineByCellControllerIp("")
        c_CellController.MachineList.AddRange(machineArray)

        c_CellController.Service = New MockupApcsProService()

        c_CellController.StartCellController()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        c_CellController.Setup()
    End Sub

    Public Function GetOis10() As Rohm.Common.Model.Ois10 Implements Rohm.Common.CellController.IOperatorPanel.GetOis10
        Return New Ois10()
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        c_CellController.StartProduction()
    End Sub

    Public Function SelectMachine(ByVal availableMachineArray() As Rohm.Common.Model.Machine) As Rohm.Common.Model.Machine Implements Rohm.Common.CellController.IOperatorPanel.SelectMachine
        Dim ret As Machine = Nothing
        Using frm As SelectMachineDialog = New SelectMachineDialog()
            frm.Datasource = availableMachineArray
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ret = frm.SelectedMachine
            End If
        End Using
        Return ret
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim checker As FileVersionChecker = New FileVersionChecker()
        Dim fv As FileVersion = checker.GetFileVersion("Rohm.Common.CellController.dll")
        MsgBox(fv.CheckSum)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim autoloadStep1 As TextFileTestProgramAutoloader = New TextFileTestProgramAutoloader()
        autoloadStep1.CheckInterval = 1000
        autoloadStep1.MailboxDirectory = "D:\MailBox\1001"
        autoloadStep1.TimeoutDuration = New TimeSpan(0, 1, 0)
        AddHandler autoloadStep1.AutoLoadFinished, AddressOf TextFileTestProgramAutoloader_AutoLoadFinished
        AddHandler autoloadStep1.AutoLoadTimedout, AddressOf TextFileTestProgramAutoloader_TimedOut
        autoloadStep1.WriteLoadInformation("M-001", "A", "BD9999FVM-XX", "AUTO1", "TO258-X", "ICT6789", "FD9999FVMA1", "1799A9999V", "0")

        'Dim autoloadStep2 As TestProgramAutoloaderComment = New TestProgramAutoloaderComment(autoloadStep1)
        'autoloadStep2.CommentFileName = "D:\MailBox\1001\SelfCon.txt"
        'autoloadStep2.CommentText = "M-01 did auto loading test program."
        'autoloadStep2.WriteLoadInformation("M-001", "A", "BD9999FVM-XX", "AUTO1", "TO258-X", "ICT6789", "FD9999FVMA1", "1799A9999V", "0")

        'Dim autoloadStep3 As TestProgramAutoloaderSecure = New TestProgramAutoloaderSecure(autoloadStep1)
        'autoloadStep3.FunctionName = "Autoloading"
        'autoloadStep3.Panel = Me
        'autoloadStep3.Service = c_CellController.Service
        'autoloadStep3.WriteLoadInformation("M-001", "A", "BD9999FVM-XX", "AUTO1", "TO258-X", "ICT6789", "FD9999FVMA1", "1799A9999V", "0")

    End Sub

    Private Sub TextFileTestProgramAutoloader_AutoLoadFinished(ByVal sender As Object, ByVal e As EventArgs)
        Dim au1 As TextFileTestProgramAutoloader = CType(sender, TextFileTestProgramAutoloader)
        MsgBox(au1.LoadAnswer)
    End Sub

    Private Sub TextFileTestProgramAutoloader_TimedOut(ByVal sender As Object, ByVal e As EventArgs)
        Dim au1 As TextFileTestProgramAutoloader = CType(sender, TextFileTestProgramAutoloader)
        MsgBox(au1.LoadAnswer)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim reg As Regex = New Regex("^\d{4}[a-zA-Z]\d{4}[a-zA-Z]")
        MsgBox(reg.Match("1243X4567v").Success)

    End Sub

    Private c_ReportForm As Form
    Public Property ReportForm() As System.Windows.Forms.Form Implements Rohm.Common.CellController.IOperatorPanel.ReportForm
        Get
            Return c_ReportForm
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            c_ReportForm = value
        End Set
    End Property

    Private c_SpecialOperationForm As Form
    Public Property SpecialOperationForm() As System.Windows.Forms.Form Implements Rohm.Common.CellController.IOperatorPanel.SpcialOperationForm
        Get
            Return c_SpecialOperationForm
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            c_SpecialOperationForm = value
        End Set
    End Property

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        c_ReportForm.Show()
    End Sub

    Public Function GetAssySlip332() As Rohm.Common.Model.AssySlip332 Implements Rohm.Common.CellController.IOperatorPanel.GetAssySlip332
        Dim ret As AssySlip332 = Nothing
        Using input As InputAssySlip332Dialog = New InputAssySlip332Dialog()
            If input.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ret = input.InputValue
            End If
        End Using
        Return ret
    End Function

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

    End Sub

    Public Function GetDicingSlip254() As Rohm.Common.Model.DicingSlip254 Implements Rohm.Common.CellController.IOperatorPanel.GetDicingSlip254
        Dim ret As DicingSlip254 = Nothing
        Using frm As InputDicingSlip254Dialog = New InputDicingSlip254Dialog()
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ret = frm.InputValue
            End If
        End Using
        Return ret
    End Function

    Public Function GetDicingSlip276() As Rohm.Common.Model.DicingSlip276 Implements Rohm.Common.CellController.IOperatorPanel.GetDicingSlip276
        Dim ret As DicingSlip276 = Nothing
        Using frm As InputDicingSlip276Dialog = New InputDicingSlip276Dialog()
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ret = frm.InputValue
            End If
        End Using
        Return ret
    End Function

    Public Function GetUser() As Rohm.Common.Model.User Implements Rohm.Common.CellController.IOperatorPanel.GetUser
        Dim ret As User = Nothing
        Using frm As InputUserCodeDialog = New InputUserCodeDialog()
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ret = frm.InputValue
            End If
        End Using
        Return ret
    End Function

    Public Function GetUserWithPasswordCheck() As Rohm.Common.Model.User Implements Rohm.Common.CellController.IOperatorPanel.GetUserWithPasswordCheck
        Dim ret As User = Nothing
        Using frm As InputUserPasswordDialog = New InputUserPasswordDialog()
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ret = frm.InputValue
            End If
        End Using
        Return ret
    End Function
End Class