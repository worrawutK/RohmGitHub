﻿using System;
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
    public partial class EditMPDataDialog : Form
    {
        public EditMPDataDialog(MPData newMpData)
        {     
            InitializeComponent();
            DisplayMainData(newMpData);
        }
       
    #region Variable
        enum MessageError
        {
            AppearanceInspectionRecord,
            LotJudgement,
            Mold,
            QuantityAdjust,
            ModeMechaNG,
            Remark,
            NotError

        };
    
    #endregion
    #region DataProperty
        private MPData c_InputValue;
        public MPData InputValue
        {
            get { return c_InputValue; }
          //  set { c_InputValue = value; }
        }

        private bool c_EnabledGroupBoxAppearanceInspectionRecord = true;
        public bool EnabledGroupBoxAppearanceInspectionRecord
        {
            get { return c_EnabledGroupBoxAppearanceInspectionRecord;}
            set 
            {
                c_EnabledGroupBoxAppearanceInspectionRecord = value;
                groupBoxAppearanceInspectionRecord.Enabled = c_EnabledGroupBoxAppearanceInspectionRecord;
            }
        }

        private bool c_EnabledGroupBoxLotNG = true;
        public bool EnabledGroupBoxLotNG
        {
            get { return c_EnabledGroupBoxLotNG; }
            set
            {
                c_EnabledGroupBoxLotNG = value;
                groupBoxLotNG.Enabled = c_EnabledGroupBoxLotNG;
            }
        }

        private bool c_EnabledGroupBoxMold = true;
        public bool EnabledGroupBoxMold
        {
            get { return c_EnabledGroupBoxMold; }
            set
            {
                c_EnabledGroupBoxMold = value;
                groupBoxMold.Enabled = c_EnabledGroupBoxMold;
            }
        }

        private bool c_EnabledGroupBoxQuantityAdjust = true;
        public bool EnabledGroupBoxQuantityAdjust
        {
            get { return c_EnabledGroupBoxQuantityAdjust; }
            set
            {
                c_EnabledGroupBoxQuantityAdjust = value;
                groupBoxMold.Enabled = c_EnabledGroupBoxQuantityAdjust;
            }
        }

        private bool c_EnabledGroupBoxModeMechaNg = true;
        public bool EnabledGroupBoxModeMechaNg
        {
            get { return c_EnabledGroupBoxModeMechaNg; }
            set
            {
                c_EnabledGroupBoxModeMechaNg = value;
                groupBoxModeMechaNg.Enabled = c_EnabledGroupBoxModeMechaNg;
            }
        }

        private bool c_EnabledGroupBoxRemark = true;
        public bool EnabledGroupBoxRemark
        {
            get { return c_EnabledGroupBoxRemark; }
            set
            {
                c_EnabledGroupBoxRemark = value;
                groupBoxRemark.Enabled = c_EnabledGroupBoxRemark;
            }
        }
    #endregion
       

        void DisplayMainData(MPData getMpData)
        {
            c_InputValue = getMpData;

            //header
            labelMCNo.Text = c_InputValue.MCNo;
            labelLotNo.Text = c_InputValue.LotNo;
            labelOpNoStart.Text = c_InputValue.OPNo;
            labelInputPcs.Text = c_InputValue.OPJudgement;
            labelGoodPcs.Text = c_InputValue.TotalGood.ToString();
            labelNgPcs.Text = c_InputValue.TotalNG.ToString();
            labelStartTime.Text = c_InputValue.LotStartTime.ToString();
            labelEndTime.Text = c_InputValue.LotEndTime.ToString();
            labelOpNoEnd.Text = c_InputValue.OPJudgement;
           
            //edit data        
            textBoxInputQtyAdjust.Text = c_InputValue.InputQty.ToString();
            textBoxTotalGoodAdjust.Text = c_InputValue.TotalGood.ToString();
            textBoxShotCount.Text = c_InputValue.ShotAccQty.ToString();

        }
        bool isNumber(string txt)
        { 
            double num;

            return double.TryParse(txt, out num);
        }
       
        //Check Data Input
        MessageError CheckDataInput()
        {
         
          
            //Appearance Inspection Record
            if (c_EnabledGroupBoxAppearanceInspectionRecord)
            {

                if (!radioButtonAppPss.Checked && !radioButtonAppFail.Checked)
                    return MessageError.AppearanceInspectionRecord;

               

                if (!isNumber(textBoxAppearInsPn.Text))
                    return MessageError.AppearanceInspectionRecord;

              
            }
           
            //Lot Judgement
            if (c_EnabledGroupBoxLotNG == true)
            {
                if ((radioButtonLotJudgeOK.Checked == false && radioButtonLotJudgeNG.Checked == false)
                   || (textBoxGLCheck.Text == "" && textBoxOPConfirm.Text == ""))
                    return MessageError.LotJudgement;
            }
           
            //Mold

            //Quantity Adjust
            if (c_EnabledGroupBoxQuantityAdjust == true)
            {
                if (textBoxTotalNGAdjust.Text == "")
                    return MessageError.QuantityAdjust;

            }
            //Mode Mecha NG

            //Remark

           
            //SetData
            string Judgement = "";
            string lotJudgement = "";
            if (radioButtonAppPss.Checked)
                Judgement = radioButtonAppPss.Text;
            else
                Judgement = radioButtonAppFail.Text;

            if (radioButtonLotJudgeOK.Checked)
                lotJudgement = radioButtonLotJudgeOK.Text;
            else
                lotJudgement = radioButtonLotJudgeNG.Text;
            //1
            c_InputValue.AppearInsMode = comboBoxAppearInsMode.SelectedIndex.ToString();
            c_InputValue.AppearInsPn = Int16.Parse(textBoxAppearInsPn.Text);
            c_InputValue.AppearInsJudge = Judgement;
            //2
            c_InputValue.Remark = textBoxRemark.Text;

            //3
            c_InputValue.ShotAccQty = Int16.Parse(textBoxShotCount.Text);

            //4
            c_InputValue.InputQtyAdjust = Int16.Parse(textBoxInputQtyAdjust.Text);
            c_InputValue.TotalGoodAdjust = Int16.Parse(textBoxTotalGoodAdjust.Text); ;
            c_InputValue.TotalNGAdjust = Int16.Parse(textBoxTotalNGAdjust.Text);
            c_InputValue.MechaNGAdjust = Int16.Parse(textBoxMechaNGAdjust.Text);
            c_InputValue.InspectionNGAdjust = Int16.Parse(textBoxInspectionNGAdjust.Text);
         //   c_InputValue.LotStartTime
            //5
            c_InputValue.MechaNGMode = comboBoxModeMecha.SelectedIndex.ToString("00");
          
            //6           
            c_InputValue.GLJudgement = textBoxGLCheck.Text;
            c_InputValue.OPJudgement = textBoxOPConfirm.Text;
            c_InputValue.LotJudgement = lotJudgement;

            return MessageError.NotError;
        }
      
        private void buttonInspctionOK_Click(object sender, EventArgs e)
        {
            MessageError result = CheckDataInput();
            if (result == MessageError.NotError)
            {
                //InputValue.AppearInsMode
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("กรุณาตรวจสอบ input >>" + result.ToString());
        }

        private void EditMPDataDialog_Load(object sender, EventArgs e)
        {

        }
        //Remark control
        private void comboBoxRemark_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRemark.Text == "OTHER")
            {
                textBoxRemark.Enabled = true;
                textBoxRemark.Text = "";
                textBoxRemark.Focus();
            }
            else
            {
                textBoxRemark.Enabled = false;
                textBoxRemark.Text = comboBoxRemark.Text;
            }
        }

        private void buttonInspctionCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }            
        }


      


}


