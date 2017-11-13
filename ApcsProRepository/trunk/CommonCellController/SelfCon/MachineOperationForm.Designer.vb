<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MachineOperationForm
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
        Me.StartButton = New System.Windows.Forms.Button
        Me.EndButton = New System.Windows.Forms.Button
        Me.SetProductQtyButton = New System.Windows.Forms.Button
        Me.CloseButton = New System.Windows.Forms.Button
        Me.RetestEndButton = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.InputRetestFLFTButton = New System.Windows.Forms.Button
        Me.ChangeStateButton = New System.Windows.Forms.Button
        Me.PlanStopButton = New System.Windows.Forms.Button
        Me.AutoLoadButton = New System.Windows.Forms.Button
        Me.SettingButton = New System.Windows.Forms.Button
        Me.ResetButton = New System.Windows.Forms.Button
        Me.InputButton = New System.Windows.Forms.Button
        Me.AndonRequestButton = New System.Windows.Forms.Button
        Me.SetupEquipmentButton = New System.Windows.Forms.Button
        Me.PMRepaireButton = New System.Windows.Forms.Button
        Me.BMRequestButton = New System.Windows.Forms.Button
        Me.WorkRecordButton = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.MachineNoLabel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.BackColor = System.Drawing.Color.Gainsboro
        Me.StartButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.StartButton.ForeColor = System.Drawing.Color.DarkRed
        Me.StartButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.StartButton.Location = New System.Drawing.Point(353, 438)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(201, 57)
        Me.StartButton.TabIndex = 7
        Me.StartButton.Text = "START"
        Me.StartButton.UseVisualStyleBackColor = False
        '
        'EndButton
        '
        Me.EndButton.BackColor = System.Drawing.Color.Gainsboro
        Me.EndButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.EndButton.ForeColor = System.Drawing.Color.DarkRed
        Me.EndButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EndButton.Location = New System.Drawing.Point(597, 584)
        Me.EndButton.Name = "EndButton"
        Me.EndButton.Size = New System.Drawing.Size(201, 57)
        Me.EndButton.TabIndex = 7
        Me.EndButton.Text = "LOT END"
        Me.EndButton.UseVisualStyleBackColor = False
        '
        'SetProductQtyButton
        '
        Me.SetProductQtyButton.BackColor = System.Drawing.Color.Gainsboro
        Me.SetProductQtyButton.Enabled = False
        Me.SetProductQtyButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.SetProductQtyButton.ForeColor = System.Drawing.Color.DarkRed
        Me.SetProductQtyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SetProductQtyButton.Location = New System.Drawing.Point(597, 438)
        Me.SetProductQtyButton.Name = "SetProductQtyButton"
        Me.SetProductQtyButton.Size = New System.Drawing.Size(201, 57)
        Me.SetProductQtyButton.TabIndex = 7
        Me.SetProductQtyButton.Text = "SET PRODUCT QTY"
        Me.SetProductQtyButton.UseVisualStyleBackColor = False
        '
        'CloseButton
        '
        Me.CloseButton.BackColor = System.Drawing.Color.Silver
        Me.CloseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CloseButton.Location = New System.Drawing.Point(1083, 111)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(113, 57)
        Me.CloseButton.TabIndex = 65
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = False
        '
        'RetestEndButton
        '
        Me.RetestEndButton.BackColor = System.Drawing.Color.Gainsboro
        Me.RetestEndButton.Enabled = False
        Me.RetestEndButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RetestEndButton.ForeColor = System.Drawing.Color.DarkRed
        Me.RetestEndButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RetestEndButton.Location = New System.Drawing.Point(597, 510)
        Me.RetestEndButton.Name = "RetestEndButton"
        Me.RetestEndButton.Size = New System.Drawing.Size(201, 57)
        Me.RetestEndButton.TabIndex = 7
        Me.RetestEndButton.Text = "LOT RETEST END"
        Me.RetestEndButton.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.DarkGray
        Me.GroupBox1.Controls.Add(Me.InputRetestFLFTButton)
        Me.GroupBox1.Controls.Add(Me.ChangeStateButton)
        Me.GroupBox1.Controls.Add(Me.PlanStopButton)
        Me.GroupBox1.Controls.Add(Me.AutoLoadButton)
        Me.GroupBox1.Controls.Add(Me.SettingButton)
        Me.GroupBox1.Controls.Add(Me.ResetButton)
        Me.GroupBox1.Controls.Add(Me.InputButton)
        Me.GroupBox1.Controls.Add(Me.AndonRequestButton)
        Me.GroupBox1.Controls.Add(Me.SetupEquipmentButton)
        Me.GroupBox1.Controls.Add(Me.PMRepaireButton)
        Me.GroupBox1.Controls.Add(Me.BMRequestButton)
        Me.GroupBox1.Controls.Add(Me.StartButton)
        Me.GroupBox1.Controls.Add(Me.SetProductQtyButton)
        Me.GroupBox1.Controls.Add(Me.RetestEndButton)
        Me.GroupBox1.Controls.Add(Me.WorkRecordButton)
        Me.GroupBox1.Controls.Add(Me.EndButton)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(61, 224)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1141, 704)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Operation"
        '
        'InputRetestFLFTButton
        '
        Me.InputRetestFLFTButton.BackColor = System.Drawing.Color.Gainsboro
        Me.InputRetestFLFTButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.InputRetestFLFTButton.ForeColor = System.Drawing.Color.DarkOrange
        Me.InputRetestFLFTButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.InputRetestFLFTButton.Location = New System.Drawing.Point(100, 290)
        Me.InputRetestFLFTButton.Name = "InputRetestFLFTButton"
        Me.InputRetestFLFTButton.Size = New System.Drawing.Size(201, 57)
        Me.InputRetestFLFTButton.TabIndex = 9
        Me.InputRetestFLFTButton.Text = "INPUT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(FL-FT RETEST)"
        Me.InputRetestFLFTButton.UseVisualStyleBackColor = False
        '
        'ChangeStateButton
        '
        Me.ChangeStateButton.BackColor = System.Drawing.Color.Gainsboro
        Me.ChangeStateButton.Enabled = False
        Me.ChangeStateButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ChangeStateButton.ForeColor = System.Drawing.Color.DarkRed
        Me.ChangeStateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ChangeStateButton.Location = New System.Drawing.Point(100, 584)
        Me.ChangeStateButton.Name = "ChangeStateButton"
        Me.ChangeStateButton.Size = New System.Drawing.Size(201, 57)
        Me.ChangeStateButton.TabIndex = 8
        Me.ChangeStateButton.Text = "CHANGE STATE"
        Me.ChangeStateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ChangeStateButton.UseVisualStyleBackColor = False
        '
        'PlanStopButton
        '
        Me.PlanStopButton.BackColor = System.Drawing.Color.Gainsboro
        Me.PlanStopButton.Enabled = False
        Me.PlanStopButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.PlanStopButton.ForeColor = System.Drawing.Color.DarkRed
        Me.PlanStopButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PlanStopButton.Location = New System.Drawing.Point(100, 510)
        Me.PlanStopButton.Name = "PlanStopButton"
        Me.PlanStopButton.Size = New System.Drawing.Size(201, 57)
        Me.PlanStopButton.TabIndex = 8
        Me.PlanStopButton.Text = "PLAN STOP"
        Me.PlanStopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.PlanStopButton.UseVisualStyleBackColor = False
        '
        'AutoLoadButton
        '
        Me.AutoLoadButton.BackColor = System.Drawing.Color.Gainsboro
        Me.AutoLoadButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.AutoLoadButton.ForeColor = System.Drawing.Color.DarkRed
        Me.AutoLoadButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AutoLoadButton.Location = New System.Drawing.Point(353, 364)
        Me.AutoLoadButton.Name = "AutoLoadButton"
        Me.AutoLoadButton.Size = New System.Drawing.Size(201, 57)
        Me.AutoLoadButton.TabIndex = 7
        Me.AutoLoadButton.Text = "AUTO LOAD"
        Me.AutoLoadButton.UseVisualStyleBackColor = False
        '
        'SettingButton
        '
        Me.SettingButton.BackColor = System.Drawing.Color.Gainsboro
        Me.SettingButton.Enabled = False
        Me.SettingButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.SettingButton.ForeColor = System.Drawing.Color.DarkRed
        Me.SettingButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SettingButton.Location = New System.Drawing.Point(100, 216)
        Me.SettingButton.Name = "SettingButton"
        Me.SettingButton.Size = New System.Drawing.Size(201, 57)
        Me.SettingButton.TabIndex = 7
        Me.SettingButton.Text = "SETTING PARAMETERS"
        Me.SettingButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.SettingButton.UseVisualStyleBackColor = False
        '
        'ResetButton
        '
        Me.ResetButton.BackColor = System.Drawing.Color.Gainsboro
        Me.ResetButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ResetButton.ForeColor = System.Drawing.Color.DarkRed
        Me.ResetButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ResetButton.Location = New System.Drawing.Point(100, 142)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(201, 57)
        Me.ResetButton.TabIndex = 7
        Me.ResetButton.Text = "RESET"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'InputButton
        '
        Me.InputButton.BackColor = System.Drawing.Color.Gainsboro
        Me.InputButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.InputButton.ForeColor = System.Drawing.Color.DarkRed
        Me.InputButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.InputButton.Location = New System.Drawing.Point(100, 68)
        Me.InputButton.Name = "InputButton"
        Me.InputButton.Size = New System.Drawing.Size(201, 57)
        Me.InputButton.TabIndex = 7
        Me.InputButton.Text = "INPUT"
        Me.InputButton.UseVisualStyleBackColor = False
        '
        'AndonRequestButton
        '
        Me.AndonRequestButton.BackColor = System.Drawing.Color.Gainsboro
        Me.AndonRequestButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.AndonRequestButton.ForeColor = System.Drawing.Color.DarkRed
        Me.AndonRequestButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AndonRequestButton.Location = New System.Drawing.Point(353, 68)
        Me.AndonRequestButton.Name = "AndonRequestButton"
        Me.AndonRequestButton.Size = New System.Drawing.Size(201, 57)
        Me.AndonRequestButton.TabIndex = 7
        Me.AndonRequestButton.Text = "ANDON" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "REQUEST"
        Me.AndonRequestButton.UseVisualStyleBackColor = False
        '
        'SetupEquipmentButton
        '
        Me.SetupEquipmentButton.BackColor = System.Drawing.Color.Gainsboro
        Me.SetupEquipmentButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.SetupEquipmentButton.ForeColor = System.Drawing.Color.DarkRed
        Me.SetupEquipmentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SetupEquipmentButton.Location = New System.Drawing.Point(353, 290)
        Me.SetupEquipmentButton.Name = "SetupEquipmentButton"
        Me.SetupEquipmentButton.Size = New System.Drawing.Size(201, 57)
        Me.SetupEquipmentButton.TabIndex = 7
        Me.SetupEquipmentButton.Text = "SET UP EQUIPMENT"
        Me.SetupEquipmentButton.UseVisualStyleBackColor = False
        '
        'PMRepaireButton
        '
        Me.PMRepaireButton.BackColor = System.Drawing.Color.Gainsboro
        Me.PMRepaireButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.PMRepaireButton.ForeColor = System.Drawing.Color.DarkRed
        Me.PMRepaireButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PMRepaireButton.Location = New System.Drawing.Point(353, 216)
        Me.PMRepaireButton.Name = "PMRepaireButton"
        Me.PMRepaireButton.Size = New System.Drawing.Size(201, 57)
        Me.PMRepaireButton.TabIndex = 7
        Me.PMRepaireButton.Text = "PM" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "REPAIRE"
        Me.PMRepaireButton.UseVisualStyleBackColor = False
        '
        'BMRequestButton
        '
        Me.BMRequestButton.BackColor = System.Drawing.Color.Gainsboro
        Me.BMRequestButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BMRequestButton.ForeColor = System.Drawing.Color.DarkRed
        Me.BMRequestButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BMRequestButton.Location = New System.Drawing.Point(353, 142)
        Me.BMRequestButton.Name = "BMRequestButton"
        Me.BMRequestButton.Size = New System.Drawing.Size(201, 57)
        Me.BMRequestButton.TabIndex = 7
        Me.BMRequestButton.Text = "BM" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "REQUEST"
        Me.BMRequestButton.UseVisualStyleBackColor = False
        '
        'WorkRecordButton
        '
        Me.WorkRecordButton.BackColor = System.Drawing.Color.Gainsboro
        Me.WorkRecordButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.WorkRecordButton.ForeColor = System.Drawing.Color.DarkRed
        Me.WorkRecordButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.WorkRecordButton.Location = New System.Drawing.Point(840, 584)
        Me.WorkRecordButton.Name = "WorkRecordButton"
        Me.WorkRecordButton.Size = New System.Drawing.Size(201, 57)
        Me.WorkRecordButton.TabIndex = 7
        Me.WorkRecordButton.Text = "WORK RECORD"
        Me.WorkRecordButton.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(1280, 82)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "      MACHINE OPERATION FORM"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MachineNoLabel
        '
        Me.MachineNoLabel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.MachineNoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MachineNoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.MachineNoLabel.ForeColor = System.Drawing.Color.Red
        Me.MachineNoLabel.Location = New System.Drawing.Point(61, 106)
        Me.MachineNoLabel.Name = "MachineNoLabel"
        Me.MachineNoLabel.Size = New System.Drawing.Size(169, 60)
        Me.MachineNoLabel.TabIndex = 69
        Me.MachineNoLabel.Text = "ITHA-001"
        Me.MachineNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(61, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MachineOperationForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.ControlBox = False
        Me.Controls.Add(Me.MachineNoLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.Label11)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximumSize = New System.Drawing.Size(1280, 1024)
        Me.MinimumSize = New System.Drawing.Size(1278, 992)
        Me.Name = "MachineOperationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ManualOperationForm"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents EndButton As System.Windows.Forms.Button
    Friend WithEvents SetProductQtyButton As System.Windows.Forms.Button
    Private WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents RetestEndButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents InputButton As System.Windows.Forms.Button
    Friend WithEvents AutoLoadButton As System.Windows.Forms.Button
    Friend WithEvents AndonRequestButton As System.Windows.Forms.Button
    Friend WithEvents BMRequestButton As System.Windows.Forms.Button
    Friend WithEvents SetupEquipmentButton As System.Windows.Forms.Button
    Friend WithEvents ResetButton As System.Windows.Forms.Button
    Friend WithEvents SettingButton As System.Windows.Forms.Button
    Friend WithEvents PMRepaireButton As System.Windows.Forms.Button
    Friend WithEvents WorkRecordButton As System.Windows.Forms.Button
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents MachineNoLabel As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PlanStopButton As System.Windows.Forms.Button
    Friend WithEvents ChangeStateButton As System.Windows.Forms.Button
    Friend WithEvents InputRetestFLFTButton As System.Windows.Forms.Button
End Class
