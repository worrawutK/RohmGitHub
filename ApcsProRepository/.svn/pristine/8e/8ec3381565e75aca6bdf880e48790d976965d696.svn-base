Public Class ManualLotCompleteOperation
    Inherits Operation

    Protected Overrides Sub Perform(ByVal mc As Machine)
        Dim f As OperatorNoInputDialog = OperatorNoInputDialog.GetInstance()
        If f.ShowDialog() <> DialogResult.OK Then
            Message = "การทำ Manual Lot End ถูกยกเลิก"
            AppendLog("OperatorNoInputDialog was cancelled")
        Else
            'prevent user
            mc.LotComplete(f.OPNo)
            IsCompleted = True
        End If
    End Sub

    Protected Overrides Function VerifyParameter(ByVal mc As Machine) As Boolean
        Dim ret As Boolean = mc.WorkingSlip IsNot Nothing AndAlso mc.OIS IsNot Nothing AndAlso mc.LotStartTime.HasValue
        If Not ret Then
            Message = "ไม่อยู่ในสถานะที่จะทำ Manual Lot End ได้"
            AppendLog("WorkSlip or OIS was not set or Lot was not start or already End")
        End If
        Return ret
    End Function
End Class
