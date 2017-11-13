Public Class AlarmTable

    Private Shared m_Table As DBxDataSet.FTAlarmTableDataTable

    Public Shared Sub LoadAllAlarm()
        Using adaptor As DBxDataSetTableAdapters.FTAlarmTableTableAdapter = New DBxDataSetTableAdapters.FTAlarmTableTableAdapter()
            m_Table = adaptor.GetData()
        End Using
    End Sub

    Public Shared Function GetAlarm(ByVal alarmNo As String, ByVal mcType As String) As Alarm
        Dim selectedRows As DBxDataSet.FTAlarmTableRow() = CType(m_Table.Select( _
             String.Format("AlarmNo = '{0}' AND MachineType = '{1}'", alarmNo, mcType)),  _
             DBxDataSet.FTAlarmTableRow())
        Dim a As Alarm = Nothing
        If selectedRows.Length = 1 Then
            a = New Alarm(selectedRows(0))
        Else
            a = Alarm.CreateUnknow(alarmNo)
        End If
        Return a
    End Function

    Private Sub New()
    End Sub

End Class
