Public Structure HHMM

    Public Shared Empty As HHMM

    Shared Sub New()
        Empty = New HHMM()
    End Sub

    Private m_Hour As Integer
    Public Property Hour() As Integer
        Get
            Return m_Hour
        End Get
        Set(ByVal value As Integer)
            m_Hour = value
        End Set
    End Property

    Private m_Minute As Integer
    Public Property Minute() As Integer
        Get
            Return m_Minute
        End Get
        Set(ByVal value As Integer)
            m_Minute = value
        End Set
    End Property

    Public Sub New(ByVal hh As Integer, ByVal mm As Integer)
        m_Hour = hh
        m_Minute = mm
    End Sub

    Public Overrides Function ToString() As String
        Return m_Hour & ":" & m_Minute.ToString(FORMAT_INTEGER1)
    End Function

End Structure