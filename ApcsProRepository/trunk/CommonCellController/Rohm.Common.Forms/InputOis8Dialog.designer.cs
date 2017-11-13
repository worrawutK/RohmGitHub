namespace Rohm.Common.Forms
{
    partial class InputOis8Dialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LabelCaption = new System.Windows.Forms.Label();
            this.TextBoxQrInput = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TimerTextMaquee = new System.Windows.Forms.Timer(this.components);
            this.GridOis8Data = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusAlarm = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.PictureCancel = new System.Windows.Forms.PictureBox();
            this.PictureBoxOK = new System.Windows.Forms.PictureBox();
            this.PictureBoxQrCode = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridOis8Data)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxQrCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelCaption
            // 
            this.LabelCaption.BackColor = System.Drawing.Color.NavajoWhite;
            this.LabelCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelCaption.Font = new System.Drawing.Font("Calibri", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCaption.Location = new System.Drawing.Point(0, 0);
            this.LabelCaption.Name = "LabelCaption";
            this.LabelCaption.Size = new System.Drawing.Size(649, 78);
            this.LabelCaption.TabIndex = 35;
            this.LabelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBoxQrInput
            // 
            this.TextBoxQrInput.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxQrInput.Location = new System.Drawing.Point(175, 95);
            this.TextBoxQrInput.Name = "TextBoxQrInput";
            this.TextBoxQrInput.Size = new System.Drawing.Size(208, 27);
            this.TextBoxQrInput.TabIndex = 27;
            this.TextBoxQrInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQrInput_KeyPress);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(78, 95);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(93, 21);
            this.Label1.TabIndex = 30;
            this.Label1.Text = "Scan Code";
            // 
            // TimerTextMaquee
            // 
            this.TimerTextMaquee.Enabled = true;
            this.TimerTextMaquee.Interval = 300;
            this.TimerTextMaquee.Tick += new System.EventHandler(this.TimerTextMaquee_Tick);
            // 
            // GridOis8Data
            // 
            this.GridOis8Data.AllowUserToAddRows = false;
            this.GridOis8Data.AllowUserToDeleteRows = false;
            this.GridOis8Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridOis8Data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridOis8Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridOis8Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridOis8Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridOis8Data.Location = new System.Drawing.Point(332, 133);
            this.GridOis8Data.Name = "GridOis8Data";
            this.GridOis8Data.ReadOnly = true;
            this.GridOis8Data.RowHeadersVisible = false;
            this.GridOis8Data.Size = new System.Drawing.Size(305, 259);
            this.GridOis8Data.TabIndex = 29;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusAlarm});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(649, 29);
            this.statusStrip1.TabIndex = 37;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 24);
            this.toolStripStatusLabel1.Text = "Info :";
            // 
            // toolStripStatusAlarm
            // 
            this.toolStripStatusAlarm.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusAlarm.Name = "toolStripStatusAlarm";
            this.toolStripStatusAlarm.Size = new System.Drawing.Size(0, 24);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Desktop;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(649, 5);
            this.label3.TabIndex = 38;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Rohm.Common.Forms.Properties.Resources.PicturBoxRohmLogo;
            this.pictureBox6.Location = new System.Drawing.Point(11, 10);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(77, 60);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 39;
            this.pictureBox6.TabStop = false;
            // 
            // PictureCancel
            // 
            this.PictureCancel.Image = global::Rohm.Common.Forms.Properties.Resources.ButtonCancelEnable;
            this.PictureCancel.Location = new System.Drawing.Point(513, 398);
            this.PictureCancel.Name = "PictureCancel";
            this.PictureCancel.Size = new System.Drawing.Size(124, 60);
            this.PictureCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureCancel.TabIndex = 36;
            this.PictureCancel.TabStop = false;
            this.PictureCancel.Click += new System.EventHandler(this.PictureBoxCancel_Click);
            // 
            // PictureBoxOK
            // 
            this.PictureBoxOK.Image = global::Rohm.Common.Forms.Properties.Resources.ButtonOkEnable;
            this.PictureBoxOK.Location = new System.Drawing.Point(384, 398);
            this.PictureBoxOK.Name = "PictureBoxOK";
            this.PictureBoxOK.Size = new System.Drawing.Size(123, 60);
            this.PictureBoxOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxOK.TabIndex = 36;
            this.PictureBoxOK.TabStop = false;
            this.PictureBoxOK.Click += new System.EventHandler(this.PictureBoxOK_Click);
            // 
            // PictureBoxQrCode
            // 
            this.PictureBoxQrCode.Location = new System.Drawing.Point(15, 88);
            this.PictureBoxQrCode.Name = "PictureBoxQrCode";
            this.PictureBoxQrCode.Size = new System.Drawing.Size(57, 41);
            this.PictureBoxQrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxQrCode.TabIndex = 31;
            this.PictureBoxQrCode.TabStop = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Azure;
            this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBox1.Location = new System.Drawing.Point(13, 133);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(313, 259);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 28;
            this.PictureBox1.TabStop = false;
            // 
            // InputOis8Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(649, 487);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.PictureCancel);
            this.Controls.Add(this.PictureBoxOK);
            this.Controls.Add(this.LabelCaption);
            this.Controls.Add(this.TextBoxQrInput);
            this.Controls.Add(this.PictureBoxQrCode);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GridOis8Data);
            this.Controls.Add(this.PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputOis8Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input FTOIS(w/ MultiNumber and LayoutPattern)";
            this.Load += new System.EventHandler(this.InputOis10Dialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridOis8Data)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxQrCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LabelCaption;
        internal System.Windows.Forms.TextBox TextBoxQrInput;
        internal System.Windows.Forms.PictureBox PictureBoxQrCode;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Timer TimerTextMaquee;
        internal System.Windows.Forms.DataGridView GridOis8Data;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.PictureBox PictureBoxOK;
        private System.Windows.Forms.PictureBox PictureCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusAlarm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox6;

    }
}