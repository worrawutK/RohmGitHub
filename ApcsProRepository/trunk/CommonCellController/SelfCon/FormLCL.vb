Public Class FormLCL

    Private m_ROHMMODELNAME As String
    Public Property ROHMMODELNAME() As String
        Get
            Return m_ROHMMODELNAME
        End Get
        Set(ByVal value As String)
            m_ROHMMODELNAME = value
            lblModelName.Text = value
        End Set
    End Property

    Private m_FLOWNO As String
    Public Property FLOWNO() As String
        Get
            Return m_FLOWNO
        End Get
        Set(ByVal value As String)
            m_FLOWNO = value
            lblFlowNo.Text = value
        End Set
    End Property

    Private m_LCL As Single
    Public Property LCL() As Single
        Get
            Return m_LCL
        End Get
        Set(ByVal value As Single)
            m_LCL = value
        End Set
    End Property

    Private Sub FormLCL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lcl As Double? = Nothing
        Try
            lcl = LclmasterTableAdapter1.GetLCL(m_ROHMMODELNAME, m_FLOWNO)
        Catch ex As Exception
            lblLCLControl.Text = ex.Message
            lblLCLControl.ForeColor = Color.Red
        End Try

        If lcl.HasValue Then
            lblLCLControl.Text = lcl.Value.ToString()
            lblLCLControl.ForeColor = Color.Green
            m_LCL = CSng(lcl.Value)
        Else
            lblLCLControl.Text = "ไม่พบ LCL"
            lblLCLControl.ForeColor = Color.Red
            m_LCL = 0
        End If

        btnClose.Enabled = False
        btnOK.Visible = True
        Timer1.Interval = 1500
        Timer1.Start()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class