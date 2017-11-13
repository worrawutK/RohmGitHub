<DataContract()> _
Public Class Ois10
    Private c_Header As String
    <DataMember()> _
    Public Property Header() As String
        Get
            Return c_Header
        End Get
        Set(ByVal value As String)
            c_Header = value
        End Set
    End Property

    Private c_DeviceName As String
    <DataMember()> _
    Public Property DeviceName() As String
        Get
            Return c_DeviceName
        End Get
        Set(ByVal value As String)
            c_DeviceName = value
        End Set
    End Property

    Private c_InputRank As String
    <DataMember()> _
    Public Property InputRank() As String
        Get
            Return c_InputRank
        End Get
        Set(ByVal value As String)
            c_InputRank = value
        End Set
    End Property

    Private c_ProcessFlow As String
    <DataMember()> _
    Public Property ProcessFlow() As String
        Get
            Return c_ProcessFlow
        End Get
        Set(ByVal value As String)
            c_ProcessFlow = value
        End Set
    End Property

    Private c_PackageName As String
    <DataMember()> _
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
    <DataMember()> _
    Public Property BoxName() As String
        Get
            Return c_BoxName
        End Get
        Set(ByVal value As String)
            c_BoxName = value
        End Set
    End Property

    Private c_ProgramName As String
    <DataMember()> _
    Public Property ProgramName() As String
        Get
            Return c_ProgramName
        End Get
        Set(ByVal value As String)
            c_ProgramName = value
        End Set
    End Property

    Private c_MultiNumber As String
    <DataMember()> _
    Public Property MultiNumber() As String
        Get
            Return c_MultiNumber
        End Get
        Set(ByVal value As String)
            c_MultiNumber = value
        End Set
    End Property

    Private c_LayoutPattern As String
    <DataMember()> _
    Public Property LayoutPattern() As String
        Get
            Return c_LayoutPattern
        End Get
        Set(ByVal value As String)
            c_LayoutPattern = value
        End Set
    End Property
End Class
