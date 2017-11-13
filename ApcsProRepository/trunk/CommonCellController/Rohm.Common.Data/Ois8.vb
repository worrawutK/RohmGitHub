Public Class Ois8
    Private c_Header As String
    Public Property Header() As String
        Get
            Return c_Header
        End Get
        Set(ByVal value As String)
            c_Header = value
        End Set
    End Property

    Private c_DeviceName As String
    Public Property DeviceName() As String
        Get
            Return c_DeviceName
        End Get
        Set(ByVal value As String)
            c_DeviceName = value
        End Set
    End Property

    Private c_InputRank As String
    Public Property InputRank() As String
        Get
            Return c_InputRank
        End Get
        Set(ByVal value As String)
            c_InputRank = value
        End Set
    End Property

    Private c_ProcessFlow As String
    Public Property ProcessFlow() As String
        Get
            Return c_ProcessFlow
        End Get
        Set(ByVal value As String)
            c_ProcessFlow = value
        End Set
    End Property

    Private c_PackageName As String
    Public Property PackageName() As String
        Get
            Return c_PackageName
        End Get
        Set(ByVal value As String)
            c_PackageName = value
        End Set
    End Property

    Private c_TesterType As String
    Public Property TesterType() As String
        Get
            Return c_TesterType
        End Get
        Set(ByVal value As String)
            c_TesterType = value
        End Set
    End Property

    Private c_BoxName As String
    Public Property BoxName() As String
        Get
            Return c_BoxName
        End Get
        Set(ByVal value As String)
            c_BoxName = value
        End Set
    End Property

    Private c_ProgramName As String
    Public Property ProgramName() As String
        Get
            Return c_ProgramName
        End Get
        Set(ByVal value As String)
            c_ProgramName = value
        End Set
    End Property

End Class
