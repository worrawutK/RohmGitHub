Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing.Drawing2D
Imports Rohm.Ems
Imports System.Data.SqlClient
Imports Rohm.Apcs.Tdc
Imports System.ServiceModel
Imports SelfCon.Rohm.FT.SettingService
Public Class FormMain

    'Private Function ConvertOISSlipToOIS(ByVal o As OIS) As OIS8
    '    Dim p As OIS = New OIS()
    '    p.Box = o.Box
    '    p.DeviceName = o.Device
    '    p.Header = o.Header
    '    p.InputRank = o.InputRank
    '    p.PackageName = o.PackageName
    '    p.ProgramName = o.ProgramName
    '    p.TesterType = o.TesterType
    '    p.TestFlow = o.TestFlow
    '    Return p
    'End Function

    'Private Function ConvertAssySlip252ToWorkSlip(ByVal assySlip As AssySlip252) As WorkingSlip
    '    Dim ws As WorkingSlip = New WorkingSlip()
    '    ws.CleamCounterMeasure = assySlip.CleamCounterMeasure
    '    ws.CodeNo = assySlip.CodeNo
    '    ws.DeviceName = assySlip.DeviceName
    '    ws.FarSetDirection = assySlip.FarSetDirection
    '    ws.ForIndication1 = assySlip.ForIndication1
    '    ws.ForIndication2 = assySlip.ForIndication2
    '    ws.FrameType = assySlip.FrameType
    '    ws.FTDevice = assySlip.FTDevice
    '    ws.LotNo = assySlip.LotNo
    '    ws.MarkingSpec1 = assySlip.MarkingSpec1
    '    ws.MarkingSpec2 = assySlip.MarkingSpec2
    '    ws.MarkingSpec3 = assySlip.MarkingSpec3
    '    ws.MarkingStep = assySlip.MarkingStep
    '    ws.MarkNo = assySlip.MarkNo
    '    ws.MarkType = assySlip.MarkType
    '    ws.Mask = assySlip.Mask
    '    ws.NewPackageName = assySlip.NewPackageName
    '    ws.OSFTChange = assySlip.OSFTChange
    '    ws.OSProgram = assySlip.OSProgram
    '    ws.PackageName = assySlip.PackageName
    '    ws.PDFree = assySlip.PDFree
    '    ws.ReelCount = assySlip.ReelCount
    '    ws.SubRank = assySlip.SubRank
    '    ws.TapingDirection = assySlip.TapingDirection
    '    ws.ULMark = assySlip.ULMark
    '    ws.WaferLotNo = assySlip.WaferLotNo

    '    Return ws

    'End Function

#Region "Variables Decralation"

    Private m_MachineList As List(Of Machine)
    Private m_StartDate As Date
    Private m_EmsClient As EmsServiceClient
    Private m_ProgramLog As Logger
    Private m_DataErrorLog As Logger
    Private m_StateManager As StateManager
    Private m_MessageRouter As MessageController
    Private m_ActiveMachine As FTMachine
    Private m_AuthenUser As AuthenticationUser.AuthenUser
    Private m_GraphGen1 As OPAlarmGraphGenerator
    Private m_UserWorkTime As WorkTime
    Private m_TDCService As TdcService
    Private m_EcoWatch As EcoWatch

#End Region

#Region "Single Instance"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_StartDate = Now
        m_MachineList = New List(Of Machine)
        m_EmsClient = New EmsServiceClient(My.Settings.EmsServiceUrl)
        m_ProgramLog = New Logger(Path.Combine(My.Settings.LogDirectory, "Program.log"), "[{0}] --> {1}")
        m_DataErrorLog = New Logger(Path.Combine(My.Settings.DataErrorDirectory, "DataError.log"), "{0}")
        m_StateManager = New StateManager(My.Settings.StateDirectory, m_ProgramLog)
        m_MessageRouter = New MessageController()
        m_AuthenUser = New AuthenticationUser.AuthenUser()
        m_GraphGen1 = New OPAlarmGraphGenerator()
        m_TDCService = TdcService.GetInstance()
        m_TDCService.ConnectionString = My.Settings.TDCConnectionString

        m_EcoWatch = New EcoWatch()
        AddHandler m_EcoWatch.EcoTimeLimit, AddressOf m_EcoWatch_EcoTimeLimit
        AddHandler m_EcoWatch.EcoClientRemoved, AddressOf m_EcoWatch_EcoClientRemoved
        m_EcoWatch.WatchDuration = My.Settings.EcoWatchDuration

        If TypeOf m_TDCService.Logger Is TdcLoggerTextWriter Then
            Dim textFileLogger As TdcLoggerTextWriter = CType(m_TDCService.Logger, TdcLoggerTextWriter)
            textFileLogger.Enabled = True
            textFileLogger.LogFolder = Path.Combine(My.Application.Info.DirectoryPath, "TDC")
        End If

    End Sub

    Private Sub TimeSpanBinding_Format(ByVal sender As Object, ByVal e As ConvertEventArgs)
        Dim t As TimeSpan = CType(e.Value, TimeSpan)
        e.Value = Formatter.Format2(t)
    End Sub

#End Region

#Region "Eco Mode"

    Private Sub m_EcoWatch_EcoTimeLimit(ByVal mcNo As String)

        For Each mc As Machine In m_MachineList

            If mc.MCNo = mcNo Then

                Dim setupRecord As DBxDataSet.FTSetupReportRow

                Using adaptor As DBxDataSetTableAdapters.FTSetupReportTableAdapter = New DBxDataSetTableAdapters.FTSetupReportTableAdapter()
                    Using tbl As DBxDataSet.FTSetupReportDataTable = adaptor.GetDataByMCNo(STRING_TDC_MACHINENO_PREFIX & mcNo)
                        If tbl.Rows.Count = 0 Then
                            m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-007", "Not found SetupRecord [" & STRING_TDC_MACHINENO_PREFIX & mcNo & "]")
                            Exit Sub
                        Else
                            setupRecord = CType(tbl.Rows(0), DBxDataSet.FTSetupReportRow)
                        End If
                    End Using
                End Using

                If setupRecord.IsTesterNoBNull() Then
                    m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-008", "No Tester Type of Setup record")
                    Exit Sub
                End If

                Dim mailBoxPath As String = ""

                Using prox As SettingServiceSoapClient = New SettingServiceSoapClient()

                    Try
                        mailBoxPath = prox.GetMailBoxPath(setupRecord.TesterType)
                    Catch ex As Exception
                        m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-001", ex.Message)
                        Exit Sub
                    End Try

                End Using

                If String.IsNullOrEmpty(mailBoxPath) Then
                    m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-002", "Empty MailBox Path")
                    Exit Sub
                ElseIf Not Directory.Exists(mailBoxPath) Then
                    m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-003", "MailBox Path was not found := " & mailBoxPath)
                    Exit Sub
                End If

                Dim testerNo As String
                Dim testerMailBox As String

                If Not setupRecord.IsTesterNoANull() AndAlso _
                   Not setupRecord.IsTesterNoBNull() AndAlso _
                   setupRecord.TesterNoA = setupRecord.TesterNoB Then

                    testerNo = GetNumberFromTesterNo(setupRecord.TesterNoA)
                    testerMailBox = Path.Combine(mailBoxPath, testerNo)

                    Try

                        Using File.Create(Path.Combine(testerMailBox, "eco_off.txt"))
                        End Using

                    Catch ex As Exception
                        m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-004", ex.Message)
                    End Try

                Else

                    If Not setupRecord.IsTesterNoANull() Then
                        testerNo = GetNumberFromTesterNo(setupRecord.TesterNoA)
                        testerMailBox = Path.Combine(mailBoxPath, testerNo)
                        Try
                            Using File.Create(Path.Combine(testerMailBox, "eco_off.txt"))
                            End Using
                        Catch ex As Exception
                            m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-005", ex.Message)
                        End Try

                    End If


                    testerNo = GetNumberFromTesterNo(setupRecord.TesterNoB)
                    testerMailBox = Path.Combine(mailBoxPath, testerNo)
                    Try
                        Using File.Create(Path.Combine(testerMailBox, "eco_off.txt"))
                        End Using
                    Catch ex As Exception
                        m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-006", ex.Message)
                    End Try

                End If
                Exit For
            End If
        Next
    End Sub

    Public Sub m_EcoWatch_EcoClientRemoved(ByVal mcNo As String)
        For Each mc As Machine In m_MachineList

            If mc.MCNo = mcNo Then

                Dim setupRecord As DBxDataSet.FTSetupReportRow

                Using adaptor As DBxDataSetTableAdapters.FTSetupReportTableAdapter = New DBxDataSetTableAdapters.FTSetupReportTableAdapter()
                    Using tbl As DBxDataSet.FTSetupReportDataTable = adaptor.GetDataByMCNo(STRING_TDC_MACHINENO_PREFIX & mcNo)
                        If tbl.Rows.Count = 0 Then
                            m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-007", "Not found SetupRecord [" & STRING_TDC_MACHINENO_PREFIX & mcNo & "]")
                            Exit Sub
                        Else
                            setupRecord = CType(tbl.Rows(0), DBxDataSet.FTSetupReportRow)
                        End If
                    End Using
                End Using


                If setupRecord.IsTesterNoBNull() Then
                    m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-008", "No Tester Type of Setup record")
                    Exit Sub
                End If

                Dim mailBoxPath As String = ""

                Using prox As SettingServiceSoapClient = New SettingServiceSoapClient()

                    Try
                        mailBoxPath = prox.GetMailBoxPath(setupRecord.TesterType)
                    Catch ex As Exception
                        m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-001", ex.Message)
                        Exit Sub
                    End Try

                End Using

                If String.IsNullOrEmpty(mailBoxPath) Then
                    m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-002", "Empty MailBox Path")
                    Exit Sub
                ElseIf Not Directory.Exists(mailBoxPath) Then
                    m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-003", "MailBox Path was not found := " & mailBoxPath)
                    Exit Sub
                End If

                Dim testerNo As String
                Dim testerMailBox As String
                Dim ecoOffFileName As String

                If Not setupRecord.IsTesterNoANull() AndAlso _
                   Not setupRecord.IsTesterNoBNull() AndAlso _
                   setupRecord.TesterNoA = setupRecord.TesterNoB Then

                    testerNo = GetNumberFromTesterNo(setupRecord.TesterNoA)
                    testerMailBox = Path.Combine(mailBoxPath, testerNo)
                    ecoOffFileName = Path.Combine(testerMailBox, "eco_off.txt")

                    Try

                        If File.Exists(ecoOffFileName) Then
                            File.Delete(ecoOffFileName)
                        End If

                    Catch ex As Exception
                        m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-004", ex.Message)
                    End Try

                Else

                    If Not setupRecord.IsTesterNoANull() Then
                        testerNo = GetNumberFromTesterNo(setupRecord.TesterNoA)
                        testerMailBox = Path.Combine(mailBoxPath, testerNo)
                        ecoOffFileName = Path.Combine(testerMailBox, "eco_off.txt")
                        Try

                            If File.Exists(ecoOffFileName) Then
                                File.Delete(ecoOffFileName)
                            End If
                        Catch ex As Exception
                            m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-005", ex.Message)
                        End Try

                    End If


                    testerNo = GetNumberFromTesterNo(setupRecord.TesterNoB)
                    testerMailBox = Path.Combine(mailBoxPath, testerNo)
                    ecoOffFileName = Path.Combine(testerMailBox, "eco_off.txt")

                    Try

                        If File.Exists(ecoOffFileName) Then
                            File.Delete(ecoOffFileName)
                        End If
                    Catch ex As Exception
                        m_ProgramLog.Write("m_EcoWatch_EcoTimeLimit-006", ex.Message)
                    End Try

                End If
                Exit For
            End If
        Next
    End Sub

    Private Function GetNumberFromTesterNo(ByVal testerNo As String) As String
        Dim ret As String = ""

        'find number in tester no example : 15TN
        For Each c As Char In testerNo
            If IsNumeric(c) Then
                ret = ret & c
            End If
        Next
        'tester folder need atleast 3 charactors example : 015
        ret = CInt(ret).ToString("D3")

        Return ret
    End Function

#End Region

#Region "Form and Control Event"

    Private Sub frmSelfCon_FormClosing(ByVal sender As Object, _
                                       ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim ftmc As FTMachine
        Dim mc As Machine
        Using dt As DBxDataSet.FTMachineSettingDataTable = New DBxDataSet.FTMachineSettingDataTable()
            Dim row As DBxDataSet.FTMachineSettingRow
            For Each ctrl As Control In FtMachinePanel1.Controls
                If TypeOf ctrl Is FTMachine Then
                    ftmc = CType(ctrl, FTMachine)
                    mc = ftmc.Machine
                    row = dt.NewFTMachineSettingRow()
                    row.MCNo = mc.MCNo
                    row.MachineType = mc.MachineType
                    row.PDMachineType = mc.PDMachineType
                    row.RPMSetting = mc.RPMSetting
                    row.OPRateSetting = mc.OPRateSetting
                    row.MTTRSetting = mc.MTTRSetting
                    row.MTBFSetting = mc.MTBFSetting
                    row.MoxaIP = mc.MoxaIP
                    row.SelfConIP = mc.SelfConIP
                    row.PositionX = ftmc.Left
                    row.PositionY = ftmc.Top
                    row.UseAutoMode = mc.UseAutoMode
                    dt.Rows.Add(row)
                    row.AcceptChanges()
                    row.SetModified()
                End If
            Next
            Try
                FtMachineSettingTableAdapter1.Update(dt)
            Catch ex As Exception
                m_ProgramLog.Write("frmSelfCon_FormClosing-001", ex.Message)
            End Try
        End Using
        m_StateManager.Save(m_MachineList, m_GraphGen1.Data, m_UserWorkTime)

        If My.Settings.EmsEnabled Then
            Try
                m_EmsClient.[Stop]()
            Catch ex As Exception
                m_ProgramLog.Write("frmSelfCon_FormClosing-002", ex.Message)
            End Try
        End If

        Try
            m_StateManager.SaveEchoWatchState(m_EcoWatch.Clients)
        Catch ex As Exception
            m_ProgramLog.Write("frmSelfCon_FormClosing-004", ex.Message)
        End Try

        m_EcoWatch.StopWatch()

        m_ProgramLog.Write("frmSelfCon_FormClosing-003", "Program close")
    End Sub

    Private Sub HandleNewMachine(ByVal mc As Machine)
        m_MachineList.Add(mc)
        m_MessageRouter.Add(mc)

        If My.Settings.EmsEnabled Then
            Dim ws As WorkingSlip = mc.WorkingSlip
            Dim lotNo As String = ""
            If ws IsNot Nothing Then
                lotNo = ws.LotNo
            End If
            Dim reg As EmsMachineRegisterInfo = New EmsMachineRegisterInfo(mc.MCNo, My.Settings.LineNo, My.Settings.ProcessName, _
                                                                           mc.MachineType, lotNo, mc.TotalGood, _
                                                                           mc.TotalNG, mc.RPMSetting, 0, 0)
            m_EmsClient.Register(reg)
        End If

        mc.CommLogFileName = Path.Combine(My.Settings.LogDirectory, mc.MCNo & ".log")

        'set the name of control
        Dim mcCtrl As FTMachine = New FTMachine(mc)
        mcCtrl.Name = mc.MCNo
        mcCtrl.Size = New System.Drawing.Size(80, 80)
        AddHandler mcCtrl.Click, AddressOf FTMachine_Click
        AddHandler mc.LotCompleted, AddressOf Machine_LotCompleted
        AddHandler mc.LotStarted, AddressOf Machine_LotStarted
        AddHandler mc.MachineStateChanged, AddressOf Machine_MachineStateChanged
        AddHandler mc.OutputChanged, AddressOf Machine_OutputChanged
        AddHandler mc.AlarmWasCleared, AddressOf Machine_AlarmWasCleared
        AddHandler mc.Removed, AddressOf Machine_Removed
        AddHandler mc.YieldCaptured, AddressOf Machine_YieldCapture
        m_ActiveMachine = mcCtrl
        Me.FtMachinePanel1.Controls.Add(mcCtrl)

        mcCtrl.BringToFront()

    End Sub

    Private Sub UnHandlerMachine(ByVal mc As Machine)
        m_MachineList.Remove(mc)
        m_MessageRouter.Remove(mc)

        If My.Settings.EmsEnabled Then
            m_EmsClient.Remove(My.Settings.ProcessName, mc.MCNo)
        End If

        RemoveHandler mc.LotCompleted, AddressOf Machine_LotCompleted
        RemoveHandler mc.LotStarted, AddressOf Machine_LotStarted
        RemoveHandler mc.MachineStateChanged, AddressOf Machine_MachineStateChanged
        RemoveHandler mc.OutputChanged, AddressOf Machine_OutputChanged
        RemoveHandler mc.AlarmWasCleared, AddressOf Machine_AlarmWasCleared
        RemoveHandler mc.Removed, AddressOf Machine_Removed
        RemoveHandler mc.YieldCaptured, AddressOf Machine_YieldCapture

    End Sub

    Private Sub Machine_Removed(ByVal sender As Object, ByVal e As EventArgs)
        Dim mc As Machine = CType(sender, Machine)
        UnHandlerMachine(mc)

        m_EcoWatch.Remove(mc.MCNo)

    End Sub

    Private Sub Machine_YieldCapture(ByVal sender As Object, ByVal e As EventArgs)
        If m_ActiveMachine IsNot Nothing AndAlso ReferenceEquals(m_ActiveMachine.Machine, sender) Then
            PopulateYieldChart(m_ActiveMachine.Machine)
        End If
    End Sub

    Private Sub Machine_AlarmWasCleared(ByVal sender As Object, ByVal e As AlarmWasClearedEventArgs)
        m_GraphGen1.CollectData(e.Alarm)
    End Sub

    Private Sub Machine_OutputChanged(ByVal sender As Object, ByVal e As EventArgs)
        If My.Settings.EmsEnabled Then
            Dim mc As Machine = CType(sender, Machine)
            m_EmsClient.SetOutput(My.Settings.ProcessName, mc.MCNo, mc.TotalGood, mc.TotalNG)
        End If
    End Sub

    Private Sub Machine_LotCompleted(ByVal sender As Object, ByVal e As EventArgs)

        Dim mc As Machine = CType(sender, Machine)

        If mc.WorkingSlip IsNot Nothing AndAlso mc.LotStartTime.HasValue Then
            Try
                SaveFTData(mc)
            Catch ex As Exception
                m_ProgramLog.Write("Machine_LotCompleted-001", ex.Message)
            End Try

            SaveFTAlarmInfo(mc)
            SaveUkebaraiData(mc)
        End If

        If My.Settings.TdcEnabled Then
            Dim opNo As String
            If String.IsNullOrEmpty(mc.EndOPNo) Then
                opNo = mc.OPNo
            Else
                opNo = mc.EndOPNo
            End If
            Dim result As TdcResponse = m_TDCService.LotEnd(STRING_TDC_MACHINENO_PREFIX & mc.MCNo, mc.WorkingSlip.LotNo, mc.LotCompleteTime.Value, mc.TotalGood, mc.TotalNG, EndModeType.Normal, opNo)
        End If

        'for safe energy : requested by Mr.Chaisiri
        m_EcoWatch.Add(mc.MCNo)

        Try
            'update socket count !!!
            UpdateSocketCountToJigTempData(mc)
        Catch ex As Exception
            m_ProgramLog.Write("UpdateSocketCountToJigTempData", ex.Message)
        End Try

    End Sub

    Private Sub UpdateSocketCountToJigTempData(ByVal mc As Machine)

        Dim mcNo As String = STRING_TDC_MACHINENO_PREFIX & mc.MCNo

        Using adap1 As DBxDataSetTableAdapters.FTSetupReportTableAdapter = New DBxDataSetTableAdapters.FTSetupReportTableAdapter()
            Using con As SqlConnection = adap1.Connection
                con.Open()

                Using tbl1 As DBxDataSet.FTSetupReportDataTable = adap1.GetDataByMCNo(mcNo)

                    If tbl1.Rows.Count = 1 Then

                        Dim totalOfUse As Integer = 0
                        totalOfUse = mc.Ch1GoodQty + mc.Ch1NGQty + mc.Ch1PatQty _
                            + mc.Ch2GoodQty + mc.Ch2NGQty + mc.Ch2PatQty _
                            + mc.Ch3GoodQty + mc.Ch3NGQty + mc.Ch3PatQty _
                            + mc.Ch4GoodQty + mc.Ch4NGQty + mc.Ch4PatQty

                        Dim setupRecord As DBxDataSet.FTSetupReportRow = CType(tbl1.Rows(0), DBxDataSet.FTSetupReportRow)

                        Using adap2 As DBxDataSetTableAdapters.TempDataTableAdapter = New DBxDataSetTableAdapters.TempDataTableAdapter()

                            adap2.Connection = con

                            Using tbl2 As DBxDataSet.TempDataDataTable = New DBxDataSet.TempDataDataTable()
                                adap2.ClearBeforeFill = False

                                If Not setupRecord.IsQRCodesocketChannel1Null() AndAlso _
                                Not String.IsNullOrEmpty(setupRecord.QRCodesocketChannel1) Then
                                    adap2.FillByQRCode(tbl2, setupRecord.QRCodesocketChannel1)
                                End If

                                If Not setupRecord.IsQRCodesocketChannel2Null() AndAlso _
                                Not String.IsNullOrEmpty(setupRecord.QRCodesocketChannel2) Then
                                    adap2.FillByQRCode(tbl2, setupRecord.QRCodesocketChannel2)
                                End If

                                If Not setupRecord.IsQRCodesocketChannel3Null() AndAlso _
                                Not String.IsNullOrEmpty(setupRecord.QRCodesocketChannel3) Then
                                    adap2.FillByQRCode(tbl2, setupRecord.QRCodesocketChannel3)
                                End If

                                If Not setupRecord.IsQRCodesocketChannel4Null() AndAlso _
                                Not String.IsNullOrEmpty(setupRecord.QRCodesocketChannel4) Then
                                    adap2.FillByQRCode(tbl2, setupRecord.QRCodesocketChannel4)
                                End If

                                '*** in DBxDataSet please see Update command of DBxDataSetTableAdapters.TempDataTableAdapter
                                'it will update only LifeTime and MCNo
                                For Each row As DBxDataSet.TempDataRow In tbl2.Rows
                                    row.LifeTime = row.LifeTime + totalOfUse
                                    row.MCNo = mc.MCNo 'MCNo's data type is varchar(10)
                                Next

                                adap2.Update(tbl2)

                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub SaveUkebaraiData(ByVal mc As Machine)
        'save to UkebaraiData on DBx
        Dim process_No As String = ""
        Select Case mc.OIS.TestFlow
            Case "AUTO1", "AUTO"
                process_No = "00892"
            Case "AUTO2"
                process_No = "00893"
            Case "AUTO3"
                process_No = "00894"
            Case "AUTO4"
                process_No = "00895"
            Case "OS/2"
                process_No = "00891" 'OS
        End Select

        Using dt As DBxDataSet.UkebaraiDataDataTable = UkebaraiDataTableAdapter1.GetDataByPKs(My.Settings.FTProcessID, _
                                                                                              mc.WorkingSlip.LotNo, _
                                                                                              mc.MCNo, _
                                                                                              mc.LotStartTime.Value)

            Dim row As DBxDataSet.UkebaraiDataRow

            If dt.Rows.Count = 0 Then
                row = dt.NewUkebaraiDataRow()
                row.DBxProcessID = My.Settings.FTProcessID
                row.DBxLotNo = mc.WorkingSlip.LotNo
                row.DBxMCNo = mc.MCNo
                row.DBxLotStartTime = mc.LotStartTime.Value
                dt.Rows.Add(row)
            Else
                row = CType(dt.Rows(0), DBxDataSet.UkebaraiDataRow)
            End If

            row.DBxLotEndTime = mc.LotCompleteTime.Value
            row.LotNo = mc.WorkingSlip.LotNo
            row.Process_No = process_No
            row._Date = mc.LotCompleteTime.Value.ToString("yyMMdd")
            row.Time = mc.LotCompleteTime.Value.ToString("HHmm")
            row.Good_Qty = mc.TotalGood.ToString("D5")
            row.NG_Qty = mc.TotalNG.ToString("D5")

            Try
                UkebaraiDataTableAdapter1.Update(dt)
            Catch ex As Exception
                Dim msg As String = vbNewLine & vbTab & "ErrorMessage :" & ex.Message & _
                   vbNewLine & vbTab & "ExceptionType :" & ex.GetType().ToString() & _
                   vbNewLine & vbTab & "FileName :" & WriteDataErrorLog(dt)
                m_DataErrorLog.Write(msg)
            End Try
        End Using

    End Sub

    Private Sub SaveFTAlarmInfo(ByVal mc As Machine)
        'save to AlarmInfo on DBx
        Using dt As DBxDataSet.FTAlarmInfoDataTable = New DBxDataSet.FTAlarmInfoDataTable()
            Dim row As DBxDataSet.FTAlarmInfoRow
            For Each a As Alarm In mc.Alarms
                If a.AlarmID <> -1 AndAlso a.ClearTime.HasValue AndAlso Not a.IsSaved Then 'avoid unknow alarm
                    row = dt.NewFTAlarmInfoRow()
                    row.AlarmID = a.AlarmID
                    row.ClearTime = a.ClearTime.Value
                    row.RecordTime = a.RecordTime
                    row.LotNo = mc.WorkingSlip.LotNo
                    row.MCNo = mc.MCNo
                    dt.Rows.Add(row)
                End If
            Next
            Try
                FtAlarmInfoTableAdapter1.Update(dt)
                For Each a As Alarm In mc.Alarms
                    If a.AlarmID <> -1 AndAlso a.ClearTime.HasValue Then
                        a.IsSaved = True
                    End If
                Next
            Catch ex As Exception
                Dim msg As String = vbNewLine & vbTab & "ErrorMessage :" & ex.Message & _
                   vbNewLine & vbTab & "ExceptionType :" & ex.GetType().ToString() & _
                   vbNewLine & vbTab & "FileName :" & WriteDataErrorLog(dt)
                m_DataErrorLog.Write(msg)
            End Try
        End Using
    End Sub

    Private Sub SaveFTData(ByVal mc As Machine)
        'save to FTData on DBx
        Using dt As DBxDataSet.FTDataDataTable = FtDataTableAdapter1.GetDataByPKs(mc.MCNo, mc.WorkingSlip.LotNo, mc.LotStartTime.Value)
            Dim row As DBxDataSet.FTDataRow
            If dt.Rows.Count = 1 Then
                row = CType(dt.Rows(0), DBxDataSet.FTDataRow)
            Else
                row = dt.NewFTDataRow()
                'PK
                row.MCNo = mc.MCNo
                row.LotNo = mc.WorkingSlip.LotNo
                row.LotStartTime = mc.LotStartTime.Value
                'add to table
                dt.Rows.Add(row)
            End If

            row.MCType = mc.MachineType
            row.OPNo = mc.OPNo
            row.InputQty = mc.InputQty
            row.TotalGood = mc.TotalGood
            row.TotalNG = mc.TotalNG
            row.OPRate = CSng(mc.OPRate)
            If mc.RPMMax.HasValue Then
                row.MaximumRPM = mc.RPMMax.Value
            Else
                row.SetMaximumRPMNull()
            End If
            row.AverageRPM = mc.RPMAverage
            row.MTBF = mc.GetCurrentMTBF()
            row.MTTR = mc.GetCurrentMTTR()
            row.AlarmTotal = CShort(mc.Alarms.Count)

            If mc.LotCompleteTime.HasValue Then
                row.LotEndTime = mc.LotCompleteTime.Value
            Else
                row.SetLotEndTimeNull()
            End If

            row.RunTime = CSng(mc.RunningTime.TotalMinutes)
            row.StopTime = CSng(mc.StopTime.TotalMinutes)
            row.AlarmTime = CSng(mc.AlarmTime.TotalMinutes)

            'support old OIS
            'program name contains pattern
            'example : FU24591B P24591(A-U)A
            Dim tmpP As String = mc.OIS.ProgramName
            If tmpP.Contains(" ") Then
                tmpP = tmpP.Split(" "c)(0)
            End If

            '2014-09-24
            row.ProgramName = tmpP
            row.TestFlowName = mc.OIS.TestFlow
            row.TesterType = mc.OIS.TesterType
            row.BoxName = mc.OIS.Box
            row.EndOPNo = mc.EndOPNo
            row.FirstGoodBin1Qty = mc.FirstGoodBin1Qty
            row.FirstGoodBin2Qty = mc.FirstGoodBin2Qty
            row.FirstNGQty = mc.FirstNGQty
            row.FirstMeka1Qty = mc.FirstMeka1Qty
            row.FirstMeka2Qty = mc.FirstMeka2Qty
            row.FirstUnknowQty = mc.FirstUnknowQty

            If mc.SecondGoodBin1Qty.HasValue Then
                row.SecondGoodBin1Qty = mc.SecondGoodBin1Qty.Value
            Else
                row.SetSecondGoodBin1QtyNull()
            End If
            If mc.SecondGoodBin2Qty.HasValue Then
                row.SecondGoodBin2Qty = mc.SecondGoodBin2Qty.Value
            Else
                row.SetSecondGoodBin2QtyNull()
            End If
            If mc.SecondNGQty.HasValue Then
                row.SecondNGQty = mc.SecondNGQty.Value
            Else
                row.SetSecondNGQtyNull()
            End If
            If mc.SecondMeka1Qty.HasValue Then
                row.SecondMeka1Qty = mc.SecondMeka1Qty.Value
            Else
                row.SetSecondMeka1QtyNull()
            End If
            If mc.SecondMeka4Qty.HasValue Then
                row.SecondMeka4Qty = mc.SecondMeka4Qty.Value
            Else
                row.SetSecondMeka4QtyNull()
            End If
            If mc.SecondUnknowQty.HasValue Then
                row.SecondUnknowQty = mc.SecondUnknowQty.Value
            Else
                row.SetSecondUnknowQtyNull()
            End If

            '2014-09-29
            row.LCL = mc.LCL
            row.InitialYield = mc.InitialYield
            If mc.FirstEndYield.HasValue Then
                row.FirstEndYield = mc.FirstEndYield.Value
            Else
                row.SetFirstEndYieldNull()
            End If
            row.FinalYield = mc.FinalYield

            '2014-10-11
            If Not String.IsNullOrEmpty(mc.TestTemperature) Then
                row.TestTemperature = mc.TestTemperature
            End If
            If mc.MarkingInspection.HasValue Then
                row.MarkingInspection = mc.MarkingInspection.Value
            End If
            row.SocketCheck = mc.SocketCheck
            row.NGSampleQty = mc.NGSampleQty
            row.GoodSampleQty = mc.GoodSampleQty
            row.LotStartVisualInspectNGQty = mc.LotStartVisualInspectNGQty
            row.LotStartVisualInspectTotalQty = mc.LotStartVisualInspectTotalQty
            'row.FirstAutoAsiCheck = ...

            '2014-10-21
            row.ChannelATestBoxNo = mc.ChannelAFtb
            row.ChannelATesterNo = mc.ChannelATesterNo
            row.ChannelBTestBoxNo = mc.ChannelBFtb
            row.ChannelBTesterNo = mc.ChannelBTesterNo

            '2014-11-25, 2015-01-07, 2017-05-29
            row.TotalGoodBin1Qty = mc.Ch1GoodQty + mc.Ch2GoodQty + mc.Ch3GoodQty + mc.Ch4GoodQty
            row.TotalGoodBin2Qty = mc.Ch1PatQty + mc.Ch2PatQty + mc.Ch3PatQty + mc.Ch4PatQty
            row.TotalMeka1Qty = mc.TotalMeka1
            row.TotalMeka2Qty = mc.TotalMeka2
            row.TotalMeka4Qty = mc.TotalMeka4
            row.TotalUnknowQty = 0
            row.TotalNGQty = mc.TotalNG

            '2015-01-07
            If mc.FirstAutoAsiChecked.HasValue Then
                row.FirstAutoAsiCheck = mc.FirstAutoAsiChecked.Value
            Else
                row.SetFirstAutoAsiCheckNull()
            End If
            If mc.SecondAutoAsiChecked.HasValue Then
                row.SecondAutoAsiCheck = mc.SecondAutoAsiChecked.Value
            Else
                row.SetSecondAutoAsiCheckNull()
            End If

            '2015-04-20
            If mc.ChangedSocketCh1 IsNot Nothing OrElse _
               mc.ChangedSocketCh2 IsNot Nothing OrElse _
               mc.ChangedSocketCh3 IsNot Nothing OrElse _
               mc.ChangedSocketCh4 IsNot Nothing Then
                row.SocketChange = True
            Else
                row.SocketChange = False
            End If

            If mc.SocketCh1 Is Nothing Then
                row.SetSocketNumCh1Null()
            Else
                row.SocketNumCh1 = mc.SocketCh1
            End If

            If mc.SocketCh2 Is Nothing Then
                row.SetSocketNumCh2Null()
            Else
                row.SocketNumCh2 = mc.SocketCh2
            End If

            If mc.SocketCh3 Is Nothing Then
                row.SetSocketNumCh3Null()
            Else
                row.SocketNumCh3 = mc.SocketCh3
            End If

            If mc.SocketCh4 Is Nothing Then
                row.SetSocketNumCh4Null()
            Else
                row.SocketNumCh4 = mc.SocketCh4
            End If

            If mc.ChangedSocketCh1 Is Nothing Then
                row.SetChangedSocketNumCh1Null()
            Else
                row.ChangedSocketNumCh1 = mc.ChangedSocketCh1
            End If

            If mc.ChangedSocketCh2 Is Nothing Then
                row.SetChangedSocketNumCh2Null()
            Else
                row.ChangedSocketNumCh2 = mc.ChangedSocketCh2
            End If

            If mc.ChangedSocketCh3 Is Nothing Then
                row.SetChangedSocketNumCh3Null()
            Else
                row.ChangedSocketNumCh3 = mc.ChangedSocketCh3
            End If

            If mc.ChangedSocketCh4 Is Nothing Then
                row.SetChangedSocketNumCh4Null()
            Else
                row.ChangedSocketNumCh4 = mc.ChangedSocketCh4
            End If

            If String.IsNullOrEmpty(mc.LotJudgement) Then
                row.SetLotJudgementNull()
            Else
                row.LotJudgement = mc.LotJudgement
            End If

            If String.IsNullOrEmpty(mc.Remark) Then
                row.IsRemarkNull()
            Else
                row.Remark = mc.Remark
            End If

            Try
                FtDataTableAdapter1.Update(dt)
            Catch ex As Exception
                Dim msg As String = vbNewLine & vbTab & "ErrorMessage :" & ex.Message & _
                    vbNewLine & vbTab & "ExceptionType :" & ex.GetType().ToString() & _
                    vbNewLine & vbTab & "FileName :" & WriteDataErrorLog(dt)
                m_DataErrorLog.Write(msg)
            End Try
        End Using
    End Sub

    Private Function WriteDataErrorLog(ByVal dataTable As DataTable) As String
        Dim fileName As String = ""
        Try
            fileName = dataTable.TableName & Now.ToString("yyyyMMdd-HHmmss-fff") & ".xml"
            Using sw As StreamWriter = New StreamWriter(Path.Combine(My.Settings.DataErrorDirectory, fileName), False)
                dataTable.WriteXml(sw.BaseStream)
            End Using
        Catch ex As Exception
            m_ProgramLog.Write("WriteDataErrorLog-001", ex.Message)
        End Try
        Return fileName
    End Function

    Private Sub Machine_LotStarted(ByVal sender As Object, ByVal e As EventArgs)

        Dim mc As Machine = CType(sender, Machine)

        If My.Settings.TdcEnabled Then
            Dim result As TdcResponse = m_TDCService.LotSet(STRING_TDC_MACHINENO_PREFIX & mc.MCNo, mc.WorkingSlip.LotNo, mc.LotStartTime.Value, mc.OPNo, RunModeType.Normal)
        End If

        If My.Settings.EmsEnabled Then
            'tel EMS
            Dim rpm As Single
            If mc.StandardRPM.HasValue Then
                rpm = mc.StandardRPM.Value
            Else
                rpm = mc.RPMSetting
            End If
            m_EmsClient.SetCurrentLot(My.Settings.ProcessName, mc.MCNo, mc.WorkingSlip.LotNo, mc.RPMSetting)
        End If

    End Sub

    Private Sub Machine_MachineStateChanged(ByVal sender As Object, ByVal e As MachineStateChangedEventArgs)
        Dim mc As Machine = CType(sender, Machine)
        If My.Settings.EmsEnabled Then
            Select Case e.CurrentState
                Case MachineStateType.Alarm
                    m_EmsClient.SetActivity(My.Settings.ProcessName, mc.MCNo, "Alarm", TmeCategory.ChokotieLoss)
                Case MachineStateType.PlanStop
                    m_EmsClient.SetActivity(My.Settings.ProcessName, mc.MCNo, "Plan Stop", TmeCategory.PlanStopLoss)
                Case MachineStateType.LotEnd
                    m_EmsClient.SetActivity(My.Settings.ProcessName, mc.MCNo, "Lot End", TmeCategory.StopLoss)
                Case MachineStateType.LotComplete
                    m_EmsClient.SetLotEnd(My.Settings.ProcessName, mc.MCNo)
                    m_EmsClient.SetActivity(My.Settings.ProcessName, mc.MCNo, "Lot Completed", TmeCategory.StopLoss)
                Case MachineStateType.Running
                    m_EmsClient.SetActivity(My.Settings.ProcessName, mc.MCNo, "Running", TmeCategory.NetOperationTime)
                Case MachineStateType.AdjustmentStop
                    m_EmsClient.SetActivity(My.Settings.ProcessName, mc.MCNo, "Adjustment Stop", TmeCategory.StopLoss)
            End Select
        End If

        If e.CurrentState = MachineStateType.Running Then
            m_EcoWatch.Remove(mc.MCNo)
        ElseIf e.CurrentState = MachineStateType.PlanStop Then
            'for safe energy : requested by Mr.Chaisiri
            m_EcoWatch.Add(mc.MCNo)
        End If

    End Sub

    Private Sub FTMachine_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim mcCtrl As FTMachine = CType(sender, FTMachine)

        If m_ActiveMachine Is mcCtrl Then
            Exit Sub
        End If

        m_ActiveMachine = mcCtrl
        SetDisplayBinding(mcCtrl.Machine)

    End Sub

    Private Sub frmSelfCon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.lblSelfConVersion.Text = My.Application.Info.Title & " ( " & My.Application.Info.Description & " )"

        AlarmsDataGridView.AutoGenerateColumns = False

        LoadingBackgroundWorker.RunWorkerAsync()

        LoadingForm.GetInstance().ShowDialog()

    End Sub

    Private Sub CheckAndCreateSystemDirectories()
        If Not Directory.Exists(My.Settings.LogDirectory) Then
            Directory.CreateDirectory(My.Settings.LogDirectory)
        End If
        If Not Directory.Exists(My.Settings.StateDirectory) Then
            Directory.CreateDirectory(My.Settings.StateDirectory)
        End If
        If Not Directory.Exists(My.Settings.DataErrorDirectory) Then
            Directory.CreateDirectory(My.Settings.DataErrorDirectory)
        End If
    End Sub

    'i don't know y some properties, example, Label.Visible could not be bind to Machine object
    'when i used MachineBindingSource bind to BindingList(Of Machine)
    'so I have to do this and it's work !!!
    Private Sub SetDisplayBinding(ByVal mc As Machine)

        MachineTypeLabel.DataBindings.Clear()
        MachineTypeLabel.DataBindings.Add("Text", mc, "MachineType")

        PDMachineTypeLabel.DataBindings.Clear()
        PDMachineTypeLabel.DataBindings.Add("Text", mc, "PDMachineType")

        MCNoLabel.DataBindings.Clear()
        MCNoLabel.DataBindings.Add("Text", mc, "MCNo")

        MoxaIPLabel.DataBindings.Clear()
        MoxaIPLabel.DataBindings.Add("Text", mc, "MoxaIP")

        MachineBindingSource.DataSource = mc

        LotNoLabel.DataBindings.Clear()
        LotNoLabel.DataBindings.Add("Text", MachineBindingSource, "WorkingSlip.LotNo")

        PackageLabel.DataBindings.Clear()
        PackageLabel.DataBindings.Add("Text", MachineBindingSource, "WorkingSlip.PackageName")

        FTDeviceLabel.DataBindings.Clear()
        FTDeviceLabel.DataBindings.Add("Text", MachineBindingSource, "WorkingSlip.FTDevice")

        TPDirectionLabel.DataBindings.Clear()
        TPDirectionLabel.DataBindings.Add("Text", MachineBindingSource, "WorkingSlip.TapingDirection")

        StartOPNoLabel.DataBindings.Clear()
        StartOPNoLabel.DataBindings.Add("Text", mc, "OPNo")

        InputQtyLabel.DataBindings.Clear()
        InputQtyLabel.DataBindings.Add("Text", mc, "InputQty")

        LCLLabel.DataBindings.Clear()
        LCLLabel.DataBindings.Add("Text", mc, "LCL")

        BoxNameLabel.DataBindings.Clear()
        BoxNameLabel.DataBindings.Add("Text", MachineBindingSource, "OIS.Box")

        TesterTypeLabel.DataBindings.Clear()
        TesterTypeLabel.DataBindings.Add("Text", MachineBindingSource, "OIS.TesterType")

        TestProgramLabel.DataBindings.Clear()
        TestProgramLabel.DataBindings.Add("Text", MachineBindingSource, "OIS.ProgramName")

        TestFlowLabel.DataBindings.Clear()
        TestFlowLabel.DataBindings.Add("Text", MachineBindingSource, "OIS.TestFlow")

        NewLotRequireLabel.DataBindings.Clear()
        'ในหน้า Design นั้น Property :Visible ต้องถูก Set เป็น True
        'http://bytes.com/topic/visual-basic-net/answers/751123-binding-visible-property-bug
        'Firstly, make sure that the Visible property of the Label is set to true
        'before it is bound to the custom object.

        'If a control is not visible before it is bound to a data source, the data
        'binding won't push data from the data source into the control. This is a by
        'design behavior.

        'Secondly, you need implement the INotifyPropertyChanged interface for the
        'custom object, so that when the values of the properties in the custom
        'object change, the bound control will reflect the change immediately.
        NewLotRequireLabel.DataBindings.Add("Visible", MachineBindingSource, "RequireNewLotSetupBeforeLA")

        StateLabel.DataBindings.Clear()
        StateLabel.DataBindings.Add("Text", mc, "State")

        Ch1GoodLabel.DataBindings.Clear()
        Ch1GoodLabel.DataBindings.Add("Text", mc, "Ch1GoodQty")

        Ch2GoodLabel.DataBindings.Clear()
        Ch2GoodLabel.DataBindings.Add("Text", mc, "Ch2GoodQty")

        Ch3GoodLabel.DataBindings.Clear()
        Ch3GoodLabel.DataBindings.Add("Text", mc, "Ch3GoodQty")

        Ch4GoodLabel.DataBindings.Clear()
        Ch4GoodLabel.DataBindings.Add("Text", mc, "Ch4GoodQty")

        Ch1NGLabel.DataBindings.Clear()
        Ch1NGLabel.DataBindings.Add("Text", mc, "Ch1NGQty")

        Ch2NGLabel.DataBindings.Clear()
        Ch2NGLabel.DataBindings.Add("Text", mc, "Ch2NGQty")

        Ch3NGLabel.DataBindings.Clear()
        Ch3NGLabel.DataBindings.Add("Text", mc, "Ch3NGQty")

        Ch4NGLabel.DataBindings.Clear()
        Ch4NGLabel.DataBindings.Add("Text", mc, "Ch4NGQty")

        '****************************
        Ch1PatLabel.DataBindings.Clear()
        Ch1PatLabel.DataBindings.Add("Text", mc, "Ch1PatQty")

        Ch2PatLabel.DataBindings.Clear()
        Ch2PatLabel.DataBindings.Add("Text", mc, "Ch2PatQty")

        Ch3PatLabel.DataBindings.Clear()
        Ch3PatLabel.DataBindings.Add("Text", mc, "Ch3PatQty")

        Ch4PatLabel.DataBindings.Clear()
        Ch4PatLabel.DataBindings.Add("Text", mc, "Ch4PatQty")
        '****************************

        AsiGoodLabel.DataBindings.Clear()
        AsiGoodLabel.DataBindings.Add("Text", mc, "ASIGoodPcs")

        AsiNGLabel.DataBindings.Clear()
        AsiNGLabel.DataBindings.Add("Text", mc, "ASINGTimes")

        AsiFirstYieldLabel.DataBindings.Clear()
        AsiFirstYieldLabel.DataBindings.Add("Text", mc, "ASIFTSYield")

        AsiEndYieldLabel.DataBindings.Clear()
        AsiEndYieldLabel.DataBindings.Add("Text", mc, "ASIFTEYield")

        LotInputTimeLabel.DataBindings.Clear()
        LotInputTimeLabel.DataBindings.Add("Text", mc, "LotInputTime", True, DataSourceUpdateMode.OnPropertyChanged, "", "yyyy/MM/dd HH:mm:ss")

        LotStartTimeLabel.DataBindings.Clear()
        LotStartTimeLabel.DataBindings.Add("Text", mc, "LotStartTime", True, DataSourceUpdateMode.OnPropertyChanged, "", "yyyy/MM/dd HH:mm:ss")

        LotCompleteTimeLabel.DataBindings.Clear()
        LotCompleteTimeLabel.DataBindings.Add("Text", mc, "LotCompleteTime", True, DataSourceUpdateMode.OnPropertyChanged, "", "yyyy/MM/dd HH:mm:ss")

        ManageTimespanBindingLabel(RunningTimeLabel, mc, "RunningTime")
        ManageTimespanBindingLabel(AlarmTimeLabel, mc, "AlarmTime")
        ManageTimespanBindingLabel(StopTimeLabel, mc, "StopTime")
        'yield chart
        PopulateYieldChart(mc)
        'alarm gridview
        AlarmsDataGridView.DataSource = mc.Alarms

    End Sub

    Private Sub ManageTimespanBindingLabel(ByVal lbl As Label, ByVal mc As Machine, ByVal propertyName As String)
        Dim b As Binding
        If lbl.DataBindings.Count > 0 Then
            b = lbl.DataBindings(0)
            RemoveHandler b.Format, AddressOf TimeSpanBinding_Format
        End If
        lbl.DataBindings.Clear()
        b = lbl.DataBindings.Add("Text", mc, propertyName)
        AddHandler b.Format, AddressOf TimeSpanBinding_Format
    End Sub

    Private Sub btnQRCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQRCode.Click

        'Dim mc As Machine = m_ActiveMachine.Machine

        'Dim op As LotInputOperation = New LotInputOperation()
        'op.Execute(mc)

        'op.ShowResult()

        'If op.IsCompleted Then
        '    Dim wr As WorkRecordForm = WorkRecordForm.GetInstance()
        '    wr.EditWorkRecord(mc)
        '    Dim aop As AutoloadTestProgramOperation = New AutoloadTestProgramOperation()
        '    aop.Execute(mc)
        '    m_ActiveMachine.Refresh()
        'End If

    End Sub

    Private Sub DurationTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DurationTimer.Tick
        Dim temp As TimeSpan
        temp = Now.Subtract(Me.m_StartDate)
        Me.lblDurationTime.Text = Formatter.Format(temp)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If ConfirmationDialog.AskForConfirmation("คุณต้องการปิดโปรแกรม ใช่ หรือ ไม่ ?") = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub btnLotReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLotReset.Click
        If m_ActiveMachine IsNot Nothing Then
            Dim mc As Machine = m_ActiveMachine.Machine
            Dim op As ResetOperation = New ResetOperation()
            op.Execute(mc)

            If op.IsCompleted Then
                m_ActiveMachine.Refresh()
            ElseIf Not String.IsNullOrEmpty(op.Message) Then
                InformationMessageBox.Inform(op.Message)
            End If

        End If
    End Sub

    Private Sub btnBMRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBMRequest.Click
        If m_ActiveMachine Is Nothing Then
            Exit Sub
        End If
        IE.OpenUrl(My.Settings.BMRequestUrl & "?" & WebRequestParameter.PopulateBMRequestQueryString(m_ActiveMachine.Machine, My.Settings.LineNo))
    End Sub

    Private Sub btnPMRepaire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPMRepaire.Click
        If m_ActiveMachine Is Nothing Then
            Exit Sub
        End If
        IE.OpenUrl(My.Settings.PMRequestUrl & "?" & WebRequestParameter.PopulatePMRequestQueryString(m_ActiveMachine.Machine))
    End Sub

    Private Sub btnAndon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAndon.Click
        IE.OpenUrl(My.Settings.AndonRequestUrl)
    End Sub

    Private Sub btnAutoLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoLoad.Click
        If m_ActiveMachine Is Nothing Then
            Exit Sub
        End If
        Dim op As AutoloadTestProgramOperation = New AutoloadTestProgramOperation()
        op.Execute(m_ActiveMachine.Machine)
        If Not op.IsCompleted Then
            InformationMessageBox.Inform(op.Message)
        End If
    End Sub

    Private Sub lblLineNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLineNo.Click
        Dim newLineNo As String = InputBox("กรุณากรอก Line No.", "SelfCon", My.Settings.LineNo)
        If Not String.IsNullOrEmpty(newLineNo) AndAlso newLineNo <> My.Settings.LineNo Then
            My.Settings.LineNo = newLineNo
            My.Settings.Save()
        End If
    End Sub

#End Region

    Private Sub PopulateYieldChart(ByVal machine As Machine)
        chartYield.BeginInit()
        'change some properties that can not change in design time
        Dim s1 As Series = chartYield.Series("CH1Series")
        Dim s2 As Series = chartYield.Series("CH2Series")
        Dim s3 As Series = chartYield.Series("EndYieldSeries")
        Dim s4 As Series = chartYield.Series("LCLSeries")
        Dim s5 As Series = chartYield.Series("CH3Series")
        Dim s6 As Series = chartYield.Series("CH4Series")
        Dim ca As ChartArea = chartYield.ChartAreas(0)
        s1.Points.Clear()
        s2.Points.Clear()
        s3.Points.Clear()
        s4.Points.Clear()
        s5.Points.Clear()
        s6.Points.Clear()
        s1.LegendText = "CH1"
        s2.LegendText = "CH2"
        s5.LegendText = "CH3"
        s6.LegendText = "CH4"

        Dim yields As List(Of YieldData) = machine.YieldHistory
        Dim lcl As Single = machine.LCL
        Dim h As Hashtable = New Hashtable()
        'fixed column
        Dim p As DataPoint
        Dim o As Integer
        For i As Integer = 0 To YIELD_MONITOR_OUTPUTS.Length - 1
            p = New DataPoint(i, lcl)
            o = YIELD_MONITOR_OUTPUTS(i)
            p.AxisLabel = o.ToString()
            s4.Points.Add(p)
            h.Add(o, i)
            If machine.InputQty < o Then
                ca.AxisX.Maximum = i + 1
                Exit For
            End If
        Next
        ca.AxisX.Minimum = -1
        Dim minY As Double = 95
        Dim pIndex As Integer
        For Each d As YieldData In yields
            If h.ContainsKey(d.Output) Then
                pIndex = CInt(h(d.Output))
            Else
                pIndex = CInt(ca.AxisX.Maximum)
                ca.AxisX.Maximum += 1
            End If
            Select Case d.Channel
                Case MachineChannelType.CH1
                    s1.Points.Add(New DataPoint(pIndex, d.YieldValue))
                Case MachineChannelType.CH2
                    s2.Points.Add(New DataPoint(pIndex, d.YieldValue))
                Case MachineChannelType.CH3
                    s5.Points.Add(New DataPoint(pIndex, d.YieldValue))
                Case MachineChannelType.CH4
                    s6.Points.Add(New DataPoint(pIndex, d.YieldValue))
                Case MachineChannelType.All
                    p = New DataPoint(pIndex, d.YieldValue)
                    p.AxisLabel = d.Comment
                    s3.Points.Add(p)
            End Select
            minY = Math.Min(d.YieldValue, minY)
        Next
        ca.AxisY.Minimum = Math.Floor(minY) - 1
        chartYield.EndInit()
        h.Clear()
        h = Nothing
    End Sub

    Private Sub SetupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetupButton.Click

        Dim mc As Machine = m_ActiveMachine.Machine

        Using f As FormSetupReport = New FormSetupReport()
            f.ViewSetupReportOfMachine(STRING_TDC_MACHINENO_PREFIX & mc.MCNo)
            f.ShowDialog()
        End Using
    End Sub

    Private Sub ClearLogTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearLogTimer.Tick
        ClearLogTimer.Stop()
        Dim tmp As Date = Now
        Dim tmps As TimeSpan = tmp.Subtract(My.Settings.ClearLogTimeStamp).Duration()
        If tmps.Days > My.Settings.ClearLogIntervalDays Then
            Dim files As String() = Directory.GetFiles(My.Settings.LogDirectory, "*.log")
            For Each f As String In files
                Try
                    File.Delete(f)
                Catch ex As Exception
                End Try
            Next
            My.Settings.ClearLogTimeStamp = tmp
            My.Settings.Save()
        End If
        ClearLogTimer.Start()
    End Sub

    Private Sub SaveStateTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveStateTimer.Tick
        m_StateManager.Save(m_MachineList, m_GraphGen1.Data, m_UserWorkTime)
    End Sub

    Private Sub WorkTimeCheckTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkTimeCheckTimer.Tick
        WorkTimeCheckTimer.Stop()
        If m_UserWorkTime.EndTime < Now Then
            m_UserWorkTime = WorkTime.GetCurrent()
            m_GraphGen1.WorkTime = m_UserWorkTime
        End If
        WorkTimeCheckTimer.Start()
    End Sub

    Private Sub DisableEnableTdcToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisableEnableTdcToolStripMenuItem.Click

        Dim fOp As OperatorNoInputDialog = OperatorNoInputDialog.GetInstance()
        If fOp.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If

        If m_AuthenUser.AuthenUser(fOp.OPNo, "System") Then
            My.Settings.TdcEnabled = Not My.Settings.TdcEnabled
            DisplayTdcSetting()
            My.Settings.Save()
        Else
            InformationMessageBox.Inform("คุณไม่มีสิทธิ์ใช้งานในส่วนนี้ (System เท่านั้น)")
        End If
    End Sub

    Private Sub DisplayTdcSetting()
        DisableEnableTdcToolStripMenuItem.Checked = My.Settings.TdcEnabled
        If My.Settings.TdcEnabled Then
            TdcLabel.ForeColor = Color.Black
            TdcLabel.BackColor = Color.Lime
        Else
            TdcLabel.ForeColor = Color.Yellow
            TdcLabel.BackColor = Color.Red
        End If
    End Sub

    Private Sub DisplayEmsSetting()
        EMSToolStripMenuItem.Checked = My.Settings.EmsEnabled
        If My.Settings.EmsEnabled Then
            EmsLabel.ForeColor = Color.Black
            EmsLabel.BackColor = Color.Lime
        Else
            EmsLabel.ForeColor = Color.Yellow
            EmsLabel.BackColor = Color.Red
        End If
    End Sub

    Private Sub EMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMSToolStripMenuItem.Click

        Dim fOp As OperatorNoInputDialog = OperatorNoInputDialog.GetInstance()
        If fOp.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If

        If m_AuthenUser.AuthenUser(fOp.OPNo, "System") Then
            If My.Settings.EmsEnabled Then
                m_EmsClient.Stop()
                For Each mc As Machine In m_MachineList
                    m_EmsClient.Remove(My.Settings.ProcessName, mc.MCNo)
                Next
            Else
                For Each mc As Machine In m_MachineList
                    Dim ws As WorkingSlip = mc.WorkingSlip
                    Dim lotNo As String = ""
                    If ws IsNot Nothing Then
                        lotNo = ws.LotNo
                    End If
                    Dim reg As EmsMachineRegisterInfo = New EmsMachineRegisterInfo(mc.MCNo, "Line-" & My.Settings.LineNo, My.Settings.ProcessName, _
                                                                                   mc.MachineType, lotNo, mc.TotalGood, _
                                                                                   mc.TotalNG, mc.RPMSetting, 0, 0)
                    m_EmsClient.Register(reg)
                Next

                m_EmsClient.Start()
            End If
            My.Settings.EmsEnabled = Not My.Settings.EmsEnabled
            DisplayEmsSetting()
            My.Settings.Save()
        Else
            InformationMessageBox.Inform("คุณไม่มีสิทธิ์ใช้งานในส่วนนี้ (System เท่านั้น)")
        End If

    End Sub

    Private Sub ConnectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectToolStripMenuItem.Click

        Dim p As Point = FtMachinePanel1.PointToClient(MousePosition)

        Dim fOp As OperatorNoInputDialog = OperatorNoInputDialog.GetInstance()
        If fOp.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        Dim f As SelectEmptySelfConIPMachineDialog = New SelectEmptySelfConIPMachineDialog()
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim mc As Machine = New Machine()
            mc.ApplyMachineSetting(f.SelectedSetting)
            Dim op As AddMachineOperation = New AddMachineOperation()
            op.OperatorNo = fOp.OPNo
            op.Execute(mc)
            If op.IsCompleted Then
                mc.PositionX = p.X
                mc.PositionY = p.Y
                HandleNewMachine(mc)
                SetDisplayBinding(mc)
            End If

        End If
    End Sub

    Private Sub WorkRecordButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkRecordButton.Click
        Dim mc As Machine = m_ActiveMachine.Machine
        Dim wr As WorkRecordForm = WorkRecordForm.GetInstance()
        wr.EditWorkRecord(mc)
    End Sub

    Private Sub ShowGridToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowGridToolStripMenuItem.Click
        My.Settings.ShowFTPanelGrid = Not My.Settings.ShowFTPanelGrid
        ShowGridToolStripMenuItem.Checked = My.Settings.ShowFTPanelGrid
        My.Settings.Save()
    End Sub

    Private Sub ToolStripMenuItemSendText_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemSendText.Click
        Dim msg As String = "TEST FROM SELFCON"
        m_MessageRouter.Send(m_ActiveMachine.Machine, msg)
    End Sub

#Region "Loading ... in background worker"

    Private Sub LoadingBackgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles LoadingBackgroundWorker.DoWork

        LoadingBackgroundWorker.ReportProgress(0)

        'check and create neccessary folder
        CheckAndCreateSystemDirectories()

        m_ProgramLog.Write("frmSelfCon_Load-001", "Program start")

        Dim ipArray As Net.IPAddress() = Utilities.GetLocalUnicastAddresses()
        If ipArray.Length = 1 Then
            SelfConIP = ipArray(0).ToString()
        ElseIf ipArray.Length > 1 Then
            'more than one LAN card
            m_ProgramLog.Write("frmSelfCon_Load-006", "There is network interface card more than 1")
            e.Result = "There is network interface card more than 1"
            e.Cancel = True
            Exit Sub
        Else
            'not found IP
            m_ProgramLog.Write("frmSelfCon_Load-007", "Network interface card was not found")
            e.Result = "Network interface card was not found"
            e.Cancel = True
            Exit Sub
        End If
        'load alarm table from database
        AlarmTable.LoadAllAlarm()
        'load machine from database
        Using dt As DBxDataSet.FTMachineSettingDataTable = FtMachineSettingTableAdapter1.GetDataBySelfConIP(SelfConIP)
            For Each r As DBxDataSet.FTMachineSettingRow In dt.Rows
                Dim mc As Machine = Nothing
                Try
                    mc = m_StateManager.LoadMachineState(r.MCNo)
                    'this "if-block" should be removed at next version
                    If mc.State = MachineStateType.LotEnd Then
                        mc.State = MachineStateType.ReTestStart
                    End If
                Catch ex As Exception
                    m_ProgramLog.Write("frmSelfCon_Load-002", ex.Message)
                End Try

                If mc Is Nothing Then
                    mc = New Machine()
                End If
                'overwrite deserialized setting by using values from database 
                mc.ApplyMachineSetting(r)
                'add to [machine list, message controller and ft machine panel]
                'move to report progress 
                'HandleNewMachine(mc)
                LoadingBackgroundWorker.ReportProgress(0, mc)
            Next
        End Using

        m_UserWorkTime = m_StateManager.LoadWorkTime()
        If m_UserWorkTime = WorkTime.Empty Then
            m_UserWorkTime = WorkTime.GetCurrent()
        End If

        m_GraphGen1 = New OPAlarmGraphGenerator()
        m_GraphGen1.BeginInit()
        m_GraphGen1.DurationSeriesName = "DurationSeries"
        m_GraphGen1.AlarmCountSeriesName = "AlarmCountSeries"
        m_GraphGen1.MTTRSeriesName = "MTTRSeries"
        m_GraphGen1.OPChart = AlarmChart
        m_GraphGen1.MTTRChart = AlarmChart
        m_GraphGen1.WorkTime = m_UserWorkTime
        Dim data As List(Of OPAlarmGraphData) = Nothing
        Try
            data = m_StateManager.LoadOPAlarmGrapDataList()
        Catch ex As Exception
            m_ProgramLog.Write("frmSelfCon_Load-004", ex.Message)
        End Try
        If data Is Nothing Then
            data = New List(Of OPAlarmGraphData)
        End If
        m_GraphGen1.LoadData(data)
        m_GraphGen1.EndInit()

        ''clear log
        Dim tempFiles As String()
        tempFiles = Directory.GetFiles(My.Application.Info.DirectoryPath, "*.sav")
        For Each f As String In tempFiles
            Try
                File.Delete(f)
            Catch ex As Exception
                m_ProgramLog.Write("frmSelfCon_Load-008", ex.Message)
            End Try
        Next

        'System.Threading.Thread.Sleep(3000)

    End Sub

    Private Sub LoadingBackgroundWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles LoadingBackgroundWorker.RunWorkerCompleted

        LoadingForm.GetInstance().Hide()

        If e.Cancelled Then
            InformationMessageBox.Inform(CStr(e.Result))
            Application.Exit()
        Else
            m_MessageRouter.Start()
            If My.Settings.EmsEnabled Then
                m_EmsClient.Start()
            End If
            m_StartDate = Now
            DurationTimer.Interval = 1000
            DurationTimer.Start()
            ClearLogTimer.Start()
            WorkTimeCheckTimer.Start()
            SaveStateTimer.Start()

            If m_MachineList.Count > 0 Then
                'relate with m_ActiveMachine which assigned in CreateFTMachineControlToPanel1(mc) function
                Dim index As Integer = m_MachineList.Count - 1
                SetDisplayBinding(m_MachineList(index))
            End If

            DisplayTdcSetting()
            DisplayEmsSetting()

            Dim ecoClients As List(Of EcoWatchClient) = Nothing
            Try
                ecoClients = m_StateManager.LoadEchoWatchState()
            Catch ex As Exception
                m_ProgramLog.Write("frmSelfCon_Load-009", ex.Message)
            End Try
            If ecoClients IsNot Nothing Then
                m_EcoWatch.Clients = ecoClients
            End If

            m_EcoWatch.StartWatch()

            ShowGridToolStripMenuItem.Checked = My.Settings.ShowFTPanelGrid
        End If
    End Sub

    Private Sub LoadingBackgroundWorker_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles LoadingBackgroundWorker.ProgressChanged
        If TypeOf e.UserState Is Machine Then
            HandleNewMachine(CType(e.UserState, Machine))
        End If
    End Sub

#End Region


    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim m_ResultForm As SetupResultForm = New SetupResultForm()
    '    'VerifyParameter
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "ตรวจสอบ Lot ก่อนหน้า", "ไม่มี") 'index : 0
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "ตรวจสอบ FT Setup Record", "พบ") 'index : 1
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "ค้นหา BOM จาก FT Setup Record", "พบ") 'index : 2        'Perform
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "บันทึก QRCode.log", "เรียบร้อย") 'index : 3
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "ตรวจสอบ Device ว่าเป็น Automotive หรือไม่", "เป็น") 'index : 4
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "ตรวจสอบสถานะเครื่อง Machine ว่าเป็น High Reliability หรือไม่", "ผ่าน") 'index : 5
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "ตรวจสอบ Machine ว่าได้รับเหมาะสมกับารผลิตหรือไม่", "เหมาะสม") 'index : 6
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "ตรวจสอบ OPNo ว่าได้รับอนุญาตให้ทำการผลิตหรือไม่", "ได้รับอนุญาต") 'index : 7
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "ค้นหา BOM จาก W/S และ OIS ที่จะทำการผลิต", "พบ") 'index : 8
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "ตรวจสอบความเข้ากันของอุปกรณ์ที่ต้องใช้ระหว่าง Input กับ FTSetup", "เหมาะสม") 'index : 9
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "ตรวจสอบสถานะของ Lot กับ APCS system", "ผ่าน") 'index : 10
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "ค้นหาค่า LCL จากระบบ  ของ LSI (Fixed LCL)", "ไม่พบ") 'index : 11
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "ค้นหาค่า LCL จากระบบ  ของ IS (LCL_MASTER)", "99.9") 'index : 12
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Success, "นำค่า RPM จาก BOM ไปใช้", "17.5") 'index : 13
    '    m_ResultForm.AppendDetailMessage(SetupResultIconType.Errored, "ตรวจสอบ Socket Life Time", "ไม่ผ่าน") 'index : 14

    '    m_ResultForm.SetOverallResult("การ Setup ไม่ผ่าน: Socket Life Time Over Limit [108:120]", Color.Red)

    '    m_ResultForm.ShowDialog()

    'End Sub

End Class

