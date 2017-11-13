Imports System.Xml.Serialization
Imports System.IO

Public Class MachineOperationForm

    Private Shared m_Instance As MachineOperationForm

    Public Shared Function GetInstance() As MachineOperationForm
        If m_Instance Is Nothing OrElse m_Instance.IsDisposed Then
            m_Instance = New MachineOperationForm()
        End If
        Return m_Instance
    End Function

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub InputButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputButton.Click
        Dim op As LotInputOperation = New LotInputOperation()
        op.Execute(m_Machine)

        op.ShowResult()

        If op.IsCompleted Then
            Dim wr As WorkRecordForm = WorkRecordForm.GetInstance()
            wr.EditWorkRecord(m_Machine)
            Dim aop As AutoloadTestProgramOperation = New AutoloadTestProgramOperation()
            aop.Execute(m_Machine)
        End If
    End Sub

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click
        Dim op As ManualStartOperation = New ManualStartOperation()
        op.Execute(m_Machine)
        If Not op.IsCompleted OrElse Not String.IsNullOrEmpty(op.Message) Then
            InformationMessageBox.Inform(op.Message)
        End If
    End Sub

    Private Sub ResetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetButton.Click

        Dim op As ResetOperation = New ResetOperation()
        Try
            op.Execute(m_Machine)
            If Not op.IsCompleted Then
                InformationMessageBox.Inform(op.Message)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private m_Machine As Machine
    Public Property Machine() As Machine
        Get
            Return m_Machine
        End Get
        Set(ByVal value As Machine)
            m_Machine = value
            MachineNoLabel.Text = m_Machine.MCNo
        End Set
    End Property

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub AndonRequestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AndonRequestButton.Click
        IE.OpenUrl(My.Settings.AndonRequestUrl)
    End Sub

    Private Sub BMRequestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMRequestButton.Click

        IE.OpenUrl(My.Settings.BMRequestUrl & "?" & WebRequestParameter.PopulateBMRequestQueryString(m_Machine, My.Settings.LineNo))
    End Sub

    Private Sub PMRepaireButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PMRepaireButton.Click
        IE.OpenUrl(My.Settings.PMRequestUrl & "?" & WebRequestParameter.PopulatePMRequestQueryString(m_Machine))
    End Sub

    Private Sub AutoLoadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoLoadButton.Click
        Dim op As AutoloadTestProgramOperation = New AutoloadTestProgramOperation()
        op.Execute(m_Machine)
    End Sub

    Private Sub PlanStopButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanStopButton.Click
        Select Case m_Machine.State
            Case MachineStateType.Locked, MachineStateType.LotComplete
                m_Machine.State = MachineStateType.PlanStop
            Case MachineStateType.PlanStop
                m_Machine.State = MachineStateType.Locked
        End Select
    End Sub

    Private Sub EndButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndButton.Click
        Dim op As ManualLotCompleteOperation = New ManualLotCompleteOperation()
        op.Execute(m_Machine)
        If Not op.IsCompleted Then
            InformationMessageBox.Inform(op.Message)
        Else
            InformationMessageBox.Inform("ทำการจบ Lot แบบ Manual เสร็จสิ้น")
        End If
    End Sub

    Private Sub WorkRecordButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkRecordButton.Click
        Dim wr As WorkRecordForm = WorkRecordForm.GetInstance()
        wr.EditWorkRecord(m_Machine)
    End Sub

    Private Sub InputRetestFLFTButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputRetestFLFTButton.Click
        Dim op As LotInputFLFTRetest = New LotInputFLFTRetest()
        op.Execute(m_Machine)

        If op.IsCompleted Then

            Dim wr As WorkRecordForm = WorkRecordForm.GetInstance()
            wr.EditWorkRecord(m_Machine)
            Dim aop As AutoloadTestProgramOperation = New AutoloadTestProgramOperation()
            aop.Execute(m_Machine)

        ElseIf Not String.IsNullOrEmpty(op.Message) Then
            InformationMessageBox.Inform(op.Message)
        End If
    End Sub
End Class