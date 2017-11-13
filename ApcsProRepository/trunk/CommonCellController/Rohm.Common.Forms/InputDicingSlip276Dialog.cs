using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.ComponentModel;
using Rohm.Common.Model;
namespace Rohm.Common.Forms
{
    public partial class InputDicingSlip276Dialog : Form
    {
        #region Property
        bool c_IsDone = false;
        private DicingSlip276 c_InputValue;
        public DicingSlip276 InputValue
        {
            get { return c_InputValue; }
            set { c_InputValue = value; }
        }
        private string c_HeaderText;
        public string HeaderText
        {
            get { return c_HeaderText; }
            set
            {
                c_HeaderText = value;
                LabelHeader.Text = value;
            }
        }
        #endregion

        public InputDicingSlip276Dialog()
        {
            InitializeComponent();
        }

        //##################################################################
        #region DicingSlip276      
        private void ReadData(string qrCode)
        {
            InputValue = new DicingSlip276(qrCode);
            LabelWaferNo.Text = InputValue.WaferQty.ToString();
            LabelWFLotNo.Text = InputValue.WaferLotNo;
            LabelChipName.Text = InputValue.ChipName;
            LabelDeviceName.Text = InputValue.DeviceName;
            LabelOrderNo.Text = InputValue.OrderNo;
            LabelDCCode.Text = InputValue.DCCode;
            LabelPlasma.Text = InputValue.Plasma;
            LabelCodeNo.Text = InputValue.CodeNo;

            foreach (Control item in TableLayoutPanelControlData.Controls)
            {
                if (item.GetType() == typeof(Label))
                {
                    Label lb = (Label)item;
                    if (lb.Name.Length > 7)
                    {

                        if (lb.Text == "-" || lb.Text == "")
                            lb.BackColor = Color.Red;
                        else
                            lb.BackColor = Color.LawnGreen;
                    }


                }
            }
        }
        private void ClaerText()
        {
            foreach (Control item in TableLayoutPanelControlData.Controls)
            {
                if (item.GetType() == typeof(Label))
                {
                    Label lb = (Label)item;
                    if (lb.Name.Length > 7)
                    {
                        lb.Text = "-";
                        lb.BackColor = Color.White;
                    }

                }
                c_IsDone = false;
                PictureBoxOk.Cursor = Cursors.No;
                PictureBoxOk.Image = Properties.Resources.ButtonOkDisAble;
            }
        }
        #endregion


        #region Control
        private void InputDicingSlip254Dialog_Load(object sender, EventArgs e)
        {
            TextBoxInputQRCode.Focus();
            ClaerText();
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            if (c_IsDone == false)
            {
                MessageBox.Show("No Data");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TextBoxInputQRCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TextBoxInputQRCode.Text.Length <= 276)
                ProgressBarQRCode.Value = TextBoxInputQRCode.Text.Length;
            else
                ProgressBarQRCode.Value = 0;

            if (e.KeyChar == 13) //e.KeyChar ==Convert.ToChar(13) 'Convert.ToInt16(e.KeyChar) == 13
            {
                ClaerText();
                if (TextBoxInputQRCode.Text.Length == 276)
                {
                    ReadData(TextBoxInputQRCode.Text);
                    PictureBoxOk.Cursor = Cursors.Hand;
                    PictureBoxOk.Image = Properties.Resources.ButtonOkEnable;
                    c_IsDone = true;

                }
                TextBoxInputQRCode.Text = "";
            }
        }


        #endregion

        private void TimerFocusQR_Tick(object sender, EventArgs e)
        {
            foreach (Control lb in PanelFocusImage.Controls)
            {
                if (lb.GetType() == typeof(Label))
                {
                    if (lb.BackColor == Color.Red)
                        lb.BackColor = Color.White;
                    else
                        lb.BackColor = Color.Red;
                }
            }
        }
        DateTime timeOpen = DateTime.Now;
        private void TimeCount_Tick(object sender, EventArgs e)
        {
            if (ProgressBarQRCode.Value <= 0)
                ProgressBarQRCode.Style = ProgressBarStyle.Marquee;
            else
                ProgressBarQRCode.Style = ProgressBarStyle.Blocks;

            TimeSpan timeNow = DateTime.Now - timeOpen;
            ToolStripStatusLabelTime.Text = timeNow.TotalHours.ToString("00") + ":" + timeNow.Minutes.ToString("00") + ":" + timeNow.Seconds.ToString("00");
        }


    }
}
