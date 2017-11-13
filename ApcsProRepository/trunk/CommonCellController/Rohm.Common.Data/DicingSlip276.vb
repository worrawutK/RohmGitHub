Public Class DicingSlip276

    Public Sub New(ByVal qrcode As String)
        FullCode = qrcode
    End Sub


    Private Sub SeperateData(ByVal qrCode As String)

        If qrCode.Length = 276 Then
            Try
                Wafer = CInt(qrCode.Substring(32, 2))
                Chip = qrCode.Substring(0, 20)
                WfLotNo = qrCode.Substring(20, 12)
                DeviceName = qrCode.Substring(234, 20)
                OrderNo = qrCode.Substring(254, 12)
                DCCode = qrCode.Substring(266, 4)
                Plasma = qrCode.Substring(270, 1)
                CodeNo = qrCode.Substring(271, 5)

                WfNo1 = qrCode.Substring(34, 2)
                WfNo2 = qrCode.Substring(42, 2)
                WfNo3 = qrCode.Substring(50, 2)
                WfNo4 = qrCode.Substring(58, 2)
                WfNo5 = qrCode.Substring(66, 2)
                WfNo6 = qrCode.Substring(74, 2)
                WfNo7 = qrCode.Substring(82, 2)
                WfNo8 = qrCode.Substring(90, 2)
                WfNo9 = qrCode.Substring(98, 2)
                WfNo10 = qrCode.Substring(106, 2)
                WfNo11 = qrCode.Substring(114, 2)
                WfNo12 = qrCode.Substring(122, 2)
                WfNo13 = qrCode.Substring(130, 2)
                WfNo14 = qrCode.Substring(138, 2)
                WfNo15 = qrCode.Substring(146, 2)
                WfNo16 = qrCode.Substring(154, 2)
                WfNo17 = qrCode.Substring(162, 2)
                WfNo18 = qrCode.Substring(170, 2)
                WfNo19 = qrCode.Substring(178, 2)
                WfNo20 = qrCode.Substring(186, 2)
                WfNo21 = qrCode.Substring(194, 2)
                WfNo22 = qrCode.Substring(202, 2)
                WfNo23 = qrCode.Substring(210, 2)
                WfNo24 = qrCode.Substring(218, 2)
                WfNo25 = qrCode.Substring(226, 2)

                WaQtyNo1 = qrCode.Substring(36, 6)
                WaQtyNo2 = qrCode.Substring(44, 6)
                WaQtyNo3 = qrCode.Substring(52, 6)
                WaQtyNo4 = qrCode.Substring(60, 6)
                WaQtyNo5 = qrCode.Substring(68, 6)
                WaQtyNo6 = qrCode.Substring(76, 6)
                WaQtyNo7 = qrCode.Substring(84, 6)
                WaQtyNo8 = qrCode.Substring(92, 6)
                WaQtyNo9 = qrCode.Substring(100, 6)
                WaQtyNo10 = qrCode.Substring(108, 6)
                WaQtyNo11 = qrCode.Substring(116, 6)
                WaQtyNo12 = qrCode.Substring(124, 6)
                WaQtyNo13 = qrCode.Substring(132, 6)
                WaQtyNo14 = qrCode.Substring(140, 6)
                WaQtyNo15 = qrCode.Substring(148, 6)
                WaQtyNo16 = qrCode.Substring(156, 6)
                WaQtyNo17 = qrCode.Substring(164, 6)
                WaQtyNo18 = qrCode.Substring(172, 6)
                WaQtyNo19 = qrCode.Substring(180, 6)
                WaQtyNo20 = qrCode.Substring(188, 6)
                WaQtyNo21 = qrCode.Substring(196, 6)
                WaQtyNo22 = qrCode.Substring(204, 6)
                WaQtyNo23 = qrCode.Substring(212, 6)
                WaQtyNo24 = qrCode.Substring(220, 6)
                WaQtyNo25 = qrCode.Substring(228, 6)

                WaferNo = GetWfNo(Wafer)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Throw New ApplicationException("Wrong data")
            Exit Sub
        End If

    End Sub
    Private Function GetWfNo(ByVal qty As Integer) As String
        Dim ret As String = Nothing
        Select Case qty
            Case 1
                ret = WfNo1
            Case 2
                ret = WfNo1 & " - " & WfNo2
            Case 3
                ret = WfNo1 & " - " & WfNo3
            Case 4
                ret = WfNo1 & " - " & WfNo4
            Case 5
                ret = WfNo1 & " - " & WfNo5
            Case 6
                ret = WfNo1 & " - " & WfNo6
            Case 7
                ret = WfNo1 & " - " & WfNo7
            Case 8
                ret = WfNo1 & " - " & WfNo8
            Case 9
                ret = WfNo1 & " - " & WfNo9
            Case 10
                ret = WfNo1 & " - " & WfNo10
            Case 11
                ret = WfNo1 & " - " & WfNo11
            Case 12
                ret = WfNo1 & " - " & WfNo12
            Case 13
                ret = WfNo1 & " - " & WfNo13
            Case 14
                ret = WfNo1 & " - " & WfNo14
            Case 15
                ret = WfNo1 & " - " & WfNo15
            Case 16
                ret = WfNo1 & " - " & WfNo16
            Case 17
                ret = WfNo1 & " - " & WfNo17
            Case 18
                ret = WfNo1 & " - " & WfNo18
            Case 19
                ret = WfNo1 & " - " & WfNo19
            Case 20
                ret = WfNo1 & " - " & WfNo20
            Case 21
                ret = WfNo1 & " - " & WfNo21
            Case 22
                ret = WfNo1 & " - " & WfNo22
            Case 23
                ret = WfNo1 & " - " & WfNo23
            Case 24
                ret = WfNo1 & " - " & WfNo24
            Case 25
                ret = WfNo1 & " - " & WfNo25
        End Select
        Return ret
    End Function

#Region "Data"
    Private c_FullCode As String
    Public Property FullCode() As String
        Get
            Return c_FullCode
        End Get
        Set(ByVal value As String)
            c_FullCode = value
            SeperateData(c_FullCode)
        End Set
    End Property

    Private c_Chip As String
    Public Property Chip() As String
        Get
            Return c_Chip
        End Get
        Set(ByVal value As String)
            c_Chip = value
        End Set
    End Property

    Private c_WfLotNo As String
    Public Property WfLotNo() As String
        Get
            Return c_WfLotNo
        End Get
        Set(ByVal value As String)
            c_WfLotNo = value
        End Set
    End Property

    Private c_Wafer As Integer
    Public Property Wafer() As Integer
        Get
            Return c_Wafer
        End Get
        Set(ByVal value As Integer)
            c_Wafer = value
        End Set
    End Property

    Private c_WfNo1 As String
    Public Property WfNo1() As String
        Get
            Return c_WfNo1
        End Get
        Set(ByVal value As String)
            c_WfNo1 = value
        End Set
    End Property

    Private c_WfNo2 As String
    Public Property WfNo2() As String
        Get
            Return c_WfNo2
        End Get
        Set(ByVal value As String)
            c_WfNo2 = value
        End Set
    End Property

    Private c_WfNo3 As String
    Public Property WfNo3() As String
        Get
            Return c_WfNo3
        End Get
        Set(ByVal value As String)
            c_WfNo3 = value
        End Set
    End Property

    Private c_WfNo4 As String
    Public Property WfNo4() As String
        Get
            Return c_WfNo4
        End Get
        Set(ByVal value As String)
            c_WfNo4 = value
        End Set
    End Property

    Private c_WfNo5 As String
    Public Property WfNo5() As String
        Get
            Return c_WfNo5
        End Get
        Set(ByVal value As String)
            c_WfNo5 = value
        End Set
    End Property

    Private c_WfNo6 As String
    Public Property WfNo6() As String
        Get
            Return c_WfNo6
        End Get
        Set(ByVal value As String)
            c_WfNo6 = value
        End Set
    End Property

    Private c_WfNo7 As String
    Public Property WfNo7() As String
        Get
            Return c_WfNo7
        End Get
        Set(ByVal value As String)
            c_WfNo7 = value
        End Set
    End Property

    Private c_WfNo8 As String
    Public Property WfNo8() As String
        Get
            Return c_WfNo8
        End Get
        Set(ByVal value As String)
            c_WfNo8 = value
        End Set
    End Property


    Private c_WfNo9 As String
    Public Property WfNo9() As String
        Get
            Return c_WfNo9
        End Get
        Set(ByVal value As String)
            c_WfNo9 = value
        End Set
    End Property

    Private c_WfNo10 As String
    Public Property WfNo10() As String
        Get
            Return c_WfNo10
        End Get
        Set(ByVal value As String)
            c_WfNo10 = value
        End Set
    End Property

    Private c_WfNo11 As String
    Public Property WfNo11() As String
        Get
            Return c_WfNo11
        End Get
        Set(ByVal value As String)
            c_WfNo11 = value
        End Set
    End Property

    Private c_WfNo12 As String
    Public Property WfNo12() As String
        Get
            Return c_WfNo12
        End Get
        Set(ByVal value As String)
            c_WfNo12 = value
        End Set
    End Property

    Private c_WfNo13 As String
    Public Property WfNo13() As String
        Get
            Return c_WfNo13
        End Get
        Set(ByVal value As String)
            c_WfNo13 = value
        End Set
    End Property

    Private c_WfNo14 As String
    Public Property WfNo14() As String
        Get
            Return c_WfNo14
        End Get
        Set(ByVal value As String)
            c_WfNo14 = value
        End Set
    End Property

    Private c_WfNo15 As String
    Public Property WfNo15() As String
        Get
            Return c_WfNo15
        End Get
        Set(ByVal value As String)
            c_WfNo15 = value
        End Set
    End Property

    Private c_WfNo16 As String
    Public Property WfNo16() As String
        Get
            Return c_WfNo16
        End Get
        Set(ByVal value As String)
            c_WfNo16 = value
        End Set
    End Property

    Private c_WfNo17 As String
    Public Property WfNo17() As String
        Get
            Return c_WfNo17
        End Get
        Set(ByVal value As String)
            c_WfNo17 = value
        End Set
    End Property

    Private c_WfNo18 As String
    Public Property WfNo18() As String
        Get
            Return c_WfNo18
        End Get
        Set(ByVal value As String)
            c_WfNo18 = value
        End Set
    End Property

    Private c_WfNo19 As String
    Public Property WfNo19() As String
        Get
            Return c_WfNo19
        End Get
        Set(ByVal value As String)
            c_WfNo19 = value
        End Set
    End Property

    Private c_WfNo20 As String
    Public Property WfNo20() As String
        Get
            Return c_WfNo20
        End Get
        Set(ByVal value As String)
            c_WfNo20 = value
        End Set
    End Property

    Private c_WfNo21 As String
    Public Property WfNo21() As String
        Get
            Return c_WfNo21
        End Get
        Set(ByVal value As String)
            c_WfNo21 = value
        End Set
    End Property

    Private c_WfNo22 As String
    Public Property WfNo22() As String
        Get
            Return c_WfNo22
        End Get
        Set(ByVal value As String)
            c_WfNo22 = value
        End Set
    End Property

    Private c_WfNo23 As String
    Public Property WfNo23() As String
        Get
            Return c_WfNo23
        End Get
        Set(ByVal value As String)
            c_WfNo23 = value
        End Set
    End Property

    Private c_WfNo24 As String
    Public Property WfNo24() As String
        Get
            Return c_WfNo24
        End Get
        Set(ByVal value As String)
            c_WfNo24 = value
        End Set
    End Property

    Private c_WfNo25 As String
    Public Property WfNo25() As String
        Get
            Return c_WfNo25
        End Get
        Set(ByVal value As String)
            c_WfNo25 = value
        End Set
    End Property

    Private c_WaQtyNo1 As String
    Public Property WaQtyNo1() As String
        Get
            Return c_WaQtyNo1
        End Get
        Set(ByVal value As String)
            c_WaQtyNo1 = value
        End Set
    End Property

    Private c_WaQtyNo2 As String
    Public Property WaQtyNo2() As String
        Get
            Return c_WaQtyNo2
        End Get
        Set(ByVal value As String)
            c_WaQtyNo2 = value
        End Set
    End Property

    Private c_WaQtyNo3 As String
    Public Property WaQtyNo3() As String
        Get
            Return c_WaQtyNo3
        End Get
        Set(ByVal value As String)
            c_WaQtyNo3 = value
        End Set
    End Property

    Private c_WaQtyNo4 As String
    Public Property WaQtyNo4() As String
        Get
            Return c_WaQtyNo4
        End Get
        Set(ByVal value As String)
            c_WaQtyNo4 = value
        End Set
    End Property

    Private c_WaQtyNo5 As String
    Public Property WaQtyNo5() As String
        Get
            Return c_WaQtyNo5
        End Get
        Set(ByVal value As String)
            c_WaQtyNo5 = value
        End Set
    End Property

    Private c_WaQtyNo6 As String
    Public Property WaQtyNo6() As String
        Get
            Return c_WaQtyNo6
        End Get
        Set(ByVal value As String)
            c_WaQtyNo6 = value
        End Set
    End Property

    Private c_WaQtyNo7 As String
    Public Property WaQtyNo7() As String
        Get
            Return c_WaQtyNo7
        End Get
        Set(ByVal value As String)
            c_WaQtyNo7 = value
        End Set
    End Property

    Private c_WaQtyNo8 As String
    Public Property WaQtyNo8() As String
        Get
            Return c_WaQtyNo8
        End Get
        Set(ByVal value As String)
            c_WaQtyNo8 = value
        End Set
    End Property

    Private c_WaQtyNo9 As String
    Public Property WaQtyNo9() As String
        Get
            Return c_WaQtyNo9
        End Get
        Set(ByVal value As String)
            c_WaQtyNo9 = value
        End Set
    End Property

    Private c_WaQtyNo10 As String
    Public Property WaQtyNo10() As String
        Get
            Return c_WaQtyNo10
        End Get
        Set(ByVal value As String)
            c_WaQtyNo10 = value
        End Set
    End Property

    Private c_WaQtyNo11 As String
    Public Property WaQtyNo11() As String
        Get
            Return c_WaQtyNo11
        End Get
        Set(ByVal value As String)
            c_WaQtyNo11 = value
        End Set
    End Property

    Private c_WaQtyNo12 As String
    Public Property WaQtyNo12() As String
        Get
            Return c_WaQtyNo12
        End Get
        Set(ByVal value As String)
            c_WaQtyNo12 = value
        End Set
    End Property

    Private c_WaQtyNo13 As String
    Public Property WaQtyNo13() As String
        Get
            Return c_WaQtyNo13
        End Get
        Set(ByVal value As String)
            c_WaQtyNo13 = value
        End Set
    End Property

    Private c_WaQtyNo14 As String
    Public Property WaQtyNo14() As String
        Get
            Return c_WaQtyNo14
        End Get
        Set(ByVal value As String)
            c_WaQtyNo14 = value
        End Set
    End Property

    Private c_WaQtyNo15 As String
    Public Property WaQtyNo15() As String
        Get
            Return c_WaQtyNo15
        End Get
        Set(ByVal value As String)
            c_WaQtyNo15 = value
        End Set
    End Property

    Private c_WaQtyNo16 As String
    Public Property WaQtyNo16() As String
        Get
            Return c_WaQtyNo16
        End Get
        Set(ByVal value As String)
            c_WaQtyNo16 = value
        End Set
    End Property

    Private c_WaQtyNo17 As String
    Public Property WaQtyNo17() As String
        Get
            Return c_WaQtyNo17
        End Get
        Set(ByVal value As String)
            c_WaQtyNo17 = value
        End Set
    End Property

    Private c_WaQtyNo18 As String
    Public Property WaQtyNo18() As String
        Get
            Return c_WaQtyNo18
        End Get
        Set(ByVal value As String)
            c_WaQtyNo18 = value
        End Set
    End Property

    Private c_WaQtyNo19 As String
    Public Property WaQtyNo19() As String
        Get
            Return c_WaQtyNo19
        End Get
        Set(ByVal value As String)
            c_WaQtyNo19 = value
        End Set
    End Property

    Private c_WaQtyNo20 As String
    Public Property WaQtyNo20() As String
        Get
            Return c_WaQtyNo20
        End Get
        Set(ByVal value As String)
            c_WaQtyNo20 = value
        End Set
    End Property

    Private c_WaQtyNo21 As String
    Public Property WaQtyNo21() As String
        Get
            Return c_WaQtyNo21
        End Get
        Set(ByVal value As String)
            c_WaQtyNo21 = value
        End Set
    End Property

    Private c_WaQtyNo22 As String
    Public Property WaQtyNo22() As String
        Get
            Return c_WaQtyNo22
        End Get
        Set(ByVal value As String)
            c_WaQtyNo22 = value
        End Set
    End Property

    Private c_WaQtyNo23 As String
    Public Property WaQtyNo23() As String
        Get
            Return c_WaQtyNo23
        End Get
        Set(ByVal value As String)
            c_WaQtyNo23 = value
        End Set
    End Property

    Private c_WaQtyNo24 As String
    Public Property WaQtyNo24() As String
        Get
            Return c_WaQtyNo24
        End Get
        Set(ByVal value As String)
            c_WaQtyNo24 = value
        End Set
    End Property

    Private c_WaQtyNo25 As String
    Public Property WaQtyNo25() As String
        Get
            Return c_WaQtyNo25
        End Get
        Set(ByVal value As String)
            c_WaQtyNo25 = value
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

    Private c_WaferNo As String
    Public Property WaferNo() As String
        Get
            Return c_WaferNo
        End Get
        Set(ByVal value As String)
            c_WaferNo = value
        End Set
    End Property

    Private c_OrderNo As String
    Public Property OrderNo() As String
        Get
            Return c_OrderNo
        End Get
        Set(ByVal value As String)
            c_OrderNo = value
        End Set
    End Property

    Private c_DCCode As String
    Public Property DCCode() As String
        Get
            Return c_DCCode
        End Get
        Set(ByVal value As String)
            c_DCCode = value
        End Set
    End Property

    Private c_Plasma As String
    Public Property Plasma() As String
        Get
            Return c_Plasma
        End Get
        Set(ByVal value As String)
            c_Plasma = value
        End Set
    End Property

    Private c_CodeNo As String
    Public Property CodeNo() As String
        Get
            Return c_CodeNo
        End Get
        Set(ByVal value As String)
            c_CodeNo = value
        End Set
    End Property


#End Region
End Class
