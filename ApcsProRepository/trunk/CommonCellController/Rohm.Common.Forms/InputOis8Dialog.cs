using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rohm.Common.Model;



namespace Rohm.Common.Forms
{
    public partial class InputOis8Dialog : Form
    {
        int  c_StartLetter;
        string  c_HeaderText;

        public  Ois8 c_InputValue;
        public Ois8 InputValue
        {
            get {
                return c_InputValue;
            }
        }

         public  InputOis8Dialog()
        {
            InitializeComponent();
           
        }

  
        private void TextBoxQrInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    Ois8 ois8Data = new Ois8();
                    ois8Data.GetOis8(TextBoxQrInput.Text);
                    DisplayData(ois8Data);
                    toolStripStatusAlarm.BackColor = DefaultBackColor ;
                    toolStripStatusAlarm.Text = "";
                    c_InputValue = ois8Data;
                }

                catch (Exception)
                {
                    c_InputValue = new Ois8() ;
                    toolStripStatusAlarm.BackColor = Color.Yellow;
                    toolStripStatusAlarm .Text  = "QR Data is invalid !";
                }
                TextBoxQrInput.Text = "";
                TextBoxQrInput.Select();
            }
        }

        void DisplayData(Ois8 qrData)
        {
            GridOis8Data.Rows.Clear();
            GridOis8Data.Columns.Clear();
            GridOis8Data.Columns.Add("DataGridViewItem", "Item");
            GridOis8Data.Columns.Add("DataGridViewData", "Data");

            GridOis8Data.Rows.Insert(0, "Header", qrData.Header );
            GridOis8Data.Rows.Insert(1, "DeviceName", qrData.DeviceName );
            GridOis8Data.Rows.Insert(2, "InputRank", qrData.InputRank );
            GridOis8Data.Rows.Insert(3, "ProcessFlow", qrData.ProcessFlow );
            GridOis8Data.Rows.Insert(4, "PackageName", qrData.PackageName );
            GridOis8Data.Rows.Insert(5, "TesterType", qrData.TesterType );
            GridOis8Data.Rows.Insert(6, "BoxName", qrData.BoxName );
            GridOis8Data.Rows.Insert(7, "ProgramName", qrData.ProgramName );
        }


        private void InputOis10Dialog_Load(object sender, EventArgs e)
        {
            c_HeaderText = "Scan FTOIS QR Code...";
            TextBoxQrInput.Select();
        }

        private void PictureBoxOK_Click(object sender, EventArgs e)
        {
            if (GridOis8Data.Rows.Count != 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                toolStripStatusAlarm.Text = "Please scan Ois QR code";
            }
        }

        private void PictureBoxCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TimerTextMaquee_Tick(object sender, EventArgs e)
        {
            if (LabelCaption.Text.Length >= c_HeaderText.Length)
            {
                LabelCaption.Text = "";
                c_StartLetter = 0;
            }
            LabelCaption.Text = c_HeaderText.Substring(0, c_StartLetter);
            c_StartLetter++;
        }





    }
}
