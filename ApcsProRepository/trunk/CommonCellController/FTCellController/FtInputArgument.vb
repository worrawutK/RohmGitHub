Imports Rohm.Common.CellController

Public Class FtInputArgument
    Implements IInputArgument

    Private c_WorkSlip As AssySlip252
    Public Property WorkSlip() As AssySlip252
        Get
            Return c_WorkSlip
        End Get
        Set(ByVal value As AssySlip252)
            c_WorkSlip = value
        End Set
    End Property

    Private c_Ois As Ois8
    Public Property Ois() As Ois8
        Get
            Return c_Ois
        End Get
        Set(ByVal value As Ois8)
            c_Ois = value
        End Set
    End Property

    Private c_InputQty As Integer
    Public Property InputQty() As Integer
        Get
            Return c_InputQty
        End Get
        Set(ByVal value As Integer)
            c_InputQty = value
        End Set
    End Property

    Private c_MCNo As String
    Public Property MCNo() As String
        Get
            Return c_MCNo
        End Get
        Set(ByVal value As String)
            c_MCNo = value
        End Set
    End Property

    Private c_EmployeeCode As String
    Public Property EmployeeCode() As String
        Get
            Return c_EmployeeCode
        End Get
        Set(ByVal value As String)
            c_EmployeeCode = value
        End Set
    End Property

    Public Function GetInputQty() As Integer Implements Rohm.Common.CellController.IInputArgument.GetInputQty
        Return c_InputQty
    End Function

    Public Function GetInputUnit() As String Implements Rohm.Common.CellController.IInputArgument.GetInputUnit
        Return "Pcs"
    End Function

    Public Function GetLotNo() As String Implements Rohm.Common.CellController.IInputArgument.GetLotNo
        Return c_WorkSlip.LotNo
    End Function

    Public Function GetLotType() As String Implements Rohm.Common.CellController.IInputArgument.GetLotType
        Return "AssyLot"
    End Function

    Public Function GetMCNo() As String Implements Rohm.Common.CellController.IInputArgument.GetMCNo
        Return c_MCNo
    End Function

    Public Function GetEmployeeCode() As String Implements Rohm.Common.CellController.IInputArgument.GetEmployeeCode
        Return c_EmployeeCode
    End Function
End Class
