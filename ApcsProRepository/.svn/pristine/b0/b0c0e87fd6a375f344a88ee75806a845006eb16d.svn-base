Public Structure ProductQty

    Private m_CH1 As Integer
    Public Property CH1() As Integer
        Get
            Return m_CH1
        End Get
        Set(ByVal value As Integer)
            m_CH1 = value
            m_Total = m_CH1 + m_CH2
        End Set
    End Property

    Private m_CH2 As Integer
    Public Property CH2() As Integer
        Get
            Return m_CH2
        End Get
        Set(ByVal value As Integer)
            m_CH2 = value
            m_Total = m_CH1 + m_CH2
        End Set
    End Property


    Private m_Total As Integer
    Public ReadOnly Property Total() As Integer
        Get
            Return m_CH1 + m_CH2
        End Get
    End Property

    Public Sub New(ByVal ch1 As Integer, ByVal ch2 As Integer)
        m_CH1 = ch1
        m_CH2 = ch2
        m_Total = m_CH1 + m_CH2
    End Sub

    Public Shared Operator +(ByVal p1 As ProductQty, ByVal p2 As ProductQty) As ProductQty
        Return New ProductQty(p1.CH1 + p2.CH1, p1.CH2 + p2.CH2)
    End Operator

    Public Shared Operator -(ByVal p1 As ProductQty, ByVal p2 As ProductQty) As ProductQty
        Return New ProductQty(p1.CH1 - p2.CH1, p1.CH2 - p2.CH2)
    End Operator

    Public Shared Operator =(ByVal p1 As ProductQty, ByVal p2 As ProductQty) As Boolean
        Return p1.m_Total = p2.m_Total
    End Operator

    Public Shared Operator <>(ByVal p1 As ProductQty, ByVal p2 As ProductQty) As Boolean
        Return p1.m_Total <> p2.m_Total
    End Operator

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is ProductQty Then
            Return False
        End If
        Dim a As ProductQty = DirectCast(obj, ProductQty)
        Return a.CH1 = m_CH1 AndAlso a.CH2 = m_CH2
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return m_CH1 Xor m_CH2
    End Function

    Public Overrides Function ToString() As String
        Return "{" & m_CH1 & "," & m_CH2 & "}"
    End Function

End Structure
