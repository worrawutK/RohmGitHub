Imports System.IO
Imports SelfCon.Rohm.FT.SettingService

Public Class AutoloadTestProgramOperation
    Inherits Operation

    Protected Overrides Sub Perform(ByVal mc As Machine)

        Dim mailBoxRootPath As String = "" 'MailBoxList.GetMailBoxPath(mc.OIS.TesterType)

        Try
            Using prox As SettingServiceSoapClient = New SettingServiceSoapClient()
                mailBoxRootPath = prox.GetMailBoxPath(mc.OIS.TesterType.Trim()) 'solve problem "ICT2000 " since 2017-09-06
            End Using
        Catch ex As Exception
            Message = "ไม่สามารถ อ่านข้อมูลจาก FT Setting Service ได้"
            AppendLog("SettingServiceSoapClient := " & ex.Message)
            Exit Sub
        End Try

        If String.IsNullOrEmpty(mailBoxRootPath) Then
            Message = "ไม่พบ Mail Box ของ Tester ชนิด : " & mc.OIS.TesterType
            AppendLog("Mailbox was not found in MailBoxList.txt for Tester Type := " & mc.OIS.TesterType)
            Exit Sub
        ElseIf Not Directory.Exists(mailBoxRootPath) Then
            Message = "ไม่พบ Directory : " & mailBoxRootPath
            AppendLog("Directory was not found := " & mailBoxRootPath)
            Exit Sub
        End If

        Dim autoLoadingList As List(Of Autoloading) = New List(Of Autoloading)
        Dim testerMailBox As String
        Dim testerNo As String

        If mc.ChannelATesterNo = mc.ChannelBTesterNo Then
            testerNo = GetNumberFromTesterNo(mc.ChannelATesterNo)

            testerMailBox = Path.Combine(mailBoxRootPath, testerNo)

            If CreateMailBoxIfNotExists(testerMailBox) Then
                autoLoadingList.Add(New Autoloading(mc.MCNo, testerNo, testerMailBox, "AB", mc.WorkingSlip, mc.OIS))
            End If

        Else
            If Not String.IsNullOrEmpty(mc.ChannelATesterNo) Then

                testerNo = GetNumberFromTesterNo(mc.ChannelATesterNo)

                testerMailBox = Path.Combine(mailBoxRootPath, testerNo)

                If CreateMailBoxIfNotExists(testerMailBox) Then
                    autoLoadingList.Add(New Autoloading(mc.MCNo, testerNo, testerMailBox, "A", mc.WorkingSlip, mc.OIS))
                End If
            End If

            If Not String.IsNullOrEmpty(mc.ChannelBTesterNo) Then

                testerNo = GetNumberFromTesterNo(mc.ChannelBTesterNo)

                testerMailBox = Path.Combine(mailBoxRootPath, testerNo)

                If CreateMailBoxIfNotExists(testerMailBox) Then
                    autoLoadingList.Add(New Autoloading(mc.MCNo, testerNo, testerMailBox, "B", mc.WorkingSlip, mc.OIS))
                End If
            End If
        End If

        Dim f As AutoLoadTestProgramDialog = AutoLoadTestProgramDialog.GetInstatnce()
        f.PerformAutoLoad(autoLoadingList)

        'keep log for each autoloading
        IsCompleted = True

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

    Private Function CreateMailBoxIfNotExists(ByVal mailBoxPath As String) As Boolean
        If Not Directory.Exists(mailBoxPath) Then
            Try
                Directory.CreateDirectory(mailBoxPath)
            Catch ex As Exception
                AppendLog("Could not create directory :=" & mailBoxPath & ", ErrorMessage :=" & ex.Message)
                Message = "ไม่สามารถสร้าง Directory ได้" & vbNewLine & mailBoxPath
                Return False
            End Try
        End If
        Return True
    End Function

    Protected Overrides Function VerifyParameter(ByVal mc As Machine) As Boolean

        If mc.WorkingSlip Is Nothing OrElse mc.OIS Is Nothing Then
            Message = "กรุณากรอกข้อมูลการผลิตก่อน"
            AppendLog("WorkingSlip Or OIS Is Nothing")
            Return False
        End If

        If String.IsNullOrEmpty(mc.ChannelATesterNo) AndAlso String.IsNullOrEmpty(mc.ChannelBTesterNo) Then
            Message = "ต้องทำการ Setup Tester ก่อนถึงจะทำ Autoload ได้"
            AppendLog("ChannelATesterNo and ChannelBTesterNo are blank")
            Return False
        End If

        Return True
    End Function

End Class
