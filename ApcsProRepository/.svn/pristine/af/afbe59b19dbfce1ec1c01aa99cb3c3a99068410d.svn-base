Public Class RecordedCommLogEventArgs

    Private m_CommLogText As String
    Public ReadOnly Property CommLogText() As String
        Get
            Return m_CommLogText
        End Get
    End Property

    Public Sub New(ByVal commLogText As String)
        m_CommLogText = commLogText
    End Sub

End Class

Public Delegate Sub RecordedCommLogEventHandler(ByVal sender As Object, ByVal e As RecordedCommLogEventArgs)
