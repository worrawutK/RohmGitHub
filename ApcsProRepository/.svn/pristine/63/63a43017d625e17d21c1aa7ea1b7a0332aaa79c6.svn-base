Imports System.Net.NetworkInformation

Public Class AddMachineOperation
    Inherits Operation

    Protected Overrides Sub Perform(ByVal mc As Machine)

        Dim pingresult As IPStatus
        Dim changNewSelfConIPResult As Boolean
        Dim saveSettingResult As Boolean
        Dim affectedRow As Integer
        Dim oldSelfConIp As String = mc.SelfConIP
        Dim newSelfConIp As String = ModGlobal.SelfConIP

        If mc.UseAutoMode Then
            'pinging moxa
            pingresult = Utilities.Ping(mc.MoxaIP)
            'show result
            AppendLog("PingResult := " & pingresult.ToString())

            If pingresult = IPStatus.Success Then
                'change moxa config
                changNewSelfConIPResult = NPort.OperatingSettingsUDPMode(mc.MoxaIP, newSelfConIp, "5720", "5720")
                AppendLog("Change Moxa's DestinationIP to " & newSelfConIp & ":=" & changNewSelfConIPResult)
                If changNewSelfConIPResult Then
                    'save moxa config changed
                    saveSettingResult = NPort.SaveSetting(mc.MoxaIP)
                    AppendLog("Save Moxa's Setting :=" & saveSettingResult)
                    If Not saveSettingResult Then
                        Message = "ไม่สามารถบันทึกการแก้ไขค่า Setting ของ Moxa Adaptor ได้"
                        GoTo SKIP_UPDATE_DATABASE
                    End If
                Else
                    Message = "ไม่สามารถแก้ไขค่า DestinationIP ของ Moxa Adaptor ได้"
                    GoTo SKIP_UPDATE_DATABASE
                End If
            Else
                Message = "ไม่สามารถติดต่อโดยคำสั่ง Ping ไปยัง " & mc.MoxaIP & " ได้"
                GoTo SKIP_UPDATE_DATABASE
            End If
        End If

        mc.SelfConIP = newSelfConIp

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
                        NPort.OperatingSettingsUDPMode(mc.MoxaIP, oldSelfConIp, "5720", "5720")
                        NPort.SaveSetting(mc.MoxaIP)
                        mc.SelfConIP = oldSelfConIp
                    End If
                    Message = "ไม่สามารถบันทึกการเปลี่ยนแปลงลงฐานข้อมูลได้"
                Else
                    IsCompleted = True
                End If
            End Using

        End Using

SKIP_UPDATE_DATABASE:
        Dim addRemoveForm As AddRemoveMachineResultDialog = AddRemoveMachineResultDialog.GetInstance()
        addRemoveForm.SetDisplay(mc.UseAutoMode, affectedRow, pingresult, mc.MoxaIP, oldSelfConIp, mc.SelfConIP, changNewSelfConIPResult, saveSettingResult, IsCompleted)
        addRemoveForm.ShowDialog()

    End Sub

    Protected Overrides Function VerifyParameter(ByVal mc As Machine) As Boolean
        Return True
    End Function
End Class
