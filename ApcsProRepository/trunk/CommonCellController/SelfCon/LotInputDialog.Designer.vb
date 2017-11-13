<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LotInputDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LotInputDialog))
        Me.WorkSlipTextBox = New System.Windows.Forms.TextBox
        Me.OPNoTextBox = New System.Windows.Forms.TextBox
        Me.OisTextBox = New System.Windows.Forms.TextBox
        Me.InputQuantityTextBox = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnOperatorNo = New System.Windows.Forms.Button
        Me.btnTestCondition = New System.Windows.Forms.Button
        Me.btnWorkingSlip = New System.Windows.Forms.Button
        Me.btnInputQuantity = New System.Windows.Forms.Button
        Me.WorkSlipPictureBox = New System.Windows.Forms.PictureBox
        Me.OisPictureBox = New System.Windows.Forms.PictureBox
        Me.OPNoPictureBox = New System.Windows.Forms.PictureBox
        Me.InputQuantityPictureBox = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.WorkSlipPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OisPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPNoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InputQuantityPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WorkSlipTextBox
        '
        Me.WorkSlipTextBox.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkSlipTextBox.Location = New System.Drawing.Point(66, 96)
        Me.WorkSlipTextBox.MaxLength = 500
        Me.WorkSlipTextBox.Name = "WorkSlipTextBox"
        Me.WorkSlipTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.WorkSlipTextBox.Size = New System.Drawing.Size(283, 30)
        Me.WorkSlipTextBox.TabIndex = 32
        '
        'OPNoTextBox
        '
        Me.OPNoTextBox.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPNoTextBox.Location = New System.Drawing.Point(64, 470)
        Me.OPNoTextBox.MaxLength = 6
        Me.OPNoTextBox.Name = "OPNoTextBox"
        Me.OPNoTextBox.Size = New System.Drawing.Size(283, 30)
        Me.OPNoTextBox.TabIndex = 38
        Me.OPNoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OisTextBox
        '
        Me.OisTextBox.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OisTextBox.Location = New System.Drawing.Point(66, 222)
        Me.OisTextBox.MaxLength = 200
        Me.OisTextBox.Name = "OisTextBox"
        Me.OisTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.OisTextBox.Size = New System.Drawing.Size(283, 30)
        Me.OisTextBox.TabIndex = 33
        '
        'InputQuantityTextBox
        '
        Me.InputQuantityTextBox.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputQuantityTextBox.Location = New System.Drawing.Point(66, 348)
        Me.InputQuantityTextBox.MaxLength = 8
        Me.InputQuantityTextBox.Name = "InputQuantityTextBox"
        Me.InputQuantityTextBox.Size = New System.Drawing.Size(283, 30)
        Me.InputQuantityTextBox.TabIndex = 34
        Me.InputQuantityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(393, 618)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 59)
        Me.btnCancel.TabIndex = 45
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(309, 618)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(78, 59)
        Me.btnOk.TabIndex = 44
        Me.btnOk.TabStop = False
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnOperatorNo
        '
        Me.btnOperatorNo.Image = Global.SelfCon.My.Resources.Resources.btn3
        Me.btnOperatorNo.Location = New System.Drawing.Point(365, 470)
        Me.btnOperatorNo.Name = "btnOperatorNo"
        Me.btnOperatorNo.Size = New System.Drawing.Size(70, 70)
        Me.btnOperatorNo.TabIndex = 43
        Me.btnOperatorNo.TabStop = False
        Me.btnOperatorNo.UseVisualStyleBackColor = True
        '
        'btnTestCondition
        '
        Me.btnTestCondition.Image = Global.SelfCon.My.Resources.Resources.btn3
        Me.btnTestCondition.Location = New System.Drawing.Point(365, 222)
        Me.btnTestCondition.Name = "btnTestCondition"
        Me.btnTestCondition.Size = New System.Drawing.Size(70, 70)
        Me.btnTestCondition.TabIndex = 41
        Me.btnTestCondition.TabStop = False
        Me.btnTestCondition.UseVisualStyleBackColor = True
        '
        'btnWorkingSlip
        '
        Me.btnWorkingSlip.Image = Global.SelfCon.My.Resources.Resources.btn3
        Me.btnWorkingSlip.Location = New System.Drawing.Point(365, 96)
        Me.btnWorkingSlip.Name = "btnWorkingSlip"
        Me.btnWorkingSlip.Size = New System.Drawing.Size(70, 70)
        Me.btnWorkingSlip.TabIndex = 40
        Me.btnWorkingSlip.TabStop = False
        Me.btnWorkingSlip.UseVisualStyleBackColor = True
        '
        'btnInputQuantity
        '
        Me.btnInputQuantity.Image = Global.SelfCon.My.Resources.Resources.btn3
        Me.btnInputQuantity.Location = New System.Drawing.Point(365, 348)
        Me.btnInputQuantity.Name = "btnInputQuantity"
        Me.btnInputQuantity.Size = New System.Drawing.Size(70, 70)
        Me.btnInputQuantity.TabIndex = 42
        Me.btnInputQuantity.TabStop = False
        Me.btnInputQuantity.UseVisualStyleBackColor = True
        '
        'WorkSlipPictureBox
        '
        Me.WorkSlipPictureBox.Image = Global.SelfCon.My.Resources.Resources.input_blank
        Me.WorkSlipPictureBox.Location = New System.Drawing.Point(66, 132)
        Me.WorkSlipPictureBox.Name = "WorkSlipPictureBox"
        Me.WorkSlipPictureBox.Size = New System.Drawing.Size(283, 28)
        Me.WorkSlipPictureBox.TabIndex = 36
        Me.WorkSlipPictureBox.TabStop = False
        '
        'OisPictureBox
        '
        Me.OisPictureBox.Image = Global.SelfCon.My.Resources.Resources.input_blank
        Me.OisPictureBox.Location = New System.Drawing.Point(66, 258)
        Me.OisPictureBox.Name = "OisPictureBox"
        Me.OisPictureBox.Size = New System.Drawing.Size(283, 28)
        Me.OisPictureBox.TabIndex = 35
        Me.OisPictureBox.TabStop = False
        '
        'OPNoPictureBox
        '
        Me.OPNoPictureBox.Image = CType(resources.GetObject("OPNoPictureBox.Image"), System.Drawing.Image)
        Me.OPNoPictureBox.Location = New System.Drawing.Point(64, 509)
        Me.OPNoPictureBox.Name = "OPNoPictureBox"
        Me.OPNoPictureBox.Size = New System.Drawing.Size(283, 28)
        Me.OPNoPictureBox.TabIndex = 37
        Me.OPNoPictureBox.TabStop = False
        '
        'InputQuantityPictureBox
        '
        Me.InputQuantityPictureBox.Image = CType(resources.GetObject("InputQuantityPictureBox.Image"), System.Drawing.Image)
        Me.InputQuantityPictureBox.Location = New System.Drawing.Point(64, 384)
        Me.InputQuantityPictureBox.Name = "InputQuantityPictureBox"
        Me.InputQuantityPictureBox.Size = New System.Drawing.Size(283, 28)
        Me.InputQuantityPictureBox.TabIndex = 39
        Me.InputQuantityPictureBox.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SelfCon.My.Resources.Resources.inputbg2
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(500, 700)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 50
        Me.PictureBox1.TabStop = False
        '
        'LotInputDialog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(492, 699)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnOperatorNo)
        Me.Controls.Add(Me.btnTestCondition)
        Me.Controls.Add(Me.btnWorkingSlip)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnInputQuantity)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.WorkSlipPictureBox)
        Me.Controls.Add(Me.OisPictureBox)
        Me.Controls.Add(Me.OPNoPictureBox)
        Me.Controls.Add(Me.InputQuantityPictureBox)
        Me.Controls.Add(Me.WorkSlipTextBox)
        Me.Controls.Add(Me.OPNoTextBox)
        Me.Controls.Add(Me.OisTextBox)
        Me.Controls.Add(Me.InputQuantityTextBox)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximumSize = New System.Drawing.Size(998, 726)
        Me.MinimumSize = New System.Drawing.Size(498, 726)
        Me.Name = "LotInputDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Input Dialog"
        CType(Me.WorkSlipPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OisPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPNoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InputQuantityPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOperatorNo As System.Windows.Forms.Button
    Friend WithEvents btnTestCondition As System.Windows.Forms.Button
    Friend WithEvents btnWorkingSlip As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnInputQuantity As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents WorkSlipPictureBox As System.Windows.Forms.PictureBox
    Private WithEvents OisPictureBox As System.Windows.Forms.PictureBox
    Private WithEvents OPNoPictureBox As System.Windows.Forms.PictureBox
    Private WithEvents InputQuantityPictureBox As System.Windows.Forms.PictureBox
    Private WithEvents WorkSlipTextBox As System.Windows.Forms.TextBox
    Private WithEvents OPNoTextBox As System.Windows.Forms.TextBox
    Private WithEvents OisTextBox As System.Windows.Forms.TextBox
    Private WithEvents InputQuantityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
