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
    public partial class EditWBDataDialog : Form
    {
        #region DataProperty

        private WBData c_InputValue;
        public WBData InputValue 
        {
            get { return c_InputValue; }
            set { c_InputValue = value; }
        }

        private Boolean c_IsFirstInspection = false;
        public Boolean IsFirstInspection
        {
            get { return c_IsFirstInspection; }
            set { c_IsFirstInspection = value; }
        }

        private Boolean c_IsFinalInspection = false;
        public Boolean IsFinalInspection 
        {
            get { return c_IsFinalInspection; } 
            set { c_IsFinalInspection = value; } 
        }

        private Boolean c_IsAlarmManagement = false;
        public Boolean IsAlarmManagement
        {
            get { return c_IsAlarmManagement; }
            set { c_IsAlarmManagement = value; }
        }

        private Boolean c_IsMaterialManagement = false;
        public Boolean IsMaterialManagement
        {
            get { return c_IsMaterialManagement; }
            set { c_IsMaterialManagement = value; }
        }

        private Boolean c_IsDefault = false;

        #endregion

        private Label c_LabelFocus = new Label();

        public EditWBDataDialog()
        {
            InitializeComponent();
            c_InputValue = new WBData();
            c_InputValue.MCNo = "X-156";
            c_InputValue.LotNo = "1723A1252V";
            c_InputValue.LotStartTime = DateTime.Now;
            //c_InputValue = inputValue;
            //c_InputValue = data;
            c_IsFinalInspection = true;
            c_IsFirstInspection = true;
            EditState();
            DisplayMainData();

        }

        private void EditWBDataDialog_Shown(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        void DisplayMainData() 
        {
            textBoxMCNo.Text = c_InputValue.MCNo;
            textBoxLotNo.Text = c_InputValue.LotNo;
            textBoxOpNoStart.Text = c_InputValue.OPNo;
            textBoxStartTime.Text = string.Format("{0:MMM.dd HH:mm:ss}", c_InputValue.LotStartTime);
            textBoxEndTime.Text = string.Format("{0:MMM.dd HH:mm:ss}", c_InputValue.LotEndTime);
            textBoxOpNoEnd.Text = c_InputValue.OPJudgement;
            if (c_InputValue.InputQty != null)
            {
                textBoxInputPcs.Text = Convert.ToString(c_InputValue.InputQty); 
            }
            if (c_InputValue.TotalGood != null)
            {
                textBoxGoodPcs.Text = Convert.ToString(c_InputValue.TotalGood);
            }
            if (c_InputValue.TotalNG != null)
            {
                textBoxNgPcs.Text = Convert.ToString(c_InputValue.TotalNG);
            } 
        }

        void EditState()
        {
            if (c_IsAlarmManagement == false && c_IsFinalInspection == false 
                && c_IsFirstInspection == false && c_IsMaterialManagement == false)
            {
                panelAlarmManagement.Enabled = true;
                panelFinalInspection.Enabled = true;
                panelFirstInspection.Enabled = true;
                panelMaterialManagement.Enabled = true;
                c_IsDefault = true;
            }
            if (c_IsAlarmManagement == true)
            {
                panelAlarmManagement.Enabled = true;
            }
            if (c_IsFinalInspection == true)
            {
                panelFinalInspection.Enabled = true;
            }
            if (c_IsFirstInspection == true)
            {
                panelFirstInspection.Enabled = true;
            }
            if (c_IsMaterialManagement == true)
            {
                panelMaterialManagement.Enabled = true;
            }
        }

        private void pictureBoxOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void ClearRadioPanel()
        {
            radioButtonA.Checked = false;
            radioButtonB.Checked = false;
            radioButtonC.Checked = false;
        }
        private void AddDataRadioPanel(string str)
        {
            switch (str)
            {
                case "A":
                    radioButtonA.Checked = true;
                    break;
                case "B":
                    radioButtonB.Checked = true;
                    break;
                case "C":
                    radioButtonC.Checked = true;
                    break;
            }
        }
        private void radioButtonA_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonA.Checked == true)
            {
                c_LabelFocus.Text = "A";
                panelAdjustData.Visible = false;
            }
        }
        private void radioButtonB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonB.Checked == true)
            {
                c_LabelFocus.Text = "B";
                panelAdjustData.Visible = false;
            }
        }
        private void radioButtonC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonC.Checked == true)
            {
                c_LabelFocus.Text = "C";
                panelAdjustData.Visible = false;
            }
        }

        private void labelHajikiTestBf_Click(object sender, EventArgs e)
        {
            c_LabelFocus =(Label)sender;
           
            if (panelAdjustData.Visible == true)
            {
                panelAdjustData.Visible = false;
                return;
            }
            panelAdjustData.Visible = true;
            if (c_LabelFocus.Text != "")
            {
                AddDataRadioPanel(c_LabelFocus.Text);   
            }
            else
            {
                ClearRadioPanel();
            }
            MouseEventArgs m = (MouseEventArgs)e;
            panelAdjustData.Location = new Point(c_LabelFocus.Location.X + m.X + tableLayoutPanelFirstInsp.Location.X
                , c_LabelFocus.Location.Y + c_LabelFocus.Size.Height + tableLayoutPanelFirstInsp.Location.Y);
        }//labelHajikiTestBf_Click

        private void panelFirstInspection_Click(object sender, EventArgs e)
        {
            if (panelAdjustData.Visible == true)
            {
                panelAdjustData.Visible = false;
            }
        }
        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (c_LabelFocus.Text.Length > 0)
            {
             c_LabelFocus.Text = c_LabelFocus.Text.Remove(c_LabelFocus.Text.Length - 1, 1);
            }
        }
        private void button0_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            c_LabelFocus.Text = c_LabelFocus.Text + bt.Text;
        }

        private void checkBoxHajikiTest_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHajikiTest.Checked == true)
            {
                labelHajikiTestBf.Text = "-";
                labelHajikiTestAf.Text = "-";
                labelHajikiTestBf.Enabled = false;
                labelHajikiTestAf.Enabled = false;
                labelHajikiTestBf.BackColor = Color.Beige;
                labelHajikiTestAf.BackColor = Color.Beige;
            }
            else
            {
                labelHajikiTestBf.Text = "";
                labelHajikiTestAf.Text = "";
                labelHajikiTestBf.Enabled = true;
                labelHajikiTestAf.Enabled = true;
                labelHajikiTestBf.BackColor = Color.Transparent;
                labelHajikiTestAf.BackColor = Color.Transparent;
            }
        }
        private void checkBoxPeelTest_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPeelTest.Checked == true)
            {
                labelPeelTestBf.Text = "-";
                labelPeelTestAf.Text = "-";
                labelPeelTestBf.Enabled = false;
                labelPeelTestAf.Enabled = false;
                labelPeelTestBf.BackColor = Color.Beige;
                labelPeelTestAf.BackColor = Color.Beige;
            }
            else
            {
                labelPeelTestBf.Text = "";
                labelPeelTestAf.Text = "";
                labelPeelTestBf.Enabled = true;
                labelPeelTestAf.Enabled = true;
                labelPeelTestBf.BackColor = Color.Transparent;
                labelPeelTestAf.BackColor = Color.Transparent;
            }
        }
        private void checkBoxDoubleBonding_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDoubleBonding.Checked == true)
            {
                labelDoubleBondingBf.Text = "-";
                labelDoubleBondingAf.Text = "-";
                labelDoubleBondingBf.Enabled = false;
                labelDoubleBondingAf.Enabled = false;
                labelDoubleBondingBf.BackColor = Color.Beige;
                labelDoubleBondingAf.BackColor = Color.Beige;
            }
            else
            {
                labelDoubleBondingBf.Text = "-";
                labelDoubleBondingAf.Text = "-";
                labelDoubleBondingBf.Enabled = true;
                labelDoubleBondingAf.Enabled = true;
                labelDoubleBondingBf.BackColor = Color.Transparent;
                labelDoubleBondingAf.BackColor = Color.Transparent;
            }
        }

        private void textBoxHajikiTestPn_Click(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "NumPadControl")
                {
                    return;
                }
            }
            NumPadControl numPad = new NumPadControl(this.Name);
            numPad.Show();
            MouseEventArgs m = (MouseEventArgs)e;
            numPad.SetStartPosition(this.Location.X + 520, this.Location.Y);
        }
        private bool ConfirmEditData()
        {
            bool res = false;
            if (c_IsDefault)
            {
                if (!ConfirmHajikiTest())
                {
                    res = false;
                }
                if (!ConfirmPeelTest())
                {
                    res = false;
                }
                if (!ConfirmDoubleBonding())
                {
                    res = false;
                }

            }
            else
            {

            }

            return res;
        }
        private bool ConfirmHajikiTest()
        {
            bool res = true;
            if (!checkBoxHajikiTest.Checked)
            {
                if (labelHajikiTestBf.Text == "")
                {
                    labelHajikiTestBf.BackColor = Color.Red;
                    res = false;
                }
                if (labelHajikiTestAf.Text == "")
                {
                    labelHajikiTestAf.BackColor = Color.Red;
                    res = false;
                }
                int a = 0;
                if (textBoxHajikiTestPn.Text == "")
                {
                    textBoxHajikiTestPn.BackColor = Color.Red;
                    res = false;
                }
                else if (!int.TryParse(textBoxHajikiTestPn.Text, out a))
                {
                    textBoxHajikiTestPn.BackColor = Color.Red;
                    toolStripStatusLabelWarningMessage.Text = "Please check HajikiTest Pn data";
                    res = false;
                }
            }
            return res;
        }
        private bool ConfirmPeelTest()
        {
            bool res = true;
            if (!checkBoxPeelTest.Checked)
            {
                if (labelPeelTestBf.Text == "")
                {
                    labelPeelTestBf.BackColor = Color.Red;
                    res = false;
                }
                if (labelPeelTestAf.Text =="")
                {
                    labelPeelTestAf.BackColor = Color.Red;
                    res = false;
                }
                int a = 0;
                if (textBoxPeelTestPn.Text == "")
                {
                    textBoxPeelTestPn.BackColor = Color.Red;
                    res = false;
                }
                else if (int.TryParse(textBoxPeelTestPn.Text,out a))
                {
                    textBoxPeelTestPn.BackColor = Color.Red;
                    toolStripStatusLabelWarningMessage.Text = "Please check PeelTest Pn data";
                    res = false;
                }
            }
            return res;
        }
        private bool ConfirmDoubleBonding()
        {
            bool res = true;
            if (!checkBoxDoubleBonding.Checked)
            {
                if (labelDoubleBondingBf.Text == "")
                {
                    labelDoubleBondingBf.BackColor = Color.Red;
                    res = false;
                }
                if (labelDoubleBondingAf.Text == "")
                {
                    labelDoubleBondingAf.BackColor = Color.Red;
                    res = false;
                }
                int a = 0;
                if (textBoxDoubleBondingPn.Text == "")
                {
                    textBoxDoubleBondingPn.BackColor = Color.Red;
                    res = false;
                }
                else if (int.TryParse(textBoxDoubleBondingPn.Text,out a))
                {
                    textBoxDoubleBondingPn.BackColor = Color.Red;
                    res = false;
                    toolStripStatusLabelWarningMessage.Text = "Please check PeelTest Pn data";
                }
            }
            return res;
        }
        private bool ConfirmTotalJudgement()
        {
            bool res = true;
            switch (labelTotalJudgementBf.Text)
            {   
                case "A":
                    if (labelTotalJudgementAf.Text != "")
                    {
                        labelTotalJudgementAf.Text = "";
                    }
                    break;
                case "B":
                case "C":

                    if (labelTotalJudgementAf.Text == "")
                    {
                        labelTotalJudgementAf.BackColor = Color.Red;
                        res = false;
                    }
                    break;                
                default:
                    break;
            }
            int a = 0;
            if (textBoxTotalJudgementPn.Text == "")
            {
                textBoxTotalJudgementPn.BackColor = Color.Red;
                res = false;
            }
            else if (int.TryParse(textBoxTotalJudgementPn.Text,out a))
            {
            }
            return res;
        }
    }
}
