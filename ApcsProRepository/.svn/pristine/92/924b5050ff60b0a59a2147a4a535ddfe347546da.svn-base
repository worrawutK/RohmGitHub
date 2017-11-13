Public Class SelectEmptySelfConIPMachineDialog

    Private Class GridCellData

        Public Overrides Function ToString() As String
            Return m_SettingData.MCNo
        End Function

        Private m_SettingData As DBxDataSet.FTMachineSettingRow
        Public Property SettingData() As DBxDataSet.FTMachineSettingRow
            Get
                Return m_SettingData
            End Get
            Set(ByVal value As DBxDataSet.FTMachineSettingRow)
                m_SettingData = value
            End Set
        End Property

    End Class

    Private Sub FormSelectMachine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim dt As DBxDataSet.FTMachineSettingDataTable = FtMachineSettingTableAdapter1.GetDataByNullOrEmptySelfConIP()

        Dim rows As Integer = dt.Rows.Count
        Dim colIndex As Integer = -1
        Dim rowIndex As Integer
        Dim cellData As GridCellData
        For Each setting As DBxDataSet.FTMachineSettingRow In dt.Rows
            If colIndex = -1 OrElse colIndex >= DataGridView1.Columns.Count Then
                rowIndex = DataGridView1.Rows.Add()
                colIndex = 0
            End If
            cellData = New GridCellData()
            cellData.SettingData = setting
            DataGridView1.Rows(rowIndex).Cells(colIndex).Value = cellData
            colIndex += 1
        Next
    End Sub

    Private m_SelectedCellData As GridCellData

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value IsNot Nothing Then
            m_SelectedCellData = CType(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, GridCellData)
        End If
    End Sub

    Private m_SelectedSetting As DBxDataSet.FTMachineSettingRow
    Public ReadOnly Property SelectedSetting() As DBxDataSet.FTMachineSettingRow
        Get
            Return m_SelectedSetting
        End Get
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If m_SelectedCellData Is Nothing Then
            Exit Sub
        End If
        m_SelectedSetting = m_SelectedCellData.SettingData
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class