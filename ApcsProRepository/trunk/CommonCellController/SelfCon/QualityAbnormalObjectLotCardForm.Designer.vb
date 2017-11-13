<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QualityAbnormalObjectLotCardForm
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.OKButton = New System.Windows.Forms.Button
        Me.QRCodeTextBox = New System.Windows.Forms.TextBox
        Me.btnQRCode = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(107, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(370, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Quality Abnormal Object Lot Card"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SelfCon.My.Resources.Resources.ROHM25
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 62)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 87
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(73, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 18)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Please Shoot QR-Code"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(76, 134)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(424, 23)
        Me.ProgressBar1.TabIndex = 89
        '
        'OKButton
        '
        Me.OKButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.OKButton.Location = New System.Drawing.Point(234, 179)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(151, 48)
        Me.OKButton.TabIndex = 2
        Me.OKButton.Text = "ยกเลิก"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'QRCodeTextBox
        '
        Me.QRCodeTextBox.Location = New System.Drawing.Point(503, 135)
        Me.QRCodeTextBox.Name = "QRCodeTextBox"
        Me.QRCodeTextBox.Size = New System.Drawing.Size(10, 20)
        Me.QRCodeTextBox.TabIndex = 0
        '
        'btnQRCode
        '
        Me.btnQRCode.Image = Global.SelfCon.My.Resources.Resources.smallQr
        Me.btnQRCode.Location = New System.Drawing.Point(519, 113)
        Me.btnQRCode.Name = "btnQRCode"
        Me.btnQRCode.Size = New System.Drawing.Size(65, 63)
        Me.btnQRCode.TabIndex = 1
        Me.btnQRCode.UseVisualStyleBackColor = False
        '
        'QualityAbnormalObjectLotCardForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 245)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnQRCode)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.QRCodeTextBox)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "QualityAbnormalObjectLotCardForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QualityAbnormalObjectLotCardForm"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents QRCodeTextBox As System.Windows.Forms.TextBox
    Private WithEvents btnQRCode As System.Windows.Forms.Button
End Class
