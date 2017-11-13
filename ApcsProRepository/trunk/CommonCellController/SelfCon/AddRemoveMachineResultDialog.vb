Imports System.Threading
Imports System.Net.NetworkInformation

Public Class AddRemoveMachineResultDialog

    Private Shared m_Instance As AddRemoveMachineResultDialog

    Public Shared Function GetInstance() As AddRemoveMachineResultDialog
        If m_Instance Is Nothing OrElse m_Instance.IsDisposed Then
            m_Instance = New AddRemoveMachineResultDialog()
        End If
        Return m_Instance
    End Function

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private m_AutoHide As Boolean = False

    Public Sub SetDisplay(ByVal autoMode As Boolean, ByVal affectedRow As Integer, ByVal pResult As IPStatus, _
                           ByVal moxaIP As String, ByVal oldSelfConIP As String, ByVal newSelfConIP As String, _
                           ByVal changeMoxaComplete As Boolean, ByVal saveComplete As Boolean, ByVal isComplete As Boolean)


        If autoMode Then
            'IPSTATUS
            lblPingResult.Text = pResult.ToString()
            If pResult = IPStatus.Success Then
                lblPingResult.ForeColor = Color.Green
            Else
                lblPingResult.ForeColor = Color.Red
            End If

            If changeMoxaComplete Then
                lblChangeMoxaSettingResult.Text = "OK"
                lblChangeMoxaSettingResult.ForeColor = Color.Green
            Else
                lblChangeMoxaSettingResult.Text = "Failed"
                lblChangeMoxaSettingResult.ForeColor = Color.Red
            End If

            If saveComplete Then
                lblSaveMoxaSettingResult.Text = "OK"
                lblSaveMoxaSettingResult.ForeColor = Color.Green
            Else
                lblSaveMoxaSettingResult.Text = "Failed"
                lblSaveMoxaSettingResult.ForeColor = Color.Red
            End If

            lblPingToMoxaIP.Text = moxaIP
            lblSelfConIpFrom.Text = oldSelfConIP
            lblSelfConIPTo.Text = newSelfConIP

        Else

            lblPingResult.Text = "Skip"
            lblPingToMoxaIP.Text = ""
            lblChangeMoxaSettingResult.Text = "Skip"
            lblSelfConIpFrom.Text = ""
            lblSelfConIPTo.Text = ""
            lblSaveMoxaSettingResult.Text = "Skip"
        End If

        If affectedRow = 1 Then
            lblUpdateDatabaseResult.Text = "OK"
            lblUpdateDatabaseResult.ForeColor = Color.Green
        Else
            lblUpdateDatabaseResult.Text = "Failed"
            lblUpdateDatabaseResult.ForeColor = Color.Red
        End If


        m_AutoHide = isComplete

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub AddRemoveMachineResultDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If m_AutoHide Then
            Timer1.Start()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class