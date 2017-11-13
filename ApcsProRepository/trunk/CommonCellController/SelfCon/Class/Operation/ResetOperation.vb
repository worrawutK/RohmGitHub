Imports System.IO

Public Class ResetOperation
    Inherits Operation

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overrides Sub Perform(ByVal mc As Machine)
        If ConfirmationDialog.AskForConfirmation("คุณต้องการทำการลบข้อมูลของการผลิต ใช่หรือไม่ ?") <> Windows.Forms.DialogResult.OK Then
            AppendLog("User cancelled")
            Exit Sub
        End If

        If mc.LotStartTime.HasValue AndAlso mc.WorkingSlip IsNot Nothing Then
            'Lot is end
            If mc.LotCompleteTime.HasValue Then
                Using adaptor As DBxDataSetTableAdapters.FTDataTableAdapter = New DBxDataSetTableAdapters.FTDataTableAdapter()
                    Using table As DBxDataSet.FTDataDataTable = adaptor.GetDataByPKs(mc.MCNo, mc.WorkingSlip.LotNo, mc.LotStartTime.Value)
                        If table.Rows.Count = 1 Then
                            Dim row As DBxDataSet.FTDataRow = CType(table.Rows(0), DBxDataSet.FTDataRow)
                            If WorkRecordIsNotComplete(row) Then
                                AppendLog("WorkRecord Data is not completed")
                                Message = "การลง Work Record ยังไม่สมบูรณ์"
                                IsCompleted = False
                            Else
                                IsCompleted = True
                            End If
                        Else
                            AppendLog("Not found data in database LotNo :=" & mc.WorkingSlip.LotNo & ", LotStartTime :=" & mc.LotStartTime.Value.ToString("yyyy/MM/dd HH:mm:ss"))
                            'Message = "ไม่พบข้อมูลการผลิตบนฐานข้อมูล"
                            IsCompleted = True
                        End If
                    End Using
                End Using
            Else 'Lot is started but not end
                IsCompleted = False
            End If
        Else 'Lot is not started
            IsCompleted = True
        End If 'If mc.LotStartTime.HasValue Then

        AppendLog("Clear data")
        If IsCompleted Then
            mc.Reset()
        End If

    End Sub

    Protected Overrides Function VerifyParameter(ByVal mc As Machine) As Boolean
        Return True
    End Function

End Class
