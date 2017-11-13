Public Class FTMachineSettingForm


    Private Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub Init()
        FtpcTypeTableAdapter1.Fill(DBxDataSet.FTPCType)
    End Sub

    Private m_MCNo As String

    Public Function PerformEditSetting(ByVal mcNo As String) As DialogResult
        m_MCNo = mcNo
        m_SavedRow = Nothing
        FTMachineSettingTableAdapter.FillByMCNo(DBxDataSet.FTMachineSetting, m_MCNo)
        Return ShowDialog()
    End Function

    Private m_SavedRow As DBxDataSet.FTMachineSettingRow
    Public ReadOnly Property SavedRow() As DBxDataSet.FTMachineSettingRow
        Get
            Return m_SavedRow
        End Get
    End Property

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Try
            Me.Validate()
            Me.FTMachineSettingBindingSource.EndEdit()
            If FTMachineSettingTableAdapter.Update(DBxDataSet.FTMachineSetting) = 1 Then
                m_SavedRow = CType(DBxDataSet.FTMachineSetting.Rows(0), SelfCon.DBxDataSet.FTMachineSettingRow)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                Me.DialogResult = Windows.Forms.DialogResult.Ignore
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CLButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub FTMachineSettingForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub PDMachineTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDMachineTypeComboBox.SelectedIndexChanged
        Dim index As Integer = FtpcTypeBindingSource.Position
        Dim row As DBxDataSet.FTPCTypeRow = CType(DBxDataSet.FTPCType.Rows(index), SelfCon.DBxDataSet.FTPCTypeRow)
        MachineTypeTextBox.Text = row.PCMain
    End Sub
End Class