Imports System.IO
Imports SelfCon.Rohm.FT.SettingService

Public Class LotInputFLFTRetest
    Inherits Operation

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

    Protected Overrides Sub Perform(ByVal mc As Machine)

        Dim abnormalText As String = ""
        Using dlg As QualityAbnormalObjectLotCardForm = New QualityAbnormalObjectLotCardForm()
            If dlg.ShowDialog() = DialogResult.OK Then
                abnormalText = dlg.InputText

                Dim inputLength As Integer = abnormalText.Length

                If inputLength = 252 Then
                    AppendLog("Quality Abnormal was canceled is due to OP input QR-Code 252")
                    GoTo OPERATION_CANCEL
                ElseIf inputLength = 332 Then
                    AppendLog("Quality Abnormal was canceled is due to OP input QR-Code 332")
                    GoTo OPERATION_CANCEL
                ElseIf inputLength > 50 Then 'Relate to size of "Remark" field in FTData table
                    AppendLog("Fixed Length of Quality Abnormal reason := " & abnormalText)
                    abnormalText = abnormalText.Substring(0, 50)
                End If
            Else
                AppendLog("Quality Abnormal was canceled")
                GoTo OPERATION_CANCEL
            End If
        End Using

        Dim inputDialog As LotInputDialog = LotInputDialog.GetInstance()

        If inputDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim msg As String = String.Empty

            '4.)
            SaveQRCodeLog(inputDialog.WorkingSlip.FullCode)
            SaveQRCodeLog(inputDialog.OIS.FullCode)
            SaveQRCodeLog(inputDialog.OPNo)

FIND_LCL:
            'find lcl value
            Dim lcl As Single
            Using adaptor As DBxDataSetTableAdapters.FixedLCLTableAdapter = New DBxDataSetTableAdapters.FixedLCLTableAdapter()
                Using dt As DBxDataSet.FixedLCLDataTable = adaptor.GetDataByTestFlowName(inputDialog.OIS.TestFlow)
                    If dt.Rows.Count > 0 Then
                        lcl = CType(dt.Rows(0), DBxDataSet.FixedLCLRow).LCL
                        AppendLog("Got Fixed LCL {TestFlow := " & inputDialog.OIS.TestFlow & ", LCL := " & lcl.ToString() & "}")
                    Else
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
                                Message = "ไม่สามารถหา TestFlowNo ได้"
                                AppendLog("SettingServiceSoapClient := " & ex.Message)
                                GoTo OPERATION_CANCEL
                            End Try
                            If lclDialog.ShowDialog() = DialogResult.OK Then
                                lcl = lclDialog.LCL
                                AppendLog("Got LCL {ROHM_MODEL_NAME := " & lclDialog.ROHMMODELNAME & ", FLOW_NO := " & lclDialog.FLOWNO & " , LCL := " & lcl.ToString() & "}")
                            Else
                                'throw error or exit sub 
                                AppendLog("LCL WAS NOT FOUND {TestFlow := " & inputDialog.OIS.TestFlow & ", ROHM_MODEL_NAME := " & lclDialog.ROHMMODELNAME & ", FLOW_NO := " & lclDialog.FLOWNO & "}")
                                Message = "ไม่พบ LCL จากฐานข้อมูล IS"
                                GoTo OPERATION_CANCEL
                            End If
                        End Using
                    End If
                End Using
            End Using


            Dim rpmToUse As Single = mc.RPMSetting

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

            mc.ChannelATesterNo = ""
            mc.ChannelAFtb = ""
            mc.ChannelBTesterNo = ""
            mc.ChannelBFtb = ""
            mc.SocketCh1 = ""
            mc.SocketCh2 = ""
            mc.SocketCh3 = ""
            mc.SocketCh4 = ""

            mc.Remark = abnormalText

            'operation is completed
            IsCompleted = True

        Else

OPERATION_CANCEL:
            IsCompleted = False
            AppendLog("Operation was cancelled")
        End If
    End Sub

    Protected Overrides Function VerifyParameter(ByVal mc As Machine) As Boolean
        '1.) ตรวจสอบว่า Lot ที่ค้างเครื่องอยู่นั้น จบสมบูรณ์ หรือยัง
        If mc.WorkingSlip Is Nothing Then
            AppendLog("There was not current lot")
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
                                    Message = "Work Record ไม่สมบูรณ์"
                                    AppendLog("WorkRecord Data was not completed")
                                    Return False
                                End If
                            Else
                                Message = "ไม่พบข้อมูลบนฐานข้อมูล"
                                AppendLog("Not found data in database MCNo :=" & mc.MCNo & ",LotNo :=" & mc.WorkingSlip.LotNo & ",LotStartTime :=" & mc.LotStartTime.Value.ToString("yyyy/MM/dd HH:mm:ss"))
                                Return False
                            End If
                        End Using
                    End Using
                Else
                    AppendLog("The lot was not finished")
                    Message = "ยังไม่จบการผลิต"
                    Return False
                End If
            End If
        End If

        Return True
    End Function

End Class
