<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfirmationDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AskingMessageLabel = New System.Windows.Forms.Label
        Me.OKButton = New System.Windows.Forms.Button
        Me.CLButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.AskingMessageLabel.Location = New System.Drawing.Point(45, 29)
        Me.AskingMessageLabel.Name = "Label1"
        Me.AskingMessageLabel.Size = New System.Drawing.Size(475, 126)
        Me.AskingMessageLabel.TabIndex = 0
        Me.AskingMessageLabel.Text = "คุณต้องการปิดโปรแกรม ใช่ หรือ ไม่ ?"
        Me.AskingMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OKButton
        '
        Me.OKButton.BackColor = System.Drawing.SystemColors.Control
        Me.OKButton.Location = New System.Drawing.Point(122, 178)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(135, 48)
        Me.OKButton.TabIndex = 2
        Me.OKButton.Text = "ใช่"
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'CLButton
        '
        Me.CLButton.BackColor = System.Drawing.SystemColors.Control
        Me.CLButton.Location = New System.Drawing.Point(318, 178)
        Me.CLButton.Name = "CLButton"
        Me.CLButton.Size = New System.Drawing.Size(158, 48)
        Me.CLButton.TabIndex = 2
        Me.CLButton.Text = "ไม่ใช่"
        Me.CLButton.UseVisualStyleBackColor = False
        '
        'ConfirmationForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.PaleGreen
        Me.ClientSize = New System.Drawing.Size(575, 252)
        Me.ControlBox = False
        Me.Controls.Add(Me.CLButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.AskingMessageLabel)
        Me.Font = New System.Drawing.Font("Consolas", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ConfirmationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ConfirmCloseForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AskingMessageLabel As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents CLButton As System.Windows.Forms.Button
End Class
