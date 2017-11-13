Imports System.ComponentModel
Imports System.IO

Public Class MessageController

    Private Sub PerformLACommand(ByVal mc As Machine, ByVal args As String())
        If mc.LotStartTime.HasValue Then
            mc.RequireNewLotSetupBeforeLA = True
        Else
            mc.LBSendBuff = CreateLBCommand(mc)
            Send(mc, mc.LBSendBuff)
            mc.State = MachineStateType.Locked
        End If
    End Sub

    Private Sub PerformLBCommand(ByVal mc As Machine, ByVal repliedCommand As String)

        If repliedCommand <> "LB,0" AndAlso repliedCommand <> "LB,3" AndAlso repliedCommand = mc.LBSendBuff Then
            Send(mc, "LC,1")
        Else
            Send(mc, "LC,0")
        End If
        mc.LBSendBuff = Nothing
    End Sub

    Private Sub PerformSACommand(ByVal mc As Machine, ByVal args As String())
        mc.State = MachineStateType.Running
        If Not mc.LotStartTime.HasValue Then
            mc.LotStart()
        End If
    End Sub

    Private Function CreateLBCommand(ByVal mc As Machine) As String

        If String.IsNullOrEmpty(mc.OPNo) Then
            Return "LB,0"
        End If

        Dim xOP As String = Nothing
        'fixed 4 charactors
        Select Case mc.OPNo.Length
            Case 4
                xOP = mc.OPNo
            Case Is > 4
                xOP = Microsoft.VisualBasic.Right(mc.OPNo, 4)
            Case Is < 4
                xOP = mc.OPNo.PadLeft(4 - mc.OPNo.Length)
        End Select

        Dim capitalMcType As String = mc.MachineType.ToUpper()
        Dim strLBCommand As String = Nothing
        If mc.WorkingSlip IsNot Nothing AndAlso Not String.IsNullOrEmpty(mc.WorkingSlip.LotNo) Then
            If capitalMcType.Contains(STRING_IFTN_FAMILY) Then
                strLBCommand = "LB," & mc.WorkingSlip.LotNo
            ElseIf capitalMcType.Contains(STRING_MDH_FAMILY) Then
                Dim xInput As String = Microsoft.VisualBasic.Hex(mc.InputQty)
                'fixed 4 charactors
                If xInput.Length < 4 Then
                    xInput = StrDup(4 - xInput.Length, "0") & xInput
                End If
                Dim xLCL As String
                'change to HEX 
                xLCL = Microsoft.VisualBasic.Hex(mc.LCL * 100)
                'fixed 4 charactors
                If xLCL.Length < 4 Then
                    xLCL = StrDup(4 - xLCL.Length, "0") & xLCL
                End If
                strLBCommand = "LB," & mc.WorkingSlip.LotNo & "," & xInput & "," & xLCL & "," & xOP
            ElseIf capitalMcType.Contains(STRING_IFZ_FAMILY) OrElse _
                capitalMcType.Contains(STRING_IFTZ_FAMILY) Then
                '2015-12-10
                strLBCommand = "LB," & mc.WorkingSlip.LotNo & "," & _
                    mc.WorkingSlip.FTDevice & "," & mc.WorkingSlip.PackageName & "," & _
                    xOP & "," & mc.InputQty.ToString() & "," & mc.LCL.ToString()
            ElseIf capitalMcType.Contains(STRING_ITHA_FAMILY) Then
                '2017-04-19 'support ITHA
                strLBCommand = "LB," & StrDup(10 - mc.WorkingSlip.LotNo.Length, " ") & mc.WorkingSlip.LotNo & _
                    "," & StrDup(10 - mc.WorkingSlip.PackageName.Length, " ") & mc.WorkingSlip.PackageName & _
                    "," & StrDup(20 - mc.WorkingSlip.FTDevice.Length, " ") & mc.WorkingSlip.FTDevice & _
                    "," & mc.InputQty.ToString("X04")

            Else
                strLBCommand = "LB,0"
            End If
        Else
            strLBCommand = "LB,0"
        End If ' If mc.WorkingSlip IsNot Nothing AndAlso Not String.IsNullOrEmpty(mc.WorkingSlip.LotNo) Then
        Return strLBCommand
    End Function

    Private Sub PerformSBCommand(ByVal mc As Machine, ByVal args As String())
        mc.State = MachineStateType.AdjustmentStop
    End Sub

    Private Sub PerformSCCommand(ByVal mc As Machine, ByVal args As String())
        mc.State = MachineStateType.Alarm
        If args.GetUpperBound(0) = 1 Then
            'arg(1) = " 067"
            Try
                'change " 067" --> 67 --> "67"

                Dim almNo As String = CInt(args(1).Trim()).ToString()

                Dim alarm As Alarm = AlarmTable.GetAlarm(almNo, mc.MachineType)

                mc.SetCurrentAlarm(alarm)

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub PerformLECommand(ByVal mc As Machine, ByVal args As String())

        '************************************************************

        Dim meka1 As Integer
        Dim meka2 As Integer
        Dim meka4 As Integer

        Select Case args.Length
            Case 1
                meka1 = 0
                meka2 = 0
                meka4 = 0
            Case 4 'LE , meka1, meka2, meka4
                Try
                    meka1 = CInt(args(1).Trim())
                    meka2 = CInt(args(2).Trim())
                    meka4 = CInt(args(3).Trim())
                Catch ex As Exception
                End Try
        End Select

        'First END
        '1st "LE"
        If mc.LotEndDataHistory.Count = 0 Then
            mc.FirstGoodBin1Qty = mc.Ch1GoodQty + mc.Ch2GoodQty + mc.Ch3GoodQty + mc.Ch4GoodQty
            mc.FirstGoodBin2Qty = mc.Ch1PatQty + mc.Ch2PatQty + mc.Ch3PatQty + mc.Ch4PatQty
            mc.FirstNGQty = mc.TotalNG  ' => mc.Ch1NGQty + mc.Ch2NGQty
            mc.FirstMeka1Qty = meka1
            mc.FirstMeka2Qty = meka2
            mc.FirstUnknowQty = 0 'fix 0
            If mc.OutputQty > 0 Then
                mc.FirstEndYield = CSng(Math.Round((mc.TotalGood / mc.OutputQty) * 100, 2))
            End If
        End If

        '************************************************************

        'capture data before Retest start
        Dim lotEndData As LotEndData = New LotEndData()
        Dim tmp As Date = Now
        lotEndData.EndTime = tmp.AddMilliseconds(-tmp.Millisecond) 'remove millisecond
        lotEndData.Ch1GoodQty = mc.Ch1GoodQty
        lotEndData.Ch2GoodQty = mc.Ch2GoodQty
        lotEndData.Ch3GoodQty = mc.Ch3GoodQty
        lotEndData.Ch4GoodQty = mc.Ch4GoodQty
        lotEndData.Ch1NGQty = mc.Ch1NGQty
        lotEndData.Ch2NGQty = mc.Ch2NGQty
        lotEndData.Ch3NGQty = mc.Ch3NGQty
        lotEndData.Ch4NGQty = mc.Ch4NGQty
        lotEndData.Ch1PatQty = mc.Ch1PatQty
        lotEndData.Ch2PatQty = mc.Ch2PatQty
        lotEndData.Ch3PatQty = mc.Ch3PatQty
        lotEndData.Ch4PatQty = mc.Ch4PatQty
        mc.LotEndDataHistory.Add(lotEndData)

        PrivateKeepYieldHistory(mc, MachineChannelType.All)
        '2015-09-02
        'clear NG qty instead of receive "DJ,0" from M/C
        mc.TotalNG = 0
        'change machine state
        mc.State = MachineStateType.ReTestStart
    End Sub

    Private Sub PerformLGCommand(ByVal mc As Machine, ByVal args As String())

        Dim endOpno As String = ""
        Dim meka1 As Integer = 0
        Dim meka2 As Integer = 0
        Dim meka4 As Integer = 0

        Select Case args.Length
            Case 1 'pure LG
                'do nothing
            Case 2 'LG, 4 digits operator no
                endOpno = "00" & args(1)
            Case 4 'LG, 0, 0, 0 'IFZ machine
                meka1 = CInt(args(1).Trim())
                meka2 = CInt(args(2).Trim())
                meka4 = CInt(args(3).Trim())
            Case 5 'LG, 4 digits operator no, meka1, meka2, meka4
                Try
                    'this TotalMeka1,2,4 might be wrong 
                    'then the operator can adjust it when input work record data
                    endOpno = "00" & args(1)
                    meka1 = CInt(args(2).Trim())
                    meka2 = CInt(args(3).Trim())
                    meka4 = CInt(args(4).Trim())
                Catch ex As Exception
                End Try
        End Select

        'ไม่มีการ Retest เลย
        If mc.LotEndDataHistory.Count = 0 Then
            'Lot end without Retest
            mc.FirstGoodBin1Qty = mc.Ch1GoodQty + mc.Ch2GoodQty + mc.Ch3GoodQty + mc.Ch4GoodQty
            mc.FirstGoodBin2Qty = mc.Ch1PatQty + mc.Ch2PatQty + mc.Ch3PatQty + mc.Ch4PatQty
            mc.FirstNGQty = mc.TotalNG
            mc.FirstMeka1Qty = 0
            mc.FirstMeka2Qty = 0
            mc.FirstUnknowQty = 0 'fix 0
            If mc.OutputQty > 0 Then
                mc.FirstEndYield = CSng(Math.Round((mc.TotalGood / mc.OutputQty) * 100, 2))
            End If
        Else
            'มีการ Retest มากกว่า 1 ครั้ง 
            'LE --> LE --> ... --> LG
            mc.SecondGoodBin1Qty = mc.Ch1GoodQty + mc.Ch2GoodQty + mc.Ch3GoodQty + mc.Ch4GoodQty
            mc.SecondGoodBin2Qty = mc.Ch1PatQty + mc.Ch2PatQty + mc.Ch3PatQty + mc.Ch4PatQty
            mc.SecondNGQty = mc.TotalNG
            mc.SecondMeka1Qty = meka1
            mc.SecondMeka4Qty = meka4
            mc.SecondUnknowQty = 0
        End If

        mc.TotalMeka1 = meka1
        mc.TotalMeka2 = meka2
        mc.TotalMeka4 = meka4

        '*************************
        Try
            If mc.OutputQty > 0 Then
                mc.FinalYield = CSng(Math.Round((mc.TotalGood / mc.OutputQty) * 100, 2))
            End If
        Catch ex As Exception
        End Try

        mc.LotComplete(endOpno)

    End Sub

    Private Sub PerformDSCommand(ByVal mc As Machine, ByVal args As String())
        Try
            Dim uBound As Integer = args.GetUpperBound(0)

            If uBound >= 1 Then
                mc.Ch1GoodQty = CInt(args(1).Trim())
            End If

            If uBound >= 2 Then
                mc.Ch2GoodQty = CInt(args(2).Trim())
            End If

            If uBound >= 3 Then
                mc.Ch3GoodQty = CInt(args(3).Trim())
            End If

            If uBound >= 4 Then
                mc.Ch4GoodQty = CInt(args(4).Trim())
            End If

            ProcessChangedOutputQty(mc)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub PerformDJCommand(ByVal mc As Machine, ByVal args As String())
        Try
            Dim uBound As Integer = args.GetUpperBound(0)

            If uBound >= 1 Then
                mc.Ch1NGQty = CInt(args(1).Trim())
            End If

            If uBound >= 2 Then
                mc.Ch2NGQty = CInt(args(2).Trim())
            End If

            If uBound >= 3 Then
                mc.Ch3NGQty = CInt(args(3).Trim())
            End If

            If uBound >= 4 Then
                mc.Ch4NGQty = CInt(args(4).Trim())
            End If

            ProcessChangedOutputQty(mc)

        Catch ex As Exception
        End Try
    End Sub

    '2017-04-25 Tanapat S.
    Private Sub PerformDHCommand(ByVal mc As Machine, ByVal args As String())
        Try
            If args.GetUpperBound(0) = 1 Then
                mc.FirstUnknowQty = CInt(args(1).Trim())
            End If

            ProcessChangedOutputQty(mc)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub PerformSPCommand(ByVal mc As Machine, ByVal args As String())
        If args.GetUpperBound(0) = 1 Then
            Try
                mc.RPM = CSng(args(1).Trim())
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub PerformASICommand(ByVal mc As Machine, ByVal args As String())
        If args.GetUpperBound(0) = 2 Then
            Try
                mc.ASIGoodPcs = CInt(args(1).Trim())
                mc.ASINGTimes = CInt(args(2).Trim())
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub PerformASI_1_Command(ByVal mc As Machine, ByVal args As String())

        Dim ach As String = "0"
        Dim bch As String = "0"

        Select Case args.Length
            Case 2 'ASI1,AchResult
                ach = args(1).Trim()
                bch = "0"
            Case 3 'ASI1,AchResult,BchResult
                ach = args(1).Trim()
                bch = args(2).Trim()
        End Select

        If ach = "2" OrElse bch = "2" Then
            mc.FirstAutoAsiChecked = False
        ElseIf ach = "1" OrElse bch = "1" Then
            mc.FirstAutoAsiChecked = True
        Else
            mc.FirstAutoAsiChecked = Nothing
        End If
    End Sub

    Private Sub PerformASI_2_Command(ByVal mc As Machine, ByVal args As String())

        Dim ach As String = "0"
        Dim bch As String = "0"

        Select Case args.Length
            Case 2 'ASI2,AchResult
                ach = args(1).Trim()
                bch = "0"
            Case 3 'ASI2,AchResult,BchResult
                ach = args(1).Trim()
                bch = args(2).Trim()
        End Select

        If ach = "2" OrElse bch = "2" Then
            mc.SecondAutoAsiChecked = False
        ElseIf ach = "1" OrElse bch = "1" Then
            mc.SecondAutoAsiChecked = True
        Else
            mc.SecondAutoAsiChecked = Nothing
        End If
    End Sub

    Private Sub PerformDICommand(ByVal mc As Machine, ByVal args As String())
        Try
            Dim uBound As Integer = args.GetUpperBound(0)
            If uBound >= 1 Then
                mc.Ch1OsNgQty = CInt(args(1).Trim())
            End If

            If uBound >= 2 Then
                mc.Ch2OsNgQty = CInt(args(2).Trim())
            End If

            If uBound >= 3 Then
                mc.Ch3OsNgQty = CInt(args(3).Trim())
            End If

            If uBound >= 4 Then
                mc.Ch4OsNgQty = CInt(args(4).Trim())
            End If

            ProcessChangedOutputQty(mc)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub PerformDKCommand(ByVal mc As Machine, ByVal args As String())

        Dim uBound As Integer = args.GetUpperBound(0)
        If uBound >= 1 Then
            mc.Ch1PatQty = CInt(args(1).Trim())
        End If

        If uBound >= 2 Then
            mc.Ch2PatQty = CInt(args(2).Trim())
        End If

        If uBound >= 3 Then
            mc.Ch3PatQty = CInt(args(3).Trim())
        End If

        If uBound >= 4 Then
            mc.Ch4PatQty = CInt(args(4).Trim())
        End If

        ProcessChangedOutputQty(mc)

    End Sub

    Private Sub ProcessChangedOutputQty(ByVal mc As Machine)
        'ที่ทำแบบนี้เพราะ "หลายที่"มีการเรียกใช้ แบบแนกชาแนล  และ  ...
        '"หลายที่"มีการเรียกใช้แบบรวม จึงได้รวมให้เลยครั้งเดียว 
        ' .... เพื่อลดการคำนวณ 

        'for detect channal qty changed
        Dim oldCh1Output As Integer = mc.Ch1OutputQty
        Dim oldCh2Output As Integer = mc.Ch2OutputQty
        Dim oldCh3Output As Integer = mc.Ch3OutputQty
        Dim oldCh4Output As Integer = mc.Ch4OutputQty

        mc.Ch1OutputQty = mc.Ch1GoodQty + mc.Ch1NGQty + mc.Ch1PatQty
        mc.Ch2OutputQty = mc.Ch2GoodQty + mc.Ch2NGQty + mc.Ch2PatQty
        mc.Ch3OutputQty = mc.Ch3GoodQty + mc.Ch3NGQty + mc.Ch3PatQty
        mc.Ch4OutputQty = mc.Ch4GoodQty + mc.Ch4NGQty + mc.Ch4PatQty

        mc.TotalGood = mc.Ch1GoodQty + mc.Ch1PatQty + mc.Ch2GoodQty + mc.Ch2PatQty + _
            mc.Ch3GoodQty + mc.Ch3PatQty + mc.Ch4GoodQty + mc.Ch4PatQty

        mc.TotalNG = mc.Ch1NGQty + mc.Ch2NGQty + mc.Ch3NGQty + mc.Ch4NGQty + _
            mc.Ch1OsNgQty + mc.Ch2OsNgQty + mc.Ch3OsNgQty + mc.Ch4OsNgQty

        mc.OutputQty = mc.Ch1OutputQty + mc.Ch2OutputQty + mc.Ch3OutputQty + mc.Ch4OutputQty

        If mc.OutputQty = 100 Then
            mc.InitialYield = CSng(Math.Round((mc.TotalGood / mc.OutputQty) * 100, 2))
        End If

        Dim flag As Boolean = False

        If oldCh1Output <> mc.Ch1OutputQty AndAlso MatchCaptureCondition(mc.Ch1OutputQty) Then
            PrivateKeepYieldHistory(mc, MachineChannelType.CH1)
            flag = True
        End If

        If oldCh2Output <> mc.Ch2OutputQty AndAlso MatchCaptureCondition(mc.Ch2OutputQty) Then
            PrivateKeepYieldHistory(mc, MachineChannelType.CH2)
            flag = True
        End If

        If oldCh3Output <> mc.Ch3OutputQty AndAlso MatchCaptureCondition(mc.Ch3OutputQty) Then
            PrivateKeepYieldHistory(mc, MachineChannelType.CH3)
            flag = True
        End If

        If oldCh4Output <> mc.Ch4OutputQty AndAlso MatchCaptureCondition(mc.Ch4OutputQty) Then
            PrivateKeepYieldHistory(mc, MachineChannelType.CH4)
            flag = True
        End If

        If flag Then
            mc.RaiseEventYieldCaptured()
        End If

        mc.RaiseEventOutputChanged()

    End Sub

    Private Sub PrivateKeepYieldHistory(ByVal mc As Machine, ByVal channel As MachineChannelType)
        Dim d As YieldData = New YieldData()
        Select Case channel
            Case MachineChannelType.CH1
                d.Output = mc.Ch1OutputQty
                d.Good = mc.Ch1GoodQty
            Case MachineChannelType.CH2
                d.Output = mc.Ch2OutputQty
                d.Good = mc.Ch2GoodQty
            Case MachineChannelType.CH3
                d.Output = mc.Ch3OutputQty
                d.Good = mc.Ch3GoodQty
            Case MachineChannelType.CH4
                d.Output = mc.Ch4OutputQty
                d.Good = mc.Ch4GoodQty
            Case MachineChannelType.All
                d.Output = mc.OutputQty
                d.Good = mc.TotalGood
                'LE ครั้งที่เท่าไร
                d.Comment = "End" & mc.LotEndDataHistory.Count.ToString()
        End Select
        d.YieldValue = CSng(d.Good / d.Output) * 100
        d.Channel = channel
        mc.YieldHistory.Add(d)
    End Sub

    Private Sub SaveCommLog(ByVal mc As Machine, ByVal direction As String, ByVal commandText As String)
        Dim commlogText As String = String.Format("{0} {1}:{2}", Now.ToString("yyyy/MM/dd HH:mm:ss"), direction, commandText)
        Dim e As RecordedCommLogEventArgs = New RecordedCommLogEventArgs(commlogText)
        Using sw As StreamWriter = New StreamWriter(mc.CommLogFileName, True)
            sw.WriteLine(commlogText)
        End Using
        mc.RaiseEventRecordedCommLog(e)
    End Sub

#Region "Networking methods"

    Private m_Spliter As String() = New String() {Chr(13)}

    Private m_MachineHash As Hashtable
    Private m_UdpSocket As UDPSocket
    Private m_NetRecvBackgroundWorker As BackgroundWorker
    Private m_NetSendBackgroundWorker As BackgroundWorker

    Public Sub New()
        m_MachineHash = New Hashtable()
        m_UdpSocket = New UDPSocket(5720)
        m_NetRecvBackgroundWorker = New BackgroundWorker()
        AddHandler m_NetRecvBackgroundWorker.DoWork, AddressOf NetRecvBackgroundWorker_DoWork
        AddHandler m_NetRecvBackgroundWorker.RunWorkerCompleted, AddressOf NetRecvBackgroundWorker_RunWorkerCompleted
        m_NetSendBackgroundWorker = New BackgroundWorker()
        AddHandler m_NetSendBackgroundWorker.DoWork, AddressOf NetSendBackgroundWorker_DoWork
        AddHandler m_NetSendBackgroundWorker.RunWorkerCompleted, AddressOf NetSendBackgroundWorker_RunWorkerCompleted
    End Sub

    Public Sub Add(ByVal machine As Machine)
        m_MachineHash.Add(machine.MoxaIP, machine)
    End Sub

    Public Sub Remove(ByVal machine As Machine)
        m_MachineHash.Remove(machine.MoxaIP)
    End Sub

    Private m_KeepContinue As Boolean

    Public Sub Start()
        m_KeepContinue = True
        m_NetRecvBackgroundWorker.RunWorkerAsync()
    End Sub

    Public Sub [Stop]()
        m_KeepContinue = False
        'stop receive blocking
        m_UdpSocket.RemoteHost = "127.0.0.1"
        m_UdpSocket.Send("0")
    End Sub

    Private Sub ReceivedMessage(ByVal um As UDPMessage)

        If m_MachineHash.ContainsKey(um.FromIP) Then

            Dim mc As Machine = CType(m_MachineHash(um.FromIP), Machine)

            mc.MessageBuffer &= um.Message.Replace(Chr(10), String.Empty)

            If mc.MessageBuffer.Contains(Chr(13)) Then
                Dim lIndex As Integer
                Dim cmdArray As String() = Nothing
                'DS,01,02[13]DJ,01,02[13]SC,
                lIndex = mc.MessageBuffer.LastIndexOf(Chr(13))
                'split "DS,01,02[13]DJ,01,02[13]" into array => {"DS,01,02", "DJ,01,02"}
                cmdArray = mc.MessageBuffer.Substring(0, lIndex).Split(m_Spliter, StringSplitOptions.RemoveEmptyEntries)
                'SC, <-- stored and execute in next round
                mc.MessageBuffer = mc.MessageBuffer.Substring(lIndex + 1, mc.MessageBuffer.Length - (lIndex + 1))
                If cmdArray IsNot Nothing Then
                    For Each cmd As String In cmdArray
                        ProcessCmd(mc, cmd.Replace(Chr(0), "")) '2017-05-23 machine send NULL charactor
                    Next
                End If

            End If

        Else
            'unknow host

        End If
    End Sub

    Private Sub ProcessCmd(ByVal mc As Machine, ByVal commandText As String)

        SaveCommLog(mc, "Recv", commandText)

        Dim args() As String = commandText.Split(","c)
        Select Case args(0)
            Case "LA"
                PerformLACommand(mc, args)
            Case "LB"
                PerformLBCommand(mc, commandText)
            Case "SA"
                PerformSACommand(mc, args)
            Case "SB"
                PerformSBCommand(mc, args)
            Case "SC"
                PerformSCCommand(mc, args)
            Case "LE"
                PerformLECommand(mc, args)
            Case "LG"
                PerformLGCommand(mc, args)
            Case "DS"
                PerformDSCommand(mc, args)
            Case "DJ"
                PerformDJCommand(mc, args)
            Case "DH"
                PerformDHCommand(mc, args)
            Case "SP"
                PerformSPCommand(mc, args)
            Case "ASI"
                PerformASICommand(mc, args)
            Case "ASI1"
                PerformASI_1_Command(mc, args)
            Case "ASI2"
                PerformASI_2_Command(mc, args)
            Case "DI"
                PerformDICommand(mc, args)
            Case "DK"
                PerformDKCommand(mc, args)
        End Select
    End Sub

    Private Sub NetRecvBackgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        e.Result = m_UdpSocket.GetUDPMessage()
    End Sub

    Private Sub NetRecvBackgroundWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Dim data As UDPMessage
        data = CType(e.Result, UDPMessage)
        ReceivedMessage(data)
        If m_KeepContinue Then
            Dim tmp As Date = Now
            While m_NetRecvBackgroundWorker.IsBusy AndAlso tmp.Subtract(Now).Duration().TotalSeconds < 2
                Threading.Thread.Sleep(50)
            End While
            m_NetRecvBackgroundWorker.RunWorkerAsync()
        End If
    End Sub

    Public Sub Send(ByVal mc As Machine, ByVal msg As String)
        m_UdpSocket.RemoteHost = mc.MoxaIP
        If Not msg.EndsWith(Chr(13)) Then
            msg = msg & Chr(13)
        End If

        Dim tmp As Date = Now
        While m_NetSendBackgroundWorker.IsBusy AndAlso tmp.Subtract(Now).Duration().TotalSeconds < 2
            Threading.Thread.Sleep(50)
        End While
        m_NetSendBackgroundWorker.RunWorkerAsync(New Object() {mc, msg})
    End Sub

    Private Sub NetSendBackgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim args As Object() = CType(e.Argument, Object())
        Dim mc As Machine = CType(args(0), Machine)
        Dim commandText As String = CStr(args(1))
        Try
            m_UdpSocket.Send(commandText)
            e.Result = args
        Catch ex As Exception
            args(1) = commandText & " **ERROR { RemoteHost := " & mc.MoxaIP & ", Message := " & ex.Message & "}"
            e.Result = args
        End Try
    End Sub

    Private Sub NetSendBackgroundWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Dim args As Object() = CType(e.Result, Object())
        Dim mc As Machine = CType(args(0), Machine)
        Dim commandText As String = CStr(args(1))
        SaveCommLog(mc, "Sent", commandText)
    End Sub

#End Region

End Class
