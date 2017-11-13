Imports System.IO
Imports System.Text
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports Rohm


<Serializable()> _
Public Class Machine
    Implements INotifyPropertyChanged

#Region "Events"

    Public Event LotStarted As EventHandler
    Public Event LotCompleted As EventHandler
    Public Event MachineStateChanged As MachineStateChangedEventHandler
    Public Event AlarmWasCleared As AlarmWasClearedEventHandler
    Public Event RecordedCommLog As RecordedCommLogEventHandler
    Public Event OutputChanged As EventHandler
    Public Event Removed As EventHandler
    Public Event YieldCaptured As EventHandler

#End Region

    Private m_RequireNewLotSetupBeforeLA As Boolean
    Public Property RequireNewLotSetupBeforeLA() As Boolean
        Get
            Return m_RequireNewLotSetupBeforeLA
        End Get
        Set(ByVal value As Boolean)
            If m_RequireNewLotSetupBeforeLA <> value Then
                m_RequireNewLotSetupBeforeLA = value
                ReportPropertyChanged("RequireNewLotSetupBeforeLA")
            End If
        End Set
    End Property

    Private m_MCNo As String
    Public Property MCNo() As String
        Get
            Return m_MCNo
        End Get
        Set(ByVal value As String)
            If m_MCNo <> value Then
                m_MCNo = value
                ReportPropertyChanged("MCNo")
            End If
        End Set
    End Property

    Private m_CurrentAlarm As Alarm
    Public Property CurrentAlarm() As Alarm
        Get
            Return m_CurrentAlarm
        End Get
        Set(ByVal value As Alarm)
            m_CurrentAlarm = value
        End Set
    End Property

    Public Sub SetCurrentAlarm(ByVal a As Alarm)
        ClearAlarm()
        m_CurrentAlarm = a
        If m_CurrentAlarm IsNot Nothing Then
            m_Alarms.Add(m_CurrentAlarm)
        End If
    End Sub

    Private m_Alarms As BindingList(Of Alarm)
    Public Property Alarms() As BindingList(Of Alarm)
        Get
            Return m_Alarms
        End Get
        Set(ByVal value As BindingList(Of Alarm))
            m_Alarms = value
        End Set
    End Property

    Private m_AlarmTime As TimeSpan
    <XmlIgnore()> _
    Public Property AlarmTime() As TimeSpan
        Get
            Return m_AlarmTime
        End Get
        Set(ByVal value As TimeSpan)
            If m_AlarmTime <> value Then
                m_AlarmTime = value
                ReportPropertyChanged("AlarmTime")
            End If
        End Set
    End Property

    Public Property AlarmTimeTicks() As Long
        Get
            Return m_AlarmTime.Ticks
        End Get
        Set(ByVal value As Long)
            m_AlarmTime = TimeSpan.FromTicks(value)
        End Set
    End Property

    Private m_ASIGoodPcs As Integer
    Public Property ASIGoodPcs() As Integer
        Get
            Return m_ASIGoodPcs
        End Get
        Set(ByVal value As Integer)
            If m_ASIGoodPcs <> value Then
                m_ASIGoodPcs = value
                ReportPropertyChanged("ASIGoodPcs")
            End If
        End Set
    End Property

    Private m_ASINGTimes As Integer
    Public Property ASINGTimes() As Integer
        Get
            Return m_ASINGTimes
        End Get
        Set(ByVal value As Integer)
            If m_ASINGTimes <> value Then
                m_ASINGTimes = value
                ReportPropertyChanged("ASINGTimes")
            End If
        End Set
    End Property

    Private m_ASITestPcs As Integer
    Public Property ASITestPcs() As Integer
        Get
            Return m_ASITestPcs
        End Get
        Set(ByVal value As Integer)
            If m_ASITestPcs <> value Then
                m_ASITestPcs = value
                ReportPropertyChanged("ASITestPcs")
            End If
        End Set
    End Property

    Private m_ASICycle As Integer
    Public Property ASICycle() As Integer
        Get
            Return m_ASICycle
        End Get
        Set(ByVal value As Integer)
            If m_ASICycle <> value Then
                m_ASICycle = value
                ReportPropertyChanged("ASICycle")
            End If
        End Set
    End Property

    Private m_ASIFTEYield As Single
    Public Property ASIFTEYield() As Single
        Get
            Return m_ASIFTEYield
        End Get
        Set(ByVal value As Single)
            If m_ASIFTEYield <> value Then
                m_ASIFTEYield = value
                ReportPropertyChanged("ASIFTEYield")
            End If
        End Set
    End Property

    Private m_ASIFTSYield As Single
    Public Property ASIFTSYield() As Single
        Get
            Return m_ASIFTSYield
        End Get
        Set(ByVal value As Single)
            If m_ASIFTSYield <> value Then
                m_ASIFTSYield = value
                ReportPropertyChanged("ASIFTSYield")
            End If
        End Set
    End Property

    Private m_LotCompleteTime As Date?
    Public Property LotCompleteTime() As Date?
        Get
            Return m_LotCompleteTime
        End Get
        Set(ByVal value As Date?)
            If Not m_LotCompleteTime.Equals(value) Then
                m_LotCompleteTime = value
                ReportPropertyChanged("LotCompleteTime")
            End If
        End Set
    End Property

    Private m_InputQty As Integer
    Public Property InputQty() As Integer
        Get
            Return m_InputQty
        End Get
        Set(ByVal value As Integer)
            If m_InputQty <> value Then
                m_InputQty = value
                ReportPropertyChanged("InputQty")
            End If
        End Set
    End Property

    Private m_LotInputTime As Date?
    Public Property LotInputTime() As Date?
        Get
            Return m_LotInputTime
        End Get
        Set(ByVal value As Date?)
            If Not m_LotInputTime.Equals(value) Then
                m_LotInputTime = value
                ReportPropertyChanged("LotInputTime")
            End If
        End Set
    End Property

    Private m_LotStartTime As Date?
    Public Property LotStartTime() As Date?
        Get
            Return m_LotStartTime
        End Get
        Set(ByVal value As Date?)
            If Not m_LotStartTime.Equals(value) Then
                m_LotStartTime = value
                ReportPropertyChanged("LotStartTime")
            End If
        End Set
    End Property

    Private m_Output As ProductOutput

    'commend out since 2017-08-29 by Tanapat S.
    '<Obsolete()> _
    'Public Property Output() As ProductOutput
    '    Get
    '        Return m_Output
    '    End Get
    '    Set(ByVal value As ProductOutput)
    '        If m_Output <> value Then
    '            m_Output = value

    '            m_Ch1GoodQty = m_Output.Good.CH1
    '            m_Ch2GoodQty = m_Output.Good.CH2
    '            m_Ch1NGQty = m_Output.NG.CH1
    '            m_Ch2NGQty = m_Output.NG.CH2

    '            ReportPropertyChanged("Output")
    '        End If
    '    End Set
    'End Property

    Private m_Ch1GoodQty As Integer
    Public Property Ch1GoodQty() As Integer
        Get
            Return m_Ch1GoodQty
        End Get
        Set(ByVal value As Integer)
            If m_Ch1GoodQty <> value Then
                m_Ch1GoodQty = value
                ReportPropertyChanged("Ch1GoodQty")
            End If
        End Set
    End Property

    Private m_Ch2GoodQty As Integer
    Public Property Ch2GoodQty() As Integer
        Get
            Return m_Ch2GoodQty
        End Get
        Set(ByVal value As Integer)
            If m_Ch2GoodQty <> value Then
                m_Ch2GoodQty = value
                ReportPropertyChanged("Ch2GoodQty")
            End If
        End Set
    End Property

    Private m_Ch3GoodQty As Integer
    Public Property Ch3GoodQty() As Integer
        Get
            Return m_Ch3GoodQty
        End Get
        Set(ByVal value As Integer)
            If m_Ch3GoodQty <> value Then
                m_Ch3GoodQty = value
                ReportPropertyChanged("Ch3GoodQty")
            End If
        End Set
    End Property

    Private m_Ch4GoodQty As Integer
    Public Property Ch4GoodQty() As Integer
        Get
            Return m_Ch4GoodQty
        End Get
        Set(ByVal value As Integer)
            If m_Ch4GoodQty <> value Then
                m_Ch4GoodQty = value
                ReportPropertyChanged("Ch4GoodQty")
            End If
        End Set
    End Property

    Private m_TotalGood As Integer
    Public Property TotalGood() As Integer
        Get
            Return m_TotalGood
        End Get
        Set(ByVal value As Integer)
            m_TotalGood = value
        End Set
    End Property

    Private m_Ch1NGQty As Integer
    Public Property Ch1NGQty() As Integer
        Get
            Return m_Ch1NGQty
        End Get
        Set(ByVal value As Integer)
            If m_Ch1NGQty <> value Then
                m_Ch1NGQty = value
                ReportPropertyChanged("Ch1NGQty")
            End If
        End Set
    End Property

    Private m_Ch2NGQty As Integer
    Public Property Ch2NGQty() As Integer
        Get
            Return m_Ch2NGQty
        End Get
        Set(ByVal value As Integer)
            If m_Ch2NGQty <> value Then
                m_Ch2NGQty = value
                ReportPropertyChanged("Ch2NGQty")
            End If
        End Set
    End Property

    Private m_Ch3NGQty As Integer
    Public Property Ch3NGQty() As Integer
        Get
            Return m_Ch3NGQty
        End Get
        Set(ByVal value As Integer)
            If m_Ch3NGQty <> value Then
                m_Ch3NGQty = value
                ReportPropertyChanged("Ch3NGQty")
            End If
        End Set
    End Property

    Private m_Ch4NGQty As Integer
    Public Property Ch4NGQty() As Integer
        Get
            Return m_Ch4NGQty
        End Get
        Set(ByVal value As Integer)
            If m_Ch4NGQty <> value Then
                m_Ch4NGQty = value
                ReportPropertyChanged("Ch4NGQty")
            End If
        End Set
    End Property

    Private m_Ch1OsNgQty As Integer
    Public Property Ch1OsNgQty() As Integer
        Get
            Return m_Ch1OsNgQty
        End Get
        Set(ByVal value As Integer)
            If m_Ch1OsNgQty <> value Then
                m_Ch1OsNgQty = value
                ReportPropertyChanged("Ch1OsNgQty")
            End If
        End Set
    End Property

    Private m_Ch2OsNgQty As Integer
    Public Property Ch2OsNgQty() As Integer
        Get
            Return m_Ch2OsNgQty
        End Get
        Set(ByVal value As Integer)
            If m_Ch2OsNgQty <> value Then
                m_Ch2OsNgQty = value
                ReportPropertyChanged("Ch2OsNgQty")
            End If
        End Set
    End Property

    Private m_Ch3OsNgQty As Integer
    Public Property Ch3OsNgQty() As Integer
        Get
            Return m_Ch3OsNgQty
        End Get
        Set(ByVal value As Integer)
            If m_Ch3OsNgQty <> value Then
                m_Ch3OsNgQty = value
                ReportPropertyChanged("Ch3OsNgQty")
            End If
        End Set
    End Property

    Private m_Ch4OsNgQty As Integer
    Public Property Ch4OsNgQty() As Integer
        Get
            Return m_Ch4OsNgQty
        End Get
        Set(ByVal value As Integer)
            If m_Ch4OsNgQty <> value Then
                m_Ch4OsNgQty = value
                ReportPropertyChanged("Ch4OsNgQty")
            End If
        End Set
    End Property

    Private m_TotalNG As Integer
    Public Property TotalNG() As Integer
        Get
            Return m_TotalNG
        End Get
        Set(ByVal value As Integer)
            m_TotalNG = value
        End Set
    End Property

    Private m_OPNo As String
    Public Property OPNo() As String
        Get
            Return m_OPNo
        End Get
        Set(ByVal value As String)
            If m_OPNo <> value Then
                m_OPNo = value
                ReportPropertyChanged("OPNo")
            End If
        End Set
    End Property

    Private m_OPRate As Double
    Public Property OPRate() As Double
        Get
            Return m_OPRate
        End Get
        Set(ByVal value As Double)
            If m_OPRate <> value Then
                m_OPRate = value
                ReportPropertyChanged("OPRate")
            End If
        End Set
    End Property

    Private m_WorkingSlip As WorkingSlip
    Public Property WorkingSlip() As WorkingSlip
        Get
            Return m_WorkingSlip
        End Get
        Set(ByVal value As WorkingSlip)
            If Not ReferenceEquals(m_WorkingSlip, value) Then
                m_WorkingSlip = value
                ReportPropertyChanged("WorkingSlip")
            End If
        End Set
    End Property

    Private m_OIS As OIS
    Public Property OIS() As OIS
        Get
            Return m_OIS
        End Get
        Set(ByVal value As OIS)
            If Not ReferenceEquals(m_OIS, value) Then
                m_OIS = value
                ReportPropertyChanged("OIS")
            End If
        End Set
    End Property

    Private m_LCL As Single
    Public Property LCL() As Single
        Get
            Return m_LCL
        End Get
        Set(ByVal value As Single)
            If m_LCL <> value Then
                m_LCL = value
                ReportPropertyChanged("LCL")
            End If
        End Set
    End Property

#Region "FTMachineSetting"

    Private m_RPMSetting As Single = 75
    Public Property RPMSetting() As Single
        Get
            Return m_RPMSetting
        End Get
        Set(ByVal value As Single)
            If m_RPMSetting <> value Then
                m_RPMSetting = value
                ReportPropertyChanged("RPMSetting")
            End If
        End Set
    End Property

    Private m_OPRateSetting As Single = 75
    Public Property OPRateSetting() As Single
        Get
            Return m_OPRateSetting
        End Get
        Set(ByVal value As Single)
            If m_OPRateSetting <> value Then
                m_OPRateSetting = value
                ReportPropertyChanged("OPRateSetting")
            End If
        End Set
    End Property

    Private m_MTTRSetting As Single
    Public Property MTTRSetting() As Single
        Get
            Return m_MTTRSetting
        End Get
        Set(ByVal value As Single)
            If m_MTTRSetting <> value Then
                m_MTTRSetting = value
                ReportPropertyChanged("MTTRSetting")
            End If
        End Set
    End Property

    Private m_MTBFSetting As Single
    Public Property MTBFSetting() As Single
        Get
            Return m_MTBFSetting
        End Get
        Set(ByVal value As Single)
            If m_MTBFSetting <> value Then
                m_MTBFSetting = value
                ReportPropertyChanged("MTBFSetting")
            End If
        End Set
    End Property

    Private m_MachineType As String
    Public Property MachineType() As String
        Get
            Return m_MachineType
        End Get
        Set(ByVal value As String)
            If m_MachineType <> value Then
                m_MachineType = value
                ReportPropertyChanged("MachineType")
            End If
        End Set
    End Property

    Private m_PDMachineType As String
    Public Property PDMachineType() As String
        Get
            Return m_PDMachineType
        End Get
        Set(ByVal value As String)
            If m_PDMachineType <> value Then
                m_PDMachineType = value
                ReportPropertyChanged("PDMachineType")
            End If
        End Set
    End Property

    Private m_MoxaIP As String
    Public Property MoxaIP() As String
        Get
            Return m_MoxaIP
        End Get
        Set(ByVal value As String)
            If m_MoxaIP <> value Then
                m_MoxaIP = value
                ReportPropertyChanged("MoxaIP")
            End If
        End Set
    End Property

    Private m_PositionX As Integer
    Public Property PositionX() As Integer
        Get
            Return m_PositionX
        End Get
        Set(ByVal value As Integer)
            If m_PositionX <> value Then
                m_PositionX = value
                ReportPropertyChanged("PositionX")
            End If
        End Set
    End Property

    Private m_PositionY As Integer
    Public Property PositionY() As Integer
        Get
            Return m_PositionY
        End Get
        Set(ByVal value As Integer)
            If m_PositionY <> value Then
                m_PositionY = value
                ReportPropertyChanged("PositionY")
            End If
        End Set
    End Property

    Private m_SelfConIP As String
    Public Property SelfConIP() As String
        Get
            Return m_SelfConIP
        End Get
        Set(ByVal value As String)
            If m_SelfConIP <> value Then
                m_SelfConIP = value
                ReportPropertyChanged("SelfConIP")
            End If
        End Set
    End Property

    Private m_UseAutoMode As Boolean
    Public Property UseAutoMode() As Boolean
        Get
            Return m_UseAutoMode
        End Get
        Set(ByVal value As Boolean)
            If m_UseAutoMode <> value Then
                m_UseAutoMode = value
                ReportPropertyChanged("UseAutoMode")
            End If
        End Set
    End Property

#End Region

    Private m_ASIRetest As Integer
    Public Property ASIRetest() As Integer
        Get
            Return m_ASIRetest
        End Get
        Set(ByVal value As Integer)
            If m_ASIRetest <> value Then
                m_ASIRetest = value
                ReportPropertyChanged("ASIRetest")
            End If
        End Set
    End Property

    Private m_RPM As Single?
    Public Property RPM() As Single?
        Get
            Return m_RPM
        End Get
        Set(ByVal value As Single?)
            If Not m_RPM.Equals(value) Then
                m_RPM = value
                ReportPropertyChanged("RPM")
            End If
        End Set
    End Property

    Private m_RPMMax As Single?
    Public Property RPMMax() As Single?
        Get
            Return m_RPMMax
        End Get
        Set(ByVal value As Single?)
            If Not m_RPMMax.Equals(value) Then
                m_RPMMax = value
                ReportPropertyChanged("RPMMax")
            End If
        End Set
    End Property

    Private m_RPMAverage As Single
    Public Property RPMAverage() As Single
        Get
            Return m_RPMAverage
        End Get
        Set(ByVal value As Single)
            If Not m_RPMAverage.Equals(value) Then
                m_RPMAverage = value
                ReportPropertyChanged("RPMAverage")
            End If
        End Set
    End Property

    Public Function GetCurrentMTBF() As Single
        Dim ret As Single
        ret = CSng(Me.RunningTime.TotalMinutes / (Me.Alarms.Count + 1))
        Return ret
    End Function

    Public Function GetCurrentMTTR() As Single
        Dim ret As Single

        If Me.Alarms.Count > 0 Then
            ret = CSng(Me.AlarmTime.TotalMinutes / Me.Alarms.Count)
        Else
            ret = 0
        End If

        Return ret
    End Function

    Private m_RunningTime As TimeSpan

    <XmlIgnore()> _
    Public Property RunningTime() As TimeSpan
        Get
            Return m_RunningTime
        End Get
        Set(ByVal value As TimeSpan)
            If m_RunningTime <> value Then
                m_RunningTime = value
                ReportPropertyChanged("RunningTime")
            End If
        End Set
    End Property

    Property RunningTimeTicks() As Long
        Get
            Return m_RunningTime.Ticks
        End Get
        Set(ByVal value As Long)
            m_RunningTime = TimeSpan.FromTicks(value)
        End Set
    End Property

    Private m_StopTime As TimeSpan
    <XmlIgnore()> _
    Public Property StopTime() As TimeSpan
        Get
            Return m_StopTime
        End Get
        Set(ByVal value As TimeSpan)
            If m_StopTime <> value Then
                m_StopTime = value
                ReportPropertyChanged("StopTime")
            End If
        End Set
    End Property

    Property StopTimeTicks() As Long
        Get
            Return m_StopTime.Ticks
        End Get
        Set(ByVal value As Long)
            m_StopTime = TimeSpan.FromTicks(value)
        End Set
    End Property

    Private m_State As MachineStateType
    Public Property State() As MachineStateType
        Get
            Return m_State
        End Get
        Set(ByVal value As MachineStateType)
            If m_State <> value Then
                ClearAlarm()
                Dim p As MachineStateType = m_State
                m_State = value
                ReportPropertyChanged("State")
                RaiseEvent MachineStateChanged(Me, New MachineStateChangedEventArgs(m_State, p))
            End If
        End Set
    End Property

    Private m_YieldHistory As List(Of YieldData)
    Public ReadOnly Property YieldHistory() As List(Of YieldData)
        Get
            Return m_YieldHistory
        End Get
    End Property

    Private m_LotEndDataHistory As List(Of LotEndData)
    'retest history
    Public ReadOnly Property LotEndDataHistory() As List(Of LotEndData)
        Get
            Return m_LotEndDataHistory
        End Get
    End Property

    Private m_MessageBuffer As String
    Public Property MessageBuffer() As String
        Get
            Return m_MessageBuffer
        End Get
        Set(ByVal value As String)
            m_MessageBuffer = value
        End Set
    End Property

    Private m_LBSendBuff As String
    Public Property LBSendBuff() As String
        Get
            Return m_LBSendBuff
        End Get
        Set(ByVal value As String)
            m_LBSendBuff = value
        End Set
    End Property

    Private m_CountTimeStamp As DateTime
    Public Property CountTimeStamp() As DateTime
        Get
            Return m_CountTimeStamp
        End Get
        Set(ByVal value As DateTime)
            If m_CountTimeStamp <> value Then
                m_CountTimeStamp = value
            End If
        End Set
    End Property

    Private m_CommLogFileName As String
    <XmlIgnore()> _
    Public Property CommLogFileName() As String
        Get
            Return m_CommLogFileName
        End Get
        Set(ByVal value As String)
            m_CommLogFileName = value
        End Set
    End Property

    'Private m_EquipmentList As List(Of Equipment)
    ''<XmlArray()> _
    'Public Property EquipmentList() As List(Of Equipment)
    '    Get
    '        Return m_EquipmentList
    '    End Get
    '    Set(ByVal value As List(Of Equipment))
    '        m_EquipmentList = value
    '    End Set
    'End Property

    Private m_StandardRPM As Single?
    Public Property StandardRPM() As Single?
        Get
            Return m_StandardRPM
        End Get
        Set(ByVal value As Single?)
            m_StandardRPM = value
        End Set
    End Property


#Region "2014-09-22 [WORKING RECORD]"

    Private m_EndOPNo As String 'varchar(8)
    Public Property EndOPNo() As String
        Get
            Return m_EndOPNo
        End Get
        Set(ByVal value As String)
            m_EndOPNo = value
        End Set
    End Property

    Private m_FirstGoodBin1Qty As Integer
    Public Property FirstGoodBin1Qty() As Integer
        Get
            Return m_FirstGoodBin1Qty
        End Get
        Set(ByVal value As Integer)
            m_FirstGoodBin1Qty = value
        End Set
    End Property

    Private m_FirstGoodBin2Qty As Integer
    Public Property FirstGoodBin2Qty() As Integer
        Get
            Return m_FirstGoodBin2Qty
        End Get
        Set(ByVal value As Integer)
            m_FirstGoodBin2Qty = value
        End Set
    End Property

    Private m_FirstNGQty As Integer
    Public Property FirstNGQty() As Integer
        Get
            Return m_FirstNGQty
        End Get
        Set(ByVal value As Integer)
            m_FirstNGQty = value
        End Set
    End Property

    Private m_FirstMeka1Qty As Integer
    Public Property FirstMeka1Qty() As Integer
        Get
            Return m_FirstMeka1Qty
        End Get
        Set(ByVal value As Integer)
            m_FirstMeka1Qty = value
        End Set
    End Property

    Private m_FirstMeka2Qty As Integer
    Public Property FirstMeka2Qty() As Integer
        Get
            Return m_FirstMeka2Qty
        End Get
        Set(ByVal value As Integer)
            m_FirstMeka2Qty = value
        End Set
    End Property

    Private m_FirstUnknowQty As Integer
    Public Property FirstUnknowQty() As Integer
        Get
            Return m_FirstUnknowQty
        End Get
        Set(ByVal value As Integer)
            m_FirstUnknowQty = value
        End Set
    End Property

    Private m_SecondGoodBin1Qty As Integer?
    Public Property SecondGoodBin1Qty() As Integer?
        Get
            Return m_SecondGoodBin1Qty
        End Get
        Set(ByVal value As Integer?)
            m_SecondGoodBin1Qty = value
        End Set
    End Property

    Private m_SecondGoodBin2Qty As Integer?
    Public Property SecondGoodBin2Qty() As Integer?
        Get
            Return m_SecondGoodBin2Qty
        End Get
        Set(ByVal value As Integer?)
            m_SecondGoodBin2Qty = value
        End Set
    End Property

    Private m_SecondNGQty As Integer?
    Public Property SecondNGQty() As Integer?
        Get
            Return m_SecondNGQty
        End Get
        Set(ByVal value As Integer?)
            m_SecondNGQty = value
        End Set
    End Property

    Private m_SecondMeka1Qty As Integer?
    Public Property SecondMeka1Qty() As Integer?
        Get
            Return m_SecondMeka1Qty
        End Get
        Set(ByVal value As Integer?)
            m_SecondMeka1Qty = value
        End Set
    End Property

    Private m_SecondMeka4Qty As Integer?
    Public Property SecondMeka4Qty() As Integer?
        Get
            Return m_SecondMeka4Qty
        End Get
        Set(ByVal value As Integer?)
            m_SecondMeka4Qty = value
        End Set
    End Property

    Private m_SecondUnknowQty As Integer?
    Public Property SecondUnknowQty() As Integer?
        Get
            Return m_SecondUnknowQty
        End Get
        Set(ByVal value As Integer?)
            m_SecondUnknowQty = value
        End Set
    End Property

#End Region

#Region "2014-10-10 [WORKING RECORD]"

    Private m_Ch1PatQty As Integer
    Public Property Ch1PatQty() As Integer
        Get
            Return m_Ch1PatQty
        End Get
        Set(ByVal value As Integer)
            m_Ch1PatQty = value
            ReportPropertyChanged("Ch1PatQty")
        End Set
    End Property

    Private m_Ch2PatQty As Integer
    Public Property Ch2PatQty() As Integer
        Get
            Return m_Ch2PatQty
        End Get
        Set(ByVal value As Integer)
            m_Ch2PatQty = value
            ReportPropertyChanged("Ch2PatQty")
        End Set
    End Property

    Private m_Ch3PatQty As Integer
    Public Property Ch3PatQty() As Integer
        Get
            Return m_Ch3PatQty
        End Get
        Set(ByVal value As Integer)
            m_Ch3PatQty = value
            ReportPropertyChanged("Ch3PatQty")
        End Set
    End Property

    Private m_Ch4PatQty As Integer
    Public Property Ch4PatQty() As Integer
        Get
            Return m_Ch4PatQty
        End Get
        Set(ByVal value As Integer)
            m_Ch4PatQty = value
            ReportPropertyChanged("Ch4PatQty")
        End Set
    End Property

    Private m_Ch1OutputQty As Integer
    Public Property Ch1OutputQty() As Integer
        Get
            Return m_Ch1OutputQty
        End Get
        Set(ByVal value As Integer)
            m_Ch1OutputQty = value
        End Set
    End Property

    Private m_Ch2OutputQty As Integer
    Public Property Ch2OutputQty() As Integer
        Get
            Return m_Ch2OutputQty
        End Get
        Set(ByVal value As Integer)
            m_Ch2OutputQty = value
        End Set
    End Property

    Private m_Ch3OutputQty As Integer
    Public Property Ch3OutputQty() As Integer
        Get
            Return m_Ch3OutputQty
        End Get
        Set(ByVal value As Integer)
            m_Ch3OutputQty = value
        End Set
    End Property

    Private m_Ch4OutputQty As Integer
    Public Property Ch4OutputQty() As Integer
        Get
            Return m_Ch4OutputQty
        End Get
        Set(ByVal value As Integer)
            m_Ch4OutputQty = value
        End Set
    End Property

    Private m_OutputQty As Integer
    Public Property OutputQty() As Integer
        Get
            Return m_OutputQty
        End Get
        Set(ByVal value As Integer)
            m_OutputQty = value
        End Set
    End Property

    Private m_TestTemperature As String
    Public Property TestTemperature() As String
        Get
            Return m_TestTemperature
        End Get
        Set(ByVal value As String)
            m_TestTemperature = value
        End Set
    End Property

    Private m_InitialYield As Single
    Public Property InitialYield() As Single
        Get
            Return m_InitialYield
        End Get
        Set(ByVal value As Single)
            m_InitialYield = value
        End Set
    End Property

    Private m_FirstEndYield As Single?
    Public Property FirstEndYield() As Single?
        Get
            Return m_FirstEndYield
        End Get
        Set(ByVal value As Single?)
            m_FirstEndYield = value
        End Set
    End Property

    Private m_FinalYield As Single
    Public Property FinalYield() As Single
        Get
            Return m_FinalYield
        End Get
        Set(ByVal value As Single)
            m_FinalYield = value
        End Set
    End Property

    Private m_MarkingInspection As Boolean?
    Public Property MarkingInspection() As Boolean?
        Get
            Return m_MarkingInspection
        End Get
        Set(ByVal value As Boolean?)
            m_MarkingInspection = value
        End Set
    End Property

    Private m_LotStartVisualInspectTotalQty As Short
    Public Property LotStartVisualInspectTotalQty() As Short
        Get
            Return m_LotStartVisualInspectTotalQty
        End Get
        Set(ByVal value As Short)
            m_LotStartVisualInspectTotalQty = value
        End Set
    End Property

    Private m_LotStartVisualInspectNGQty As Short
    Public Property LotStartVisualInspectNGQty() As Short
        Get
            Return m_LotStartVisualInspectNGQty
        End Get
        Set(ByVal value As Short)
            m_LotStartVisualInspectNGQty = value
        End Set
    End Property

    Private m_GoodSampleQty As Short
    Public Property GoodSampleQty() As Short
        Get
            Return m_GoodSampleQty
        End Get
        Set(ByVal value As Short)
            m_GoodSampleQty = value
        End Set
    End Property

    Private m_NGSampleQty As Short
    Public Property NGSampleQty() As Short
        Get
            Return m_NGSampleQty
        End Get
        Set(ByVal value As Short)
            m_NGSampleQty = value
        End Set
    End Property

    Private m_SocketCheck As String 'char(1)
    Public Property SocketCheck() As String
        Get
            Return m_SocketCheck
        End Get
        Set(ByVal value As String)
            m_SocketCheck = value
        End Set
    End Property

#End Region

#Region "2014-10-21 [WORKING RECORD]"

    Private m_ChannelATesterNo As String
    Public Property ChannelATesterNo() As String
        Get
            Return m_ChannelATesterNo
        End Get
        Set(ByVal value As String)
            m_ChannelATesterNo = value
        End Set
    End Property

    Private m_ChannelBTesterNo As String
    Public Property ChannelBTesterNo() As String
        Get
            Return m_ChannelBTesterNo
        End Get
        Set(ByVal value As String)
            m_ChannelBTesterNo = value
        End Set
    End Property

    Private m_ChannelAFtb As String
    Public Property ChannelAFtb() As String
        Get
            Return m_ChannelAFtb
        End Get
        Set(ByVal value As String)
            m_ChannelAFtb = value
        End Set
    End Property

    Private m_ChannelBFtb As String
    Public Property ChannelBFtb() As String
        Get
            Return m_ChannelBFtb
        End Get
        Set(ByVal value As String)
            m_ChannelBFtb = value
        End Set
    End Property

#End Region

#Region "2015-01-07 [WORKING RECORD]"

    Private m_TotalMeka1 As Integer
    Public Property TotalMeka1() As Integer
        Get
            Return m_TotalMeka1
        End Get
        Set(ByVal value As Integer)
            m_TotalMeka1 = value
        End Set
    End Property

    Private m_TotalMeka2 As Integer
    Public Property TotalMeka2() As Integer
        Get
            Return m_TotalMeka2
        End Get
        Set(ByVal value As Integer)
            m_TotalMeka2 = value
        End Set
    End Property

    Private m_TotalMeka4 As Integer
    Public Property TotalMeka4() As Integer
        Get
            Return m_TotalMeka4
        End Get
        Set(ByVal value As Integer)
            m_TotalMeka4 = value
        End Set
    End Property

    Private m_FirstAutoAsiChecked As Boolean?
    Public Property FirstAutoAsiChecked() As Boolean?
        Get
            Return m_FirstAutoAsiChecked
        End Get
        Set(ByVal value As Boolean?)
            m_FirstAutoAsiChecked = value
        End Set
    End Property

    Private m_SecondAutoAsiChecked As Boolean?
    Public Property SecondAutoAsiChecked() As Boolean?
        Get
            Return m_SecondAutoAsiChecked
        End Get
        Set(ByVal value As Boolean?)
            m_SecondAutoAsiChecked = value
        End Set
    End Property

#End Region

#Region "2015-04-20 [WORKING RECORD]"

    Private m_SocketCh1 As String
    Public Property SocketCh1() As String
        Get
            Return m_SocketCh1
        End Get
        Set(ByVal value As String)
            m_SocketCh1 = value
        End Set
    End Property

    Private m_SocketCh2 As String
    Public Property SocketCh2() As String
        Get
            Return m_SocketCh2
        End Get
        Set(ByVal value As String)
            m_SocketCh2 = value
        End Set
    End Property

    Private m_SocketCh3 As String
    Public Property SocketCh3() As String
        Get
            Return m_SocketCh3
        End Get
        Set(ByVal value As String)
            m_SocketCh3 = value
        End Set
    End Property

    Private m_SocketCh4 As String
    Public Property SocketCh4() As String
        Get
            Return m_SocketCh4
        End Get
        Set(ByVal value As String)
            m_SocketCh4 = value
        End Set
    End Property

    Private m_ChangedSocketCh1 As String
    Public Property ChangedSocketCh1() As String
        Get
            Return m_ChangedSocketCh1
        End Get
        Set(ByVal value As String)
            m_ChangedSocketCh1 = value
        End Set
    End Property

    Private m_ChangedSocketCh2 As String
    Public Property ChangedSocketCh2() As String
        Get
            Return m_ChangedSocketCh2
        End Get
        Set(ByVal value As String)
            m_ChangedSocketCh2 = value
        End Set
    End Property

    Private m_ChangedSocketCh3 As String
    Public Property ChangedSocketCh3() As String
        Get
            Return m_ChangedSocketCh3
        End Get
        Set(ByVal value As String)
            m_ChangedSocketCh3 = value
        End Set
    End Property

    Private m_ChangedSocketCh4 As String
    Public Property ChangedSocketCh4() As String
        Get
            Return m_ChangedSocketCh4
        End Get
        Set(ByVal value As String)
            m_ChangedSocketCh4 = value
        End Set
    End Property

#End Region

#Region "2015-08-17 [WORKING RECORD]"

    Private m_LotJudgement As String
    Public Property LotJudgement() As String
        Get
            Return m_LotJudgement
        End Get
        Set(ByVal value As String)
            m_LotJudgement = value
        End Set
    End Property

    Private m_Remark As String
    Public Property Remark() As String
        Get
            Return m_Remark
        End Get
        Set(ByVal value As String)
            m_Remark = value
        End Set
    End Property

#End Region

    Public Sub ClearAlarm()
        If m_CurrentAlarm IsNot Nothing Then
            m_CurrentAlarm.ClearTime = Now
            Dim e As AlarmWasClearedEventArgs = New AlarmWasClearedEventArgs(m_CurrentAlarm)
            m_CurrentAlarm = Nothing
            RaiseEvent AlarmWasCleared(Me, e)
        End If
    End Sub

    Public Sub New()
        m_Alarms = New BindingList(Of Alarm)
        m_YieldHistory = New List(Of YieldData)
        m_LotEndDataHistory = New List(Of LotEndData)
        m_CountTimeStamp = Now 'support old version
        'm_Testers = New List(Of Tester)
        'm_EquipmentList = New List(Of Equipment)
    End Sub

    Public Sub ApplyMachineSetting(ByVal row As DBxDataSet.FTMachineSettingRow)
        'should assign via property to raise the PropertyChanged event 
        MCNo = row.MCNo
        MachineType = row.MachineType
        If Not row.IsPDMachineTypeNull() Then
            PDMachineType = row.PDMachineType
        End If
        If Not row.IsRPMSettingNull() Then
            RPMSetting = row.RPMSetting
        End If
        If Not row.IsOPRateSettingNull() Then
            OPRateSetting = row.OPRateSetting
        End If
        If Not row.IsMTTRSettingNull() Then
            MTTRSetting = row.MTTRSetting
        End If
        If Not row.IsMTBFSettingNull() Then
            MTBFSetting = row.MTBFSetting
        End If
        If Not row.IsMoxaIPNull() Then
            MoxaIP = row.MoxaIP
        End If
        If Not row.IsSelfConIPNull() Then
            SelfConIP = row.SelfConIP
        End If
        If Not row.IsUseAutoModeNull() Then
            m_UseAutoMode = row.UseAutoMode
        End If
        PositionX = row.PositionX
        PositionY = row.PositionY
    End Sub

    Public Sub LotStart()
        Dim tmp As Date = Now
        Me.LotStartTime = tmp.AddMilliseconds(-tmp.Millisecond) 'remove millisecond
        Me.CountTimeStamp = tmp
        Me.RaiseEventLotStarted()
    End Sub

    Public Sub LotComplete(ByVal opEnd As String)
        '-----  MDH ------
        'LG, OPNo
        'LG,4955
        '----- IFTN ------
        'LG, เวลา, เวลา, เวลา
        'LG, 229,    4, ,  73
        If Not Me.LotCompleteTime.HasValue Then
            Dim tmp As Date = Now
            Me.LotCompleteTime = tmp.AddMilliseconds(-tmp.Millisecond) 'remove millisecond
        End If

        'sometime, LG command has come without LE command
        Me.RequireNewLotSetupBeforeLA = True
        Me.EndOPNo = opEnd
        Me.State = MachineStateType.LotComplete

        Me.RaiseEventLotCompleted()
        'apply new socket setup to current
        If m_ChangedSocketCh1 IsNot Nothing Then
            m_SocketCh1 = m_ChangedSocketCh1
            m_ChangedSocketCh1 = Nothing
        End If
        If m_ChangedSocketCh2 IsNot Nothing Then
            m_SocketCh2 = m_ChangedSocketCh2
            m_ChangedSocketCh2 = Nothing
        End If
        If m_ChangedSocketCh3 IsNot Nothing Then
            m_SocketCh3 = m_ChangedSocketCh3
            m_ChangedSocketCh3 = Nothing
        End If
        If m_ChangedSocketCh4 IsNot Nothing Then
            m_SocketCh4 = m_ChangedSocketCh4
            m_ChangedSocketCh4 = Nothing
        End If
    End Sub

    Public Sub Reset()

        Me.ASICycle = 0
        Me.Alarms.Clear()
        Me.AlarmTime = TimeSpan.Zero
        Me.AlarmTimeTicks = 0
        Me.ASIFTEYield = 0
        Me.ASIFTSYield = 0
        Me.ASIGoodPcs = 0
        Me.ASINGTimes = 0
        Me.ASIRetest = 0
        Me.ASITestPcs = 0
        Me.Ch1GoodQty = 0
        Me.Ch1NGQty = 0
        Me.Ch1OsNgQty = 0
        Me.Ch1OutputQty = 0
        Me.Ch1PatQty = 0
        Me.Ch2GoodQty = 0
        Me.Ch2NGQty = 0
        Me.Ch2OsNgQty = 0
        Me.Ch2OutputQty = 0
        Me.Ch2PatQty = 0
        Me.Ch3GoodQty = 0
        Me.Ch3NGQty = 0
        Me.Ch3OsNgQty = 0
        Me.Ch3OutputQty = 0
        Me.Ch3PatQty = 0
        Me.Ch4GoodQty = 0
        Me.Ch4NGQty = 0
        Me.Ch4OsNgQty = 0
        Me.Ch4OutputQty = 0
        Me.Ch4PatQty = 0
        Me.ChangedSocketCh1 = ""
        Me.ChangedSocketCh2 = ""
        Me.ChangedSocketCh3 = ""
        Me.ChangedSocketCh4 = ""
        Me.ChannelAFtb = ""
        Me.ChannelATesterNo = ""
        Me.ChannelBFtb = ""
        Me.ChannelBTesterNo = ""
        Me.CurrentAlarm = Nothing
        Me.EndOPNo = ""
        Me.FinalYield = 0
        Me.FirstAutoAsiChecked = Nothing
        Me.FirstEndYield = Nothing
        Me.FirstGoodBin1Qty = 0
        Me.FirstGoodBin2Qty = 0
        Me.FirstMeka1Qty = 0
        Me.FirstMeka2Qty = 0
        Me.FirstNGQty = 0
        Me.FirstUnknowQty = 0
        Me.GoodSampleQty = 0
        Me.InitialYield = 0
        Me.InputQty = 0
        Me.LBSendBuff = ""
        Me.LCL = 0
        Me.LotCompleteTime = Nothing
        Me.LotEndDataHistory.Clear()
        Me.LotInputTime = Nothing
        Me.LotJudgement = ""
        Me.LotStartTime = Nothing
        Me.LotStartVisualInspectNGQty = 0
        Me.LotStartVisualInspectTotalQty = 0
        Me.MarkingInspection = Nothing
        Me.MessageBuffer = ""
        Me.NGSampleQty = 0
        Me.OIS = Nothing
        Me.OPNo = ""
        Me.OPRate = 0
        'Me.Output = ProductOutput.Zero
        Me.OutputQty = 0
        Me.Remark = ""
        Me.RequireNewLotSetupBeforeLA = False
        Me.RPM = Nothing
        Me.RPMAverage = 0
        Me.RPMMax = 0
        Me.RunningTime = TimeSpan.Zero
        Me.RunningTimeTicks = 0
        Me.SecondAutoAsiChecked = Nothing
        Me.SecondGoodBin1Qty = Nothing
        Me.SecondMeka1Qty = Nothing
        Me.SecondNGQty = Nothing
        Me.SecondUnknowQty = Nothing
        Me.SocketCh1 = ""
        Me.SocketCh2 = ""
        Me.SocketCh3 = ""
        Me.SocketCh4 = ""
        Me.SocketCheck = ""
        Me.StandardRPM = Nothing
        Me.State = MachineStateType.Locked
        Me.StopTime = TimeSpan.Zero
        Me.StopTimeTicks = 0
        Me.TestTemperature = ""
        Me.TotalGood = 0
        Me.TotalMeka1 = 0
        Me.TotalMeka2 = 0
        Me.TotalMeka4 = 0
        Me.TotalNG = 0
        Me.WorkingSlip = Nothing

        Me.YieldHistory.Clear()

    End Sub

#Region "RaiseEvent Methods"

    Private Sub RaiseEventLotStarted()
        RaiseEvent LotStarted(Me, EventArgs.Empty)
    End Sub

    Private Sub RaiseEventLotCompleted()
        RaiseEvent LotCompleted(Me, EventArgs.Empty)
    End Sub

    Friend Sub RaiseEventOutputChanged()
        RaiseEvent OutputChanged(Me, EventArgs.Empty)
    End Sub

    Friend Sub RaiseEventRecordedCommLog(ByVal e As RecordedCommLogEventArgs)
        RaiseEvent RecordedCommLog(Me, e)
    End Sub

    Friend Sub RaiseEventRemoved()
        RaiseEvent Removed(Me, EventArgs.Empty)
    End Sub

    Friend Sub RaiseEventYieldCaptured()
        RaiseEvent YieldCaptured(Me, EventArgs.Empty)
    End Sub

    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    Private Sub ReportPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

#End Region

End Class
