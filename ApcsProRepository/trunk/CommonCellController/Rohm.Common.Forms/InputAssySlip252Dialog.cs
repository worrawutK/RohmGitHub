using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rohm.Common.Model;
using System.Text.RegularExpressions;

namespace Rohm.Common.Forms
{
    public partial class InputAssySlip252Dialog : Form
    {

        private AssySlip252 c_InputValue;
        public  AssySlip252 InputValue
        {
            get { return c_InputValue; }
            set { c_InputValue = value; }
        }

        Boolean c_IsDone = false;
        public InputAssySlip252Dialog()
        {
            InitializeComponent();
        }


    private void InputAssySlip252Dialog_Load(object sender, EventArgs e)
    {
        c_InputValue = new AssySlip252();
        DisplayWarningMessage("Please input assyslip qrcode", Color.Blue);
        progressBarInputQrCode.Maximum = 252;
        progressBarInputQrCode.Value = 0;
    }

#region DetailData
        
    private void ClearDisplay() 
    {
        LabelLotNo.Text = "";
        LabelPackageName.Text = "";
        LabelDeviceName.Text = "";
        LabelFrameType.Text = "";
        LabelFaSet.Text = "";
        LabelCodeNo.Text = "";
        LabelWaferLotNo.Text = "";
        LabelTpRank.Text = "";
        LabelMarkType.Text = "";
        LabelMarkingSpec1.Text = "";
        LabelMarkingSpec2.Text = "";
        LabelMarkingSpec3.Text = "";
        LabelMarkngStep.Text = "";
        LabelCustomerDevice.Text = "";
        LabelOsFtChange.Text = "";
        LabelOsProgram.Text = "";
        LabelResinType.Text = "";
        LabelNewPackage.Text = "";
        LabelFtDevice.Text = "";
        LabelMarkNo.Text = "";
        LabelPbFree.Text = "";
        LabelUlMark.Text = "";
        LabelReelCount.Text = "";
        LabelProvisionalIndication.Text = "";
        LabelSubRank.Text = "";
        LabelMask.Text = "";
        LabelLabelDevice.Text = "";

        TextBoxQrCodeInput.Text = "";
        PictureboxQrCodeInputCheck.Image = Rohm.Common.Forms.Properties.Resources.PictureBoxWrong;
        c_IsDone = false;
        PictureBoxOk.Image = Rohm.Common.Forms.Properties.Resources.ButtonOkDisAble;
        progressBarInputQrCode.Value = 0;
        progressBarInputQrCode.Style = ProgressBarStyle.Marquee;
    }
    private void DisplayData()
    {
        LabelLotNo.Text = c_InputValue.LotNo;
        LabelPackageName.Text = c_InputValue.PackageName;
        LabelDeviceName.Text = c_InputValue.DeviceName;
        LabelFrameType.Text = c_InputValue.FrameType;
        LabelFaSet.Text = c_InputValue.FaSet;
        LabelCodeNo.Text = c_InputValue.CodeNo;
        LabelWaferLotNo.Text = c_InputValue.WaferLotNo;
        LabelTpRank.Text = c_InputValue.TpRank;
        LabelMarkType.Text = c_InputValue.MarkType;
        LabelMarkingSpec1.Text = c_InputValue.MarkingSpec1;
        LabelMarkingSpec2.Text = c_InputValue.MarkingSpec2;
        LabelMarkingSpec3.Text = c_InputValue.MarkingSpec3;
        LabelMarkngStep.Text = c_InputValue.MarkingStep;
        LabelCustomerDevice.Text = c_InputValue.CustomerDevice;
        LabelOsFtChange.Text = c_InputValue.OsFtChange;
        LabelOsProgram.Text = c_InputValue.OsProgram;
        LabelResinType.Text = c_InputValue.ResinType;
        LabelNewPackage.Text = c_InputValue.NewPackageName;
        LabelFtDevice.Text = c_InputValue.FtDevice;
        LabelMarkNo.Text = c_InputValue.MarkNo;
        LabelPbFree.Text = c_InputValue.PbFree;
        LabelUlMark.Text = c_InputValue.UlMark;
        LabelReelCount.Text = c_InputValue.ReelCount;
        LabelProvisionalIndication.Text = c_InputValue.ProvisionalIndication;
        LabelSubRank.Text = c_InputValue.SubRank;
        LabelMask.Text = c_InputValue.Mask;
        LabelLabelDevice.Text = c_InputValue.LabelDevice;

        TextBoxQrCodeInput.Text = c_InputValue.LotNo;
        PictureboxQrCodeInputCheck.Image = Rohm.Common.Forms.Properties.Resources.PictureBoxCorrect;

        DisplayWarningMessage("Please confirm data with assyslip", Color.Blue);
    }
        
#endregion

    private void PictureboxQrCodeInput_Click(object sender, EventArgs e)
    {
        DisplayWarningMessage("Please input assyslip qrcode", Color.Blue);
        ClearDisplay();
        progressBarInputQrCode.Style = ProgressBarStyle.Marquee;
    }

    private void TextBoxQrCodeInput_KeyDown(object sender, KeyEventArgs e)
    {
        if (progressBarInputQrCode.Style == ProgressBarStyle.Marquee)
        {
            progressBarInputQrCode.Style = ProgressBarStyle.Continuous;
        }
        if (progressBarInputQrCode.Value < progressBarInputQrCode.Maximum)
        {
           progressBarInputQrCode.Value += 1;   
        }
       
         
        if (e.KeyCode == Keys.Enter)
        {
            AssySlip252 dummy = new AssySlip252();
            try
            {
                dummy.ReadFromQrString(TextBoxQrCodeInput.Text);
                Regex reg = new Regex(@"^\d{4}[a-zA-Z]{1}\d{4}[a-zA-Z]{1}");
                if (reg.Match(dummy.LotNo).Success)
                {
                    c_InputValue = dummy;
                    c_IsDone = true;
                    PictureBoxOk.Image = Rohm.Common.Forms.Properties.Resources.ButtonOkEnable;
                    DisplayData(); 
                }
                else
                {
                    DisplayWarningMessage("Invalid LotNo", Color.Red);
                    ClearDisplay();
                }
                           
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                DisplayWarningMessage(ex.Message, Color.Red);
                ClearDisplay();
                //throw;
            }
        }
    }
    private void DisplayWarningMessage(string message, Color c) 
    {
        toolStripStatusLabelMessage.Text = message;
        toolStripStatusLabelMessage.ForeColor = c;
         
    }
    private void PictureBoxOk_Click(object sender, EventArgs e)
    {
        if (c_IsDone)
        {
            DialogResult = DialogResult.OK;
        }
    }

    private void PictureBoxCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private void timerBlink_Tick(object sender, EventArgs e)
    {
        if (L1.BackColor == Color.DarkTurquoise)
        {
            L1.BackColor = Color.Red;
            L2.BackColor = Color.Red;
            L3.BackColor = Color.Red;
            L4.BackColor = Color.Red;
        }
        else if (L1.BackColor == Color.Red)
        {
            L1.BackColor = Color.DarkTurquoise;
            L2.BackColor = Color.DarkTurquoise;
            L3.BackColor = Color.DarkTurquoise;
            L4.BackColor = Color.DarkTurquoise;
        }
        //else
        //{
        //    L1.BackColor = Color.DarkTurquoise;
        //    L2.BackColor = Color.DarkTurquoise;
        //    L3.BackColor = Color.DarkTurquoise;
        //    L4.BackColor = Color.DarkTurquoise;
        //}
    }

   

     }
}
