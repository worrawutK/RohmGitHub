Public Class DicingSlip254

    Public Sub New(ByVal qrcode As String)
        FullCode = qrcode
    End Sub

    Private Sub SeperateData(ByVal qrCode As String)

        If qrCode.Length = 254 Then
            WaferQty = CInt(qrCode.Substring(32, 2))
            ChipName = qrCode.Substring(0, 20)
            WaferLotNo = qrCode.Substring(20, 12)
            DeviceName = qrCode.Substring(234, 20)

            WaferNo1 = qrCode.Substring(34, 2)
            WaferNo2 = qrCode.Substring(42, 2)
            WaferNo3 = qrCode.Substring(50, 2)
            WaferNo4 = qrCode.Substring(58, 2)
            WaferNo5 = qrCode.Substring(66, 2)
            WaferNo6 = qrCode.Substring(74, 2)
            WaferNo7 = qrCode.Substring(82, 2)
            WaferNo8 = qrCode.Substring(90, 2)
            WaferNo9 = qrCode.Substring(98, 2)
            WaferNo10 = qrCode.Substring(106, 2)
            WaferNo11 = qrCode.Substring(114, 2)
            WaferNo12 = qrCode.Substring(122, 2)
            WaferNo13 = qrCode.Substring(130, 2)
            WaferNo14 = qrCode.Substring(138, 2)
            WaferNo15 = qrCode.Substring(146, 2)
            WaferNo16 = qrCode.Substring(154, 2)
            WaferNo17 = qrCode.Substring(162, 2)
            WaferNo18 = qrCode.Substring(170, 2)
            WaferNo19 = qrCode.Substring(178, 2)
            WaferNo20 = qrCode.Substring(186, 2)
            WaferNo21 = qrCode.Substring(194, 2)
            WaferNo22 = qrCode.Substring(202, 2)
            WaferNo23 = qrCode.Substring(210, 2)
            WaferNo24 = qrCode.Substring(218, 2)
            WaferNo25 = qrCode.Substring(226, 2)

            WaferQtyNo1 = CInt(qrCode.Substring(36, 6))
            WaferQtyNo2 = CInt(qrCode.Substring(44, 6))
            WaferQtyNo3 = CInt(qrCode.Substring(52, 6))
            WaferQtyNo4 = CInt(qrCode.Substring(60, 6)
            WaferQtyNo5 = CInt(qrCode.Substring(68, 6)
            WaferQtyNo6 = CInt(qrCode.Substring(76, 6)
            WaferQtyNo7 = CInt(qrCode.Substring(84, 6)
            WaferQtyNo8 = CInt(qrCode.Substring(92, 6)
            WaferQtyNo9 = CInt(qrCode.Substring(100, 6)
            WaferQtyNo10 = qrCode.Substring(108, 6)
            WaferQtyNo11 = qrCode.Substring(116, 6)
            WaferQtyNo12 = qrCode.Substring(124, 6)
            WaferQtyNo13 = qrCode.Substring(132, 6)
            WaferQtyNo14 = qrCode.Substring(140, 6)
            WaferQtyNo15 = qrCode.Substring(148, 6)
            WaferQtyNo16 = qrCode.Substring(156, 6)
            WaferQtyNo17 = qrCode.Substring(164, 6)
            WaferQtyNo18 = qrCode.Substring(172, 6)
            WaferQtyNo19 = qrCode.Substring(180, 6)
            WaferQtyNo20 = qrCode.Substring(188, 6)
            WaferQtyNo21 = qrCode.Substring(196, 6)
            WaferQtyNo22 = qrCode.Substring(204, 6)
            WaferQtyNo23 = qrCode.Substring(212, 6)
            WaferQtyNo24 = qrCode.Substring(220, 6)
            WaferQtyNo25 = qrCode.Substring(228, 6)

        Else
            Throw New ApplicationException("Wrong data")
        End If

    End Sub

    '**** for display from Wafer: 01-06 **Only arm use it
    'Private Function GetWaferNo(ByVal qty As Integer) As String
    '    Dim ret As String = Nothing
    '    Select Case qty
    '        Case 1
    '            ret = WaferNo1
    '        Case 2
    '            ret = WaferNo1 & " - " & WaferNo2
    '        Case 3
    '            ret = WaferNo1 & " - " & WaferNo3
    '        Case 4
    '            ret = WaferNo1 & " - " & WaferNo4
    '        Case 5
    '            ret = WaferNo1 & " - " & WaferNo5
    '        Case 6
    '            ret = WaferNo1 & " - " & WaferNo6
    '        Case 7
    '            ret = WaferNo1 & " - " & WaferNo7
    '        Case 8
    '            ret = WaferNo1 & " - " & WaferNo8
    '        Case 9
    '            ret = WaferNo1 & " - " & WaferNo9
    '        Case 10
    '            ret = WaferNo1 & " - " & WaferNo10
    '        Case 11
    '            ret = WaferNo1 & " - " & WaferNo11
    '        Case 12
    '            ret = WaferNo1 & " - " & WaferNo12
    '        Case 13
    '            ret = WaferNo1 & " - " & WaferNo13
    '        Case 14
    '            ret = WaferNo1 & " - " & WaferNo14
    '        Case 15
    '            ret = WaferNo1 & " - " & WaferNo15
    '        Case 16
    '            ret = WaferNo1 & " - " & WaferNo16
    '        Case 17
    '            ret = WaferNo1 & " - " & WaferNo17
    '        Case 18
    '            ret = WaferNo1 & " - " & WaferNo18
    '        Case 19
    '            ret = WaferNo1 & " - " & WaferNo19
    '        Case 20
    '            ret = WaferNo1 & " - " & WaferNo20
    '        Case 21
    '            ret = WaferNo1 & " - " & WaferNo21
    '        Case 22
    '            ret = WaferNo1 & " - " & WaferNo22
    '        Case 23
    '            ret = WaferNo1 & " - " & WaferNo23
    '        Case 24
    '            ret = WaferNo1 & " - " & WaferNo24
    '        Case 25
    '            ret = WaferNo1 & " - " & WaferNo25
    '    End Select
    '    Return ret
    'End Function

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
    Public Property ChipName() As String
        Get
            Return c_Chip
        End Get
        Set(ByVal value As String)
            c_Chip = value
        End Set
    End Property

    Private c_WfLotNo As String
    Public Property WaferLotNo() As String
        Get
            Return c_WfLotNo
        End Get
        Set(ByVal value As String)
            c_WfLotNo = value
        End Set
    End Property

    Private c_Wafer As Integer
    Public Property WaferQty() As Integer
        Get
            Return c_Wafer
        End Get
        Set(ByVal value As Integer)
            c_Wafer = value
        End Set
    End Property

    Private c_WaferNo1 As String
    Public Property WaferNo1() As String
        Get
            Return c_WaferNo1
        End Get
        Set(ByVal value As String)
            c_WaferNo1 = value
        End Set
    End Property

    Private c_WaferNo2 As String
    Public Property WaferNo2() As String
        Get
            Return c_WaferNo2
        End Get
        Set(ByVal value As String)
            c_WaferNo2 = value
        End Set
    End Property

    Private c_WaferNo3 As String
    Public Property WaferNo3() As String
        Get
            Return c_WaferNo3
        End Get
        Set(ByVal value As String)
            c_WaferNo3 = value
        End Set
    End Property

    Private c_WaferNo4 As String
    Public Property WaferNo4() As String
        Get
            Return c_WaferNo4
        End Get
        Set(ByVal value As String)
            c_WaferNo4 = value
        End Set
    End Property

    Private c_WaferNo5 As String
    Public Property WaferNo5() As String
        Get
            Return c_WaferNo5
        End Get
        Set(ByVal value As String)
            c_WaferNo5 = value
        End Set
    End Property

    Private c_WaferNo6 As String
    Public Property WaferNo6() As String
        Get
            Return c_WaferNo6
        End Get
        Set(ByVal value As String)
            c_WaferNo6 = value
        End Set
    End Property

    Private c_WaferNo7 As String
    Public Property WaferNo7() As String
        Get
            Return c_WaferNo7
        End Get
        Set(ByVal value As String)
            c_WaferNo7 = value
        End Set
    End Property

    Private c_WaferNo8 As String
    Public Property WaferNo8() As String
        Get
            Return c_WaferNo8
        End Get
        Set(ByVal value As String)
            c_WaferNo8 = value
        End Set
    End Property


    Private c_WaferNo9 As String
    Public Property WaferNo9() As String
        Get
            Return c_WaferNo9
        End Get
        Set(ByVal value As String)
            c_WaferNo9 = value
        End Set
    End Property

    Private c_WaferNo10 As String
    Public Property WaferNo10() As String
        Get
            Return c_WaferNo10
        End Get
        Set(ByVal value As String)
            c_WaferNo10 = value
        End Set
    End Property

    Private c_WaferNo11 As String
    Public Property WaferNo11() As String
        Get
            Return c_WaferNo11
        End Get
        Set(ByVal value As String)
            c_WaferNo11 = value
        End Set
    End Property

    Private c_WaferNo12 As String
    Public Property WaferNo12() As String
        Get
            Return c_WaferNo12
        End Get
        Set(ByVal value As String)
            c_WaferNo12 = value
        End Set
    End Property

    Private c_WaferNo13 As String
    Public Property WaferNo13() As String
        Get
            Return c_WaferNo13
        End Get
        Set(ByVal value As String)
            c_WaferNo13 = value
        End Set
    End Property

    Private c_WaferNo14 As String
    Public Property WaferNo14() As String
        Get
            Return c_WaferNo14
        End Get
        Set(ByVal value As String)
            c_WaferNo14 = value
        End Set
    End Property

    Private c_WaferNo15 As String
    Public Property WaferNo15() As String
        Get
            Return c_WaferNo15
        End Get
        Set(ByVal value As String)
            c_WaferNo15 = value
        End Set
    End Property

    Private c_WaferNo16 As String
    Public Property WaferNo16() As String
        Get
            Return c_WaferNo16
        End Get
        Set(ByVal value As String)
            c_WaferNo16 = value
        End Set
    End Property

    Private c_WaferNo17 As String
    Public Property WaferNo17() As String
        Get
            Return c_WaferNo17
        End Get
        Set(ByVal value As String)
            c_WaferNo17 = value
        End Set
    End Property

    Private c_WaferNo18 As String
    Public Property WaferNo18() As String
        Get
            Return c_WaferNo18
        End Get
        Set(ByVal value As String)
            c_WaferNo18 = value
        End Set
    End Property

    Private c_WaferNo19 As String
    Public Property WaferNo19() As String
        Get
            Return c_WaferNo19
        End Get
        Set(ByVal value As String)
            c_WaferNo19 = value
        End Set
    End Property

    Private c_WaferNo20 As String
    Public Property WaferNo20() As String
        Get
            Return c_WaferNo20
        End Get
        Set(ByVal value As String)
            c_WaferNo20 = value
        End Set
    End Property

    Private c_WaferNo21 As String
    Public Property WaferNo21() As String
        Get
            Return c_WaferNo21
        End Get
        Set(ByVal value As String)
            c_WaferNo21 = value
        End Set
    End Property

    Private c_WaferNo22 As String
    Public Property WaferNo22() As String
        Get
            Return c_WaferNo22
        End Get
        Set(ByVal value As String)
            c_WaferNo22 = value
        End Set
    End Property

    Private c_WaferNo23 As String
    Public Property WaferNo23() As String
        Get
            Return c_WaferNo23
        End Get
        Set(ByVal value As String)
            c_WaferNo23 = value
        End Set
    End Property

    Private c_WaferNo24 As String
    Public Property WaferNo24() As String
        Get
            Return c_WaferNo24
        End Get
        Set(ByVal value As String)
            c_WaferNo24 = value
        End Set
    End Property

    Private c_WaferNo25 As String
    Public Property WaferNo25() As String
        Get
            Return c_WaferNo25
        End Get
        Set(ByVal value As String)
            c_WaferNo25 = value
        End Set
    End Property

    Private c_WaferQtyNo1 As Integer
    Public Property WaferQtyNo1() As Integer
        Get
            Return c_WaferQtyNo1
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo1 = value
        End Set
    End Property

    Private c_WaferQtyNo2 As Integer
    Public Property WaferQtyNo2() As Integer
        Get
            Return c_WaferQtyNo2
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo2 = value
        End Set
    End Property

    Private c_WaferQtyNo3 As Integer
    Public Property WaferQtyNo3() As Integer
        Get
            Return c_WaferQtyNo3
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo3 = value
        End Set
    End Property

    Private c_WaferQtyNo4 As Integer
    Public Property WaferQtyNo4() As Integer
        Get
            Return c_WaferQtyNo4
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo4 = value
        End Set
    End Property

    Private c_WaferQtyNo5 As Integer
    Public Property WaferQtyNo5() As Integer
        Get
            Return c_WaferQtyNo5
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo5 = value
        End Set
    End Property

    Private c_WaferQtyNo6 As Integer
    Public Property WaferQtyNo6() As Integer
        Get
            Return c_WaferQtyNo6
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo6 = value
        End Set
    End Property

    Private c_WaferQtyNo7 As Integer
    Public Property WaferQtyNo7() As Integer
        Get
            Return c_WaferQtyNo7
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo7 = value
        End Set
    End Property

    Private c_WaferQtyNo8 As Integer
    Public Property WaferQtyNo8() As Integer
        Get
            Return c_WaferQtyNo8
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo8 = value
        End Set
    End Property

    Private c_WaferQtyNo9 As Integer
    Public Property WaferQtyNo9() As Integer
        Get
            Return c_WaferQtyNo9
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo9 = value
        End Set
    End Property

    Private c_WaferQtyNo10 As Integer
    Public Property WaferQtyNo10() As Integer
        Get
            Return c_WaferQtyNo10
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo10 = value
        End Set
    End Property

    Private c_WaferQtyNo11 As Integer
    Public Property WaferQtyNo11() As Integer
        Get
            Return c_WaferQtyNo11
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo11 = value
        End Set
    End Property

    Private c_WaferQtyNo12 As Integer
    Public Property WaferQtyNo12() As Integer
        Get
            Return c_WaferQtyNo12
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo12 = value
        End Set
    End Property

    Private c_WaferQtyNo13 As Integer
    Public Property WaferQtyNo13() As Integer
        Get
            Return c_WaferQtyNo13
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo13 = value
        End Set
    End Property

    Private c_WaferQtyNo14 As Integer
    Public Property WaferQtyNo14() As Integer
        Get
            Return c_WaferQtyNo14
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo14 = value
        End Set
    End Property

    Private c_WaferQtyNo15 As Integer
    Public Property WaferQtyNo15() As Integer
        Get
            Return c_WaferQtyNo15
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo15 = value
        End Set
    End Property

    Private c_WaferQtyNo16 As Integer
    Public Property WaferQtyNo16() As Integer
        Get
            Return c_WaferQtyNo16
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo16 = value
        End Set
    End Property

    Private c_WaferQtyNo17 As Integer
    Public Property WaferQtyNo17() As Integer
        Get
            Return c_WaferQtyNo17
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo17 = value
        End Set
    End Property

    Private c_WaferQtyNo18 As Integer
    Public Property WaferQtyNo18() As Integer
        Get
            Return c_WaferQtyNo18
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo18 = value
        End Set
    End Property

    Private c_WaferQtyNo19 As Integer
    Public Property WaferQtyNo19() As Integer
        Get
            Return c_WaferQtyNo19
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo19 = value
        End Set
    End Property

    Private c_WaferQtyNo20 As Integer
    Public Property WaferQtyNo20() As Integer
        Get
            Return c_WaferQtyNo20
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo20 = value
        End Set
    End Property

    Private c_WaferQtyNo21 As Integer
    Public Property WaferQtyNo21() As Integer
        Get
            Return c_WaferQtyNo21
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo21 = value
        End Set
    End Property

    Private c_WaferQtyNo22 As Integer
    Public Property WaferQtyNo22() As Integer
        Get
            Return c_WaferQtyNo22
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo22 = value
        End Set
    End Property

    Private c_WaferQtyNo23 As Integer
    Public Property WaferQtyNo23() As Integer
        Get
            Return c_WaferQtyNo23
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo23 = value
        End Set
    End Property

    Private c_WaferQtyNo24 As Integer
    Public Property WaferQtyNo24() As Integer
        Get
            Return c_WaferQtyNo24
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo24 = value
        End Set
    End Property

    Private c_WaferQtyNo25 As Integer
    Public Property WaferQtyNo25() As Integer
        Get
            Return c_WaferQtyNo25
        End Get
        Set(ByVal value As Integer)
            c_WaferQtyNo25 = value
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

    'Private c_WaferNo As String
    'Public Property WaferNo() As String
    '    Get
    '        Return c_WaferNo
    '    End Get
    '    Set(ByVal value As String)
    '        c_WaferNo = value
    '    End Set
    'End Property

#End Region
End Class
