Public Class SetupResultForm

    Private Shared m_Instance As SetupResultForm

    Public Shared Function GetInstance() As SetupResultForm
        If m_Instance Is Nothing OrElse m_Instance.IsDisposed Then
            m_Instance = New SetupResultForm()
        End If
        Return m_Instance
    End Function


    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub SetupResultForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MockupErrorMessage()
    End Sub

    Public Sub AppendDetailMessage(ByVal icon As SetupResultIconType, ByVal action As String, ByVal message As String)

        Dim status As String = "Stopped"
        Dim img As Bitmap = My.Resources.stop_16
        Dim col_4_color As Color = Color.Black
        col_4_color = Color.Black
        Select Case icon
            Case SetupResultIconType.Success
                img = My.Resources.accept_16
                status = "Success"
                'Case SetupResultIconType.Stopped
                '    img = My.Resources.stop_16
                '    status = "Stopped"
            Case SetupResultIconType.Warning
                img = My.Resources.warn_16
                status = "Warning"
            Case SetupResultIconType.Errored
                img = My.Resources.error_16
                col_4_color = Color.Red
                status = "Failed"
        End Select

        Dim rIndex As Integer = DataGridView1.Rows.Add(img, action, status, message)
        DataGridView1.Rows(rIndex).Cells(3).Style.ForeColor = col_4_color
    End Sub

    Public Sub UpdateDetailMessage(ByVal index As Integer, ByVal icon As SetupResultIconType, ByVal message As String)

        Dim row As DataGridViewRow = DataGridView1.Rows(index)

        Dim status As String = "Stopped"
        Dim img As Bitmap = My.Resources.stop_16
        Dim col_4_color As Color = Color.Black
        col_4_color = Color.Black
        Select Case icon
            Case SetupResultIconType.Success
                img = My.Resources.accept_16
                status = "Success"
                'Case SetupResultIconType.Stopped
                '    img = My.Resources.stop_16
                '    status = "Stopped"
            Case SetupResultIconType.Warning
                img = My.Resources.warn_16
                status = "Warning"
            Case SetupResultIconType.Errored
                img = My.Resources.error_16
                col_4_color = Color.Red
                status = "Failed"
        End Select

        row.Cells(0).Value = img
        row.Cells(2).Value = status
        row.Cells(3).Value = message
        row.Cells(3).Style.ForeColor = col_4_color
    End Sub

    Public Sub SetOverallResult(ByVal message As String, ByVal c As Color)
        OverAllResultLabel.Text = message
        OverAllResultLabel.ForeColor = c
    End Sub

    'Private Sub MockupErrorMessage()
    '    OverAllResultLabel.Text = "การ Setup ไม่ผ่าน"
    '    Dim rIndex As Integer
    '    rIndex = DataGridView1.Rows.Add(My.Resources.accept_16, " 1.) ค้นหา FTSetupRecord ของเครื่อง", "Success", "พบ 1 Record")
    '    rIndex = DataGridView1.Rows.Add(My.Resources.accept_16, " 2.) ตรวจสอบสถานะของ FTSetupRecord", "Success", "CONFIRMED")
    '    rIndex = DataGridView1.Rows.Add(My.Resources.accept_16, " 3.) ค้นหา BOM โดยอ้างอิงจาก FTSetupReport", "Success", "พบ 1 Record")
    '    rIndex = DataGridView1.Rows.Add(My.Resources.accept_16, " 4.) ค้นหา BOM โดยอ้างอิงจาก W/S และ OIS", "Success", "พบ 1 Record")
    '    rIndex = DataGridView1.Rows.Add(My.Resources.accept_16, " 5.) ตรวจสอบความเหมือนของอุปกรณ์  3.) กับ 4.)", "Success", "เหมือนกัน")
    '    rIndex = DataGridView1.Rows.Add(My.Resources.accept_16, " 6.) ตรวจสอบสถานะของ Lot ที่ค้างเครื่องอยู่", "Success", "ไม่มี")
    '    rIndex = DataGridView1.Rows.Add(My.Resources.stop_16, " 7.) ตรวจสอบสถานะ WorkRecord ของ Lot ที่ค้างเครื่องอยู่", "Stopped", "ข้าม")
    '    rIndex = DataGridView1.Rows.Add(My.Resources.stop_16, " 8.) ตรวจสอบสถานะ WorkRecord ของ Lot ที่ค้างเครื่องอยู่", "Stopped", "ข้าม")
    '    rIndex = DataGridView1.Rows.Add(My.Resources.warn_16, " 9.) ตรวจสอบ Flow การผลิตกับ TDC", "Success", "ปล่อยผ่าน > 01:Not Found")
    '    rIndex = DataGridView1.Rows.Add(My.Resources.accept_16, "10.) ค้นหาค่า Fixed LCL", "Success", "ไม่พบ")
    '    rIndex = DataGridView1.Rows.Add(My.Resources.accept_16, "11.) ค้นหาค่า LCL_MASTER", "Success", "99.2")
    '    rIndex = DataGridView1.Rows.Add(My.Resources.accept_16, "12.) ค้นหาค่า RPM จาก BOM", "Success", "57.5")
    '    rIndex = DataGridView1.Rows.Add(My.Resources.error_16, "13.) ใช้ค่า RPM Setting", "Skip", "")
    '    DataGridView1.Rows(rIndex).Cells(3).Style.ForeColor = Color.Red
    'End Sub

End Class