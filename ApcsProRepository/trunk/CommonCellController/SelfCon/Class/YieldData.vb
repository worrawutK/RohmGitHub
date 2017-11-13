Public Class YieldData

    Private m_Output As Integer
    Public Property Output() As Integer
        Get
            Return m_Output
        End Get
        Set(ByVal value As Integer)
            m_Output = value
        End Set
    End Property

    Private m_Good As Integer
    Public Property Good() As Integer
        Get
            Return m_Good
        End Get
        Set(ByVal value As Integer)
            m_Good = value
        End Set
    End Property

    Private m_YieldValue As Single
    Public Property YieldValue() As Single
        Get
            Return m_YieldValue
        End Get
        Set(ByVal value As Single)
            m_YieldValue = value
        End Set
    End Property

    Private m_Channel As MachineChannelType
    Public Property Channel() As MachineChannelType
        Get
            Return m_Channel
        End Get
        Set(ByVal value As MachineChannelType)
            m_Channel = value
        End Set
    End Property

    Private m_Comment As String
    Public Property Comment() As String
        Get
            Return m_Comment
        End Get
        Set(ByVal value As String)
            m_Comment = value
        End Set
    End Property


End Class