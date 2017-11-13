Public Class ManualStartOperation
    Inherits Operation

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overrides Sub Perform(ByVal mc As Machine)

        If ConfirmationDialog.AskForConfirmation("คุณต้องการเปลี่ยนสถานะเครื่องจักรเป็น Start ใช่หรือไม่") <> DialogResult.OK Then
            AppendLog("User cancelled")
            Exit Sub
        End If

        AppendLog("Start Machine")
        mc.LotStart()

        IsCompleted = True
    End Sub

    Protected Overrides Function VerifyParameter(ByVal mc As Machine) As Boolean

        If mc.WorkingSlip Is Nothing OrElse mc.OIS Is Nothing Then
            'machine is not yet setup
            AppendLog("Working slip Or OIS was not set")
            Message = "กรุณากรอกข้อมูลการผลิตก่อน"
            Return False
        End If

        If mc.LotStartTime.HasValue Then
            'machine not yet start
            AppendLog("Machine is already started")
            Message = "เครื่องจักรได้เริ่มผลิตไปแล้ว"
            Return False
        End If

        Return True

    End Function
End Class
