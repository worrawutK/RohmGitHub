Imports System.IO
Imports Rohm
Imports System.Text

Public Class AutoLoadTestProgramDialog

    Private Shared m_Instance As AutoLoadTestProgramDialog

    Public Shared Function GetInstatnce() As AutoLoadTestProgramDialog
        If m_Instance Is Nothing OrElse m_Instance.IsDisposed Then
            m_Instance = New AutoLoadTestProgramDialog()
        End If
        Return m_Instance
    End Function

    Private Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private m_Autoloadings As List(Of Autoloading)

    Public Sub PerformAutoLoad(ByVal autoloadList As List(Of Autoloading))
        m_Autoloadings = autoloadList
        AutoLoadingBindingSource.DataSource = m_Autoloadings
        ShowDialog()
    End Sub

    Private Sub btnAutoLoad1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoLoad1.Click
        Dim au As Autoloading = m_Autoloadings(AutoLoadDataRepeater.CurrentItemIndex)
        Dim btn As Button = CType(sender, Button)
        If au.IsLoading Then
            au.[Stop]()
            btn.Image = My.Resources.btautol
        Else
            au.Start()
            btn.Image = My.Resources.btautoc
            AddHandler au.AutoLoadFinished, AddressOf au_AutoLoadFinished
            AddHandler au.AutoLoadAborted, AddressOf au_AutoLoadAbortedAndTimedOut
            AddHandler au.AutoLoadTimedout, AddressOf au_AutoLoadAbortedAndTimedOut
        End If
    End Sub

    Private Sub au_AutoLoadAbortedAndTimedOut(ByVal sender As Object, ByVal e As EventArgs)
        Dim au As Autoloading = CType(sender, Autoloading)
        Dim idx As Integer = m_Autoloadings.IndexOf(au)
        AutoLoadDataRepeater.CurrentItemIndex = idx
        Dim foundControls As Control() = AutoLoadDataRepeater.CurrentItem.Controls.Find("lblLoadans1", False)
        foundControls(0).ForeColor = Color.Black
        foundControls(0).BackColor = Color.Yellow
        foundControls = AutoLoadDataRepeater.CurrentItem.Controls.Find("btnAutoLoad1", False)
        Dim btn As Button = CType(foundControls(0), Button)
        btn.Image = My.Resources.btautol
        RemoveHandler au.AutoLoadFinished, AddressOf au_AutoLoadFinished
        RemoveHandler au.AutoLoadAborted, AddressOf au_AutoLoadAbortedAndTimedOut
        RemoveHandler au.AutoLoadTimedout, AddressOf au_AutoLoadAbortedAndTimedOut
    End Sub

    Private Sub au_AutoLoadFinished(ByVal sender As Object, ByVal e As EventArgs)
        Dim au As Autoloading = CType(sender, Autoloading)
        Dim idx As Integer = m_Autoloadings.IndexOf(au)
        AutoLoadDataRepeater.CurrentItemIndex = idx
        Dim foundControls As Control() = AutoLoadDataRepeater.CurrentItem.Controls.Find("lblLoadans1", False)
        If au.ProgramName = au.LoadAns Then
            foundControls(0).ForeColor = Color.Green
        Else
            foundControls(0).ForeColor = Color.Red
        End If
        foundControls(0).BackColor = Color.Black
        foundControls = AutoLoadDataRepeater.CurrentItem.Controls.Find("btnAutoLoad1", False)
        Dim btn As Button = CType(foundControls(0), Button)
        btn.Image = My.Resources.btautol
        RemoveHandler au.AutoLoadFinished, AddressOf au_AutoLoadFinished
        RemoveHandler au.AutoLoadAborted, AddressOf au_AutoLoadAbortedAndTimedOut
        RemoveHandler au.AutoLoadTimedout, AddressOf au_AutoLoadAbortedAndTimedOut

    End Sub

    Private Sub lblTesterMailBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTesterMailBox1.Click
        Dim lbl As Label = CType(sender, Label)
        Process.Start("explorer.exe", lbl.Text)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If AllAutoloadIsFinished() Then
            Me.Close()
        Else
            If ConfirmationDialog.AskForConfirmation("การ Autoload ยังทำงานไม่เสร็จจะยกเลิกหรือไม่ ?") = Windows.Forms.DialogResult.OK Then
                CancelAllAutoload()
                Me.Close()
            End If
        End If

    End Sub

    Private Sub CancelAllAutoload()
        For Each au As Autoloading In m_Autoloadings
            If au.IsLoading Then
                au.Stop()
            End If
        Next
    End Sub

    Private Function AllAutoloadIsFinished() As Boolean
        Dim ret As Boolean = True
        For Each au As Autoloading In m_Autoloadings
            If au.IsLoading Then
                ret = False
                Exit For
            End If
        Next
        Return ret
    End Function

End Class