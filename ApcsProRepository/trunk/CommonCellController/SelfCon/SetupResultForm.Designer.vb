<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupResultForm
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.HeadColumn = New System.Windows.Forms.DataGridViewImageColumn
        Me.ActionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MessageColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CloseButton = New System.Windows.Forms.Button
        Me.OverAllResultLabel = New System.Windows.Forms.Label
        Me.HeadPictureBox = New System.Windows.Forms.PictureBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeadPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HeadColumn, Me.ActionColumn, Me.StatusColumn, Me.MessageColumn})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 139)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(777, 360)
        Me.DataGridView1.TabIndex = 0
        '
        'HeadColumn
        '
        Me.HeadColumn.HeaderText = ""
        Me.HeadColumn.Name = "HeadColumn"
        Me.HeadColumn.ReadOnly = True
        Me.HeadColumn.Width = 50
        '
        'ActionColumn
        '
        Me.ActionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ActionColumn.HeaderText = "Action"
        Me.ActionColumn.Name = "ActionColumn"
        Me.ActionColumn.ReadOnly = True
        '
        'StatusColumn
        '
        Me.StatusColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        Me.StatusColumn.Width = 62
        '
        'MessageColumn
        '
        Me.MessageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MessageColumn.HeaderText = "Message"
        Me.MessageColumn.Name = "MessageColumn"
        Me.MessageColumn.ReadOnly = True
        Me.MessageColumn.Width = 75
        '
        'CloseButton
        '
        Me.CloseButton.Location = New System.Drawing.Point(672, 505)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(117, 56)
        Me.CloseButton.TabIndex = 1
        Me.CloseButton.Text = "ปิด"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'OverAllResultLabel
        '
        Me.OverAllResultLabel.BackColor = System.Drawing.Color.White
        Me.OverAllResultLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.OverAllResultLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.OverAllResultLabel.ForeColor = System.Drawing.Color.Red
        Me.OverAllResultLabel.Location = New System.Drawing.Point(12, 70)
        Me.OverAllResultLabel.Name = "OverAllResultLabel"
        Me.OverAllResultLabel.Size = New System.Drawing.Size(776, 38)
        Me.OverAllResultLabel.TabIndex = 3
        Me.OverAllResultLabel.Text = "การ Setup มีข้อบกพร่อง"
        Me.OverAllResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HeadPictureBox
        '
        Me.HeadPictureBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeadPictureBox.Image = Global.SelfCon.My.Resources.Resources.setup_result_header
        Me.HeadPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.HeadPictureBox.Name = "HeadPictureBox"
        Me.HeadPictureBox.Size = New System.Drawing.Size(800, 50)
        Me.HeadPictureBox.TabIndex = 2
        Me.HeadPictureBox.TabStop = False
        '
        'SetupResultForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 573)
        Me.ControlBox = False
        Me.Controls.Add(Me.OverAllResultLabel)
        Me.Controls.Add(Me.HeadPictureBox)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "SetupResultForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SetupResultForm"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeadPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents HeadPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents HeadColumn As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ActionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MessageColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OverAllResultLabel As System.Windows.Forms.Label
End Class
