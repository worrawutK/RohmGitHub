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
    public partial class EditFTDataDialog : Form
    {
        private FTData c_InputValue;
        public FTData InputValue;

        public EditFTDataDialog()
        {
            InitializeComponent();
        }
        //CHECK INPUT DATA
        enum MessageError
        {
            MarkingInspection,
            TestTemperature,
            QuantityAdjust,
            ASI,
            DuringProductionCheck,
            SocketCheck,
            LotJudgement,
            RPM,
            Remark,
            NotError
        };

        bool isNumber(string txt)
        {
            double num;
            return double.TryParse(txt, out num);
        }

        void DisplayMainData(FTData getFTData)
        {
            c_InputValue = getFTData;
            //header
            textBoxMCNo.Text = c_InputValue.MCNo;
            textBoxLotNo.Text = c_InputValue.LotNo;
            textBoxOpNoStart.Text = c_InputValue.OPNo;
            textBoxInputPcs.Text = c_InputValue.InputQty.ToString();
            textBoxGoodPcs.Text = c_InputValue.TotalGood.ToString();
            textBoxNgPcs.Text = c_InputValue.TotalNG.ToString();
            textBoxStartTime.Text = c_InputValue.LotStartTime.ToString();
            textBoxEndTime.Text = c_InputValue.LotEndTime.ToString();
            textBoxOpNoEnd.Text = c_InputValue.EndOPNo;
            //QUANTITY ADJUSTMENT        
            textBoxFirstGoodBin1Qty.Text = c_InputValue.FirstGoodBin1Qty.ToString();
            textBoxSecondGoodBin1Qty.Text = c_InputValue.SecondGoodBin1Qty.ToString();
            textBoxTotalGoodBin1Qty.Text = c_InputValue.TotalGoodBin1Qty.ToString();
            textBoxFirstGoodBin2Qty.Text = c_InputValue.FirstGoodBin2Qty.ToString();
            textBoxSecondGoodBin2Qty.Text = c_InputValue.SecondGoodBin2Qty.ToString();
            textBoxTotalGoodBin2Qty.Text = c_InputValue.TotalGoodBin2Qty.ToString();
            textBoxFirstNGBin6Qty.Text = c_InputValue.FirstNGQty.ToString();
            textBoxSecondNGBin6Qty.Text = c_InputValue.SecondNGQty.ToString();
            textBoxTotalNGBin6Qty.Text = c_InputValue.TotalNGQty.ToString();
            textBoxFirstNGBin7Qty.Text = c_InputValue.FirstNGBin7Qty.ToString();
            textBoxSecondNGBin7Qty.Text = c_InputValue.SecondNGBin7Qty.ToString();
            textBoxTotalNGBin7Qty.Text = c_InputValue.TotalNGBin7Qty.ToString();
            textBoxFirstMeka1Qty.Text = c_InputValue.FirstMeka1Qty.ToString();
            textBoxSecondMeka1Qty.Text = c_InputValue.SecondMeka1Qty.ToString();
            textBoxTotalMeka1Qty.Text = c_InputValue.TotalMeka1Qty.ToString();
            textBoxFirstMeka2Qty.Text = c_InputValue.FirstMeka2Qty.ToString();
            textBoxTotalMeka2Qty.Text = c_InputValue.TotalMeka2Qty.ToString();
            textBoxSecondMeka4Qty.Text = c_InputValue.SecondMeka4Qty.ToString();
            textBoxTotalMeka4Qty.Text = c_InputValue.TotalMeka4Qty.ToString();
            textBoxFirstUnknowQty.Text = c_InputValue.FirstUnknowQty.ToString();
            textBoxSecondUnknowQty.Text = c_InputValue.SecondUnknowQty.ToString();
            textBoxTotalUnknowQty.Text = c_InputValue.TotalUnknowQty.ToString();
            textBoxHandlerCounterQty.Text = c_InputValue.HandlerCounterQty.ToString();
            textBoxTesterACounterQty.Text = c_InputValue.TesterACounterQty.ToString();
            textBoxTesterBCounterQty.Text = c_InputValue.TesterBCounterQty.ToString();
            //Marking Inspection
            if (c_InputValue.MarkingInspection == true)
            {
                radioButtonMarkingPass.Checked = true;
                radioButtonMarkingFail.Checked = false;
            }
            else if (c_InputValue.MarkingInspection == false)
            {
                radioButtonMarkingPass.Checked = false;
                radioButtonMarkingFail.Checked = true;
            }
            //Test Temperature
            if (c_InputValue.TestTemperature == "ROOM")
            {
                radioButtonRoom.Checked = true;
                radioButtonHot.Checked = false;
                radioButtonCold.Checked = false;
            }
            else if (c_InputValue.TestTemperature == "HOT")
            {
                radioButtonRoom.Checked = false;
                radioButtonHot.Checked = true;
                radioButtonCold.Checked = false;
            }
            else if (c_InputValue.TestTemperature == "COLD")
            {
                radioButtonRoom.Checked = false;
                radioButtonHot.Checked = false;
                radioButtonCold.Checked = true;
            }
            //Visual Inspection
            textBoxLotEndVisualInspectNGQty.Text = c_InputValue.LotEndVisualInspectNGQty.ToString();
            textBoxLotEndVisualInspectTotalQty.Text = c_InputValue.LotEndVisualInspectTotalQty.ToString();
            textBoxLotStartVisualInspectNGQty.Text = c_InputValue.LotStartVisualInspectNGQty.ToString();
            textBoxLotStartVisualInspectTotalQty.Text = c_InputValue.LotStartVisualInspectTotalQty.ToString();
            //ASI
            if (c_InputValue.FirstAutoAsiCheck == true)
            {
                radioButtonASI1Pass.Checked = true;
                radioButtonASI1Fail.Checked = false;
            }
            else if (c_InputValue.FirstAutoAsiCheck == false)
            {
                radioButtonASI1Pass.Checked = false;
                radioButtonASI1Fail.Checked = true;
            }
            if (c_InputValue.SecondAutoAsiCheck == true)
            {
                radioButtonASI2Pass.Checked = true;
                radioButtonASI2Fail.Checked = false;
            }
            else if (c_InputValue.SecondAutoAsiCheck == false)
            {
                radioButtonASI2Pass.Checked = false;
                radioButtonASI2Fail.Checked = true;
            }
            //CHECK DURING PRODUCTION
            if (c_InputValue.DuringProductionCheck == "A")
            {
                radioButtonDuringPDCheckA.Checked = true;
                radioButtonDuringPDCheckB.Checked = false;
                radioButtonDuringPDCheckC.Checked = false;
            }
            else if (c_InputValue.DuringProductionCheck == "B")
            {
                radioButtonDuringPDCheckA.Checked = false;
                radioButtonDuringPDCheckB.Checked = true;
                radioButtonDuringPDCheckC.Checked = false;
            }
            else if (c_InputValue.DuringProductionCheck == "C")
            {
                radioButtonDuringPDCheckA.Checked = false;
                radioButtonDuringPDCheckB.Checked = false;
                radioButtonDuringPDCheckC.Checked = true;
            }
            //SOCKET CHECK
            if (c_InputValue.SocketCheck == "A")
            {
                radioButtonSocketCheckA.Checked = true;
                radioButtonSocketCheckB.Checked = false;
                radioButtonSocketCheckC.Checked = false;
            }
            else if (c_InputValue.SocketCheck == "B")
            {
                radioButtonSocketCheckA.Checked = false;
                radioButtonSocketCheckB.Checked = true;
                radioButtonSocketCheckC.Checked = false;
            }
            else if (c_InputValue.SocketCheck == "C")
            {
                radioButtonSocketCheckA.Checked = false;
                radioButtonSocketCheckB.Checked = false;
                radioButtonSocketCheckC.Checked = true;
            }
            //GOOD AND NG INSPECTION
            textBoxGoodSampleQty.Text = c_InputValue.GoodSampleQty.ToString();
            textBoxNGSampleQty.Text = c_InputValue.NGSampleQty.ToString();
            //SOCKET CHANGE
            if (c_InputValue.SocketChange == true)
                checkBoxSocketChange.Checked = true;
            else if (c_InputValue.SocketChange == false)
                checkBoxSocketChange.Checked = false;
            textBoxSocketNumCh1.Text = c_InputValue.SocketNumCh1.ToString();
            textBoxSocketNumCh2.Text = c_InputValue.SocketNumCh2.ToString();
            textBoxSocketNumCh3.Text = c_InputValue.SocketNumCh3.ToString();
            textBoxSocketNumCh4.Text = c_InputValue.SocketNumCh4.ToString();
            textBoxChangedSocketNumCh1.Text = c_InputValue.ChangedSocketNumCh1.ToString();
            textBoxChangedSocketNumCh2.Text = c_InputValue.ChangedSocketNumCh2.ToString();
            textBoxChangedSocketNumCh3.Text = c_InputValue.ChangedSocketNumCh3.ToString();
            textBoxChangedSocketNumCh4.Text = c_InputValue.ChangedSocketNumCh4.ToString();
            //LOT JUDGEMENT
            if (c_InputValue.LotJudgement == "PASS")
            {
                radioButtonLotJudgementPass.Checked = true;
                radioButtonLotJudgementInspection.Checked = false;
                radioButtonLotJudgementLowYield.Checked = false;
                radioButtonLotJudgementOthers.Checked = false;
            }
            else if (c_InputValue.LotJudgement == "INSPECTION")
            {
                radioButtonLotJudgementPass.Checked = false;
                radioButtonLotJudgementInspection.Checked = true;
                radioButtonLotJudgementLowYield.Checked = false;
                radioButtonLotJudgementOthers.Checked = false;
            }
            else if (c_InputValue.LotJudgement == "LOW YIELD")
            {
                radioButtonLotJudgementPass.Checked = false;
                radioButtonLotJudgementInspection.Checked = false;
                radioButtonLotJudgementLowYield.Checked = true;
                radioButtonLotJudgementOthers.Checked = false;
            }
            else if (c_InputValue.LotJudgement == "OTHERS")
            {
                radioButtonLotJudgementPass.Checked = false;
                radioButtonLotJudgementInspection.Checked = false;
                radioButtonLotJudgementLowYield.Checked = false;
                radioButtonLotJudgementOthers.Checked = true;
            }
            //YIELD CHECK
            textBoxLCL.Text = c_InputValue.LCL.ToString();
            textBoxInitialYield.Text = c_InputValue.InitialYield.ToString();
            textBoxFirstEndYield.Text = c_InputValue.FirstEndYield.ToString();
            textBoxFinalYield.Text = c_InputValue.FinalYield.ToString();
            //REMARKS
            textBoxRemark.Text = c_InputValue.Remark;
            textBoxGLCheck.Text = c_InputValue.GLCheck;
        }
        MessageError CheckInputData()
        {
            //Marking Inspection
            if (radioButtonMarkingPass.Checked == false && radioButtonMarkingFail.Checked == false)
                return MessageError.MarkingInspection;
            //Test Temperature
            if (radioButtonRoom.Checked == false && radioButtonHot.Checked == false && radioButtonCold.Checked == false)
                return MessageError.TestTemperature;
            //ASI
            if (radioButtonASI1Fail.Checked == false && radioButtonASI1Pass.Checked == false)
                return MessageError.ASI;
            if (radioButtonASI2Fail.Checked == false && radioButtonASI2Pass.Checked == false)
                return MessageError.ASI;
            //DURING PRODUCTION CHECK
            if (radioButtonDuringPDCheckA.Checked == false && radioButtonDuringPDCheckB.Checked == false && radioButtonDuringPDCheckC.Checked == false)
                return MessageError.DuringProductionCheck;
            if (radioButtonSocketCheckA.Checked == false && radioButtonSocketCheckB.Checked == false && radioButtonSocketCheckC.Checked == false)
                return MessageError.SocketCheck;
            //LOT JUDGEMENT
            if (radioButtonLotJudgementPass.Checked == false && radioButtonLotJudgementInspection.Checked == false && radioButtonLotJudgementLowYield.Checked == false && radioButtonLotJudgementOthers.Checked == false)
                return MessageError.LotJudgement;
            //Quantity Adjustment
            c_InputValue.FirstGoodBin1Qty = Int16.Parse(textBoxFirstGoodBin1Qty.Text);
            c_InputValue.SecondGoodBin1Qty = Int16.Parse(textBoxSecondGoodBin1Qty.Text);
            c_InputValue.TotalGoodBin1Qty = Int16.Parse(textBoxTotalGoodBin1Qty.Text);
            c_InputValue.FirstGoodBin2Qty = Int16.Parse(textBoxFirstGoodBin2Qty.Text);
            c_InputValue.SecondGoodBin2Qty = Int16.Parse(textBoxSecondGoodBin2Qty.Text);
            c_InputValue.TotalGoodBin2Qty = Int16.Parse(textBoxTotalGoodBin2Qty.Text);
            c_InputValue.FirstNGQty = Int16.Parse(textBoxFirstNGBin6Qty.Text);
            c_InputValue.SecondNGQty = Int16.Parse(textBoxSecondNGBin6Qty.Text);
            c_InputValue.TotalNGQty = Int16.Parse(textBoxTotalNGBin6Qty.Text);
            c_InputValue.FirstNGBin7Qty = Int16.Parse(textBoxFirstNGBin7Qty.Text);
            c_InputValue.SecondNGBin7Qty = Int16.Parse(textBoxSecondNGBin7Qty.Text);
            c_InputValue.TotalNGBin7Qty = Int16.Parse(textBoxTotalNGBin7Qty.Text);
            c_InputValue.FirstMeka1Qty = Int16.Parse(textBoxFirstMeka1Qty.Text);
            c_InputValue.SecondMeka1Qty = Int16.Parse(textBoxSecondMeka1Qty.Text);
            c_InputValue.TotalMeka1Qty = Int16.Parse(textBoxTotalMeka1Qty.Text);
            c_InputValue.FirstMeka2Qty = Int16.Parse(textBoxFirstMeka2Qty.Text);
            c_InputValue.TotalMeka2Qty = Int16.Parse(textBoxTotalMeka2Qty.Text);
            c_InputValue.SecondMeka4Qty = Int16.Parse(textBoxSecondMeka4Qty.Text);
            c_InputValue.TotalMeka4Qty = Int16.Parse(textBoxTotalMeka4Qty.Text);
            c_InputValue.FirstUnknowQty = Int16.Parse(textBoxFirstUnknowQty.Text);
            c_InputValue.SecondUnknowQty = Int16.Parse(textBoxSecondUnknowQty.Text);
            c_InputValue.TotalUnknowQty = Int16.Parse(textBoxTotalUnknowQty.Text);
            c_InputValue.HandlerCounterQty = Int16.Parse(textBoxHandlerCounterQty.Text);
            c_InputValue.TesterACounterQty = Int16.Parse(textBoxTesterACounterQty.Text);
            c_InputValue.TesterBCounterQty = Int16.Parse(textBoxTesterBCounterQty.Text);
            //Marking Inspection
            if (radioButtonMarkingPass.Checked == true && radioButtonMarkingFail.Checked == false)
                c_InputValue.MarkingInspection = true;
            else if (radioButtonMarkingPass.Checked == false && radioButtonMarkingFail.Checked == true)
                c_InputValue.MarkingInspection = false;
            //Test Temprature
            if (radioButtonRoom.Checked == true && radioButtonHot.Checked == false && radioButtonCold.Checked == false)
                c_InputValue.TestTemperature = "ROOM";
            else if (radioButtonRoom.Checked == false && radioButtonHot.Checked == true && radioButtonCold.Checked == false)
                c_InputValue.TestTemperature = "HOT";
            else if (radioButtonRoom.Checked == false && radioButtonHot.Checked == false && radioButtonCold.Checked == true)
                c_InputValue.TestTemperature = "COLD";
            //Visual Inspection
            c_InputValue.LotEndVisualInspectNGQty = Int16.Parse(textBoxLotEndVisualInspectNGQty.Text);
            c_InputValue.LotEndVisualInspectTotalQty = Int16.Parse(textBoxLotEndVisualInspectTotalQty.Text);
            c_InputValue.LotStartVisualInspectNGQty = Int16.Parse(textBoxLotStartVisualInspectNGQty.Text);
            c_InputValue.LotStartVisualInspectTotalQty = Int16.Parse(textBoxLotStartVisualInspectTotalQty.Text);
            //ASI
            if (radioButtonASI1Pass.Checked == true && radioButtonASI1Fail.Checked == false)
                c_InputValue.FirstAutoAsiCheck = true;
            else if (radioButtonASI1Pass.Checked == false && radioButtonASI1Fail.Checked == true)
                c_InputValue.FirstAutoAsiCheck = false;
            if (radioButtonASI2Pass.Checked == true && radioButtonASI2Fail.Checked == false)
                c_InputValue.SecondAutoAsiCheck = true;
            else if (radioButtonASI2Pass.Checked == false && radioButtonASI2Fail.Checked == true)
                c_InputValue.SecondAutoAsiCheck = false;
            //DURING PRODUCTION CHECK
            if (radioButtonDuringPDCheckA.Checked == true && radioButtonDuringPDCheckB.Checked == false && radioButtonDuringPDCheckC.Checked == false)
                c_InputValue.DuringProductionCheck = "A";
            else if (radioButtonDuringPDCheckA.Checked == false && radioButtonDuringPDCheckB.Checked == true && radioButtonDuringPDCheckC.Checked == false)
                c_InputValue.DuringProductionCheck = "B";
            else if (radioButtonDuringPDCheckA.Checked == false && radioButtonDuringPDCheckB.Checked == false && radioButtonDuringPDCheckC.Checked == false)
                c_InputValue.DuringProductionCheck = "C";
            //SOCKET CHECK
            if (radioButtonSocketCheckA.Checked == true && radioButtonSocketCheckB.Checked == false && radioButtonSocketCheckC.Checked == false)
                c_InputValue.SocketCheck = "A";
            else if (radioButtonSocketCheckA.Checked == false && radioButtonSocketCheckB.Checked == true && radioButtonSocketCheckC.Checked == false)
                c_InputValue.SocketCheck = "B";
            if (radioButtonSocketCheckA.Checked == false && radioButtonSocketCheckB.Checked == false && radioButtonSocketCheckC.Checked == false)
                c_InputValue.SocketCheck = "C";
            //GOOD AND NG INSPECTION
            c_InputValue.GoodSampleQty = Int16.Parse(textBoxGoodSampleQty.Text);
            c_InputValue.NGSampleQty = Int16.Parse(textBoxNGSampleQty.Text);
            //SOCKET CHANGE
            if (checkBoxSocketChange.Checked == true)
                c_InputValue.SocketChange = true;
            else
                c_InputValue.SocketChange = false;
            c_InputValue.SocketNumCh1 = textBoxSocketNumCh1.Text;
            c_InputValue.SocketNumCh2 = textBoxSocketNumCh2.Text;
            c_InputValue.SocketNumCh3 = textBoxSocketNumCh3.Text;
            c_InputValue.SocketNumCh4 = textBoxSocketNumCh4.Text;
            c_InputValue.ChangedSocketNumCh1 = textBoxChangedSocketNumCh1.Text;
            c_InputValue.ChangedSocketNumCh2 = textBoxChangedSocketNumCh2.Text;
            c_InputValue.ChangedSocketNumCh3 = textBoxChangedSocketNumCh3.Text;
            c_InputValue.ChangedSocketNumCh4 = textBoxChangedSocketNumCh4.Text;
            //LOT JUDGEMENT
            if (radioButtonLotJudgementPass.Checked == true && radioButtonLotJudgementInspection.Checked == false && radioButtonLotJudgementLowYield.Checked == false && radioButtonLotJudgementOthers.Checked == false)
                c_InputValue.LotJudgement = "PASS";
            else if (radioButtonLotJudgementPass.Checked == false && radioButtonLotJudgementInspection.Checked == true && radioButtonLotJudgementLowYield.Checked == false && radioButtonLotJudgementOthers.Checked == false)
                c_InputValue.LotJudgement = "INSPECTION";
            else if (radioButtonLotJudgementPass.Checked == false && radioButtonLotJudgementInspection.Checked == false && radioButtonLotJudgementLowYield.Checked == true && radioButtonLotJudgementOthers.Checked == false)
                c_InputValue.LotJudgement = "LOW YIELD";
            else if (radioButtonLotJudgementPass.Checked == false && radioButtonLotJudgementInspection.Checked == false && radioButtonLotJudgementLowYield.Checked == false && radioButtonLotJudgementOthers.Checked == true)
                c_InputValue.LotJudgement = "OTHERS";
            //YIELD CHECK
            c_InputValue.LCL = Int16.Parse(textBoxLCL.Text);
            c_InputValue.InitialYield = Int16.Parse(textBoxInitialYield.Text);
            c_InputValue.FirstEndYield = Int16.Parse(textBoxFirstEndYield.Text);
            c_InputValue.FinalYield = Int16.Parse(textBoxFinalYield.Text);
            //REMARKS
            c_InputValue.Remark = textBoxRemark.Text;
            c_InputValue.GLCheck = textBoxGLCheck.Text;
            return MessageError.NotError;
        }
        private void pictureBoxOk_Click(object sender, EventArgs e)
        {
            MessageError result = CheckInputData();
            if (result == MessageError.NotError)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Please Check Input >>" + result.ToString());
        }
        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void checkBoxSocketChange_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSocketChange.Checked == true)
            {
                textBoxChangedSocketNumCh1.Enabled = true;
                textBoxChangedSocketNumCh2.Enabled = true;
                textBoxChangedSocketNumCh3.Enabled = true;
                textBoxChangedSocketNumCh4.Enabled = true;
            }
            else if (checkBoxSocketChange.Checked == false)
            {
                textBoxChangedSocketNumCh1.Enabled = false;
                textBoxChangedSocketNumCh2.Enabled = false;
                textBoxChangedSocketNumCh3.Enabled = false;
                textBoxChangedSocketNumCh4.Enabled = false;
            }
        }
    }
}
