Public Class Jig

    Private m_QRCode As String
    Public Property QRCode() As String
        Get
            Return m_QRCode
        End Get
        Set(ByVal value As String)
            m_QRCode = value
        End Set
    End Property

    Private m_SmallCode As String
    Public Property SmallCode() As String
        Get
            Return m_SmallCode
        End Get
        Set(ByVal value As String)
            m_SmallCode = value
        End Set
    End Property

End Class
