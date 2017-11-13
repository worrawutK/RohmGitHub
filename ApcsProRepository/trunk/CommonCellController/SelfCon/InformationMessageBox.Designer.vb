<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformationMessageBox
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
        Me.MessageLabel = New System.Windows.Forms.Label
        Me.DismissButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'MessageLabel
        '
        Me.MessageLabel.AutoSize = True
        Me.MessageLabel.Location = New System.Drawing.Point(41, 33)
        Me.MessageLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.MessageLabel.Name = "MessageLabel"
        Me.MessageLabel.Size = New System.Drawing.Size(105, 32)
        Me.MessageLabel.TabIndex = 0
        Me.MessageLabel.Text = "Label1"
        Me.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DismissButton
        '
        Me.DismissButton.BackColor = System.Drawing.SystemColors.Control
        Me.DismissButton.Location = New System.Drawing.Point(12, 112)
        Me.DismissButton.Name = "DismissButton"
        Me.DismissButton.Size = New System.Drawing.Size(158, 48)
        Me.DismissButton.TabIndex = 2
        Me.DismissButton.Text = "รับทราบ"
        Me.DismissButton.UseVisualStyleBackColor = False
        '
        'InformationMessageBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Moccasin
        Me.ClientSize = New System.Drawing.Size(189, 172)
        Me.ControlBox = False
        Me.Controls.Add(Me.DismissButton)
        Me.Controls.Add(Me.MessageLabel)
        Me.Font = New System.Drawing.Font("Consolas", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "InformationMessageBox"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MessageForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MessageLabel As System.Windows.Forms.Label
    Friend WithEvents DismissButton As System.Windows.Forms.Button
End Class
