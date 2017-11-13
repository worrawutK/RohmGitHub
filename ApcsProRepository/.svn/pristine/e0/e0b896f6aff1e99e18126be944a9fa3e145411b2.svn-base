Imports System.Net.NetworkInformation

Public Class RemoveMachineOperation
    Inherits Operation

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overrides Sub Perform(ByVal mc As Machine)
        If ConfirmationDialog.AskForConfirmation("คุณต้องการหยุดการเชื่อมต่อกับเครื่องจักร " & mc.MCNo & " ใช่หรือไม่ ?") = Windows.Forms.DialogResult.OK Then

            Dim f As OperatorNoInputDialog = OperatorNoInputDialog.GetInstance()
            If f.ShowDialog() = DialogResult.OK Then
                AppendLog("User " & f.OPNo & " accept remove")
            Else
                GoTo OPERATION_CANCEL
            End If
            Dim result As Boolean = False
            AppendLog("Disconnection MCNo := " & mc.MCNo)

            Dim pingresult As IPStatus
            Dim changNewSelfConIPResult As Boolean
            Dim saveSettingResult As Boolean
            Dim affectedRow As Integer
            Dim oldSelfConIp As String = mc.SelfConIP

            If mc.UseAutoMode Then
                'pinging moxa
                pingresult = Utilities.Ping(mc.MoxaIP)
                'show result
                AppendLog("PingResult := " & pingresult.ToString())
                If pingresult <> IPStatus.Success Then
                    GoTo OPERATION_RESULT
                End If

                'change moxa config
                changNewSelfConIPResult = NPort.OperatingSettingsUDPMode(mc.MoxaIP, String.Empty, "5720", "5720")
                AppendLog("Change Moxa's DestinationIP to Empty :=" & changNewSelfConIPResult)
                If Not changNewSelfConIPResult Then
                    GoTo OPERATION_RESULT
                End If

                'save moxa config changed
                saveSettingResult = NPort.SaveSetting(mc.MoxaIP)
                AppendLog("Save Moxa's Setting :=" & saveSettingResult)
                If Not saveSettingResult Then
                    GoTo OPERATION_RESULT
                End If
            End If

            mc.SelfConIP = String.Empty

            'updating database
            Using dt As DBxDataSet.FTMachineSettingDataTable = New DBxDataSet.FTMachineSettingDataTable()
                Dim row As DBxDataSet.FTMachineSettingRow = dt.NewFTMachineSettingRow()
                row.MCNo = mc.MCNo
                row.MachineType = mc.MachineType
                row.PDMachineType = mc.PDMachineType
                row.RPMSetting = mc.RPMSetting
                row.OPRateSetting = mc.OPRateSetting
                row.MTTRSetting = mc.MTTRSetting
                row.MTBFSetting = mc.MTBFSetting
                row.MoxaIP = mc.MoxaIP
                row.SelfConIP = mc.SelfConIP  'change SelfConIP 
                row.PositionX = mc.PositionX
                row.PositionY = mc.PositionY
                row.UseAutoMode = mc.UseAutoMode
                dt.Rows.Add(row)
                row.AcceptChanges()
                row.SetModified() 'tell adaptor to user UPDATE command

                Using adaptor As DBxDataSetTableAdapters.FTMachineSettingTableAdapter = New DBxDataSetTableAdapters.FTMachineSettingTableAdapter()
                    affectedRow = adaptor.Update(row)
                    AppendLog("Update database affected row :=" & affectedRow.ToString())
                    If affectedRow = 0 Then
                        If mc.UseAutoMode Then
                            'roll back moxa setting
                            NPort.OperatingSettingsUDPMode(mc.MoxaIP, ModGlobal.SelfConIP, "5720", "5720")
                            mc.SelfConIP = ModGlobal.SelfConIP
                            NPort.SaveSetting(mc.MoxaIP)
                        End If
                        GoTo OPERATION_RESULT
                    Else
                        IsCompleted = True
                        mc.RaiseEventRemoved()
                    End If
                End Using

            End Using
OPERATION_RESULT:
            Dim addRemoveForm As AddRemoveMachineResultDialog = AddRemoveMachineResultDialog.GetInstance()
            addRemoveForm.SetDisplay(mc.UseAutoMode, affectedRow, pingresult, mc.MoxaIP, oldSelfConIp, mc.SelfConIP, changNewSelfConIPResult, saveSettingResult, IsCompleted)
            addRemoveForm.ShowDialog()
        Else
OPERATION_CANCEL:
            AppendLog("Operation was cancelled")
        End If

    End Sub

    Protected Overrides Function VerifyParameter(ByVal mc As Machine) As Boolean
        Dim ret As Boolean = False
        If mc.LotStartTime.HasValue Then
            If mc.LotCompleteTime.HasValue Then
                If mc.WorkingSlip IsNot Nothing Then
                    Using adaptor As DBxDataSetTableAdapters.FTDataTableAdapter = New DBxDataSetTableAdapters.FTDataTableAdapter()
                        Using table As DBxDataSet.FTDataDataTable = adaptor.GetDataByPKs(mc.MCNo, mc.WorkingSlip.LotNo, mc.LotStartTime.Value)
                            If table.Rows.Count = 1 Then
                                Dim row As DBxDataSet.FTDataRow = CType(table.Rows(0), DBxDataSet.FTDataRow)
                                If WorkRecordIsNotComplete(row) Then
                                    AppendLog("WorkRecord Data is not completed")
                                    Message = "การลง Work Record ยังไม่สมบูรณ์"
                                Else
                                    ret = True
                                End If
                            Else
                                AppendLog("Not found data in database LotNo :=" & mc.WorkingSlip.LotNo & ", LotStartTime :=" & mc.LotStartTime.Value.ToString("yyyy/MM/dd HH:mm:ss"))
                                ret = True
                            End If
                        End Using
                    End Using
                End If 'If mc.WorkingSlip Is Nothing Then
            Else
                'not complete yet
                Message = "ยังไม่จบการผลิต"
                ret = False
            End If 'If mc.LotCompleteTime.HasValue Then
        Else
            ret = True
        End If 'If mc.LotStartTime.HasValue Then
        Return ret
    End Function

End Class
