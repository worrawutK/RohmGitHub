Public Class AlarmWasClearedEventArgs

    Private m_Alarm As Alarm
    Public ReadOnly Property Alarm() As Alarm
        Get
            Return m_Alarm
        End Get
    End Property

    Public Sub New(ByVal a As Alarm)
        m_Alarm = a
    End Sub

End Class

Public Delegate Sub AlarmWasClearedEventHandler(ByVal sender As Object, ByVal e As AlarmWasClearedEventArgs)
