
<KnownType(GetType(Wire))> _
<DataContract(IsReference:=True)> _
Public Class Material

    Public Sub New(ByVal t As MaterialTypes)
        c_MaterialType = t
        c_ChildMaterialList = New List(Of Material)
    End Sub

    Private c_Id As Integer
    <DataMember()> _
    Public Property Id() As Integer
        Get
            Return c_Id
        End Get
        Set(ByVal value As Integer)
            c_Id = value
        End Set
    End Property

    Private c_Name As String
    <DataMember()> _
    Public Property Name() As String
        Get
            Return c_Name
        End Get
        Set(ByVal value As String)
            c_Name = value
        End Set
    End Property

    Private c_MaterialType As MaterialTypes
    <DataMember()> _
    Public Property MaterialType() As MaterialTypes
        Get
            Return c_MaterialType
        End Get
        Set(ByVal value As MaterialTypes)
            c_MaterialType = value
        End Set
    End Property

    Private c_UsableDate As Date
    <DataMember()> _
    Public Property UsableDate() As Date
        Get
            Return c_UsableDate
        End Get
        Set(ByVal value As Date)
            c_UsableDate = value
        End Set
    End Property

    Private c_ExpiredDate As Date
    <DataMember()> _
    Public Property ExpiredDate() As Date
        Get
            Return c_ExpiredDate
        End Get
        Set(ByVal value As Date)
            c_ExpiredDate = value
        End Set
    End Property

    Private c_WarningDate As Date
    <DataMember()> _
    Public Property WarningDate() As Date
        Get
            Return c_WarningDate
        End Get
        Set(ByVal value As Date)
            c_WarningDate = value
        End Set
    End Property

    Private c_ParentMaterial As Material
    <DataMember()> _
    Public Property ParentMaterial() As Material
        Get
            Return c_ParentMaterial
        End Get
        Set(ByVal value As Material)
            c_ParentMaterial = value
        End Set
    End Property

    Private c_ChildMaterialList As List(Of Material)
    <DataMember()> _
    Public Property ChildMaterialList() As List(Of Material)
        Get
            Return c_ChildMaterialList
        End Get
        Set(ByVal value As List(Of Material))
            c_ChildMaterialList = value
        End Set
    End Property


End Class

<DataContract()> _
Public Enum MaterialTypes
    <EnumMember()> _
    Wire = 0

    <EnumMember()> _
    Frame = 1

    <EnumMember()> _
    Preform = 2

    <EnumMember()> _
    Resin = 3
End Enum