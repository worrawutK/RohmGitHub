<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OperatorNoInputDialog
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
        Me.OPNoTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CLButton = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'OPNoTextBox
        '
        Me.OPNoTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.OPNoTextBox.Location = New System.Drawing.Point(26, 56)
        Me.OPNoTextBox.Name = "OPNoTextBox"
        Me.OPNoTextBox.Size = New System.Drawing.Size(219, 38)
        Me.OPNoTextBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "กรุณาใส่รหัสพนักงาน"
        '
        'CLButton
        '
        Me.CLButton.BackColor = System.Drawing.Color.White
        Me.CLButton.Image = Global.SelfCon.My.Resources.Resources.close
        Me.CLButton.Location = New System.Drawing.Point(180, 106)
        Me.CLButton.Name = "CLButton"
        Me.CLButton.Size = New System.Drawing.Size(65, 65)
        Me.CLButton.TabIndex = 4
        Me.CLButton.UseVisualStyleBackColor = False
        '
        'OKButton
        '
        Me.OKButton.BackColor = System.Drawing.Color.White
        Me.OKButton.Image = Global.SelfCon.My.Resources.Resources.checked
        Me.OKButton.Location = New System.Drawing.Point(109, 106)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(65, 65)
        Me.OKButton.TabIndex = 5
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'OperatorNoInputDialog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Moccasin
        Me.ClientSize = New System.Drawing.Size(272, 183)
        Me.ControlBox = False
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.CLButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OPNoTextBox)
        Me.Name = "OperatorNoInputDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Input OP No"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OPNoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CLButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
End Class
