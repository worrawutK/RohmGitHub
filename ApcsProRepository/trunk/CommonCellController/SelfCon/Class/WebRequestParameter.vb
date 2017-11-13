Imports System.Web

Public Class WebRequestParameter

    Public Shared Function PopulateBMRequestQueryString(ByVal mc As Machine, ByVal lineNo As String) As String
        Dim lotNo As String = ""
        If mc.WorkingSlip IsNot Nothing Then
            lotNo = mc.WorkingSlip.LotNo
        End If
        Dim testerType As String = ""
        Dim programName As String = ""
        Dim boxName As String = ""
        If mc.OIS IsNot Nothing Then
            testerType = mc.OIS.TesterType
            programName = mc.OIS.ProgramName
            boxName = mc.OIS.Box
        End If
        Dim mcStatus As String
        If mc.State = MachineStateType.Running Then
            mcStatus = "Running"
        Else
            mcStatus = "Stop"
        End If
        Dim tL As List(Of String) = New List(Of String)
        Dim cL As List(Of String) = New List(Of String)

        If mc.ChannelATesterNo = mc.ChannelBTesterNo Then
            tL.Add(mc.ChannelATesterNo)
            cL.Add("AB")
        Else
            If Not String.IsNullOrEmpty(mc.ChannelATesterNo) Then
                tL.Add(mc.ChannelATesterNo)
                cL.Add("A")
            End If

            If Not String.IsNullOrEmpty(mc.ChannelBTesterNo) Then
                tL.Add(mc.ChannelBTesterNo)
                cL.Add("B")
            End If
        End If


        Dim queryString As String = "McNo=" & HttpUtility.UrlEncode(mc.MCNo) & _
        "&LotNo=" & HttpUtility.UrlEncode(lotNo) & _
        "&TypeTester=" & HttpUtility.UrlEncode(testerType) & _
        "&ProgramAuto=" & HttpUtility.UrlEncode(programName) & _
        "&MCStatus=" & HttpUtility.UrlEncode(mcStatus) & _
        "&TesterNo=" & HttpUtility.UrlEncode(String.Join(",", tL.ToArray())) & _
        "&Channel=" & HttpUtility.UrlEncode(String.Join(",", cL.ToArray())) & _
        "&TBoxName=" & HttpUtility.UrlEncode(boxName) & _
        "&LineNo=" & HttpUtility.UrlEncode(lineNo)

        tL.Clear()
        tL = Nothing

        cL.Clear()
        cL = Nothing

        Return queryString
    End Function

    Public Shared Function PopulatePMRequestQueryString(ByVal mc As Machine) As String
        Dim queryString As String = "McNo=" & HttpUtility.UrlEncode(mc.MCNo)
        Return queryString
    End Function

End Class
