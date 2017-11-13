Public Delegate Sub MachineStateChangedEventHandler(ByVal sender As Object, ByVal e As MachineStateChangedEventArgs)

Public Class MachineStateChangedEventArgs

    Private m_PreviousState As MachineStateType
    Public Property PreviousState() As MachineStateType
        Get
            Return m_PreviousState
        End Get
        Private Set(ByVal value As MachineStateType)
            m_PreviousState = value
        End Set
    End Property

    Private m_CurrentState As MachineStateType
    Public Property CurrentState() As MachineStateType
        Get
            Return m_CurrentState
        End Get
        Private Set(ByVal value As MachineStateType)
            m_CurrentState = value
        End Set
    End Property

    Public Sub New(ByVal current As MachineStateType, ByVal previous As MachineStateType)
        m_CurrentState = current
        m_PreviousState = previous
    End Sub

End Class
