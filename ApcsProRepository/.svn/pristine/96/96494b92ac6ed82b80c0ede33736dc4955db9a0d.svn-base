Imports Rohm
Imports System.ComponentModel
Imports System.IO
Imports System.Data
Imports System.Text
Imports Rohm.Ems

Public Class FTMachine

#Region "Properties"

    Private m_Machine As Machine
    Public ReadOnly Property Machine() As Machine
        Get
            Return m_Machine
        End Get
    End Property

    Private m_BeforeDragLocation As Point
    Public ReadOnly Property BeforeDragLocation() As Point
        Get
            Return m_BeforeDragLocation
        End Get
    End Property

#End Region

    Public Sub New(ByVal machine As Machine)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_Machine = machine
        Me.Left = m_Machine.PositionX
        Me.Top = m_Machine.PositionY

        'NotificationLabel.DataBindings.Add("Text", m_Machine, "NotificationMessage")
        'NotificationLabel.DataBindings.Add("Visible", m_Machine, "HasNotification")

        AddHandler m_Machine.MachineStateChanged, AddressOf m_Machine_MachineStateChanged
        m_Machine_MachineStateChanged(Nothing, Nothing)

    End Sub

#Region "PictureBox Background"

    Private m_MouseDownPostion As Point
    Public ReadOnly Property MouseDownPostion() As Point
        Get
            Return Me.m_MouseDownPostion
        End Get
    End Property

    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        MyBase.OnClick(e)
        If TypeOf Me.Parent Is FTMachinePanel Then
            CType(Me.Parent, FTMachinePanel).ActiveFTMachine = Me
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then

            'return right click show contextmenu strip
            Me.ContextMenuStrip = ContextMenuStrip1

            m_MouseDownPostion = Point.Empty
            PictureBox1.Cursor = Cursors.Hand
            If TypeOf Me.Parent Is FTMachinePanel Then
                Dim panel As FTMachinePanel = CType(Me.Parent, FTMachinePanel)
                panel.GrabOrderPosition(Me)
            End If
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            'prevent right click context menu strip popup
            Me.ContextMenuStrip = Nothing
            m_MouseDownPostion = New Point(e.X, e.Y)
            m_BeforeDragLocation = Me.Location
            PictureBox1.Cursor = Cursors.SizeAll
            Me.BringToFront()
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If TypeOf Me.Parent Is FTMachinePanel Then
                Dim panel As FTMachinePanel = CType(Me.Parent, FTMachinePanel)
                Dim newPoint As Point = New Point(Me.Left - m_MouseDownPostion.X + e.X, Me.Top - m_MouseDownPostion.Y + e.Y)
                If newPoint.X >= 0 AndAlso newPoint.X <= panel.Width - Me.Width _
                AndAlso newPoint.Y >= 0 AndAlso newPoint.Y <= panel.Height - Me.Height Then
                    Me.Left = newPoint.X
                    Me.Top = newPoint.Y
                End If
            End If
        End If
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        Dim g As Graphics
        g = e.Graphics
        g.DrawRectangle(Pens.Black, 1, 1, Me.Width - 2, Me.Height - 2)
        g.DrawString(m_Machine.MCNo, Me.Font, Brushes.Black, 5, 5)
        If m_Machine.State <> MachineStateType.PlanStop Then
            If m_Machine.UseAutoMode Then
                If m_Machine.WorkingSlip IsNot Nothing Then
                    g.DrawString(m_Machine.WorkingSlip.LotNo, Me.Font, Brushes.Black, 5, 23)
                    g.DrawString(m_Machine.WorkingSlip.PackageName, Me.Font, Brushes.Black, 5, 41)
                    g.DrawString(m_Machine.WorkingSlip.ForIndication2, Me.Font, Brushes.Black, 5, 59)
                End If
            Else

                If m_Machine.WorkingSlip IsNot Nothing Then
                    g.DrawString(m_Machine.WorkingSlip.LotNo, Me.Font, Brushes.Black, 5, 23)
                    g.DrawString(m_Machine.WorkingSlip.ForIndication2, Me.Font, Brushes.Black, 5, 41)
                End If

                g.DrawImage(My.Resources.mode_m, 25, 55, My.Resources.mode_m.Width, My.Resources.mode_m.Height)
                End If
        End If
    End Sub

#End Region

#Region "Running Alarm and Stop time counting"

    Private Sub m_Machine_MachineStateChanged(ByVal sender As Object, ByVal e As MachineStateChangedEventArgs)

        Select Case m_Machine.State
            Case MachineStateType.Alarm
                Me.TowerLightBlinkTimer.Start()
                Me.m_Blink = True
                Me.GreenLampLabel.BackColor = Color.Gray
                Me.YellowLampLabel.BackColor = Color.Gray
                Me.RedLampLabel.BackColor = Color.Red
                Me.PictureBox1.Image = Nothing
                Me.PictureBox1.BackColor = Color.Red
                Me.CountUpTimer.Start()

            Case MachineStateType.Running
                Me.TowerLightBlinkTimer.Enabled = False
                Me.GreenLampLabel.BackColor = Color.Green
                Me.YellowLampLabel.BackColor = Color.Gray
                Me.RedLampLabel.BackColor = Color.Gray
                Me.PictureBox1.Image = Nothing
                Me.PictureBox1.BackColor = Color.Green
                Me.CountUpTimer.Start()

            Case MachineStateType.AdjustmentStop
                Me.TowerLightBlinkTimer.Enabled = False
                Me.GreenLampLabel.BackColor = Color.Gray
                Me.YellowLampLabel.BackColor = Color.Yellow
                Me.RedLampLabel.BackColor = Color.Gray
                Me.PictureBox1.Image = Nothing
                Me.PictureBox1.BackColor = Color.White
                Me.CountUpTimer.Start()

            Case MachineStateType.PlanStop
                Me.TowerLightBlinkTimer.Enabled = False
                Me.GreenLampLabel.BackColor = Color.Gray
                Me.YellowLampLabel.BackColor = Color.Gray
                Me.RedLampLabel.BackColor = Color.Gray
                Me.PictureBox1.Image = My.Resources.planStop
                Me.PictureBox1.BackColor = Color.Yellow
                Me.PlanStopToolStripMenuItem.Checked = True
                CountUpTimer.Stop()

            Case MachineStateType.LotComplete, MachineStateType.LotEnd, MachineStateType.Locked, MachineStateType.ReTestStart
                Me.TowerLightBlinkTimer.Enabled = False
                Me.GreenLampLabel.BackColor = Color.Gray
                Me.YellowLampLabel.BackColor = Color.Yellow
                Me.RedLampLabel.BackColor = Color.Gray
                Me.PictureBox1.Image = Nothing
                Me.PictureBox1.BackColor = Color.White
                CountUpTimer.Stop()

        End Select

    End Sub

    Private m_Blink As Boolean

    Private Sub tmrTowerLightBlink_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TowerLightBlinkTimer.Tick
        If m_Machine.State = MachineStateType.Alarm Then
            m_Blink = Not m_Blink
            If m_Blink Then
                RedLampLabel.BackColor = Color.Red
                PictureBox1.BackColor = Color.Red
            Else
                RedLampLabel.BackColor = Color.Gray
                PictureBox1.BackColor = Color.White
            End If
        Else
            TowerLightBlinkTimer.Stop()
        End If
    End Sub

#End Region

    Private Sub CountUpTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CountUpTimer.Tick
        Dim currentTime As Date = Now
        Dim tmp As TimeSpan = m_Machine.CountTimeStamp.Subtract(currentTime).Duration()
        Select Case m_Machine.State
            Case MachineStateType.AdjustmentStop
                m_Machine.StopTime += tmp
                m_Machine.CountTimeStamp = currentTime
            Case MachineStateType.Alarm
                m_Machine.AlarmTime += tmp
                m_Machine.CountTimeStamp = currentTime
            Case MachineStateType.Running
                m_Machine.RunningTime += tmp
                m_Machine.CountTimeStamp = currentTime
            Case Else
                CountUpTimer.[Stop]()
        End Select
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        Dim f As MachineOperationForm = MachineOperationForm.GetInstance()
        f.Machine = m_Machine
        f.ShowDialog()
        Me.Refresh()
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        Dim op As RemoveMachineOperation = New RemoveMachineOperation()
        op.Execute(m_Machine)
        If op.IsCompleted Then
            Me.Parent.Controls.Remove(Me)
        End If
    End Sub

    Private Sub PlanStopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanStopToolStripMenuItem.Click

        If m_Machine.WorkingSlip IsNot Nothing AndAlso m_Machine.LotStartTime.HasValue Then
            Using adaptor As DBxDataSetTableAdapters.FTDataTableAdapter = New DBxDataSetTableAdapters.FTDataTableAdapter()
                Using table As DBxDataSet.FTDataDataTable = adaptor.GetDataByPKs(m_Machine.MCNo, m_Machine.WorkingSlip.LotNo, m_Machine.LotStartTime.Value)
                    If table.Rows.Count = 1 Then
                        Dim row As DBxDataSet.FTDataRow = CType(table.Rows(0), DBxDataSet.FTDataRow)
                        If WorkRecordIsNotComplete(row) Then
                            InformationMessageBox.Inform("การลง Work Record ยังไม่สมบูรณ์")
                            Exit Sub
                        End If
                    End If
                End Using
            End Using
        End If

        Select Case m_Machine.State
            Case MachineStateType.Locked, MachineStateType.LotComplete
                m_Machine.State = MachineStateType.PlanStop
            Case MachineStateType.PlanStop
                m_Machine.State = MachineStateType.Locked
            Case MachineStateType.AdjustmentStop
                If m_Machine.LotCompleteTime.HasValue Then
                    m_Machine.State = MachineStateType.PlanStop
                End If
        End Select
        PlanStopToolStripMenuItem.Checked = (m_Machine.State = MachineStateType.PlanStop)
    End Sub
End Class

