
<DataContract(IsReference:=True)> _
Public Class Wire
    Inherits Material

    Public Sub New()
        MyBase.new(MaterialTypes.Wire)
    End Sub

    Private c_WireType As WireTypes
    Public Property WireType() As WireTypes
        Get
            Return c_WireType
        End Get
        Set(ByVal value As WireTypes)
            c_WireType = value
        End Set
    End Property

End Class

<DataContract()> _
Public Enum WireTypes
    <EnumMember()> _
    GoldWire = 0
    <EnumMember()> _
    CopperWire = 1
End Enum
