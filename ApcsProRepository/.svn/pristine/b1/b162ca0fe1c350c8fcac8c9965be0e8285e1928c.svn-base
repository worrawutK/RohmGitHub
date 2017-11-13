
Public Structure ProductOutput

    Public Shared ReadOnly Zero As ProductOutput

    Shared Sub New()
        Zero = New ProductOutput()
    End Sub

    Public Sub New(ByVal goodCh1 As Integer, ByVal goodCh2 As Integer, ByVal ngCh1 As Integer, ByVal ngCh2 As Integer)
        m_Good.CH1 = goodCh1
        m_Good.CH2 = goodCh2
        m_NG.CH1 = ngCh1
        m_NG.CH2 = ngCh2
    End Sub

    Private m_Good As ProductQty
    Public Property Good() As ProductQty
        Get
            Return m_Good
        End Get
        Set(ByVal value As ProductQty)
            m_Good = value
        End Set
    End Property

    Private m_NG As ProductQty
    Public Property NG() As ProductQty
        Get
            Return m_NG
        End Get
        Set(ByVal value As ProductQty)
            m_NG = value
        End Set
    End Property

    Public ReadOnly Property CH1() As Integer
        Get
            Return m_Good.CH1 + m_NG.CH1
        End Get
    End Property

    Public ReadOnly Property CH2() As Integer
        Get
            Return m_Good.CH2 + m_NG.CH2
        End Get
    End Property

    Public ReadOnly Property Total() As Integer
        Get
            Return m_Good.Total + m_NG.Total
        End Get
    End Property

    Public Shared Operator =(ByVal p1 As ProductOutput, ByVal p2 As ProductOutput) As Boolean
        Return p1.Good = p2.Good AndAlso p1.NG = p2.NG
    End Operator

    Public Shared Operator <>(ByVal p1 As ProductOutput, ByVal p2 As ProductOutput) As Boolean
        Return p1.Good <> p2.Good OrElse p1.NG <> p2.NG
    End Operator

    Public Overrides Function ToString() As String
        Return "Good:{ CH1:" & m_Good.CH1.ToString() & ", CH2:" & m_Good.CH2.ToString() & " }. NG {CH1:" & m_NG.CH1.ToString() & ", CH2:" & m_NG.CH2.ToString() & "}"
    End Function

End Structure
