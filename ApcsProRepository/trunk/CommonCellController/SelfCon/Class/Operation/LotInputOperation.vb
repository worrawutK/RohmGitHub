Imports Rohm.Apcs.Tdc
Imports System.IO
Imports AuthenticationUser
Imports SelfCon.Rohm.ApcsWeb
Imports SelfCon.Rohm.FT.SettingService
Imports System.Data.SqlClient

Public Class LotInputOperation
    Inherits Operation

    Private m_AuthenUser As AuthenUser
    Private m_SetupRecord As DBxDataSet.FTSetupReportRow
    Private m_CurrentBom As DBxDataSet.FTBomRow
    Private m_ResultForm As SetupResultForm

    Public Sub New()
        MyBase.New()
        m_AuthenUser = New AuthenUser()
        'm_ResultForm = New SetupResultForm()

        'VerifyParameter
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ตรวจสอบ Lot ก่อนหน้า", "") 'index : 0
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ตรวจสอบ FT Setup Record", "") 'index : 1
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ค้นหา BOM จาก FT Setup Record", "") 'index : 2
        'Perform
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "บันทึก QRCode.log", "") 'index : 3
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ตรวจสอบ Device ว่าเป็น Automotive หรือไม่", "") 'index : 4
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ตรวจสอบสถานะเครื่อง Machine ว่าเป็น High Reliability หรือไม่", "") 'index : 5
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ตรวจสอบ Machine ว่าได้รับเหมาะสมกับารผลิตหรือไม่", "") 'index : 6
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ตรวจสอบ OPNo ว่าได้รับอนุญาตให้ทำการผลิตหรือไม่", "") 'index : 7
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ค้นหา BOM จาก W/S และ OIS ที่จะทำการผลิต", "") 'index : 8
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ตรวจสอบความเข้ากันของอุปกรณ์ที่ต้องใช้ระหว่าง Input กับ FTSetup", "") 'index : 9
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ตรวจสอบสถานะของ Lot กับ APCS system", "") 'index : 10
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ค้นหาค่า LCL จากระบบ  ของ LSI (Fixed LCL)", "") 'index : 11
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ค้นหาค่า LCL จากระบบ  ของ IS (LCL_MASTER)", "") 'index : 12
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "นำค่า RPM จาก BOM ไปใช้", "") 'index : 13
        m_ResultForm.AppendDetailMessage(SetupResultIconType.Stopped, "ตรวจสอบ Socket LifeTime", "") 'index : 14

    End Sub


    Protected Overrides Function VerifyParameter(ByVal mc As Machine) As Boolean

        'ตรวจสอบความพร้อมของเครื่อง ว่าพร้อมให้ผลิตต่อไปได้ไหม
        m_ResultForm.SetOverallResult("การ Setup มีข้อบกพร่อง", Color.Red)

        '1.) ตรวจสอบว่า Lot ที่ค้างเครื่องอยู่นั้น จบสมบูรณ์ หรือยัง
        If mc.WorkingSlip Is Nothing Then
            AppendLog("There was not current lot")
            m_ResultForm.UpdateDetailMessage(0, SetupResultIconType.Success, "ผ่าน")
        Else
            AppendLog("There was current lot [" & mc.WorkingSlip.LotNo & "]")
            If mc.LotStartTime.HasValue Then
                If mc.LotCompleteTime.HasValue Then
                    AppendLog("The lot was finished")
                    'ตรวจสอบว่า Lot ที่ค้างเครื่องอยู่นั้น กรอก Work Record สมบูรณ์หรือยัง
                    Using adaptor As DBxDataSetTableAdapters.FTDataTableAdapter = New DBxDataSetTableAdapters.FTDataTableAdapter()
                        Using table As DBxDataSet.FTDataDataTable = adaptor.GetDataByPKs(mc.MCNo, mc.WorkingSlip.LotNo, mc.LotStartTime.Value)
                            If table.Rows.Count = 1 Then
                                Dim row As DBxDataSet.FTDataRow = CType(table.Rows(0), DBxDataSet.FTDataRow)
                                If WorkRecordIsNotComplete(row) Then
                                    m_ResultForm.UpdateDetailMessage(0, SetupResultIconType.Errored, "ไม่ผ่าน")
                                    m_ResultForm.SetOverallResult("Work Record ไม่สมบูรณ์", Color.Red)
                                    AppendLog("WorkRecord Data was not completed")
                                    Return False
                                Else
                                    m_ResultForm.UpdateDetailMessage(0, SetupResultIconType.Success, "ผ่าน")
                                End If
                            Else
                                m_ResultForm.UpdateDetailMessage(0, SetupResultIconType.Errored, "ไม่ผ่าน")
                                m_ResultForm.SetOverallResult("ไม่พบข้อมูลบนฐานข้อมูล", Color.Red)
                                AppendLog("Not found data in database MCNo :=" & mc.MCNo & ",LotNo :=" & mc.WorkingSlip.LotNo & ",LotStartTime :=" & mc.LotStartTime.Value.ToString("yyyy/MM/dd HH:mm:ss"))
                                Return False
                            End If
                        End Using
                    End Using
                Else
                    AppendLog("The lot was not finished")
                    m_ResultForm.UpdateDetailMessage(0, SetupResultIconType.Errored, "ไม่ผ่าน")
                    m_ResultForm.SetOverallResult("ยังไม่จบการผลิต", Color.Red)
                    Return False
                End If
            End If
        End If

        '2.) ตรวจสอบว่า ทำการยิง FTSetup แล้วหรือยัง
        'check setup status must be CONFIRMED !!
        Using adaptor As DBxDataSetTableAdapters.FTSetupReportTableAdapter = New DBxDataSetTableAdapters.FTSetupReportTableAdapter()
            Using dt As DBxDataSet.FTSetupReportDataTable = adaptor.GetDataByMCNo(STRING_TDC_MACHINENO_PREFIX & mc.MCNo)
                If dt.Rows.Count = 0 Then
                    m_SetupRecord = Nothing
                    m_ResultForm.UpdateDetailMessage(1, SetupResultIconType.Errored, "ไม่ผ่าน")
                    m_ResultForm.SetOverallResult("ไม่พบข้อมูล Setup Report", Color.Red)
                    AppendLog("No setup record of " & STRING_TDC_MACHINENO_PREFIX & mc.MCNo)
                    Return False
                Else
                    m_SetupRecord = CType(dt.Rows(0), DBxDataSet.FTSetupReportRow)
                    If m_SetupRecord.SetupStatus = "CONFIRMED" Then
                        m_ResultForm.UpdateDetailMessage(1, SetupResultIconType.Success, "ผ่าน")
                    Else
                        m_ResultForm.UpdateDetailMessage(1, SetupResultIconType.Errored, "ไม่ผ่าน")
                        m_ResultForm.SetOverallResult("สถานะ FTSetup ยังไม่ถูก Confim Lot", Color.Red)
                        AppendLog("Invalid Setup Status [" & m_SetupRecord.SetupStatus & "]")
                        m_SetupRecord = Nothing
                        Return False
                    End If

                End If
            End Using
        End Using

        '3.) get bom from current setup
        m_CurrentBom = GetBomByFTSetupReport(m_SetupRecord)
        If m_CurrentBom Is Nothing Then
            m_ResultForm.UpdateDetailMessage(2, SetupResultIconType.Errored, "ไม่พบ")
            m_ResultForm.SetOverallResult("ไม่พบ BOM ที่ตรงกับ FTSetup", Color.Red)

            AppendLog("Could not find BOM")
            Return False
        Else
            m_ResultForm.UpdateDetailMessage(2, SetupResultIconType.Success, "พบ")
        End If

        Return True
    End Function

    Protected Overrides Sub Perform(ByVal mc As Machine)

        Dim inputDialog As LotInputDialog = LotInputDialog.GetInstance()

        If inputDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim msg As String = String.Empty

            '4.)
            SaveQRCodeLog(inputDialog.WorkingSlip.FullCode)
            SaveQRCodeLog(inputDialog.OIS.FullCode)
            SaveQRCodeLog(inputDialog.OPNo)
            m_ResultForm.UpdateDetailMessage(3, SetupResultIconType.Success, "สำเร็จ")

            '5.) - 8.)
            'checking authorization
            If Not Authorization(mc, inputDialog.WorkingSlip, inputDialog.OPNo) Then
                GoTo OPERATION_CANCEL
            End If

            '9.) - 10.)
            'checking(Setup)
            If Not IsUseSameEquipment(m_CurrentBom, m_SetupRecord, inputDialog.WorkingSlip, inputDialog.OIS) Then
                'log and message will be set inside this function
                GoTo OPERATION_CANCEL
            End If

            'tdc checking 
            '   skip tdc check if tdc is not enabled
            If Not My.Settings.TdcEnabled Then
                m_ResultForm.UpdateDetailMessage(10, SetupResultIconType.Warning, "ข้าม")
                AppendLog("Skip TDC Checking. LotNo :=" & inputDialog.WorkingSlip.LotNo)
                GoTo FIND_LCL
            End If
            Dim tdcSv As TdcService = TdcService.GetInstance()
            Dim result As TdcResponse = tdcSv.LotRequest(STRING_TDC_MACHINENO_PREFIX & mc.MCNo, inputDialog.WorkingSlip.LotNo, 0)
            '   tdc result handle
            If result.HasError Then

LBL_CHECK_IGNORE:
                Using prox As ApcsWebServiceSoapClient = New ApcsWebServiceSoapClient()
                    If prox.LotRptIgnoreError(result.MCNo, result.ErrorCode) Then
                        m_ResultForm.UpdateDetailMessage(10, SetupResultIconType.Warning, "Ignore :" & result.ErrorCode)
                        AppendLog("Tdc Error Was Ignored :=" & result.ErrorCode & " of " & inputDialog.WorkingSlip.LotNo)
                        GoTo FIND_LCL
                    Else

                        Dim lInfo As LotInfo = Nothing

                        'SKIP if error open connection to database
                        If result.ErrorCode <> "70" Then
                            Try
                                lInfo = tdcSv.GetLotInfo(result.LotNo, result.MCNo)
                            Catch ex As Exception
                            End Try
                        End If

                        Using dlg1 As TdcAlarmMessageForm = New TdcAlarmMessageForm(result.ErrorCode, result.ErrorMessage, result.LotNo, lInfo)
                            dlg1.ShowDialog()
                        End Using

                        msg = "Tdc Error :=" & result.ErrorCode & " : " & result.Message
                        AppendLog(msg)
                        Message = ""
                        GoTo OPERATION_CANCEL
                    End If
                End Using
            End If

FIND_LCL:
            'find lcl value
            Dim lcl As Single
            Using adaptor As DBxDataSetTableAdapters.FixedLCLTableAdapter = New DBxDataSetTableAdapters.FixedLCLTableAdapter()
                Using dt As DBxDataSet.FixedLCLDataTable = adaptor.GetDataByTestFlowName(inputDialog.OIS.TestFlow)
                    If dt.Rows.Count > 0 Then
                        lcl = CType(dt.Rows(0), DBxDataSet.FixedLCLRow).LCL
                        m_ResultForm.UpdateDetailMessage(11, SetupResultIconType.Success, lcl.ToString())
                        AppendLog("Got Fixed LCL {TestFlow := " & inputDialog.OIS.TestFlow & ", LCL := " & lcl.ToString() & "}")
                    Else
                        m_ResultForm.UpdateDetailMessage(11, SetupResultIconType.Success, "ไม่พบ")
                        Using lclDialog As FormLCL = New FormLCL()
                            '********************** change log ***********************
                            '2015-07-20 
                            '   change from 
                            'lclDialog.ROHMMODELNAME = inputDialog.WorkingSlip.ForIndication1
                            '   change to
                            lclDialog.ROHMMODELNAME = inputDialog.WorkingSlip.ForIndication2
                            '*********************************************************
                            Try
                                Using prox As SettingServiceSoapClient = New SettingServiceSoapClient()
                                    lclDialog.FLOWNO = prox.GetTestFlowNo(inputDialog.OIS.TestFlow)
                                End Using
                            Catch ex As Exception
                                m_ResultForm.UpdateDetailMessage(12, SetupResultIconType.Errored, "ไม่ผ่าน")
                                m_ResultForm.SetOverallResult("ไม่สามารถหา TestFlowNo ได้", Color.Red)
                                AppendLog("SettingServiceSoapClient := " & ex.Message)
                                GoTo OPERATION_CANCEL
                            End Try
                            If lclDialog.ShowDialog() = DialogResult.OK Then
                                lcl = lclDialog.LCL
                                m_ResultForm.UpdateDetailMessage(12, SetupResultIconType.Success, lcl.ToString())
                                AppendLog("Got LCL {ROHM_MODEL_NAME := " & lclDialog.ROHMMODELNAME & ", FLOW_NO := " & lclDialog.FLOWNO & " , LCL := " & lcl.ToString() & "}")
                            Else
                                'throw error or exit sub 
                                AppendLog("LCL WAS NOT FOUND {TestFlow := " & inputDialog.OIS.TestFlow & ", ROHM_MODEL_NAME := " & lclDialog.ROHMMODELNAME & ", FLOW_NO := " & lclDialog.FLOWNO & "}")
                                m_ResultForm.UpdateDetailMessage(12, SetupResultIconType.Errored, "ไม่พบ")
                                m_ResultForm.SetOverallResult("ไม่พบค่า LCL จากระบบ IS", Color.Red)
                                GoTo OPERATION_CANCEL
                            End If
                        End Using
                    End If
                End Using
            End Using


            Dim rpmToUse As Single = 0

            If Not m_CurrentBom.IsRPMNull() Then
                rpmToUse = m_CurrentBom.RPM
                AppendLog(String.Format("StandardRPM from BOM:= {0}", rpmToUse))
                'overwrite the previous value
                'and store to use when failed to get standard RPM
                mc.RPMSetting = rpmToUse
            Else
                rpmToUse = mc.RPMSetting
                AppendLog(String.Format("StandardRPM from Setting:= {0}", rpmToUse))
            End If

            m_ResultForm.UpdateDetailMessage(13, SetupResultIconType.Success, rpmToUse.ToString())

            '******************************************************************
            'Added by Tanapat S. since 2017-08-21
            'Check socket life time
            '******************************************************************
            'If Not m_SetupRecord.IsQRCodesocket1Null() Then
            '    mc.SocketCh1 = m_SetupRecord.QRCodesocket1
            'End If
            'If Not m_SetupRecord.IsQRCodesocket2Null() Then
            '    mc.SocketCh2 = m_SetupRecord.QRCodesocket2
            'End If
            'If Not m_SetupRecord.IsQRCodesocket3Null() Then
            '    mc.SocketCh3 = m_SetupRecord.QRCodesocket3
            'End If
            'If Not m_SetupRecord.IsQRCodesocket4Null() Then
            '    mc.SocketCh4 = m_SetupRecord.QRCodesocket4
            'End If
            '******************************************************************

            'save to database
            SaveTransactionData(inputDialog.WorkingSlip)
            'clear old data
            mc.Reset()
            'apply new lot data
            mc.LotInputTime = Now
            mc.WorkingSlip = inputDialog.WorkingSlip
            mc.InputQty = inputDialog.InputQty
            mc.OIS = inputDialog.OIS
            mc.OPNo = inputDialog.OPNo
            mc.LCL = lcl
            mc.StandardRPM = rpmToUse

            Try

                If m_SetupRecord.IsTesterNoANull() Then
                    mc.ChannelATesterNo = ""
                Else
                    mc.ChannelATesterNo = m_SetupRecord.TesterNoA
                End If

                If m_SetupRecord.IsChannelAFTBNull() Then
                    mc.ChannelAFtb = ""
                Else
                    mc.ChannelAFtb = m_SetupRecord.ChannelAFTB
                End If

                If m_SetupRecord.IsTesterNoBNull() Then
                    mc.ChannelBTesterNo = ""
                Else
                    mc.ChannelBTesterNo = m_SetupRecord.TesterNoB
                End If
                If m_SetupRecord.IsChannelBFTBNull() Then
                    mc.ChannelBFtb = ""
                Else
                    mc.ChannelBFtb = m_SetupRecord.ChannelBFTB
                End If

                If m_SetupRecord.IsQRCodesocket1Null() Then
                    mc.SocketCh1 = ""
                Else
                    mc.SocketCh1 = m_SetupRecord.QRCodesocket1
                End If
                If m_SetupRecord.IsQRCodesocket2Null() Then
                    mc.SocketCh2 = ""
                Else
                    mc.SocketCh2 = m_SetupRecord.QRCodesocket2
                End If
                If m_SetupRecord.IsQRCodesocket3Null() Then
                    mc.SocketCh3 = ""
                Else
                    mc.SocketCh3 = m_SetupRecord.QRCodesocket3
                End If
                If m_SetupRecord.IsQRCodesocket4Null() Then
                    mc.SocketCh4 = ""
                Else
                    mc.SocketCh4 = m_SetupRecord.QRCodesocket4
                End If

            Catch ex As Exception
                AppendLog("Failed to setup Equipment data :=" & ex.Message)
            End Try

            m_ResultForm.SetOverallResult("การ Setup เสร็จสมบูรณ์ !!!", Color.Green)
            'operation is completed
            IsCompleted = True

        Else

OPERATION_CANCEL:
            IsCompleted = False
            AppendLog("Operation was cancelled")
        End If

    End Sub

    'Private Function IsSocketLifeTimeOK(ByVal socketQr As String) As Boolean
    '    Using adap As DBxDataSetTableAdapters.TempDataTableAdapter = New DBxDataSetTableAdapters.TempDataTableAdapter()
    '        Using tbl As DBxDataSet.TempDataDataTable = adap.GetDataByQRCode(socketQr)

    '        End Using
    '    End Using
    'End Function

    Public Sub ShowResult()
        m_ResultForm.ShowDialog()
    End Sub

    Private Sub SaveTransactionData(ByVal ws As WorkingSlip)
        'save to DBx.TransactionData
        Using table As DBxDataSet.TransactionDataDataTable = New DBxDataSet.TransactionDataDataTable()

            Dim r As DBxDataSet.TransactionDataRow = table.NewTransactionDataRow()

            r.CleamCounterMeasure = ws.CleamCounterMeasure
            r.CodeNo = ws.CodeNo
            r.Device = ws.DeviceName
            r.ETC1 = ws.ForIndication1
            r.ETC2 = ws.ForIndication2
            r.FASetDirection = ws.FarSetDirection
            r.FrameNo = ws.FrameType
            r.FTForm = ws.FTDevice
            r.LotNo = ws.LotNo
            r.MarkNo = ws.MarkNo
            r.MarkTextLine1 = ws.MarkingSpec3
            r.MarkTextLine2 = ws.MarkingSpec2
            r.MarkTextLine3 = ws.MarkingSpec1
            r.MarkType = ws.MarkType
            r.Mask = ws.Mask
            r.MoldType = ws.MoldType
            r.NewFormName = ws.NewPackageName
            r.NumberOfStampStep = ws.MarkingStep
            r.OSFT = ws.OSFTChange
            r.OSProgram = ws.OSProgram
            r.Package = ws.PackageName
            r.PDFree = ws.PDFree
            r.ReelCount = ws.ReelCount
            r.SubRank = ws.SubRank
            r.TapingDirection = ws.TapingDirection
            r.ULMark = ws.ULMark
            r.WaferLotNo = ws.WaferLotNo
            'add row to datatable
            table.Rows.Add(r)
            Try
                'update datatable
                Using adaptor As DBxDataSetTableAdapters.TransactionDataTableAdapter = New DBxDataSetTableAdapters.TransactionDataTableAdapter()
                    AppendLog("Inserting " & ws.LotNo & " to TransactionData")
                    adaptor.Update(table)
                    AppendLog("Inserted")
                End Using
            Catch ex As Exception
                AppendLog(ex.Message)
            End Try
        End Using
    End Sub

    Private Sub SaveQRCodeLog(ByVal qrData As String)
        Using sw As StreamWriter = New StreamWriter(Path.Combine(m_LogFolder, "QRCode.log"), True)
            sw.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & vbTab & qrData)
        End Using
    End Sub

    Private Function Authorization(ByVal mc As Machine, ByVal ws As WorkingSlip, ByVal opNo As String) As Boolean

        AppendLog("Authorization checking ...")

        Dim isAutomotiveDevice As Boolean = m_AuthenUser.CheckAutomotiveLot(ws.ForIndication2)

        If isAutomotiveDevice Then
            m_ResultForm.UpdateDetailMessage(4, SetupResultIconType.Success, "ใช่")
        Else
            m_ResultForm.UpdateDetailMessage(4, SetupResultIconType.Success, "ไม่ใช่")
        End If

        AppendLog("Device := " & ws.ForIndication2 & ", IsAutomotive := " & isAutomotiveDevice.ToString())


        Dim isAutomotiveMachine As Boolean = m_AuthenUser.CheckMachineAutomotive(My.Settings.ProcessName, mc.MCNo)

        If isAutomotiveMachine Then
            m_ResultForm.UpdateDetailMessage(5, SetupResultIconType.Success, "ใช่")
        Else
            m_ResultForm.UpdateDetailMessage(5, SetupResultIconType.Success, "ไม่ใช่")
        End If
        AppendLog("Machine := " & mc.MCNo & ", IsAutomotive := " & isAutomotiveMachine.ToString())

        If isAutomotiveDevice AndAlso Not isAutomotiveMachine Then
            m_ResultForm.UpdateDetailMessage(6, SetupResultIconType.Errored, "เครื่องจักรไม่ใช่ HR")
            Return False
        Else
            m_ResultForm.UpdateDetailMessage(6, SetupResultIconType.Success, "เหมาะสม")
        End If

        Dim isOpFT As Boolean = m_AuthenUser.AuthenUser(opNo, My.Settings.FTOPGroupName)
        Dim isGlFT As Boolean = m_AuthenUser.AuthenUser(opNo, My.Settings.GroupLeaderGroupName)

        If isAutomotiveDevice Then
            Dim isOpAutomotive As Boolean = m_AuthenUser.AuthenUser(opNo, My.Settings.AutomotiveGroupName)
            If isOpAutomotive And isOpFT Then 'allow FT-OP that also have Automotive license
                'ok
                m_ResultForm.UpdateDetailMessage(7, SetupResultIconType.Success, "ได้รับอนุญาต")
            ElseIf isGlFT Then 'allow FT-GL
                m_ResultForm.UpdateDetailMessage(7, SetupResultIconType.Success, "ได้รับอนุญาต")
            Else
                m_ResultForm.UpdateDetailMessage(7, SetupResultIconType.Errored, "ไม่ได้รับอนุญาต")
                Return False
            End If

        ElseIf isOpFT OrElse isGlFT Then
            m_ResultForm.UpdateDetailMessage(7, SetupResultIconType.Success, "ได้รับอนุญาต")
        Else
            m_ResultForm.UpdateDetailMessage(7, SetupResultIconType.Errored, "ไม่ได้รับอนุญาต")
            Return False
        End If


        Return True

    End Function

    Private Function IsUseSameEquipment(ByVal currentBom As DBxDataSet.FTBomRow, ByVal currentSetupRecord As DBxDataSet.FTSetupReportRow, ByVal inputWs As WorkingSlip, ByVal inputOis As OIS) As Boolean

        Dim pkg2 As String = inputWs.PackageName
        Dim dev2 As String = inputWs.ForIndication2  'customer device name
        Dim flow2 As String = inputOis.TestFlow
        Dim tester2 As String = inputOis.TesterType
        Dim prog2 As String = inputOis.ProgramName

        Dim bomRow1 As DBxDataSet.FTBomRow = currentBom
        Dim bomRow2 As DBxDataSet.FTBomRow

        Using adap As DBxDataSetTableAdapters.FTBomTableAdapter = New DBxDataSetTableAdapters.FTBomTableAdapter()

            Dim con As SqlConnection = adap.Connection
            con.Open()


            Dim pcMain As String = ""
            Using adap0 As DBxDataSetTableAdapters.FTPCTypeTableAdapter = New DBxDataSetTableAdapters.FTPCTypeTableAdapter()
                Using tbl0 As DBxDataSet.FTPCTypeDataTable = adap0.GetPCType(currentSetupRecord.MCNo)

                    If tbl0.Rows.Count > 0 Then
                        Dim row0 As DBxDataSet.FTPCTypeRow = CType(tbl0.Rows(0), DBxDataSet.FTPCTypeRow)
                        pcMain = row0.PCMain
                    Else
                        'show have error
                    End If

                End Using
            End Using

            AppendLog(String.Format("Search for BOM Input [Device :={0}, PCMain:={1}, TestFlow:={2}, Tester:={3}, Package:={4}]", _
                                                      dev2, pcMain, flow2, tester2, pkg2))

            'user BomTesterType joined with TesterType
            Using tblBom2 As DBxDataSet.FTBomDataTable = adap.GetDataBy20170616(dev2, pcMain, flow2, tester2, pkg2)
                If tblBom2.Rows.Count > 0 Then
                    bomRow2 = CType(tblBom2.Rows(0), DBxDataSet.FTBomRow)
                    m_ResultForm.UpdateDetailMessage(8, SetupResultIconType.Success, "พบ")
                Else
                    'throw error
                    m_ResultForm.UpdateDetailMessage(8, SetupResultIconType.Errored, "ไม่พบ")
                    AppendLog("BOM was not found")
                    Return False
                End If
            End Using

            If bomRow1.TestProgram <> bomRow2.TestProgram Then
                m_ResultForm.UpdateDetailMessage(9, SetupResultIconType.Errored, "Test Program ไม่เหมือนกัน")
                AppendLog(String.Format("Test program was not same [{0} and {1}]", bomRow1.TestProgram, bomRow2.TestProgram))
                Return False
            End If

            Using adap1 As DBxDataSetTableAdapters.FTBomOptionTableAdapter = New DBxDataSetTableAdapters.FTBomOptionTableAdapter()

                adap1.Connection = con

                Dim tblOption1 As DBxDataSet.FTBomOptionDataTable = adap1.GetDataByFTBomID(bomRow1.ID)
                Dim tblOption2 As DBxDataSet.FTBomOptionDataTable = adap1.GetDataByFTBomID(bomRow2.ID)

                If tblOption1.Rows.Count <> tblOption2.Rows.Count Then
                    m_ResultForm.UpdateDetailMessage(9, SetupResultIconType.Errored, "จำนวน Option ไม่เท่ากัน")
                    AppendLog("Option usage quantity was not same")
                    Return False
                End If

                Dim matchQty As Integer = 0

                For Each r1 As DBxDataSet.FTBomOptionRow In tblOption1.Rows
                    For Each r2 As DBxDataSet.FTBomOptionRow In tblOption2.Rows
                        If r1.OptionTypeID = r2.OptionTypeID Then
                            matchQty = matchQty + 1
                            GoTo LBL_NEXT_OPTION_ROW1
                        End If
                    Next
LBL_NEXT_OPTION_ROW1:
                Next

                If matchQty <> tblOption1.Rows.Count Then
                    m_ResultForm.UpdateDetailMessage(9, SetupResultIconType.Errored, "Option ไม่เหมือนกัน")
                    AppendLog("Option setup was not same")
                    Return False
                End If

            End Using 'Using adap1 As DBxDataSetTableAdapters.FTBomOptionTableAdapter = New DBxDataSetTableAdapters.FTBomOptionTableAdapter()

            Using adap2 As DBxDataSetTableAdapters.FTBomTestEquipmentTableAdapter = New DBxDataSetTableAdapters.FTBomTestEquipmentTableAdapter()
                adap2.Connection = con

                Dim tblTestEquipment1 As DBxDataSet.FTBomTestEquipmentDataTable = adap2.GetDataByFTBomID(bomRow1.ID)
                Dim tblTestEquipment2 As DBxDataSet.FTBomTestEquipmentDataTable = adap2.GetDataByFTBomID(bomRow2.ID)

                If tblTestEquipment1.Rows.Count <> tblTestEquipment2.Rows.Count Then
                    m_ResultForm.UpdateDetailMessage(9, SetupResultIconType.Errored, "จำนวน Test Equipment ไม่เท่ากัน")
                    AppendLog("TestEquipment usage quantity was not same")
                    Return False
                End If

                Dim matchQty As Integer = 0

                For Each r1 As DBxDataSet.FTBomTestEquipmentRow In tblTestEquipment1.Rows
                    For Each r2 As DBxDataSet.FTBomTestEquipmentRow In tblTestEquipment2.Rows
                        If r1.TestEquipmentID = r2.TestEquipmentID Then
                            matchQty = matchQty + 1
                            GoTo LBL_NEXT_EQUIPMENT_ROW1
                        End If
                    Next
LBL_NEXT_EQUIPMENT_ROW1:
                Next

                If matchQty <> tblTestEquipment1.Rows.Count Then
                    m_ResultForm.UpdateDetailMessage(9, SetupResultIconType.Errored, "Test Equipment ไม่เหมือนกัน")
                    AppendLog("TestEquipment setup was not same")
                    Return False
                End If

            End Using

            con.Close()

        End Using

        m_ResultForm.UpdateDetailMessage(9, SetupResultIconType.Success, "เหมาะสม")
        Return True

    End Function

    Private Function GetBomByFTSetupReport(ByVal setupRecord As DBxDataSet.FTSetupReportRow) As DBxDataSet.FTBomRow
        Dim ret As DBxDataSet.FTBomRow = Nothing

        Dim pcMain As String = ""
        Using adap0 As DBxDataSetTableAdapters.FTPCTypeTableAdapter = New DBxDataSetTableAdapters.FTPCTypeTableAdapter()
            Using tbl0 As DBxDataSet.FTPCTypeDataTable = adap0.GetPCType(setupRecord.MCNo)

                If tbl0.Rows.Count > 0 Then
                    Dim row0 As DBxDataSet.FTPCTypeRow = CType(tbl0.Rows(0), DBxDataSet.FTPCTypeRow)
                    pcMain = row0.PCMain
                Else
                    'show have error
                End If

            End Using
        End Using

        AppendLog(String.Format("GetBOM Device:={0}, PCMain:={1}, Flow :={2}, Tester:={3}, Package:={4}", _
                   setupRecord.DeviceName, pcMain, setupRecord.TestFlow, setupRecord.TesterType, setupRecord.PackageName))

        If Not String.IsNullOrEmpty(pcMain) Then
            Using adap As DBxDataSetTableAdapters.FTBomTableAdapter = New DBxDataSetTableAdapters.FTBomTableAdapter()
                Dim table As DBxDataSet.FTBomDataTable = adap.GetDataBy20170616(setupRecord.DeviceName, _
                                                                                pcMain, _
                                                                                setupRecord.TestFlow, _
                                                                                setupRecord.TesterType, _
                                                                                setupRecord.PackageName)
                If table.Rows.Count > 0 Then
                    ret = CType(table.Rows(0), DBxDataSet.FTBomRow)
                End If
            End Using
        End If
        Return ret

    End Function

End Class
