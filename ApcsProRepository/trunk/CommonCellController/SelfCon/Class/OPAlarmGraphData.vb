<Serializable()> _
Public Class OPAlarmGraphData

    Private m_AlarmCount As Integer
    Public Property AlarmCount() As Integer
        Get
            Return m_AlarmCount
        End Get
        Set(ByVal value As Integer)
            m_AlarmCount = value
        End Set
    End Property

    Private m_Duration As Double
    Public Property Duration() As Double
        Get
            Return m_Duration
        End Get
        Set(ByVal value As Double)
            m_Duration = value
        End Set
    End Property

    Private m_LabelX As String
    Public Property LabelX() As String
        Get
            Return m_LabelX
        End Get
        Set(ByVal value As String)
            m_LabelX = value
        End Set
    End Property

    Private m_MTTR As Double
    Public Property MTTR() As Double
        Get
            Return m_MTTR
        End Get
        Set(ByVal value As Double)
            m_MTTR = value
        End Set
    End Property

    Public Sub New()
    End Sub

End Class
