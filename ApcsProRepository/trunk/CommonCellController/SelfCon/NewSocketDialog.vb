
Public Class NewSocketDialog

    Private m_ChangedSocketCh1 As Jig
    Public Property ChangedSocketCh1() As Jig
        Get
            Return m_ChangedSocketCh1
        End Get
        Set(ByVal value As Jig)
            m_ChangedSocketCh1 = value
        End Set
    End Property

    Private m_ChangedSocketCh2 As Jig
    Public Property ChangedSocketCh2() As Jig
        Get
            Return m_ChangedSocketCh2
        End Get
        Set(ByVal value As Jig)
            m_ChangedSocketCh2 = value
        End Set
    End Property

    Private m_ChangedSocketCh3 As Jig
    Public Property ChangedSocketCh3() As Jig
        Get
            Return m_ChangedSocketCh3
        End Get
        Set(ByVal value As Jig)
            m_ChangedSocketCh3 = value
        End Set
    End Property

    Private m_ChangedSocketCh4 As Jig
    Public Property ChangedSocketCh4() As Jig
        Get
            Return m_ChangedSocketCh4
        End Get
        Set(ByVal value As Jig)
            m_ChangedSocketCh4 = value
        End Set
    End Property

    Private Enum SocketChannel
        None = 0
        CH1 = 1
        CH2 = 2
        CH3 = 3
        CH4 = 4
    End Enum

    Private m_CurrentChannel As SocketChannel

    Private Sub PrepareQRCodeTextBox(ByVal ch As SocketChannel)
        m_CurrentChannel = ch
        QRCodeTextBox.Text = Nothing
        QRCodeTextBox.Focus()

        Select Case ch
            Case SocketChannel.CH1
                ChangedSocketNum_Ch1_Label.BackColor = Color.Yellow
            Case SocketChannel.CH2
                ChangedSocketNum_Ch2_Label.BackColor = Color.Yellow
            Case SocketChannel.CH3
                ChangedSocketNum_Ch3_Label.BackColor = Color.Yellow
            Case SocketChannel.CH4
                ChangedSocketNum_Ch4_Label.BackColor = Color.Yellow
        End Select
    End Sub

    Private Sub ChangeSocket_Ch1_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeSocket_Ch1_Button.Click
        PrepareQRCodeTextBox(SocketChannel.CH1)
    End Sub

    Private Sub ChangeSocket_Ch2_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeSocket_Ch2_Button.Click
        PrepareQRCodeTextBox(SocketChannel.CH2)
    End Sub

    Private Sub ChangeSocket_Ch3_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeSocket_Ch3_Button.Click
        PrepareQRCodeTextBox(SocketChannel.CH3)
    End Sub

    Private Sub ChangeSocket_Ch4_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeSocket_Ch4_Button.Click
        PrepareQRCodeTextBox(SocketChannel.CH4)
    End Sub

    Private Sub NewSocketDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        m_ChangedSocketCh1 = Nothing
        m_ChangedSocketCh2 = Nothing
        m_ChangedSocketCh3 = Nothing
        m_ChangedSocketCh4 = Nothing

        ChangedSocketNum_Ch1_Label.Text = Nothing
        ChangedSocketNum_Ch2_Label.Text = Nothing
        ChangedSocketNum_Ch3_Label.Text = Nothing
        ChangedSocketNum_Ch4_Label.Text = Nothing

        ChangedSocketNum_Ch1_Label.BackColor = Color.White
        ChangedSocketNum_Ch2_Label.BackColor = Color.White
        ChangedSocketNum_Ch3_Label.BackColor = Color.White
        ChangedSocketNum_Ch4_Label.BackColor = Color.White

        m_CurrentChannel = SocketChannel.None

    End Sub

    Private Sub QRCodeTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles QRCodeTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim qrText As String = QRCodeTextBox.Text.Trim().ToUpper()
            QRCodeTextBox.Text = Nothing

            If Not qrText.StartsWith("String") Then
                Exit Sub
            End If

            If m_CurrentChannel = SocketChannel.None Then
                Exit Sub
            End If

            If (m_ChangedSocketCh1 IsNot Nothing AndAlso m_ChangedSocketCh1.QRCode = qrText) OrElse _
            (m_ChangedSocketCh2 IsNot Nothing AndAlso m_ChangedSocketCh2.QRCode = qrText) OrElse _
            (m_ChangedSocketCh3 IsNot Nothing AndAlso m_ChangedSocketCh3.QRCode = qrText) OrElse _
            (m_ChangedSocketCh4 IsNot Nothing AndAlso m_ChangedSocketCh4.QRCode = qrText) Then
                InformationMessageBox.Inform("ข้อมูลซ้ำกรุณากรอกใหม่")
                Exit Sub
            End If

            'MCNo	    LotNo	    PackageName	DeviceName	    ProgramName	TesterType	TestFlow	QRCodesocket1	QRCodesocket2	QRCodesocket3	QRCodesocket4	QRCodesocketChannel1	QRCodesocketChannel2	QRCodesocketChannel3	QRCodesocketChannel4	TesterNoA	TesterNoAQRcode	TesterNoB	TesterNoBQRcode	ChannelAFTB	ChannelAFTBQRcode	ChannelBFTB	ChannelBFTBQRcode	TestBoxA	TestBoxAQRcode	TestBoxB	TestBoxBQRcode	AdaptorA	AdaptorAQRcode	AdaptorB	AdaptorBQRcode	DutcardA	DutcardAQRcode	DutcardB	DutcardBQRcode	BridgecableA	BridgecableAQRcode	BridgecableB	BridgecableBQRcode	TypeChangePackage	SetupStartDate	SetupEndDate	BoxTesterConnection	OptionSetup	OptionConnection	OptionName1	OptionName2	OptionName3	OptionName4	OptionName5	OptionName6	OptionName7	OptionType1	OptionType1QRcode	OptionType2	OptionType2QRcode	OptionType3	OptionType3QRcode	OptionType4	OptionType4QRcode	OptionType5	OptionType5QRcode	OptionType6	OptionType6QRcode	OptionType7	OptionType7QRcode	OptionSetting1	OptionSetting2	OptionSetting3	OptionSetting4	OptionSetting5	OptionSetting6	OptionSetting7	QfpVacuumPad	QfpSocketSetup	QfpSocketDecision	QfpDecisionLeadPress	QfpTray	SopStopper	SopSocketDecision	SopDecisionLeadPress	ManualCheckTest	ManualCheckTE	ManualCheckRequestTE	ManualCheckRequestTEConfirm	PkgGood	PkgNG	PkgGoodJudgement	PkgNGJudgement	PkgNishikiCamara	PkgNishikiCamaraJudgement	PkqBantLead	PkqKakeHige	BgaSmallBall	BgaBentTape	Bge5S	SetupStatus	ConfirmedCheckSheetOp	ConfirmedCheckSheetSection	ConfirmedCheckSheetGL	ConfirmedShonoSection	ConfirmedShonoGL	ConfirmedShonoOp	StatusShonoOP	SetupConfirmDate
            'FT-EP-002	1726A5082V	HSON-A8	    BV1LB090HFS-CTR	FV1LB090K1	ICT2000	    AUTO1	    ATCB	        ATFG	        ATBI	        ATBJ	        JIG012898	            JIG012981	            JIG012879	            JIG012880	            291TX	    EQP000172		FTB-1				F2 BV1LB085	EQP014979			D2 BV1LB085HFS	EQP014980												2017-07-24 13:34:36.463	2017-07-24 13:39:01.443	OK	YES	OK	PA 36 V3.0 A	PA 120 V6.0 A	PA 60 V6.0 A					PA 36 V3.0 A	EQP010136	PA 120 V6.0 A	EQP017806	PA 60 V6.0 A	EQP015150																								10	OK	5	OK	5	5	OK	OK							OK	CONFIRMED								2017-07-24 13:39:21.440
            Using adaptor As DBxDataSetTableAdapters.TempDataTableAdapter = New DBxDataSetTableAdapters.TempDataTableAdapter()

                Using tbl As DBxDataSet.TempDataDataTable = adaptor.GetDataByQRCode(qrText)
                    If tbl.Rows.Count = 1 Then
                        Dim row As DBxDataSet.TempDataRow = CType(tbl.Rows(0), DBxDataSet.TempDataRow)
                        Dim j As Jig = New Jig With {.QRCode = row.QRCode, .SmallCode = row.SmallCode}

                        Dim lbl As Label

                        Select Case m_CurrentChannel
                            Case SocketChannel.CH1
                                m_ChangedSocketCh1 = j
                                lbl = ChangedSocketNum_Ch1_Label
                            Case SocketChannel.CH2
                                m_ChangedSocketCh2 = j
                                lbl = ChangedSocketNum_Ch2_Label
                            Case SocketChannel.CH3
                                m_ChangedSocketCh3 = j
                                lbl = ChangedSocketNum_Ch3_Label
                            Case SocketChannel.CH4
                                m_ChangedSocketCh4 = j
                                lbl = ChangedSocketNum_Ch4_Label
                            Case Else
                                Exit Sub
                        End Select

                        lbl.Text = j.SmallCode
                        lbl.BackColor = Color.Green
                    Else
                        'show error message : NOT FOUND
                    End If

                End Using

            End Using

        End If
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        If m_ChangedSocketCh1 Is Nothing AndAlso _
            m_ChangedSocketCh2 Is Nothing AndAlso _
            m_ChangedSocketCh3 Is Nothing AndAlso _
            m_ChangedSocketCh4 Is Nothing Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub CLButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLButton.Click

        m_ChangedSocketCh1 = Nothing
        m_ChangedSocketCh2 = Nothing
        m_ChangedSocketCh3 = Nothing
        m_ChangedSocketCh4 = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

#Region "Single instance"

    Private Shared m_Instance As NewSocketDialog
    Public Shared Function GetInstance() As NewSocketDialog
        If m_Instance Is Nothing OrElse m_Instance.IsDisposed Then
            m_Instance = New NewSocketDialog()
        End If
        Return m_Instance
    End Function

#End Region

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

End Class