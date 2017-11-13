Public Class WorkRecordForm

    Private Shared m_Instance As WorkRecordForm

    Public Shared Function GetInstance() As WorkRecordForm
        If m_Instance Is Nothing OrElse m_Instance.IsDisposed Then
            m_Instance = New WorkRecordForm()
        End If
        Return m_Instance
    End Function

    Private Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Enum EditType
        FromMachine = 0
        FromDatabase = 1
    End Enum

    Private m_Machine As Machine
    Private m_DataRow As DBxDataSet.FTDataRow
    Private m_EditMode As EditType

    Public Sub EditWorkRecord(ByVal mc As Machine)

        If mc.WorkingSlip Is Nothing Then
            InformationMessageBox.Inform("กรุณากรอกข้อมูล Working Slip ก่อน")
            Exit Sub
        End If


        If mc.LotCompleteTime.HasValue Then
            Dim table As DBxDataSet.FTDataDataTable = FtDataTableAdapter1.GetDataByPKs(mc.MCNo, mc.WorkingSlip.LotNo, mc.LotStartTime.Value)

            If table.Rows.Count = 1 Then
                EditFromDatabase(table, mc)
            Else
                InformationMessageBox.Inform("ไม่พบข้อมูลของ Lot := " & mc.WorkingSlip.LotNo & " ในฐานข้อมูล")
                Exit Sub
            End If

        Else
            EditFromMachine(mc)
        End If

        ShokoWarningPictureBox.Visible = Not IsFTSetupShokonokoshiCompleted()

        ChangeMeControlsColor()

        ShowDialog()

    End Sub

    Private Sub ChangeMeControlsColor()

        Dim txt As TextBox
        Dim rdb As RadioButton
        Dim cb As CheckBox
        Dim gb As GroupBox

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                txt = CType(ctrl, TextBox)
                ChangeTextBoxColor(txt)
            ElseIf TypeOf ctrl Is RadioButton Then
                rdb = CType(ctrl, RadioButton)
                ChangeRadioButtonColor(rdb)
            ElseIf TypeOf ctrl Is CheckBox Then
                cb = CType(ctrl, CheckBox)
                ChangeCheckBoxColor(cb)
            ElseIf TypeOf ctrl Is GroupBox Then
                gb = CType(ctrl, GroupBox)
                DoChangeControlColorInGroupBox(gb)
            End If
        Next
    End Sub

    Private Sub DoChangeControlColorInGroupBox(ByVal gb As GroupBox)
        Dim txt As TextBox
        Dim rdb As RadioButton
        Dim cb As CheckBox

        Dim gb2 As GroupBox

        For Each ctrl As Control In gb.Controls
            If TypeOf ctrl Is TextBox Then
                txt = CType(ctrl, TextBox)
                ChangeTextBoxColor(txt)
            ElseIf TypeOf ctrl Is RadioButton Then
                rdb = CType(ctrl, RadioButton)
                ChangeRadioButtonColor(rdb)
            ElseIf TypeOf ctrl Is CheckBox Then
                cb = CType(ctrl, CheckBox)
                ChangeCheckBoxColor(cb)
            ElseIf TypeOf ctrl Is GroupBox Then
                gb2 = CType(ctrl, GroupBox)
                DoChangeControlColorInGroupBox(gb2)
            End If
        Next
    End Sub

    Private Sub ChangeTextBoxColor(ByVal txt As TextBox)
        If txt.Enabled Then
            If String.IsNullOrEmpty(txt.Text) Then
                txt.BackColor = Color.Khaki
            Else
                txt.BackColor = Color.LimeGreen
            End If
        Else
            txt.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ChangeCheckBoxColor(ByVal cb As CheckBox)
        If cb.Enabled AndAlso cb.Checked Then
            cb.BackColor = Color.LimeGreen
        Else
            cb.BackColor = cb.Parent.BackColor
        End If
    End Sub

    Private Sub ChangeRadioButtonColor(ByVal rdb As RadioButton)
        If rdb.Enabled AndAlso rdb.Checked Then
            Select Case rdb.Text
                Case "ไม่ผ่าน"
                    rdb.BackColor = Color.Tomato
                Case "ผ่าน", "Pass"
                    rdb.BackColor = Color.LimeGreen
                Case "Room", "Hot", "Cold"
                    rdb.BackColor = Color.Gold
                Case Else
                    rdb.BackColor = Color.DeepSkyBlue
            End Select
        Else
            rdb.BackColor = rdb.Parent.BackColor
        End If
    End Sub

    Private Sub EditFromDatabase(ByVal table As DBxDataSet.FTDataDataTable, ByVal mc As Machine)

        m_EditMode = EditType.FromDatabase

        m_Machine = mc
        MachineNoLabel.Text = mc.MCNo
        m_DataRow = CType(table.Rows(0), DBxDataSet.FTDataRow)

        TesterNoATextBox.Enabled = True
        TesterNoBTextBox.Enabled = True
        BoxNoATextBox.Enabled = True
        BoxNoBTextBox.Enabled = True

        RoomTemperatureRadioButton.Enabled = True
        HotTemperatureRadioButton.Enabled = True
        ColdTemperatureRadioButton.Enabled = True

        MarkingInspectionFailRadioButton.Enabled = True
        MarkingInspectionPassRadioButton.Enabled = True

        FirstAutoAsiFailRadioButton.Enabled = True
        FirstAutoAsiPassRadioButton.Enabled = True
        SecondAutoAsiFailRadioButton.Enabled = True
        SecondAutoAsiPassRadioButton.Enabled = True

        FirstGoodBin1TextBox.Enabled = True
        FirstGoodBin2TextBox.Enabled = True
        FirstFtNgBin6TextBox.Enabled = True
        FirstMeka1TextBox.Enabled = True
        FirstMeka2TextBox.Enabled = True
        'FirstMeka4TextBox.Enabled = True
        FirstMekaUnknowTextBox.Enabled = True

        SecondGoodBin1TextBox.Enabled = True
        SecondGoodBin2TextBox.Enabled = True
        SecondFtNgBin6TextBox.Enabled = True
        SecondMeka1TextBox.Enabled = True
        'SecondMeka2TextBox.Enabled = True
        SecondMeka4TextBox.Enabled = True
        SecondMekaUnknowTextBox.Enabled = True

        TotalGoodBin1TextBox.Enabled = True
        TotalGoodBin2TextBox.Enabled = True
        TotalNGTextBox.Enabled = True
        TotalMeka1TextBox.Enabled = True
        TotalMeka2TextBox.Enabled = True
        TotalMeka4TextBox.Enabled = True
        TotalMekaUnknowTextBox.Enabled = True

        LotStartVisualInspectTotalQtyTextBox.Enabled = True
        LotStartVisualInspectNGQtyTextBox.Enabled = True

        LotEndVisualInspectTotalQtyTextBox.Enabled = True
        LotEndVisualInspectNGQtyTextBox.Enabled = True

        HandlerCounterTextBox.Enabled = True
        TesterACounterTextBox.Enabled = True
        TesterBCounterTextBox.Enabled = True

        InitialYieldTextBox.Enabled = True
        FirstEndYieldTextBox.Enabled = True
        FinalYieldTextBox.Enabled = True

        GoodSampleQtyTextBox.Enabled = True
        NGSampleQtyTextBox.Enabled = True

        DuringProductionCheck_A_RadioButton.Enabled = True
        DuringProductionCheck_B_RadioButton.Enabled = True
        DuringProductionCheck_C_RadioButton.Enabled = True

        SocketChangeCheckBox.Enabled = False

        SocketCheck_A_RadioButton.Enabled = True
        SocketCheck_B_RadioButton.Enabled = True
        SocketCheck_C_RadioButton.Enabled = True

        LotJudgementInspectionRadioButton.Enabled = True
        LotJudgementLowYieldRadioButton.Enabled = True
        LotJudgementOtherRadioButton.Enabled = True
        LotJudgementPassRadioButton.Enabled = True

        RemarkTextBox.Enabled = True
        GLCheckTextBox.Enabled = True

        OPEndTextBox.Enabled = True

        ReadFromDatabaseToUi(m_Machine, m_DataRow)

    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        'save FTSetup Report
        'incase of socket changed
        UpdateFTSetupRecordSocket()

        'checking for Shokonokoshi
        If m_Machine.LotCompleteTime.HasValue Then
            If Not IsFTSetupShokonokoshiCompleted() Then
                InformationMessageBox.Inform("กรุณาทำ Shokonokoshi ก่อน")
                Exit Sub
            End If
        End If

        'save to FTData
        If m_EditMode = EditType.FromDatabase Then

            If Not String.IsNullOrEmpty(GLCheckTextBox.Text) Then
                Dim authen As AuthenticationUser.AuthenUser = New AuthenticationUser.AuthenUser()
                If Not authen.AuthenUser(GLCheckTextBox.Text, My.Settings.GroupLeaderGroupName) Then
                    InformationMessageBox.Inform("รหัสพนักงาน " & GLCheckTextBox.Text & " ไม่ได้เป็น " & My.Settings.GroupLeaderGroupName)
                    Exit Sub
                End If
            End If

            Try
                ApplyUiToDatabase(m_DataRow)
                Dim affectedRow As Integer = FtDataTableAdapter1.Update(m_DataRow)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Catch ex As Exception
                InformationMessageBox.Inform(ex.Message)
            End Try

        Else
            ApplyFromUiToMachine(m_Machine)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

    End Sub

    Private Function IsFTSetupShokonokoshiCompleted() As Boolean

        Dim ret As Boolean = False

        Using adap1 As DBxDataSetTableAdapters.FTSetupReportTableAdapter = New DBxDataSetTableAdapters.FTSetupReportTableAdapter()

            Using tbl1 As DBxDataSet.FTSetupReportDataTable = adap1.GetDataByMCNo(STRING_TDC_MACHINENO_PREFIX & m_Machine.MCNo)
                If tbl1.Rows.Count = 1 Then
                    Dim row1 As DBxDataSet.FTSetupReportRow = CType(tbl1.Rows(0), DBxDataSet.FTSetupReportRow)
                    If Not row1.IsStatusShonoOPNull() AndAlso _
                        Not row1.IsConfirmedShonoOpNull() AndAlso _
                        row1.ConfirmedShonoOp <> "" AndAlso _
                        row1.StatusShonoOP = "1" Then
                        ret = True
                    End If
                End If
            End Using
        End Using

        Return ret

    End Function

    Private Sub UpdateFTSetupRecordSocket()

        'no need to change
        If ChangedSocketNum_Ch1_Label.Tag Is Nothing AndAlso _
            ChangedSocketNum_Ch2_Label.Tag Is Nothing AndAlso _
            ChangedSocketNum_Ch3_Label.Tag Is Nothing AndAlso _
            ChangedSocketNum_Ch4_Label.Tag Is Nothing Then
            Exit Sub
        End If

        Using adaptor As DBxDataSetTableAdapters.FTSetupReportTableAdapter = New DBxDataSetTableAdapters.FTSetupReportTableAdapter()
            Using table As DBxDataSet.FTSetupReportDataTable = adaptor.GetDataByMCNo(STRING_TDC_MACHINENO_PREFIX & m_Machine.MCNo)

                If table.Rows.Count = 1 Then

                    Dim row As DBxDataSet.FTSetupReportRow = CType(table.Rows(0), DBxDataSet.FTSetupReportRow)
                    Dim tmp As Jig

                    If TypeOf ChangedSocketNum_Ch1_Label.Tag Is Jig Then
                        tmp = CType(ChangedSocketNum_Ch1_Label.Tag, Jig)
                        row.QRCodesocket1 = tmp.SmallCode
                        row.QRCodesocketChannel1 = tmp.QRCode
                    End If

                    If TypeOf ChangedSocketNum_Ch2_Label.Tag Is Jig Then
                        tmp = CType(ChangedSocketNum_Ch2_Label.Tag, Jig)
                        row.QRCodesocket2 = tmp.SmallCode
                        row.QRCodesocketChannel2 = tmp.QRCode
                    End If

                    If TypeOf ChangedSocketNum_Ch3_Label.Tag Is Jig Then
                        tmp = CType(ChangedSocketNum_Ch3_Label.Tag, Jig)
                        row.QRCodesocket3 = tmp.SmallCode
                        row.QRCodesocketChannel3 = tmp.QRCode
                    End If

                    If TypeOf ChangedSocketNum_Ch4_Label.Tag Is Jig Then
                        tmp = CType(ChangedSocketNum_Ch4_Label.Tag, Jig)
                        row.QRCodesocket4 = tmp.SmallCode
                        row.QRCodesocketChannel4 = tmp.QRCode
                    End If

                    adaptor.Update(row)

                End If

            End Using
        End Using


    End Sub

    Private Sub ApplyUiToDatabase(ByVal row As DBxDataSet.FTDataRow) '(ByVal mc As Machine)

        'Counter
        If IsNumeric(HandlerCounterTextBox.Text) Then
            row.HandlerCounterQty = CInt(HandlerCounterTextBox.Text)
        Else
            row.SetHandlerCounterQtyNull()
        End If
        If IsNumeric(TesterACounterTextBox.Text) Then
            row.TesterACounterQty = CInt(TesterACounterTextBox.Text)
        Else
            row.SetTesterACounterQtyNull()
        End If
        If IsNumeric(TesterBCounterTextBox.Text) Then
            row.TesterBCounterQty = CInt(TesterBCounterTextBox.Text)
        Else
            row.SetTesterBCounterQtyNull()
        End If

        If RoomTemperatureRadioButton.Checked Then
            row.TestTemperature = "Room"
        ElseIf HotTemperatureRadioButton.Checked Then
            row.TestTemperature = "Hot"
        ElseIf ColdTemperatureRadioButton.Checked Then
            row.TestTemperature = "Cold"
        End If

        If String.IsNullOrEmpty(TesterNoATextBox.Text) Then
            row.SetChannelATesterNoNull()
        Else
            row.ChannelATesterNo = TesterNoATextBox.Text
        End If
        If String.IsNullOrEmpty(TesterNoBTextBox.Text) Then
            row.SetChannelBTesterNoNull()
        Else
            row.ChannelBTesterNo = TesterNoBTextBox.Text
        End If

        If String.IsNullOrEmpty(BoxNoATextBox.Text) Then
            row.SetChannelATestBoxNoNull()
        Else
            row.ChannelATestBoxNo = BoxNoATextBox.Text
        End If
        If String.IsNullOrEmpty(BoxNoBTextBox.Text) Then
            row.SetChannelBTestBoxNoNull()
        Else
            row.ChannelBTestBoxNo = BoxNoBTextBox.Text
        End If

        'socket change
        row.SocketChange = SocketChangeCheckBox.Checked

        If IsNumeric(FirstGoodBin1TextBox.Text) Then
            row.FirstGoodBin1Qty = CInt(FirstGoodBin1TextBox.Text)
        Else
            row.SetFirstGoodBin1QtyNull()
        End If

        If IsNumeric(FirstGoodBin2TextBox.Text) Then
            row.FirstGoodBin2Qty = CInt(FirstGoodBin2TextBox.Text)
        Else
            row.SetFirstGoodBin2QtyNull()
        End If

        If IsNumeric(FirstFtNgBin6TextBox.Text) Then
            row.FirstNGQty = CInt(FirstFtNgBin6TextBox.Text)
        Else
            row.SetFirstNGQtyNull()
        End If

        If IsNumeric(FirstMeka1TextBox.Text) Then
            row.FirstMeka1Qty = CInt(FirstMeka1TextBox.Text)
        Else
            row.SetFirstMeka1QtyNull()
        End If

        If IsNumeric(FirstMeka2TextBox.Text) Then
            row.FirstMeka2Qty = CInt(FirstMeka2TextBox.Text)
        Else
            row.SetFirstMeka2QtyNull()
        End If

        If IsNumeric(FirstMekaUnknowTextBox.Text) Then
            row.FirstUnknowQty = CInt(FirstMekaUnknowTextBox.Text)
        Else
            row.SetFirstUnknowQtyNull()
        End If

        If IsNumeric(SecondGoodBin1TextBox.Text) Then
            row.SecondGoodBin1Qty = CInt(SecondGoodBin1TextBox.Text)
        Else
            row.SetSecondGoodBin1QtyNull()
        End If

        If IsNumeric(SecondGoodBin2TextBox.Text) Then
            row.SecondGoodBin2Qty = CInt(SecondGoodBin2TextBox.Text)
        Else
            row.SetSecondGoodBin2QtyNull()
        End If

        If IsNumeric(SecondFtNgBin6TextBox.Text) Then
            row.SecondNGQty = CInt(SecondFtNgBin6TextBox.Text)
        Else
            row.SetSecondNGQtyNull()
        End If

        If IsNumeric(SecondMeka1TextBox.Text) Then
            row.SecondMeka1Qty = CInt(SecondMeka1TextBox.Text)
        Else
            row.SetSecondMeka1QtyNull()
        End If

        If IsNumeric(SecondMeka4TextBox.Text) Then
            row.SecondMeka4Qty = CInt(SecondMeka4TextBox.Text)
        Else
            row.SetSecondMeka4QtyNull()
        End If

        If IsNumeric(SecondMekaUnknowTextBox.Text) Then
            row.SecondUnknowQty = CInt(SecondMekaUnknowTextBox.Text)
        Else
            row.SetSecondUnknowQtyNull()
        End If

        'row.TotalGood = TotalGoodTextBox.Text 
        If IsNumeric(TotalNGTextBox.Text) Then
            row.TotalNGQty = CInt(TotalNGTextBox.Text)
        Else
            row.SetTotalNGQtyNull()
        End If

        If IsNumeric(TotalGoodBin1TextBox.Text) Then
            row.TotalGoodBin1Qty = CInt(TotalGoodBin1TextBox.Text)
        Else
            row.SetTotalGoodBin1QtyNull()
        End If

        If IsNumeric(TotalGoodBin2TextBox.Text) Then
            row.TotalGoodBin2Qty = CInt(TotalGoodBin2TextBox.Text)
        Else
            row.SetTotalGoodBin2QtyNull()
        End If

        If IsNumeric(TotalMeka1TextBox.Text) Then
            row.TotalMeka1Qty = CInt(TotalMeka1TextBox.Text)
        Else
            row.SetTotalMeka1QtyNull()
        End If

        If IsNumeric(TotalMeka2TextBox.Text) Then
            row.TotalMeka2Qty = CInt(TotalMeka2TextBox.Text)
        Else
            row.SetTotalMeka2QtyNull()
        End If

        If IsNumeric(TotalMeka4TextBox.Text) Then
            row.TotalMeka4Qty = CInt(TotalMeka4TextBox.Text)
        Else
            row.SetTotalMeka4QtyNull()
        End If

        If IsNumeric(TotalMekaUnknowTextBox.Text) Then
            row.TotalUnknowQty = CInt(TotalMekaUnknowTextBox.Text)
        Else
            row.SetTotalUnknowQtyNull()
        End If

        If FirstAutoAsiPassRadioButton.Checked Then
            row.FirstAutoAsiCheck = True
        ElseIf FirstAutoAsiFailRadioButton.Checked Then
            row.FirstAutoAsiCheck = False
        Else
            row.SetFirstAutoAsiCheckNull()
        End If

        If SecondAutoAsiPassRadioButton.Checked Then
            row.SecondAutoAsiCheck = True
        ElseIf SecondAutoAsiFailRadioButton.Checked Then
            row.SecondAutoAsiCheck = False
        Else
            row.SetSecondAutoAsiCheckNull()
        End If

        If SocketCheck_A_RadioButton.Checked Then
            row.SocketCheck = "A"
        ElseIf SocketCheck_B_RadioButton.Checked Then
            row.SocketCheck = "B"
        ElseIf SocketCheck_C_RadioButton.Checked Then
            row.SocketCheck = "C"
        End If

        row.GoodSampleQty = CShort(GoodSampleQtyTextBox.Text)
        row.NGSampleQty = CShort(NGSampleQtyTextBox.Text)

        If LotJudgementPassRadioButton.Checked Then
            row.LotJudgement = "Pass"
        ElseIf LotJudgementInspectionRadioButton.Checked Then
            row.LotJudgement = "Inspection"
        ElseIf LotJudgementLowYieldRadioButton.Checked Then
            row.LotJudgement = "Low Yield"
        ElseIf LotJudgementOtherRadioButton.Checked Then
            row.LotJudgement = "Other"
        End If

        row.Remark = RemarkTextBox.Text

        If String.IsNullOrEmpty(GLCheckTextBox.Text) Then
            row.SetGLCheckNull()
        Else
            row.GLCheck = GLCheckTextBox.Text
        End If

        If IsNumeric(LotStartVisualInspectNGQtyTextBox.Text) Then
            row.LotStartVisualInspectNGQty = CShort(LotStartVisualInspectNGQtyTextBox.Text)
        Else
            row.SetLotStartVisualInspectNGQtyNull()
        End If

        If IsNumeric(LotStartVisualInspectTotalQtyTextBox.Text) Then
            row.LotStartVisualInspectTotalQty = CShort(LotStartVisualInspectTotalQtyTextBox.Text)
        Else
            row.SetLotStartVisualInspectTotalQtyNull()
        End If

        If IsNumeric(LotEndVisualInspectNGQtyTextBox.Text) Then
            row.LotEndVisualInspectNGQty = CShort(LotEndVisualInspectNGQtyTextBox.Text)
        Else
            row.SetLotEndVisualInspectNGQtyNull()
        End If

        If IsNumeric(LotEndVisualInspectTotalQtyTextBox.Text) Then
            row.LotEndVisualInspectTotalQty = CShort(LotEndVisualInspectTotalQtyTextBox.Text)
        Else
            row.SetLotEndVisualInspectTotalQtyNull()
        End If

        If DuringProductionCheck_A_RadioButton.Checked Then
            row.DuringProductionCheck = "A"
        ElseIf DuringProductionCheck_B_RadioButton.Checked Then
            row.DuringProductionCheck = "B"
        ElseIf DuringProductionCheck_C_RadioButton.Checked Then
            row.DuringProductionCheck = "C"
        Else
            row.SetDuringProductionCheckNull()
        End If

        If MarkingInspectionFailRadioButton.Checked Then
            row.MarkingInspection = False
        ElseIf MarkingInspectionPassRadioButton.Checked Then
            row.MarkingInspection = True
        Else
            row.SetMarkingInspectionNull()
        End If

        If IsNumeric(InitialYieldTextBox.Text) Then
            row.InitialYield = CSng(InitialYieldTextBox.Text)
        Else
            row.SetInitialYieldNull()
        End If

        If IsNumeric(FirstEndYieldTextBox.Text) Then
            row.FirstEndYield = CSng(FirstEndYieldTextBox.Text)
        Else
            row.SetFirstEndYieldNull()
        End If

        If IsNumeric(FinalYieldTextBox.Text) Then
            row.FinalYield = CSng(FinalYieldTextBox.Text)
        Else
            row.SetFinalYieldNull()
        End If

        If String.IsNullOrEmpty(OPEndTextBox.Text) Then
            row.SetEndOPNoNull()
        Else
            row.EndOPNo = OPEndTextBox.Text
        End If

        If String.IsNullOrEmpty(ChangedSocketNum_Ch1_Label.Text) Then
            row.SetChangedSocketNumCh1Null()
        Else
            row.ChangedSocketNumCh1 = ChangedSocketNum_Ch1_Label.Text
        End If

        If String.IsNullOrEmpty(ChangedSocketNum_Ch2_Label.Text) Then
            row.SetChangedSocketNumCh2Null()
        Else
            row.ChangedSocketNumCh2 = ChangedSocketNum_Ch2_Label.Text
        End If

        If String.IsNullOrEmpty(ChangedSocketNum_Ch3_Label.Text) Then
            row.SetChangedSocketNumCh3Null()
        Else
            row.ChangedSocketNumCh3 = ChangedSocketNum_Ch3_Label.Text
        End If

        If String.IsNullOrEmpty(ChangedSocketNum_Ch4_Label.Text) Then
            row.SetChangedSocketNumCh4Null()
        Else
            row.ChangedSocketNumCh4 = ChangedSocketNum_Ch4_Label.Text
        End If

    End Sub

    Private Sub ReadFromDatabaseToUi(ByVal mc As Machine, ByVal row As DBxDataSet.FTDataRow)

        Dim ws As WorkingSlip = mc.WorkingSlip
        If ws IsNot Nothing Then
            LotNoLabel.Text = ws.LotNo
            PackageLabel.Text = ws.PackageName
            DeviceLabel.Text = ws.ForIndication2
            MarkNoLabel.Text = ws.MarkNo
        End If

        If row.IsInputQtyNull() Then
            InputQtyLabel.Text = ""
        Else
            InputQtyLabel.Text = row.InputQty.ToString()
        End If

        If row.IsProgramNameNull() Then
            ProgramNameLabel.Text = ""
        Else
            ProgramNameLabel.Text = row.ProgramName
        End If

        If row.IsTestFlowNameNull() Then
            TestFlowLabel.Text = ""
        Else
            TestFlowLabel.Text = row.TestFlowName
        End If

        If row.IsTesterTypeNull() Then
            TesterTypeLabel.Text = ""
        Else
            TesterTypeLabel.Text = row.TesterType
        End If

        If row.IsTestTemperatureNull() Then
            RoomTemperatureRadioButton.Checked = False
            HotTemperatureRadioButton.Checked = False
            ColdTemperatureRadioButton.Checked = False
        Else
            Select Case row.TestTemperature
                Case "Room"
                    RoomTemperatureRadioButton.Checked = True
                Case "Hot"
                    HotTemperatureRadioButton.Checked = True
                Case "Cold"
                    ColdTemperatureRadioButton.Checked = True
            End Select
        End If

        If row.IsMarkingInspectionNull() Then
            MarkingInspectionPassRadioButton.Checked = False
        Else
            MarkingInspectionPassRadioButton.Checked = row.MarkingInspection
        End If

        If row.IsChannelATesterNoNull() Then
            TesterNoATextBox.Text = Nothing
        Else
            TesterNoATextBox.Text = row.ChannelATesterNo
        End If

        If row.IsChannelBTesterNoNull() Then
            TesterNoBTextBox.Text = Nothing
        Else
            TesterNoBTextBox.Text = row.ChannelBTesterNo
        End If

        If row.IsChannelATestBoxNoNull() Then
            BoxNoATextBox.Text = Nothing
        Else
            BoxNoATextBox.Text = row.ChannelATestBoxNo
        End If

        If row.IsChannelBTestBoxNoNull() Then
            BoxNoBTextBox.Text = Nothing
        Else
            BoxNoBTextBox.Text = row.ChannelBTestBoxNo
        End If

        'socket change
        If row.IsSocketChangeNull() Then
            SocketChangeCheckBox.Checked = False
        Else
            SocketChangeCheckBox.Checked = row.SocketChange
        End If

        StartTimeLabel.Text = row.LotStartTime.ToString("yyyy/MM/dd HH:mm:ss")

        If row.IsLotEndTimeNull() Then
            EndTimeLabel.Text = Nothing
        Else
            EndTimeLabel.Text = row.LotEndTime.ToString("yyyy/MM/dd HH:mm:ss")
        End If

        If row.IsOPNoNull() Then
            OPStartLabel.Text = Nothing
        Else
            OPStartLabel.Text = row.OPNo
        End If

        If row.IsEndOPNoNull() Then
            OPEndTextBox.Text = Nothing
        Else
            OPEndTextBox.Text = row.EndOPNo
        End If

        'First qty

        If row.IsFirstGoodBin1QtyNull() Then
            FirstGoodBin1TextBox.Text = ""
        Else
            FirstGoodBin1TextBox.Text = row.FirstGoodBin1Qty.ToString()
        End If

        If row.IsFirstGoodBin2QtyNull() Then
            FirstGoodBin2TextBox.Text = ""
        Else
            FirstGoodBin2TextBox.Text = row.FirstGoodBin2Qty.ToString()
        End If

        If row.IsFirstNGQtyNull() Then
            FirstFtNgBin6TextBox.Text = ""
        Else
            FirstFtNgBin6TextBox.Text = row.FirstNGQty.ToString()
        End If
        If row.IsFirstMeka1QtyNull() Then
            FirstMeka1TextBox.Text = ""
        Else
            FirstMeka1TextBox.Text = row.FirstMeka1Qty.ToString()
        End If
        If row.IsFirstMeka2QtyNull() Then
            FirstMeka2TextBox.Text = ""
        Else
            FirstMeka2TextBox.Text = row.FirstMeka2Qty.ToString()
        End If
        If row.IsFirstUnknowQtyNull() Then
            FirstMekaUnknowTextBox.Text = ""
        Else
            FirstMekaUnknowTextBox.Text = row.FirstUnknowQty.ToString()
        End If

        'Second qty
        If row.IsSecondGoodBin1QtyNull() Then
            SecondGoodBin1TextBox.Text = ""
        Else
            SecondGoodBin1TextBox.Text = row.SecondGoodBin1Qty.ToString()
        End If

        If row.IsSecondGoodBin2QtyNull() Then
            SecondGoodBin2TextBox.Text = ""
        Else
            SecondGoodBin2TextBox.Text = row.SecondGoodBin2Qty.ToString()
        End If

        If row.IsSecondNGQtyNull() Then
            SecondFtNgBin6TextBox.Text = ""
        Else
            SecondFtNgBin6TextBox.Text = row.SecondNGQty.ToString()
        End If
        If row.IsSecondMeka1QtyNull() Then
            SecondMeka1TextBox.Text = ""
        Else
            SecondMeka1TextBox.Text = row.SecondMeka1Qty.ToString()
        End If
        If row.IsSecondMeka4QtyNull() Then
            SecondMeka4TextBox.Text = ""
        Else
            SecondMeka4TextBox.Text = row.SecondMeka4Qty.ToString()
        End If
        If row.IsSecondUnknowQtyNull() Then
            SecondMekaUnknowTextBox.Text = ""
        Else
            SecondMekaUnknowTextBox.Text = row.SecondUnknowQty.ToString()
        End If

        'Total qty
        If row.IsTotalGoodBin1QtyNull() Then
            TotalGoodBin1TextBox.Text = ""
        Else
            TotalGoodBin1TextBox.Text = row.TotalGoodBin1Qty.ToString()
        End If

        If row.IsTotalGoodBin2QtyNull() Then
            TotalGoodBin2TextBox.Text = ""
        Else
            TotalGoodBin2TextBox.Text = row.TotalGoodBin2Qty.ToString()
        End If

        If row.IsTotalNGQtyNull() Then
            TotalNGTextBox.Text = ""
        Else
            TotalNGTextBox.Text = row.TotalNGQty.ToString()
        End If

        If row.IsTotalMeka1QtyNull() Then
            TotalMeka1TextBox.Text = ""
        Else
            TotalMeka1TextBox.Text = row.TotalMeka1Qty.ToString()
        End If
        If row.IsTotalMeka2QtyNull() Then
            TotalMeka2TextBox.Text = ""
        Else
            TotalMeka2TextBox.Text = row.TotalMeka2Qty.ToString()
        End If
        If row.IsTotalMeka4QtyNull() Then
            TotalMeka4TextBox.Text = ""
        Else
            TotalMeka4TextBox.Text = row.TotalMeka4Qty.ToString()
        End If
        If row.IsTotalUnknowQtyNull() Then
            TotalMekaUnknowTextBox.Text = ""
        Else
            TotalMekaUnknowTextBox.Text = row.TotalUnknowQty.ToString()
        End If

        'Counter
        If row.IsHandlerCounterQtyNull() Then
            HandlerCounterTextBox.Text = Nothing
        Else
            HandlerCounterTextBox.Text = row.HandlerCounterQty.ToString()
        End If
        If row.IsTesterACounterQtyNull() Then
            TesterACounterTextBox.Text = Nothing
        Else
            TesterACounterTextBox.Text = row.TesterACounterQty.ToString()
        End If
        If row.IsTesterBCounterQtyNull() Then
            TesterBCounterTextBox.Text = Nothing
        Else
            TesterBCounterTextBox.Text = row.TesterBCounterQty.ToString()
        End If

        If row.IsFirstAutoAsiCheckNull() Then
            FirstAutoAsiPassRadioButton.Checked = False
            FirstAutoAsiFailRadioButton.Checked = False
        Else
            FirstAutoAsiPassRadioButton.Checked = row.FirstAutoAsiCheck
            FirstAutoAsiFailRadioButton.Checked = Not row.FirstAutoAsiCheck
        End If

        If row.IsSecondAutoAsiCheckNull() Then
            SecondAutoAsiPassRadioButton.Checked = False
            SecondAutoAsiFailRadioButton.Checked = False
        Else
            SecondAutoAsiPassRadioButton.Checked = row.SecondAutoAsiCheck
            SecondAutoAsiFailRadioButton.Checked = Not row.SecondAutoAsiCheck
        End If

        If row.IsSocketCheckNull() Then
            SocketCheck_A_RadioButton.Checked = False
            SocketCheck_B_RadioButton.Checked = False
            SocketCheck_C_RadioButton.Checked = False
        Else
            Select Case row.SocketCheck
                Case "A"
                    SocketCheck_A_RadioButton.Checked = True
                Case "B"
                    SocketCheck_B_RadioButton.Checked = True
                Case "C"
                    SocketCheck_C_RadioButton.Checked = True
            End Select
        End If

        If row.IsGoodSampleQtyNull() Then
            GoodSampleQtyTextBox.Text = Nothing
        Else
            GoodSampleQtyTextBox.Text = row.GoodSampleQty.ToString()
        End If
        If row.IsNGSampleQtyNull() Then
            NGSampleQtyTextBox.Text = Nothing
        Else
            NGSampleQtyTextBox.Text = row.NGSampleQty.ToString()
        End If

        If row.IsLotJudgementNull() Then
            LotJudgementPassRadioButton.Checked = False
            LotJudgementInspectionRadioButton.Checked = False
            LotJudgementLowYieldRadioButton.Checked = False
            LotJudgementOtherRadioButton.Checked = False
        Else
            Select Case row.LotJudgement
                Case "Pass"
                    LotJudgementPassRadioButton.Checked = True
                Case "Inspection"
                    LotJudgementInspectionRadioButton.Checked = True
                Case "Low Yield"
                    LotJudgementLowYieldRadioButton.Checked = True
                Case "Other"
                    LotJudgementOtherRadioButton.Checked = True

            End Select
        End If

        If row.IsRemarkNull() Then
            RemarkTextBox.Text = Nothing
        Else
            RemarkTextBox.Text = row.Remark
        End If

        If row.IsGLCheckNull() Then
            GLCheckTextBox.Text = Nothing
        Else
            GLCheckTextBox.Text = row.GLCheck
        End If

        If row.IsLotStartVisualInspectNGQtyNull() Then
            LotStartVisualInspectNGQtyTextBox.Text = ""
        Else
            LotStartVisualInspectNGQtyTextBox.Text = row.LotStartVisualInspectNGQty.ToString()
        End If

        If row.IsLotStartVisualInspectTotalQtyNull() Then
            LotStartVisualInspectTotalQtyTextBox.Text = ""
        Else
            LotStartVisualInspectTotalQtyTextBox.Text = row.LotStartVisualInspectTotalQty.ToString()
        End If

        If row.IsLotEndVisualInspectNGQtyNull() Then
            LotEndVisualInspectNGQtyTextBox.Text = ""
        Else
            LotEndVisualInspectNGQtyTextBox.Text = row.LotEndVisualInspectNGQty.ToString()
        End If

        If row.IsLotEndVisualInspectTotalQtyNull() Then
            LotEndVisualInspectTotalQtyTextBox.Text = ""
        Else
            LotEndVisualInspectTotalQtyTextBox.Text = row.LotEndVisualInspectTotalQty.ToString()
        End If

        If row.IsDuringProductionCheckNull() Then
            DuringProductionCheck_A_RadioButton.Checked = False
            DuringProductionCheck_B_RadioButton.Checked = False
            DuringProductionCheck_C_RadioButton.Checked = False
        Else
            Select Case row.DuringProductionCheck
                Case "A"
                    DuringProductionCheck_A_RadioButton.Checked = True
                Case "B"
                    DuringProductionCheck_B_RadioButton.Checked = True
                Case "C"
                    DuringProductionCheck_C_RadioButton.Checked = True
            End Select
        End If

        If row.IsLCLNull() Then
            LCLLabel.Text = ""
        Else
            LCLLabel.Text = row.LCL.ToString()
        End If

        If row.IsInitialYieldNull() Then
            InitialYieldTextBox.Text = ""
        Else
            InitialYieldTextBox.Text = row.InitialYield.ToString()
        End If

        If row.IsFirstEndYieldNull() Then
            FirstEndYieldTextBox.Text = ""
        Else
            FirstEndYieldTextBox.Text = row.FirstEndYield.ToString()
        End If

        If row.IsFinalYieldNull() Then
            FinalYieldTextBox.Text = ""
        Else
            FinalYieldTextBox.Text = row.FinalYield.ToString()
        End If

        If row.IsSocketNumCh1Null() Then
            SocketNum_Ch1_Label.Text = Nothing
        Else
            SocketNum_Ch1_Label.Text = row.SocketNumCh1
        End If

        If row.IsSocketNumCh2Null() Then
            SocketNum_Ch2_Label.Text = Nothing
        Else
            SocketNum_Ch2_Label.Text = row.SocketNumCh2
        End If

        If row.IsSocketNumCh3Null() Then
            SocketNum_Ch3_Label.Text = Nothing
        Else
            SocketNum_Ch3_Label.Text = row.SocketNumCh3
        End If

        If row.IsSocketNumCh4Null() Then
            SocketNum_Ch4_Label.Text = Nothing
        Else
            SocketNum_Ch4_Label.Text = row.SocketNumCh4
        End If

        If row.IsChangedSocketNumCh1Null() Then
            ChangedSocketNum_Ch1_Label.Text = Nothing
        Else
            ChangedSocketNum_Ch1_Label.Text = row.ChangedSocketNumCh1
        End If

        If row.IsChangedSocketNumCh2Null() Then
            ChangedSocketNum_Ch2_Label.Text = Nothing
        Else
            ChangedSocketNum_Ch2_Label.Text = row.ChangedSocketNumCh2
        End If

        If row.IsChangedSocketNumCh3Null() Then
            ChangedSocketNum_Ch3_Label.Text = Nothing
        Else
            ChangedSocketNum_Ch3_Label.Text = row.ChangedSocketNumCh3
        End If

        If row.IsChangedSocketNumCh4Null() Then
            ChangedSocketNum_Ch4_Label.Text = Nothing
        Else
            ChangedSocketNum_Ch4_Label.Text = row.ChangedSocketNumCh4
        End If
    End Sub

    Private Sub ReadFromMachineToUi(ByVal mc As Machine)

        Dim ws As WorkingSlip = mc.WorkingSlip

        MachineNoLabel.Text = mc.MCNo

        InputQtyLabel.Text = mc.InputQty.ToString()

        If ws IsNot Nothing Then
            LotNoLabel.Text = ws.LotNo
            PackageLabel.Text = ws.PackageName
            DeviceLabel.Text = ws.ForIndication2
            MarkNoLabel.Text = ws.MarkNo
        End If

        Dim ois As OIS = mc.OIS

        ProgramNameLabel.Text = ois.ProgramName
        TestFlowLabel.Text = ois.TestFlow
        TesterTypeLabel.Text = ois.TesterType

        TesterNoATextBox.Text = mc.ChannelATesterNo
        TesterNoBTextBox.Text = mc.ChannelBTesterNo

        OPStartLabel.Text = mc.OPNo

        If mc.LotStartTime.HasValue Then
            StartTimeLabel.Text = mc.LotStartTime.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Else
            StartTimeLabel.Text = ""
        End If

        EndTimeLabel.Text = ""

        'not yet support
        BoxNoATextBox.Text = mc.ChannelAFtb
        BoxNoBTextBox.Text = mc.ChannelBFtb

        Select Case mc.TestTemperature
            Case "Room"
                RoomTemperatureRadioButton.Checked = True
            Case "Hot"
                HotTemperatureRadioButton.Checked = True
            Case "Cold"
                ColdTemperatureRadioButton.Checked = True
            Case Else
                RoomTemperatureRadioButton.Checked = False
                HotTemperatureRadioButton.Checked = False
                ColdTemperatureRadioButton.Checked = False
        End Select

        If mc.MarkingInspection.HasValue Then
            If mc.MarkingInspection.Value Then
                MarkingInspectionPassRadioButton.Checked = True
            Else
                MarkingInspectionFailRadioButton.Checked = True
            End If
        Else
            MarkingInspectionPassRadioButton.Checked = False
            MarkingInspectionFailRadioButton.Checked = False
        End If

        FirstAutoAsiFailRadioButton.Checked = False
        FirstAutoAsiPassRadioButton.Checked = False
        SecondAutoAsiFailRadioButton.Checked = False
        SecondAutoAsiPassRadioButton.Checked = False

        TotalGoodBin1TextBox.Text = ""
        TotalGoodBin2TextBox.Text = ""
        TotalNGTextBox.Text = ""
        TotalMeka1TextBox.Text = ""
        TotalMeka2TextBox.Text = ""
        TotalMeka4TextBox.Text = ""
        TotalMekaUnknowTextBox.Text = ""

        LotStartVisualInspectTotalQtyTextBox.Text = mc.LotStartVisualInspectTotalQty.ToString()
        LotStartVisualInspectNGQtyTextBox.Text = mc.LotStartVisualInspectNGQty.ToString()

        LotEndVisualInspectTotalQtyTextBox.Text = ""
        LotEndVisualInspectNGQtyTextBox.Text = ""

        HandlerCounterTextBox.Text = ""
        TesterACounterTextBox.Text = ""
        TesterBCounterTextBox.Text = ""

        LCLLabel.Text = mc.LCL.ToString()
        InitialYieldTextBox.Text = mc.InitialYield.ToString()
        If mc.FirstEndYield.HasValue Then
            FirstEndYieldTextBox.Text = mc.FirstEndYield.Value.ToString()
        Else
            FirstEndYieldTextBox.Text = ""
        End If

        FinalYieldTextBox.Text = ""

        GoodSampleQtyTextBox.Text = mc.GoodSampleQty.ToString()
        NGSampleQtyTextBox.Text = mc.NGSampleQty.ToString()

        DuringProductionCheck_A_RadioButton.Checked = False
        DuringProductionCheck_B_RadioButton.Checked = False
        DuringProductionCheck_C_RadioButton.Checked = False

        Select Case mc.SocketCheck
            Case "A"
                SocketCheck_A_RadioButton.Checked = True
            Case "B"
                SocketCheck_B_RadioButton.Checked = True
            Case "C"
                SocketCheck_C_RadioButton.Checked = True
            Case Else
                SocketCheck_A_RadioButton.Checked = False
                SocketCheck_B_RadioButton.Checked = False
                SocketCheck_C_RadioButton.Checked = False
        End Select

        If String.IsNullOrEmpty(mc.LotJudgement) Then
            LotJudgementPassRadioButton.Checked = False
            LotJudgementInspectionRadioButton.Checked = False
            LotJudgementLowYieldRadioButton.Checked = False
            LotJudgementOtherRadioButton.Checked = False
        Else
            Select Case mc.LotJudgement
                Case "Pass"
                    LotJudgementPassRadioButton.Checked = True
                Case "Inspection"
                    LotJudgementInspectionRadioButton.Checked = True
                Case "Low Yield"
                    LotJudgementLowYieldRadioButton.Checked = True
                Case "Other"
                    LotJudgementOtherRadioButton.Checked = True
            End Select
        End If

        If mc.ChangedSocketCh1 IsNot Nothing OrElse _
            mc.ChangedSocketCh2 IsNot Nothing OrElse _
            mc.ChangedSocketCh3 IsNot Nothing OrElse _
            mc.ChangedSocketCh4 IsNot Nothing Then
            SocketChangeCheckBox.Checked = True
        Else
            SocketChangeCheckBox.Checked = False
        End If

        If mc.SocketCh1 IsNot Nothing Then
            SocketNum_Ch1_Label.Text = mc.SocketCh1
        Else
            SocketNum_Ch1_Label.Text = Nothing
        End If

        If mc.SocketCh2 IsNot Nothing Then
            SocketNum_Ch2_Label.Text = mc.SocketCh2
        Else
            SocketNum_Ch2_Label.Text = Nothing
        End If

        If mc.SocketCh3 IsNot Nothing Then
            SocketNum_Ch3_Label.Text = mc.SocketCh3
        Else
            SocketNum_Ch3_Label.Text = Nothing
        End If

        If mc.SocketCh4 IsNot Nothing Then
            SocketNum_Ch4_Label.Text = mc.SocketCh4
        Else
            SocketNum_Ch4_Label.Text = Nothing
        End If

        If mc.ChangedSocketCh1 IsNot Nothing Then
            ChangedSocketNum_Ch1_Label.Text = mc.ChangedSocketCh1
            ChangedSocketNum_Ch1_Label.Tag = mc.ChangedSocketCh1
        Else
            ChangedSocketNum_Ch1_Label.Text = Nothing
            ChangedSocketNum_Ch1_Label.Tag = Nothing
        End If

        If mc.ChangedSocketCh2 IsNot Nothing Then
            ChangedSocketNum_Ch2_Label.Text = mc.ChangedSocketCh2
            ChangedSocketNum_Ch2_Label.Tag = mc.ChangedSocketCh2
        Else
            ChangedSocketNum_Ch2_Label.Text = Nothing
            ChangedSocketNum_Ch2_Label.Tag = Nothing
        End If

        If mc.ChangedSocketCh3 IsNot Nothing Then
            ChangedSocketNum_Ch3_Label.Text = mc.ChangedSocketCh3
            ChangedSocketNum_Ch3_Label.Tag = mc.ChangedSocketCh3
        Else
            ChangedSocketNum_Ch3_Label.Text = Nothing
            ChangedSocketNum_Ch3_Label.Tag = Nothing
        End If

        If mc.ChangedSocketCh4 IsNot Nothing Then
            ChangedSocketNum_Ch4_Label.Text = mc.ChangedSocketCh4
            ChangedSocketNum_Ch4_Label.Tag = mc.ChangedSocketCh4
        Else
            ChangedSocketNum_Ch4_Label.Text = Nothing
            ChangedSocketNum_Ch4_Label.Tag = Nothing
        End If

        FirstGoodBin1TextBox.Text = mc.FirstGoodBin1Qty.ToString()
        FirstGoodBin2TextBox.Text = mc.FirstGoodBin2Qty.ToString()
        FirstFtNgBin6TextBox.Text = mc.FirstNGQty.ToString()
        FirstMeka1TextBox.Text = mc.FirstMeka1Qty.ToString()
        FirstMeka2TextBox.Text = mc.FirstMeka2Qty.ToString()
        FirstMekaUnknowTextBox.Text = mc.FirstUnknowQty.ToString()

        If mc.SecondGoodBin1Qty.HasValue Then
            SecondGoodBin1TextBox.Text = mc.SecondGoodBin1Qty.Value.ToString()
        Else
            SecondGoodBin1TextBox.Text = ""
        End If
        If mc.SecondGoodBin2Qty.HasValue Then
            SecondGoodBin2TextBox.Text = mc.SecondGoodBin2Qty.Value.ToString()
        Else
            SecondGoodBin2TextBox.Text = ""
        End If
        If mc.SecondNGQty.HasValue Then
            SecondFtNgBin6TextBox.Text = mc.SecondNGQty.Value.ToString()
        Else
            SecondFtNgBin6TextBox.Text = ""
        End If
        If mc.SecondMeka1Qty.HasValue Then
            SecondMeka1TextBox.Text = mc.SecondMeka1Qty.Value.ToString()
        Else
            SecondMeka1TextBox.Text = ""
        End If
        If mc.SecondMeka4Qty.HasValue Then
            SecondMeka4TextBox.Text = mc.SecondMeka4Qty.Value.ToString()
        Else
            SecondMeka4TextBox.Text = ""
        End If
        If mc.SecondUnknowQty.HasValue Then
            SecondMekaUnknowTextBox.Text = mc.SecondUnknowQty.Value.ToString()
        Else
            SecondMekaUnknowTextBox.Text = ""
        End If

        RemarkTextBox.Text = mc.Remark
        GLCheckTextBox.Text = ""
        OPEndTextBox.Text = ""

    End Sub

    Private Sub ApplyFromUiToMachine(ByVal mc As Machine)

        If RoomTemperatureRadioButton.Checked Then
            mc.TestTemperature = "Room"
        ElseIf HotTemperatureRadioButton.Checked Then
            mc.TestTemperature = "Hot"
        ElseIf ColdTemperatureRadioButton.Checked Then
            mc.TestTemperature = "Cold"
        Else
            mc.TestTemperature = ""
        End If

        If MarkingInspectionPassRadioButton.Checked Then
            mc.MarkingInspection = True
        ElseIf MarkingInspectionFailRadioButton.Checked Then
            mc.MarkingInspection = False
        Else
            mc.MarkingInspection = Nothing
        End If
        mc.LotStartVisualInspectTotalQty = CShort(LotStartVisualInspectTotalQtyTextBox.Text)
        mc.LotStartVisualInspectNGQty = CShort(LotStartVisualInspectNGQtyTextBox.Text)

        mc.GoodSampleQty = CShort(GoodSampleQtyTextBox.Text)
        mc.NGSampleQty = CShort(NGSampleQtyTextBox.Text)

        If SocketCheck_A_RadioButton.Checked Then
            mc.SocketCheck = "A"
        ElseIf SocketCheck_B_RadioButton.Checked Then
            mc.SocketCheck = "B"
        ElseIf SocketCheck_C_RadioButton.Checked Then
            mc.SocketCheck = "C"
        Else
            mc.SocketCheck = ""
        End If

        If LotJudgementPassRadioButton.Checked Then
            mc.LotJudgement = "Pass"
        ElseIf LotJudgementInspectionRadioButton.Checked Then
            mc.LotJudgement = "Inspection"
        ElseIf LotJudgementLowYieldRadioButton.Checked Then
            mc.LotJudgement = "Low Yield"
        ElseIf LotJudgementOtherRadioButton.Checked Then
            mc.LotJudgement = "Other"
        Else
            mc.LotJudgement = ""
        End If

        mc.Remark = RemarkTextBox.Text

        'do not allow to change current sockets
        'allow to change only changed sockets
        If Not String.IsNullOrEmpty(ChangedSocketNum_Ch1_Label.Text) Then
            mc.ChangedSocketCh1 = ChangedSocketNum_Ch1_Label.Text
        Else
            mc.ChangedSocketCh1 = Nothing
        End If

        If Not String.IsNullOrEmpty(ChangedSocketNum_Ch2_Label.Text) Then
            mc.ChangedSocketCh2 = ChangedSocketNum_Ch2_Label.Text
        Else
            mc.ChangedSocketCh2 = Nothing
        End If

        If Not String.IsNullOrEmpty(ChangedSocketNum_Ch3_Label.Text) Then
            mc.ChangedSocketCh3 = ChangedSocketNum_Ch3_Label.Text
        Else
            mc.ChangedSocketCh3 = Nothing
        End If

        If Not String.IsNullOrEmpty(ChangedSocketNum_Ch4_Label.Text) Then
            mc.ChangedSocketCh4 = ChangedSocketNum_Ch4_Label.Text
        Else
            mc.ChangedSocketCh4 = Nothing
        End If

        If IsNumeric(FirstGoodBin1TextBox.Text) Then
            mc.FirstGoodBin1Qty = CInt(FirstGoodBin1TextBox.Text)
        Else
            mc.FirstGoodBin1Qty = 0
        End If
        If IsNumeric(FirstGoodBin2TextBox.Text) Then
            mc.FirstGoodBin2Qty = CInt(FirstGoodBin2TextBox.Text)
        Else
            mc.FirstGoodBin2Qty = 0
        End If
        If IsNumeric(FirstFtNgBin6TextBox.Text) Then
            mc.FirstNGQty = CInt(FirstFtNgBin6TextBox.Text)
        Else
            mc.FirstNGQty = 0
        End If
        If IsNumeric(FirstMeka1TextBox.Text) Then
            mc.FirstMeka1Qty = CInt(FirstMeka1TextBox.Text)
        Else
            mc.FirstMeka1Qty = 0
        End If
        If IsNumeric(FirstMeka2TextBox.Text) Then
            mc.FirstMeka2Qty = CInt(FirstMeka2TextBox.Text)
        Else
            mc.FirstMeka2Qty = 0
        End If
        If IsNumeric(FirstMekaUnknowTextBox.Text) Then
            mc.FirstUnknowQty = CInt(FirstMekaUnknowTextBox.Text)
        Else
            mc.FirstUnknowQty = 0
        End If

    End Sub

    Private Sub CLButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub AllTextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TotalNGTextBox.KeyDown, TotalMekaUnknowTextBox.KeyDown, TotalMeka4TextBox.KeyDown, TotalMeka2TextBox.KeyDown, TotalMeka1TextBox.KeyDown, TotalGoodBin1TextBox.KeyDown, TesterBCounterTextBox.KeyDown, TesterACounterTextBox.KeyDown, SecondMekaUnknowTextBox.KeyDown, SecondMeka4TextBox.KeyDown, SecondMeka1TextBox.KeyDown, SecondGoodBin1TextBox.KeyDown, SecondFtNgBin6TextBox.KeyDown, RemarkTextBox.KeyDown, OPEndTextBox.KeyDown, NGSampleQtyTextBox.KeyDown, LotStartVisualInspectTotalQtyTextBox.KeyDown, LotStartVisualInspectNGQtyTextBox.KeyDown, LotEndVisualInspectTotalQtyTextBox.KeyDown, LotEndVisualInspectNGQtyTextBox.KeyDown, HandlerCounterTextBox.KeyDown, GoodSampleQtyTextBox.KeyDown, GLCheckTextBox.KeyDown, FirstMekaUnknowTextBox.KeyDown, FirstMeka2TextBox.KeyDown, FirstMeka1TextBox.KeyDown, FirstGoodBin1TextBox.KeyDown, FirstFtNgBin6TextBox.KeyDown, FirstEndYieldTextBox.KeyDown, FinalYieldTextBox.KeyDown, InitialYieldTextBox.KeyDown, TotalGoodBin2TextBox.KeyDown, SecondGoodBin2TextBox.KeyDown, FirstGoodBin2TextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub EditFromMachine(ByVal mc As Machine)

        m_EditMode = EditType.FromMachine
        m_Machine = mc

        TesterNoATextBox.Enabled = True
        TesterNoBTextBox.Enabled = True
        BoxNoATextBox.Enabled = True
        BoxNoBTextBox.Enabled = True

        RoomTemperatureRadioButton.Enabled = True
        HotTemperatureRadioButton.Enabled = True
        ColdTemperatureRadioButton.Enabled = True

        MarkingInspectionFailRadioButton.Enabled = True
        MarkingInspectionPassRadioButton.Enabled = True

        FirstAutoAsiFailRadioButton.Enabled = False
        FirstAutoAsiPassRadioButton.Enabled = False
        SecondAutoAsiFailRadioButton.Enabled = False
        SecondAutoAsiPassRadioButton.Enabled = False

        FirstGoodBin1TextBox.Enabled = True
        FirstGoodBin2TextBox.Enabled = True
        FirstFtNgBin6TextBox.Enabled = True
        FirstMeka1TextBox.Enabled = True
        FirstMeka2TextBox.Enabled = True
        'FirstMeka4TextBox.Enabled = False
        FirstMekaUnknowTextBox.Enabled = True

        SecondGoodBin1TextBox.Enabled = False
        SecondGoodBin2TextBox.Enabled = False
        SecondFtNgBin6TextBox.Enabled = False
        SecondMeka1TextBox.Enabled = False
        'SecondMeka2TextBox.Enabled = False
        SecondMeka4TextBox.Enabled = False
        SecondMekaUnknowTextBox.Enabled = False

        TotalGoodBin1TextBox.Enabled = False
        TotalGoodBin2TextBox.Enabled = False
        TotalNGTextBox.Enabled = False
        TotalMeka1TextBox.Enabled = False
        TotalMeka2TextBox.Enabled = False
        TotalMeka4TextBox.Enabled = False
        TotalMekaUnknowTextBox.Enabled = False

        LotStartVisualInspectTotalQtyTextBox.Enabled = True
        LotStartVisualInspectNGQtyTextBox.Enabled = True

        LotEndVisualInspectTotalQtyTextBox.Enabled = False
        LotEndVisualInspectNGQtyTextBox.Enabled = False

        HandlerCounterTextBox.Enabled = False
        TesterACounterTextBox.Enabled = False
        TesterBCounterTextBox.Enabled = False

        InitialYieldTextBox.Enabled = False
        FirstEndYieldTextBox.Enabled = False
        FinalYieldTextBox.Enabled = False

        GoodSampleQtyTextBox.Enabled = True
        NGSampleQtyTextBox.Enabled = True

        DuringProductionCheck_A_RadioButton.Enabled = False
        DuringProductionCheck_B_RadioButton.Enabled = False
        DuringProductionCheck_C_RadioButton.Enabled = False

        SocketCheck_A_RadioButton.Enabled = True
        SocketCheck_B_RadioButton.Enabled = True
        SocketCheck_C_RadioButton.Enabled = True

        SocketChangeCheckBox.Enabled = False

        LotJudgementInspectionRadioButton.Enabled = True
        LotJudgementLowYieldRadioButton.Enabled = True
        LotJudgementOtherRadioButton.Enabled = True
        LotJudgementPassRadioButton.Enabled = True

        RemarkTextBox.Enabled = True
        GLCheckTextBox.Enabled = False

        OPEndTextBox.Enabled = False

        ReadFromMachineToUi(mc)

    End Sub

    Private Sub AllRadioButton_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SocketCheck_C_RadioButton.KeyDown, SocketCheck_B_RadioButton.KeyDown, SocketCheck_A_RadioButton.KeyDown, SecondAutoAsiPassRadioButton.KeyDown, SecondAutoAsiFailRadioButton.KeyDown, RoomTemperatureRadioButton.KeyDown, MarkingInspectionPassRadioButton.KeyDown, MarkingInspectionFailRadioButton.KeyDown, LotJudgementPassRadioButton.KeyDown, LotJudgementOtherRadioButton.KeyDown, LotJudgementLowYieldRadioButton.KeyDown, LotJudgementInspectionRadioButton.KeyDown, HotTemperatureRadioButton.KeyDown, FirstAutoAsiPassRadioButton.KeyDown, FirstAutoAsiFailRadioButton.KeyDown, DuringProductionCheck_C_RadioButton.KeyDown, DuringProductionCheck_B_RadioButton.KeyDown, DuringProductionCheck_A_RadioButton.KeyDown, ColdTemperatureRadioButton.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub SocketChangeCheckBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SocketChangeCheckBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub AllTextBox_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalNGTextBox.Validated, TotalMekaUnknowTextBox.Validated, TotalMeka4TextBox.Validated, TotalMeka2TextBox.Validated, TotalMeka1TextBox.Validated, TotalGoodBin2TextBox.Validated, TotalGoodBin1TextBox.Validated, TesterBCounterTextBox.Validated, TesterACounterTextBox.Validated, SecondMekaUnknowTextBox.Validated, SecondMeka4TextBox.Validated, SecondMeka1TextBox.Validated, SecondGoodBin2TextBox.Validated, SecondGoodBin1TextBox.Validated, SecondFtNgBin6TextBox.Validated, RemarkTextBox.Validated, OPEndTextBox.Validated, NGSampleQtyTextBox.Validated, LotStartVisualInspectTotalQtyTextBox.Validated, LotStartVisualInspectNGQtyTextBox.Validated, LotEndVisualInspectTotalQtyTextBox.Validated, LotEndVisualInspectNGQtyTextBox.Validated, InitialYieldTextBox.Validated, HandlerCounterTextBox.Validated, GoodSampleQtyTextBox.Validated, GLCheckTextBox.Validated, FirstMekaUnknowTextBox.Validated, FirstMeka2TextBox.Validated, FirstMeka1TextBox.Validated, FirstGoodBin2TextBox.Validated, FirstGoodBin1TextBox.Validated, FirstFtNgBin6TextBox.Validated, FirstEndYieldTextBox.Validated, FinalYieldTextBox.Validated
        Dim txt As TextBox = CType(sender, TextBox)
        ChangeTextBoxColor(txt)
    End Sub

    Private Sub AllRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SocketCheck_C_RadioButton.CheckedChanged, SocketCheck_B_RadioButton.CheckedChanged, SocketCheck_A_RadioButton.CheckedChanged, SecondAutoAsiPassRadioButton.CheckedChanged, SecondAutoAsiFailRadioButton.CheckedChanged, RoomTemperatureRadioButton.CheckedChanged, MarkingInspectionPassRadioButton.CheckedChanged, MarkingInspectionFailRadioButton.CheckedChanged, LotJudgementPassRadioButton.CheckedChanged, LotJudgementOtherRadioButton.CheckedChanged, LotJudgementLowYieldRadioButton.CheckedChanged, LotJudgementInspectionRadioButton.CheckedChanged, HotTemperatureRadioButton.CheckedChanged, FirstAutoAsiPassRadioButton.CheckedChanged, FirstAutoAsiFailRadioButton.CheckedChanged, DuringProductionCheck_C_RadioButton.CheckedChanged, DuringProductionCheck_B_RadioButton.CheckedChanged, DuringProductionCheck_A_RadioButton.CheckedChanged, ColdTemperatureRadioButton.CheckedChanged
        Dim rdb As RadioButton = CType(sender, RadioButton)
        ChangeRadioButtonColor(rdb)
    End Sub

    Private Sub SocketChangeCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SocketChangeCheckBox.CheckedChanged
        Dim cb As CheckBox = CType(sender, CheckBox)
        ChangeCheckBoxColor(cb)
    End Sub

    Private Sub ChangeSocketButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeSocketButton.Click

        Dim f As NewSocketDialog = NewSocketDialog.GetInstance()
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If f.ChangedSocketCh1 IsNot Nothing Then
                ChangedSocketNum_Ch1_Label.Text = f.ChangedSocketCh1.SmallCode
                ChangedSocketNum_Ch1_Label.Tag = f.ChangedSocketCh1
            Else
                ChangedSocketNum_Ch1_Label.Text = Nothing
                ChangedSocketNum_Ch1_Label.Tag = Nothing
            End If

            If f.ChangedSocketCh2 IsNot Nothing Then
                ChangedSocketNum_Ch2_Label.Text = f.ChangedSocketCh2.SmallCode
                ChangedSocketNum_Ch2_Label.Tag = f.ChangedSocketCh2
            Else
                ChangedSocketNum_Ch2_Label.Text = Nothing
                ChangedSocketNum_Ch2_Label.Tag = Nothing
            End If

            If f.ChangedSocketCh3 IsNot Nothing Then
                ChangedSocketNum_Ch3_Label.Text = f.ChangedSocketCh3.SmallCode
                ChangedSocketNum_Ch3_Label.Tag = f.ChangedSocketCh3
            Else
                ChangedSocketNum_Ch3_Label.Text = Nothing
                ChangedSocketNum_Ch3_Label.Tag = Nothing
            End If

            If f.ChangedSocketCh4 IsNot Nothing Then
                ChangedSocketNum_Ch4_Label.Text = f.ChangedSocketCh4.SmallCode
                ChangedSocketNum_Ch4_Label.Tag = f.ChangedSocketCh4
            Else
                ChangedSocketNum_Ch4_Label.Text = Nothing
                ChangedSocketNum_Ch4_Label.Tag = Nothing
            End If

        End If
    End Sub


End Class