<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FTMachine
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Me.TowerLightBlinkTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RedLampLabel = New System.Windows.Forms.Label
        Me.YellowLampLabel = New System.Windows.Forms.Label
        Me.GreenLampLabel = New System.Windows.Forms.Label
        Me.CountUpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PlanStopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TowerLightBlinkTimer
        '
        Me.TowerLightBlinkTimer.Interval = 1000
        '
        'RedLampLabel
        '
        Me.RedLampLabel.BackColor = System.Drawing.Color.Red
        Me.RedLampLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RedLampLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RedLampLabel.Location = New System.Drawing.Point(70, 5)
        Me.RedLampLabel.Name = "RedLampLabel"
        Me.RedLampLabel.Size = New System.Drawing.Size(5, 5)
        Me.RedLampLabel.TabIndex = 6
        '
        'YellowLampLabel
        '
        Me.YellowLampLabel.BackColor = System.Drawing.Color.Yellow
        Me.YellowLampLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.YellowLampLabel.Location = New System.Drawing.Point(70, 11)
        Me.YellowLampLabel.Name = "YellowLampLabel"
        Me.YellowLampLabel.Size = New System.Drawing.Size(5, 5)
        Me.YellowLampLabel.TabIndex = 7
        '
        'GreenLampLabel
        '
        Me.GreenLampLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GreenLampLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GreenLampLabel.Location = New System.Drawing.Point(70, 17)
        Me.GreenLampLabel.Name = "GreenLampLabel"
        Me.GreenLampLabel.Size = New System.Drawing.Size(5, 5)
        Me.GreenLampLabel.TabIndex = 8
        '
        'CountUpTimer
        '
        Me.CountUpTimer.Interval = 1000
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.ImageLocation = ""
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.MaximumSize = New System.Drawing.Size(80, 80)
        Me.PictureBox1.MinimumSize = New System.Drawing.Size(80, 80)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem, Me.PlanStopToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 70)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Image = Global.SelfCon.My.Resources.Resources.discon
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'PlanStopToolStripMenuItem
        '
        Me.PlanStopToolStripMenuItem.Name = "PlanStopToolStripMenuItem"
        Me.PlanStopToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PlanStopToolStripMenuItem.Text = "PlanStop"
        '
        'FTMachine
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.GreenLampLabel)
        Me.Controls.Add(Me.YellowLampLabel)
        Me.Controls.Add(Me.RedLampLabel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximumSize = New System.Drawing.Size(80, 80)
        Me.Name = "FTMachine"
        Me.Size = New System.Drawing.Size(80, 80)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TowerLightBlinkTimer As System.Windows.Forms.Timer
    Private WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents RedLampLabel As System.Windows.Forms.Label
    Private WithEvents YellowLampLabel As System.Windows.Forms.Label
    Private WithEvents GreenLampLabel As System.Windows.Forms.Label
    Friend WithEvents CountUpTimer As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlanStopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
