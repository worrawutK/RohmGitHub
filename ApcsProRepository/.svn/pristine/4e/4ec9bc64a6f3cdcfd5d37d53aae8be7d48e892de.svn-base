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
    public partial class InputOis10Dialog : Form
    {

        int  c_StartLetter;
        string  c_HeaderText;
        public  Ois10 c_InputValue;
        public Ois10 InputValue
        {
            get
            {
                return c_InputValue;
            }
        }

        public InputOis10Dialog()
        {
            InitializeComponent();
        }

  
        private void TextBoxQrInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    Ois10 ois10Data = new Ois10();
                    ois10Data.GetOis10(TextQrInput.Text);
                    DisplayData(ois10Data);
                    toolStripStatusAlarm.BackColor = DefaultBackColor ;
                    toolStripStatusAlarm.Text = "";
                    c_InputValue = ois10Data;
                }

                catch (Exception)
                {
                    c_InputValue = new Ois10() ;
                    toolStripStatusAlarm.BackColor = Color.Yellow;
                    toolStripStatusAlarm .Text  = "QR Data is invalid !";
                }
                TextQrInput.Text = "";
                TextQrInput.Select();
            }
        }

        void DisplayData(Ois10 qrData)
        {
            GridOis10Data.Rows.Clear();
            GridOis10Data.Columns.Clear();
            GridOis10Data.Columns.Add("DataGridViewItem", "Item");
            GridOis10Data.Columns.Add("DataGridViewData", "Data");

            GridOis10Data.Rows.Insert(0, "Header", qrData.Header );
            GridOis10Data.Rows.Insert(1, "DeviceName", qrData.DeviceName );
            GridOis10Data.Rows.Insert(2, "InputRank", qrData.InputRank );
            GridOis10Data.Rows.Insert(3, "ProcessFlow", qrData.ProcessFlow );
            GridOis10Data.Rows.Insert(4, "PackageName", qrData.PackageName );
            GridOis10Data.Rows.Insert(5, "TesterType", qrData.TesterType );
            GridOis10Data.Rows.Insert(6, "BoxName", qrData.BoxName );
            GridOis10Data.Rows.Insert(7, "ProgramName", qrData.ProgramName );
            GridOis10Data.Rows.Insert(8, "MultiNumber", qrData.MultiNumber);
            GridOis10Data.Rows.Insert(9, "LayoutPattern", qrData.LayoutPattern);
        }


        private void TimerTextMaquee_Tick(object sender, EventArgs e)
        {
           
            if (labelCaption.Text.Length >= c_HeaderText.Length )
            {
                labelCaption.Text = "";
                c_StartLetter = 0;
            }
            labelCaption.Text = c_HeaderText.Substring(0, c_StartLetter);
            c_StartLetter ++;
        }

        private void InputOis10Dialog_Load(object sender, EventArgs e)
        {
            c_HeaderText = "Scan FTOIS QR Code...";
            TextQrInput.Select();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (GridOis10Data.Rows.Count != 0)
            {

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                toolStripStatusAlarm.Text = "Please scan Ois QR code";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }





    }
}
