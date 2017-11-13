
<DataContract()> _
Public Class AssySlip252

#Region "IQRCode Members"
    Private Sub ClearExceptFullCode()
        Me.m_PackageName = Nothing
        Me.m_DeviceName = Nothing
        Me.m_LotNo = Nothing
        Me.m_FrameType = Nothing
        Me.m_FarSetDirection = Nothing
        Me.m_CodeNo = Nothing
        Me.m_WaferLotNo = Nothing
        Me.m_TapingDirection = Nothing
        Me.m_MarkType = Nothing
        Me.m_MarkingSpec1 = Nothing
        Me.m_MarkingSpec2 = Nothing
        Me.m_MarkingSpec3 = Nothing
        Me.m_MarkingStep = Nothing
        Me.m_OSFTChange = Nothing
        Me.m_OSProgram = Nothing
        Me.m_MoldType = Nothing
        Me.m_NewPackageName = Nothing
        Me.m_FTDevice = Nothing
        Me.m_MarkNo = Nothing
        Me.m_PDFree = Nothing
        Me.m_ULMark = Nothing
        Me.m_ReelCount = Nothing
        Me.m_CleamCounterMeasure = Nothing
        Me.m_SubRank = Nothing
        Me.m_Mask = Nothing
        Me.m_ForIndication1 = Nothing
        Me.m_ForIndication2 = Nothing
    End Sub
    Public Sub ReadFromQRstring(ByVal fullcode As String)
        If fullcode.Length <> 252 Then
            Throw New Exception("Invalid Data")
        End If
        Me.m_FullCode = fullcode
        Me.m_PackageName = fullcode.Substring(0, 10).Trim()
        Me.m_DeviceName = fullcode.Substring(10, 20).Trim()
        Me.m_LotNo = fullcode.Substring(30, 10).Trim()
        Me.m_FrameType = fullcode.Substring(40, 16).Trim()
        Me.m_FarSetDirection = fullcode.Substring(56, 4).Trim()
        Me.m_CodeNo = fullcode.Substring(60, 10).Trim()
        Me.m_WaferLotNo = fullcode.Substring(70, 12).Trim()
        Me.m_TapingDirection = fullcode.Substring(82, 3).Trim()
        Me.m_MarkType = fullcode.Substring(85, 1).Trim()
        Me.m_MarkingSpec1 = fullcode.Substring(86, 10).Trim()
        Me.m_MarkingSpec2 = fullcode.Substring(96, 10).Trim()
        Me.m_MarkingSpec3 = fullcode.Substring(106, 10).Trim()
        Me.m_MarkingStep = fullcode.Substring(116, 1).Trim()
        Me.m_OSFTChange = fullcode.Substring(117, 1).Trim()
        Me.m_OSProgram = fullcode.Substring(118, 12).Trim()
        Me.m_MoldType = fullcode.Substring(130, 16).Trim()
        Me.m_NewPackageName = fullcode.Substring(146, 20).Trim()
        Me.m_FTDevice = fullcode.Substring(166, 20).Trim()
        Me.m_MarkNo = fullcode.Substring(186, 10).Trim()
        Me.m_PDFree = fullcode.Substring(196, 1).Trim()
        Me.m_ULMark = fullcode.Substring(197, 1).Trim()
        Me.m_ReelCount = fullcode.Substring(198, 5).Trim()
        Me.m_CleamCounterMeasure = fullcode.Substring(203, 4).Trim()
        Me.m_SubRank = fullcode.Substring(207, 3).Trim()
        Me.m_Mask = fullcode.Substring(210, 2).Trim()
        Me.m_ForIndication1 = fullcode.Substring(212, 20).Trim()
        Me.m_ForIndication2 = fullcode.Substring(232, 20).Trim()
    End Sub
#End Region

#Region "Properties"

    Private m_FullCode As String
    <DataMember()> _
    Public Property FullCode() As String
        Get
            Return m_FullCode
        End Get
        Set(ByVal value As String)
            m_FullCode = value
        End Set
    End Property

    Private m_PackageName As String
    <DataMember()> _
    Public Property PackageName() As String
        Get
            Return m_PackageName
        End Get
        Set(ByVal value As String)
            If m_PackageName <> value Then
                m_PackageName = value
            End If
        End Set
    End Property

    Private m_DeviceName As String
    <DataMember()> _
    Public Property DeviceName() As String
        Get
            Return m_DeviceName
        End Get
        Set(ByVal value As String)
            If m_DeviceName <> value Then
                m_DeviceName = value
            End If
        End Set
    End Property

    Private m_LotNo As String
    <DataMember()> _
    Public Property LotNo() As String
        Get
            Return m_LotNo
        End Get
        Set(ByVal value As String)
            If m_LotNo <> value Then
                m_LotNo = value
            End If
        End Set
    End Property

    Private m_FrameType As String
    <DataMember()> _
    Public Property FrameType() As String
        Get
            Return m_FrameType
        End Get
        Set(ByVal value As String)
            If m_FrameType <> value Then
                m_FrameType = value
            End If
        End Set
    End Property

    Private m_FarSetDirection As String
    <DataMember()> _
    Public Property FarSetDirection() As String
        Get
            Return m_FarSetDirection
        End Get
        Set(ByVal value As String)
            If m_FarSetDirection <> value Then
                m_FarSetDirection = value
            End If
        End Set
    End Property

    Private m_CodeNo As String
    <DataMember()> _
    Public Property CodeNo() As String
        Get
            Return m_CodeNo
        End Get
        Set(ByVal value As String)
            If m_CodeNo <> value Then
                m_CodeNo = value
            End If
        End Set
    End Property

    Private m_WaferLotNo As String
    <DataMember()> _
    Public Property WaferLotNo() As String
        Get
            Return m_WaferLotNo
        End Get
        Set(ByVal value As String)
            If m_WaferLotNo <> value Then
                m_WaferLotNo = value
            End If
        End Set
    End Property

    Private m_TapingDirection As String
    <DataMember()> _
    Public Property TapingDirection() As String
        Get
            Return m_TapingDirection
        End Get
        Set(ByVal value As String)
            If m_TapingDirection <> value Then
                m_TapingDirection = value
            End If
        End Set
    End Property

    Private m_MarkType As String
    <DataMember()> _
    Public Property MarkType() As String
        Get
            Return m_MarkType
        End Get
        Set(ByVal value As String)
            If m_MarkType <> value Then
                m_MarkType = value
            End If
        End Set
    End Property

    Private m_MarkingSpec1 As String
    <DataMember()> _
    Public Property MarkingSpec1() As String
        Get
            Return m_MarkingSpec1
        End Get
        Set(ByVal value As String)
            If m_MarkingSpec1 <> value Then
                m_MarkingSpec1 = value
            End If
        End Set
    End Property

    Private m_MarkingSpec2 As String
    <DataMember()> _
    Public Property MarkingSpec2() As String
        Get
            Return m_MarkingSpec2
        End Get
        Set(ByVal value As String)
            If m_MarkingSpec2 <> value Then
                m_MarkingSpec2 = value
            End If
        End Set
    End Property

    Private m_MarkingSpec3 As String
    <DataMember()> _
    Public Property MarkingSpec3() As String
        Get
            Return m_MarkingSpec3
        End Get
        Set(ByVal value As String)
            If m_MarkingSpec3 <> value Then
                m_MarkingSpec3 = value
            End If
        End Set
    End Property

    Private m_MarkingStep As String
    <DataMember()> _
    Public Property MarkingStep() As String
        Get
            Return m_MarkingStep
        End Get
        Set(ByVal value As String)
            If m_MarkingStep <> value Then
                m_MarkingStep = value
            End If
        End Set
    End Property

    Private m_OSFTChange As String
    <DataMember()> _
    Public Property OSFTChange() As String
        Get
            Return m_OSFTChange
        End Get
        Set(ByVal value As String)
            If m_OSFTChange <> value Then
                m_OSFTChange = value
            End If
        End Set
    End Property

    Private m_OSProgram As String
    <DataMember()> _
    Public Property OSProgram() As String
        Get
            Return m_OSProgram
        End Get
        Set(ByVal value As String)
            If m_OSProgram <> value Then
                m_OSProgram = value
            End If
        End Set
    End Property

    Private m_MoldType As String
    <DataMember()> _
    Public Property MoldType() As String
        Get
            Return m_MoldType
        End Get
        Set(ByVal value As String)
            If m_MoldType <> value Then
                m_MoldType = value
            End If
        End Set
    End Property

    Private m_NewPackageName As String
    <DataMember()> _
    Public Property NewPackageName() As String
        Get
            Return m_NewPackageName
        End Get
        Set(ByVal value As String)
            If m_NewPackageName <> value Then
                m_NewPackageName = value
            End If
        End Set
    End Property

    Private m_FTDevice As String
    <DataMember()> _
    Public Property FTDevice() As String
        Get
            Return m_FTDevice
        End Get
        Set(ByVal value As String)
            If m_FTDevice <> value Then
                m_FTDevice = value
            End If
        End Set
    End Property

    Private m_MarkNo As String
    <DataMember()> _
    Public Property MarkNo() As String
        Get
            Return m_MarkNo
        End Get
        Set(ByVal value As String)
            If m_MarkNo <> value Then
                m_MarkNo = value
            End If
        End Set
    End Property

    Private m_PDFree As String
    <DataMember()> _
    Public Property PDFree() As String
        Get
            Return m_PDFree
        End Get
        Set(ByVal value As String)
            If m_PDFree <> value Then
                m_PDFree = value
            End If
        End Set
    End Property

    Private m_ULMark As String
    <DataMember()> _
    Public Property ULMark() As String
        Get
            Return m_ULMark
        End Get
        Set(ByVal value As String)
            If m_ULMark <> value Then
                m_ULMark = value
            End If
        End Set
    End Property

    Private m_ReelCount As String
    <DataMember()> _
    Public Property ReelCount() As String
        Get
            Return m_ReelCount
        End Get
        Set(ByVal value As String)
            If m_ReelCount <> value Then
                m_ReelCount = value
            End If
        End Set
    End Property

    Private m_CleamCounterMeasure As String
    <DataMember()> _
    Public Property CleamCounterMeasure() As String
        Get
            Return m_CleamCounterMeasure
        End Get
        Set(ByVal value As String)
            If m_CleamCounterMeasure <> value Then
                m_CleamCounterMeasure = value
            End If
        End Set
    End Property

    Private m_SubRank As String
    <DataMember()> _
    Public Property SubRank() As String
        Get
            Return m_SubRank
        End Get
        Set(ByVal value As String)
            If m_SubRank <> value Then
                m_SubRank = value
            End If
        End Set
    End Property

    Private m_Mask As String
    <DataMember()> _
    Public Property Mask() As String
        Get
            Return m_Mask
        End Get
        Set(ByVal value As String)
            If m_Mask <> value Then
                m_Mask = value
            End If
        End Set
    End Property

    Private m_ForIndication1 As String
    <DataMember()> _
    Public Property ForIndication1() As String
        Get
            Return m_ForIndication1
        End Get
        Set(ByVal value As String)
            If m_ForIndication1 <> value Then
                m_ForIndication1 = value
            End If
        End Set
    End Property

    Private m_ForIndication2 As String
    <DataMember()> _
    Public Property ForIndication2() As String
        Get
            Return m_ForIndication2
        End Get
        Set(ByVal value As String)
            If m_ForIndication2 <> value Then
                m_ForIndication2 = value
            End If
        End Set
    End Property
#End Region

End Class
