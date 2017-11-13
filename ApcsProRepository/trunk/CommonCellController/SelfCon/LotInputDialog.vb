Imports Rohm
Imports System.ComponentModel

Public Class LotInputDialog

    Private Shared m_Instance As LotInputDialog

    Public Shared Function GetInstance() As LotInputDialog
        If m_Instance Is Nothing OrElse m_Instance.IsDisposed Then
            m_Instance = New LotInputDialog()
        End If
        Return m_Instance
    End Function

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Property Text"

    Private m_WorkSlip As WorkingSlip
    Public Property WorkingSlip() As WorkingSlip
        Get
            Return m_WorkSlip
        End Get
        Set(ByVal value As WorkingSlip)
            m_WorkSlip = value
        End Set
    End Property

    Private m_OIS As OIS
    Public Property OIS() As OIS
        Get
            Return m_OIS
        End Get
        Set(ByVal value As OIS)
            m_OIS = value
        End Set
    End Property

    Private m_InputQty As Integer
    Public Property InputQty() As Integer
        Get
            Return m_InputQty
        End Get
        Set(ByVal value As Integer)
            m_InputQty = value
        End Set
    End Property

    Private m_OPNo As String
    Public Property OPNo() As String
        Get
            Return m_OPNo
        End Get
        Set(ByVal value As String)
            m_OPNo = value
        End Set
    End Property

#End Region

#Region "WorkingSlip"

    Private Sub txtWorkSlip_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles WorkSlipTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            'clear object reference
            m_WorkSlip = Nothing
            'uppercase charactors
            WorkSlipTextBox.Text = WorkSlipTextBox.Text.ToUpper()

            Dim isSupportFormat As Boolean = True

            Select Case WorkSlipTextBox.Text.Length
                Case 252 'normal working slip
                    m_WorkSlip = New WorkingSlip()
                    m_WorkSlip.FullCode = WorkSlipTextBox.Text
                Case 10 'cut card
                    Try
                        m_WorkSlip = GetWorkingSlipFromDbByCutCard(WorkSlipTextBox.Text)

                        If m_WorkSlip IsNot Nothing Then
                            WorkSlipPictureBox.Image = SelfCon.My.Resources.input_successed
                        Else
                            'error not found
                            WorkSlipPictureBox.Image = SelfCon.My.Resources.Resources.couldnotfindwsfromdb
                            Exit Sub
                        End If

                    Catch ex As Exception
                        'can not get working slip data from database
                        WorkSlipPictureBox.Image = SelfCon.My.Resources.Resources.errorwhilegettingdata
                        Exit Sub
                    End Try

                Case Else 'unsupport format
                    WorkSlipPictureBox.Image = SelfCon.My.Resources.unknowformat
                    isSupportFormat = False
            End Select

            If isSupportFormat Then
                If m_OIS IsNot Nothing Then
                    If WsAndOisAreMatch() Then
                        WorkSlipPictureBox.Image = SelfCon.My.Resources.input_successed
                        InputQuantityTextBox.Focus()
                    Else
                        m_WorkSlip = Nothing
                        WorkSlipPictureBox.Image = SelfCon.My.Resources.input_error_messages5
                    End If
                Else
                    WorkSlipPictureBox.Image = SelfCon.My.Resources.input_successed
                    OisTextBox.Focus()
                End If 'If m_OIS IsNot Nothing Then
            End If 'If isSupportFormat Then
        End If
    End Sub

    Private Sub btnWorkingSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWorkingSlip.Click
        m_WorkSlip = Nothing
        WorkSlipTextBox.Text = ""
        WorkSlipPictureBox.Image = SelfCon.My.Resources.input_blank
        WorkSlipTextBox.Focus()
    End Sub

    Private Function GetWorkingSlipFromDbByCutCard(ByVal lotNo As String) As WorkingSlip
        Dim ws As WorkingSlip = Nothing
        Using adaptor As DBxDataSetTableAdapters.TransactionDataTableAdapter = New DBxDataSetTableAdapters.TransactionDataTableAdapter()
            Using table As DBxDataSet.TransactionDataDataTable = adaptor.GetDataByLotNo(lotNo)
                If table.Rows.Count = 1 Then
                    ws = New WorkingSlip()
                    ws.FullCode = lotNo
                    Dim r As DBxDataSet.TransactionDataRow = CType(table.Rows(0), DBxDataSet.TransactionDataRow)
                    If Not r.IsCleamCounterMeasureNull() Then
                        ws.CleamCounterMeasure = r.CleamCounterMeasure
                    End If
                    If Not r.IsCodeNoNull() Then
                        ws.CodeNo = r.CodeNo
                    End If
                    If Not r.IsDeviceNull() Then
                        ws.DeviceName = r.Device
                    End If
                    If Not r.IsETC1Null() Then
                        ws.ForIndication1 = r.ETC1
                    End If
                    If Not r.IsETC2Null() Then
                        ws.ForIndication2 = r.ETC2
                    End If
                    If Not r.IsFASetDirectionNull() Then
                        ws.FarSetDirection = r.FASetDirection
                    End If
                    If Not r.IsFrameNoNull() Then
                        ws.FrameType = r.FrameNo
                    End If
                    If Not r.IsFTFormNull() Then
                        ws.FTDevice = r.FTForm
                    End If
                    ws.LotNo = r.LotNo 'PK
                    If Not r.IsMarkNoNull() Then
                        ws.MarkNo = r.MarkNo
                    End If
                    If Not r.IsMarkTextLine1Null() Then
                        ws.MarkingSpec3 = r.MarkTextLine1
                    End If
                    If Not r.IsMarkTextLine2Null() Then
                        ws.MarkingSpec2 = r.MarkTextLine2
                    End If
                    If Not r.IsMarkTextLine3Null() Then
                        ws.MarkingSpec1 = r.MarkTextLine3
                    End If
                    If Not r.IsMarkTypeNull() Then
                        ws.MarkType = r.MarkType
                    End If
                    If Not r.IsMaskNull() Then
                        ws.Mask = r.Mask
                    End If
                    If Not r.IsMoldTypeNull() Then
                        ws.MoldType = r.MoldType
                    End If
                    If Not r.IsNewFormNameNull() Then
                        ws.NewPackageName = r.NewFormName
                    End If
                    If Not r.IsNumberOfStampStepNull() Then
                        ws.MarkingStep = r.NumberOfStampStep
                    End If
                    If Not r.IsOSFTNull() Then
                        ws.OSFTChange = r.OSFT
                    End If
                    If Not r.IsOSProgramNull() Then
                        ws.OSProgram = r.OSProgram
                    End If
                    If Not r.IsPackageNull() Then
                        ws.PackageName = r.Package
                    End If
                    If Not r.IsPDFreeNull() Then
                        ws.PDFree = r.PDFree
                    End If
                    If Not r.IsReelCountNull() Then
                        ws.ReelCount = r.ReelCount
                    End If
                    If Not r.IsSubRankNull() Then
                        ws.SubRank = r.SubRank
                    End If
                    If Not r.IsTapingDirectionNull() Then
                        ws.TapingDirection = r.TapingDirection
                    End If
                    If Not r.IsULMarkNull() Then
                        ws.ULMark = r.ULMark
                    End If
                    If Not r.IsWaferLotNoNull() Then
                        ws.WaferLotNo = r.WaferLotNo
                    End If
                End If
            End Using
        End Using

        Return ws
    End Function

#End Region

#Region "TestCondition"

    Private Sub txtTestCondition_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OisTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            'upper case
            OisTextBox.Text = OisTextBox.Text.ToUpper()
            'check device match with working slip
            Dim args() As String = OisTextBox.Text.Split(","c)
            If args.GetUpperBound(0) = 7 Then
                m_OIS = New OIS()
                m_OIS.FullCode = OisTextBox.Text
            Else
                OisPictureBox.Image = SelfCon.My.Resources.unknowformat
            End If

            If m_WorkSlip IsNot Nothing AndAlso Not WsAndOisAreMatch() Then
                m_OIS = Nothing
                OisPictureBox.Image = SelfCon.My.Resources.input_error_messages5
            Else
                OisPictureBox.Image = SelfCon.My.Resources.input_successed
                InputQuantityTextBox.Focus()
            End If

        End If
    End Sub

    Private Function WsAndOisAreMatch() As Boolean
        Dim ret As Boolean = False

        'plase use this INSTEAD OF the below code
        'If m_OIS.Header = "FQI" Then
        If m_OIS.Header = "FQI" OrElse m_WorkSlip.FTDevice = m_OIS.DeviceName Then
            ret = True
        Else
            Dim ranks As String() = OIS.InputRank.Split(New String() {"/"}, StringSplitOptions.RemoveEmptyEntries)
            Dim rankToCompare As String

            For Each r As String In ranks
                rankToCompare = r
                If rankToCompare = "-" Then
                    If m_WorkSlip.FTDevice = m_OIS.DeviceName Then
                        ret = True
                        Exit For
                    End If
                Else
                    rankToCompare = rankToCompare.Replace("-", "")
                    If m_WorkSlip.FTDevice = m_OIS.DeviceName & "-" & rankToCompare Then
                        ret = True
                        Exit For
                    End If
                End If

            Next
        End If
        Return ret
    End Function

    Private Sub btnTestCondition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestCondition.Click
        OisTextBox.Text = ""
        m_OIS = Nothing
        OisPictureBox.Image = SelfCon.My.Resources.input_blank
        OisTextBox.Focus()
    End Sub
#End Region

#Region "InputQuantity"

    Private Sub txtInputQuantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles InputQuantityTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            m_InputQty = 0
            If Not String.IsNullOrEmpty(InputQuantityTextBox.Text) AndAlso IsNumeric(InputQuantityTextBox.Text) Then
                m_InputQty = CInt(InputQuantityTextBox.Text)
                InputQuantityPictureBox.Image = SelfCon.My.Resources.input_successed
                OPNoTextBox.Focus()
            Else
                InputQuantityPictureBox.Image = SelfCon.My.Resources.NumericOnly
            End If
        End If
    End Sub

    Private Sub btnInputQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInputQuantity.Click
        If InputQuantityTextBox.Focus Then
            InputQuantityTextBox.Text = ""
            InputQuantityPictureBox.Image = SelfCon.My.Resources.input_blank
        End If
    End Sub

#End Region

#Region "OperatorNo"

    Private Sub btnOperatorNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOperatorNo.Click
        If OPNoTextBox.Focus Then
            OPNoTextBox.Text = Nothing
            OPNoPictureBox.Image = SelfCon.My.Resources.input_blank
        End If
    End Sub

    Private Sub txtOperatorNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OPNoTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            m_OPNo = Nothing
            If OPNoTextBox.Text.Length >= 6 OrElse OPNoTextBox.Text.Length <= 8 Then
                m_OPNo = OPNoTextBox.Text.ToUpper()
                OPNoPictureBox.Image = My.Resources.input_successed
                'auto click "OK"
                btnOk_Click(Nothing, Nothing)
            End If
        End If
    End Sub

#End Region


    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        btnOk.Enabled = False
        If Not String.IsNullOrEmpty(m_OPNo) AndAlso _
           m_InputQty > 0 AndAlso _
           m_OIS IsNot Nothing AndAlso _
           m_WorkSlip IsNot Nothing Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        btnOk.Enabled = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub LotInputDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        InputQuantityTextBox.Text = Nothing
        OPNoTextBox.Text = Nothing
        WorkSlipTextBox.Text = Nothing
        OisTextBox.Text = Nothing
        WorkSlipPictureBox.Image = My.Resources.input_blank
        OisPictureBox.Image = My.Resources.input_blank
        InputQuantityPictureBox.Image = My.Resources.input_blank
        OPNoPictureBox.Image = My.Resources.input_blank
        m_WorkSlip = Nothing
        m_OIS = Nothing
        m_OPNo = Nothing
        m_InputQty = 0
        WorkSlipTextBox.Focus()
    End Sub

End Class
