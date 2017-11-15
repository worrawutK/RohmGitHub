﻿namespace Rohm.Common.Forms
{
    partial class ViewInfoWithLinkDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewInfoWithLinkDialog));
            this.labelAlarmMessage = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.linkLabelOnePoint = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDismiss = new System.Windows.Forms.Button();
            this.labelAlarmTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAlarmMessage
            // 
            this.labelAlarmMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAlarmMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelAlarmMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAlarmMessage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlarmMessage.ForeColor = System.Drawing.Color.Maroon;
            this.labelAlarmMessage.Location = new System.Drawing.Point(10, 34);
            this.labelAlarmMessage.Name = "labelAlarmMessage";
            this.labelAlarmMessage.Size = new System.Drawing.Size(410, 137);
            this.labelAlarmMessage.TabIndex = 2;
            this.labelAlarmMessage.Text = "This text is only example of alarm message..";
            this.labelAlarmMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.linkLabelOnePoint);
            this.panel3.Controls.Add(this.labelAlarmMessage);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.buttonDismiss);
            this.panel3.Location = new System.Drawing.Point(12, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(432, 251);
            this.panel3.TabIndex = 1;
            // 
            // linkLabelOnePoint
            // 
            this.linkLabelOnePoint.Location = new System.Drawing.Point(11, 171);
            this.linkLabelOnePoint.Name = "linkLabelOnePoint";
            this.linkLabelOnePoint.Size = new System.Drawing.Size(398, 31);
            this.linkLabelOnePoint.TabIndex = 3;
            this.linkLabelOnePoint.TabStop = true;
            this.linkLabelOnePoint.Text = "link:http//www.sampleonepoint.net";
            this.linkLabelOnePoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alarm Message :";
            // 
            // buttonDismiss
            // 
            this.buttonDismiss.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonDismiss.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDismiss.Location = new System.Drawing.Point(178, 205);
            this.buttonDismiss.Name = "buttonDismiss";
            this.buttonDismiss.Size = new System.Drawing.Size(75, 34);
            this.buttonDismiss.TabIndex = 0;
            this.buttonDismiss.Text = "&Dismiss";
            this.buttonDismiss.UseVisualStyleBackColor = true;
            // 
            // labelAlarmTitle
            // 
            this.labelAlarmTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAlarmTitle.AutoSize = true;
            this.labelAlarmTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlarmTitle.ForeColor = System.Drawing.Color.White;
            this.labelAlarmTitle.Location = new System.Drawing.Point(14, 19);
            this.labelAlarmTitle.Name = "labelAlarmTitle";
            this.labelAlarmTitle.Size = new System.Drawing.Size(285, 29);
            this.labelAlarmTitle.TabIndex = 0;
            this.labelAlarmTitle.Text = "ALARM INFORMATION";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelAlarmTitle);
            this.panel2.Location = new System.Drawing.Point(0, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 70);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 319);
            this.panel1.TabIndex = 2;
            // 
            // ViewInfoWithLinkDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 319);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ViewInfoWithLinkDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewInfoWithLinkDialog";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelAlarmMessage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel linkLabelOnePoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDismiss;
        private System.Windows.Forms.Label labelAlarmTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}