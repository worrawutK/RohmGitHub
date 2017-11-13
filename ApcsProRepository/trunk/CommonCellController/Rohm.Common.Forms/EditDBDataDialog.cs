using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Rohm.Common.Model;
namespace Rohm.Common.Forms
{
    public partial class EditDBDataDialog : Form
    {
        NumPadControl c_numPad;
        public DBData c_InputValue;
        public DBData InputValue
        {
            get
            {
                return c_InputValue;
            }
        }

        public EditDBDataDialog(DBData dbInputValue)
        {
            c_InputValue = dbInputValue;
            InitializeComponent();
            InitialNozzleTypeComboBoxItems();

            CheckMachineOfKind();
            QueryLotInfoFromDenpyoPrint();
            UpdateDisplayTemplate();
        }
        void UpdateDisplayTemplate()
        {
            labelMCNo.Text = c_InputValue.MCNo;
            labelLotNo.Text = c_InputValue.LotNo;
            labelOpNoStart.Text = c_InputValue.OPNo;

            labelGoodPcs.Text = c_InputValue.TotalGood.ToString();
            labelInputPcs.Text = c_InputValue.InputQty.ToString();
            labelNgPcs.Text = c_InputValue.TotalNG.ToString();

            labelStartTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", c_InputValue.LotStartTime);
            labelEndTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", c_InputValue.LotEndTime);

            labelOpNoEnd.Text = c_InputValue.OPCheck;

        }
        void CheckMachineOfKind()
        {
            switch (c_InputValue.PasteType)
            {
                case (DBData.DBPasteType.Preform):
                    groupBoxNozzle.Enabled = true;
                    groupBoxChipSizeX.Enabled = false;
                    groupBoxChipSizeY.Enabled = false;
                    break;
                case (DBData.DBPasteType.Solder):
                    groupBoxNozzle.Enabled = false;
                    groupBoxChipSizeX.Enabled = true;
                    groupBoxChipSizeY.Enabled = true;
                    break;
            }

            //Select Form First /Final
            if (c_InputValue.LotStartTime == null && c_InputValue.LotEndTime == null)
            {
                tabControlDBInsp.SelectedIndex = 0;
                panelFirst.Enabled = true;
                panelFinal.Enabled = false;
            }
            else
            {
                tabControlDBInsp.SelectedIndex = 1;
                panelFirst.Enabled = false;
                panelFinal.Enabled = true;
                GetInputFinalForm();
            }
        }

        void InitialNozzleTypeComboBoxItems()
        {
            comboBoxPasteNozzleType.Items.Clear();
            comboBoxPasteNozzleType.Items.Add("Single");
            comboBoxPasteNozzleType.Items.Add("Dual");
            comboBoxPasteNozzleType.Items.Add("Stamp Nozzle");
            comboBoxPasteNozzleType.Items.Add("Mullti Nozzle");
            comboBoxPasteNozzleType.Items.Add("Accurate");
            comboBoxPasteNozzleType.Items.Add("");
        }


        void InitialNozzleNoComboBoxItems()
        {
            comboBoxPastNozzleNo.Items.Clear();
            comboBoxPastNozzleNo.Text = "";
            switch (comboBoxPasteNozzleType.Text)
            {
                case "Single":
                    comboBoxPastNozzleNo.Items.Add("S1");
                    comboBoxPastNozzleNo.Items.Add("S2");
                    comboBoxPastNozzleNo.Items.Add("S3");
                    comboBoxPastNozzleNo.Items.Add("S4");
                    comboBoxPastNozzleNo.Items.Add("");
                    break;
                case "Dual":
                    comboBoxPastNozzleNo.Items.Add("T1");
                    comboBoxPastNozzleNo.Items.Add("T2");
                    comboBoxPastNozzleNo.Items.Add("");
                    break;
                case "Stamp Nozzle":
                    comboBoxPastNozzleNo.Items.Add("X1");
                    comboBoxPastNozzleNo.Items.Add("X2");
                    comboBoxPastNozzleNo.Items.Add("X3");
                    comboBoxPastNozzleNo.Items.Add("X4");
                    comboBoxPastNozzleNo.Items.Add("X5");
                    comboBoxPastNozzleNo.Items.Add("");
                    break;
                case "Mullti Nozzle":
                    comboBoxPastNozzleNo.Items.Add("M1");
                    comboBoxPastNozzleNo.Items.Add("M2");
                    comboBoxPastNozzleNo.Items.Add("M3");
                    comboBoxPastNozzleNo.Items.Add("M4");
                    comboBoxPastNozzleNo.Items.Add("M5");
                    comboBoxPastNozzleNo.Items.Add("M6");
                    comboBoxPastNozzleNo.Items.Add("M7");
                    comboBoxPastNozzleNo.Items.Add("M8");
                    comboBoxPastNozzleNo.Items.Add("M9");
                    comboBoxPastNozzleNo.Items.Add("M10");
                    comboBoxPastNozzleNo.Items.Add("M11");
                    comboBoxPastNozzleNo.Items.Add("M12");
                    comboBoxPastNozzleNo.Items.Add("M13");
                    comboBoxPastNozzleNo.Items.Add("M14");
                    comboBoxPastNozzleNo.Items.Add("M15");
                    comboBoxPastNozzleNo.Items.Add("M16");
                    comboBoxPastNozzleNo.Items.Add("M17");
                    comboBoxPastNozzleNo.Items.Add("M18");
                    comboBoxPastNozzleNo.Items.Add("M19");
                    comboBoxPastNozzleNo.Items.Add("M20");
                    comboBoxPastNozzleNo.Items.Add("M21");
                    comboBoxPastNozzleNo.Items.Add("M22");
                    comboBoxPastNozzleNo.Items.Add("M23");
                    comboBoxPastNozzleNo.Items.Add("M24");
                    comboBoxPastNozzleNo.Items.Add("M25");
                    comboBoxPastNozzleNo.Items.Add("");
                    break;
                case "Accurate":
                    comboBoxPastNozzleNo.Items.Add("0.15");
                    comboBoxPastNozzleNo.Items.Add("0.20");
                    comboBoxPastNozzleNo.Items.Add("0.25");
                    comboBoxPastNozzleNo.Items.Add("SHN-0.15");
                    comboBoxPastNozzleNo.Items.Add("SHN-0.20");
                    comboBoxPastNozzleNo.Items.Add("");
                    break;
            }
        }

        private void comboBoxPasteNozzleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitialNozzleNoComboBoxItems();
        }

        private void CalCulateThickness()
        {
            int[] ThicknessArray = new int[4];

            if (isNumber(textboxThickness1.Text) == true)
            {
                ThicknessArray[0] = int.Parse(textboxThickness1.Text);
            }
            else
            {
                ThicknessArray[0] = 0;
            }


            if (isNumber(textboxThickness2.Text) == true)
            {
                ThicknessArray[1] = int.Parse(textboxThickness2.Text);
            }
            else
            {
                ThicknessArray[1] = 0;
            }


            if (isNumber(textboxThickness3.Text) == true)
            {
                ThicknessArray[2] = int.Parse(textboxThickness3.Text);
            }
            else
            {
                ThicknessArray[2] = 0;
            }

            if (isNumber(textboxThickness4.Text) == true)
            {
                ThicknessArray[3] = int.Parse(textboxThickness4.Text);
            }
            else
            {
                ThicknessArray[3] = 0;
            }


            int arrayMax = ThicknessArray.Max();
            int arrayMin = ThicknessArray.Min();
            double avr;
            textboxThicknessR.Text = (arrayMax - arrayMin).ToString();

            avr = (ThicknessArray.Sum() / 4);

            textboxThicknessAver.Text = Math.Round(avr, 2).ToString();


        }

        void SetParameterFirstInsp()
        {
            c_InputValue.TsukaigeNeedNo = Int16.Parse(textboxTsukaigeNeedNo.Text);
            c_InputValue.TsukiageStrock = Int16.Parse(textboxTsukaigePinStrock.Text);
            c_InputValue.RubberColletNo = Int16.Parse(textboxRubberColletNo.Text);

            if (textboxChipSizeX.Text != "")
            {
                c_InputValue.Chipsize1 = Int16.Parse(textboxChipSizeX.Text);
            }

            if (textboxChipSizeY.Text != "")
            {
                c_InputValue.Chipsize2 = Int16.Parse(textboxChipSizeY.Text);
            }

            if (comboBoxPasteNozzleType.Text != "")
            {
                c_InputValue.PasteNozzleType = comboBoxPasteNozzleType.Text;
            }

            if (comboBoxPastNozzleNo.Text != "")
            {
                c_InputValue.PateNozzleNo = comboBoxPastNozzleNo.Text;
            }
            if (textboxTsukaigePinStrock.Text != "")
            {
                c_InputValue.TsukiageStrock = Int16.Parse(textboxTsukaigePinStrock.Text);
            }
            if (radiobuttonRubberCheckA.Checked == true)
            {
                c_InputValue.RubberCondition = "A";
            }
            else if (radiobuttonRubberCheckB.Checked == true)
            {
                c_InputValue.RubberCondition = "B";
            }
            else if (radiobuttonRubberCheckC.Checked == true)
            {
                c_InputValue.RubberCondition = "C";
            }

            if (radiobuttonBlockChcekA.Checked == true)
            {
                c_InputValue.BlockCheck = "A";
            }
            else if (radiobuttonBlockChcekB.Checked == true)
            {
                c_InputValue.BlockCheck = "B";
            }
            else if (radiobuttonBlockChcekC.Checked == true)
            {
                c_InputValue.BlockCheck = "C";
            }

            if (radiobuttonPasteNozzleA.Checked == true)
            {
                c_InputValue.PasteNozzleCond = "A";
            }
            else if (radiobuttonPasteNozzleB.Checked == true)
            {
                c_InputValue.PasteNozzleCond = "B";
            }
            else if (radiobuttonPasteNozzleC.Checked == true)
            {
                c_InputValue.PasteNozzleCond = "C";
            }

            if (radiobuttonTsukaigeA.Checked == true)
            {
                c_InputValue.TsukaigeCheck = "A";
            }
            else if (radiobuttonTsukaigeB.Checked == true)
            {
                c_InputValue.TsukaigeCheck = "B";
            }
            else if (radiobuttonTsukaigeC.Checked == true)
            {
                c_InputValue.TsukaigeCheck = "C";
            }

            if (c_InputValue.PasteType == DBData.DBPasteType.Preform)
            {
                if (textboxThickness1.Text != "" && isNumber(textboxThickness1.Text) == true)
                {
                    c_InputValue.PreformThickness1 = Int16.Parse(textboxThickness1.Text);
                }

                if (textboxThickness2.Text != "" && isNumber(textboxThickness2.Text) == true)
                {
                    c_InputValue.PreformThickness2 = Int16.Parse(textboxThickness2.Text);
                }

                if (textboxThickness3.Text != "" && isNumber(textboxThickness3.Text) == true)
                {
                    c_InputValue.PreformThickness3 = Int16.Parse(textboxThickness3.Text);
                }

                if (textboxThickness4.Text != "" && isNumber(textboxThickness4.Text) == true)
                {
                    c_InputValue.PreformThickness4 = Int16.Parse(textboxThickness4.Text);
                }

                if (textboxThicknessAver.Text != "" && isNumber(textboxThicknessAver.Text) == true)
                {
                    c_InputValue.PreformThicknessAvg = Int16.Parse(textboxThicknessAver.Text);
                }

                if (textboxThicknessR.Text != "" && isNumber(textboxThicknessR.Text) == true)
                {
                    c_InputValue.PreformThicknessR = Int16.Parse(textboxThicknessR.Text);
                }
            }
            else
            {
                if (textboxThickness1.Text != "" && isNumber(textboxThickness1.Text) == true)
                {
                    c_InputValue.SolderThickness1 = Int16.Parse(textboxThickness1.Text);
                }
                if (textboxThickness2.Text != "" && isNumber(textboxThickness2.Text) == true)
                {
                    c_InputValue.SolderThickness2 = Int16.Parse(textboxThickness2.Text);
                }
                if (textboxThickness3.Text != "" && isNumber(textboxThickness3.Text) == true)
                {
                    c_InputValue.SolderThickness3 = Int16.Parse(textboxThickness3.Text);
                }
                if (textboxThickness4.Text != "" && isNumber(textboxThickness4.Text) == true)
                {
                    c_InputValue.SolderThickness4 = Int16.Parse(textboxThickness4.Text);
                }
                if (textboxThicknessAver.Text != "" && isNumber(textboxThicknessAver.Text) == true)
                {
                    c_InputValue.SolderThicknessAvg = Int16.Parse(textboxThicknessAver.Text);
                }
                if (textboxThicknessR.Text != "" && isNumber(textboxThicknessR.Text) == true)
                {
                    c_InputValue.PreformThicknessR = Int16.Parse(textboxThicknessR.Text);
                }
            }

        }

        void SetParameterFinalInsp()
        {
            c_InputValue.AlarmBonder = Int16.Parse(textboxAlmBonder.Text);
            c_InputValue.AlarmBridgeInsp = Int16.Parse(textboxAlmBridgeInsp.Text);
            c_InputValue.AlarmFrameOut = Int16.Parse(textboxAlmFrameOut.Text);
            c_InputValue.AlarmPickUp = Int16.Parse(textboxAlmPickup.Text);
            c_InputValue.AlarmPreform = Int16.Parse(textboxAlmPreform.Text);
            c_InputValue.AlarmPreformInsp = Int16.Parse(textboxAlmPreformInsp.Text);

            c_InputValue.InputQtyAdjust = Int32.Parse(textboxInputQty.Text);
            c_InputValue.TotalGoodAdjust = Int32.Parse(textboxGoodQty.Text);
            c_InputValue.TotalNGAdjust = Int32.Parse(textboxNGQty.Text);
            c_InputValue.NoChipQTY = Int16.Parse(textboxNoChip.Text);

            if (textboxDoubleFrame.Text != "")
            {
                c_InputValue.DoubleFrame = Int16.Parse(textboxDoubleFrame.Text);
            }
            if (textboxFrameBent.Text != "")
            {
                c_InputValue.FrameBent = Int16.Parse(textboxFrameBent.Text);
            }
            if (textboxFrameBurn.Text != "")
            {
                c_InputValue.FrameBurn = Int16.Parse(textboxFrameBurn.Text);
            }
            if (textboxBondingNG.Text != "")
            {
                c_InputValue.BondingNG = Int16.Parse(textboxBondingNG.Text);
            }

        }

        bool CheckFirstFormData(DBData.DBPasteType machineType)
        {
            if (textboxRubberColletNo.Text == "")
            {
                toolStripLabelMessage.Text = "กรุณากรอก Rubber Collet No.";
                return false;
            }
            else if (isNumber(textboxRubberColletNo.Text) == false)
            {
                toolStripLabelMessage.Text = "กรุณากรอก Rubber Collet No.ไม่ถูกต้อง กรุณาตรวจสอบ";
                return false;
            }
            else if (textboxTsukaigeNeedNo.Text == "")
            {
                toolStripLabelMessage.Text = "กรุณากรอก Tsukaige No.";
                return false;
            }
            else if (textboxTsukaigePinStrock.Text == "")
            {
                toolStripLabelMessage.Text = "กรุณากรอก Tsukaige Pin Strock";
                return false;
            }
            else if (isNumber(textboxTsukaigePinStrock.Text) == false)
            {
                toolStripLabelMessage.Text = "กรุณากรอก Tsukaige Pin Strock ไม่ถูกต้อง";
                return false;
            }
            else if (isNumber(textboxTsukaigeNeedNo.Text) == false)
            {
                toolStripLabelMessage.Text = "กรุณากรอก Tsukaige No. ไม่ถูกต้องกรุณาตรวจสอบ";
                return false;
            }
            if (radiobuttonBlockChcekA.Checked == false && radiobuttonBlockChcekB.Checked == false && radiobuttonBlockChcekC.Checked == false)
            {
                toolStripLabelMessage.Text = "กรุณาเลือกโหมด Block check";
                return false;
            }
            else if (radiobuttonTsukaigeA.Checked == false && radiobuttonTsukaigeB.Checked == false && radiobuttonTsukaigeC.Checked == false)
            {
                toolStripLabelMessage.Text = "กรุณาเลือกโหมด Tsukaige condition";
                return false;
            }
            else if (radiobuttonRubberCheckA.Checked == false && radiobuttonRubberCheckB.Checked == false && radiobuttonRubberCheckC.Checked == false)
            {
                toolStripLabelMessage.Text = "กรุณาเลือกโหมด Rubber Check";
                return false;
            }

            if (machineType == DBData.DBPasteType.Solder)
            {
                //  ChipSize
                if (textboxChipSizeX.Text == "" || isNumber(textboxChipSizeX.Text) == false)
                {
                    toolStripLabelMessage.Text = "กรุณากรอก ChipSize X";
                    return false;
                }
                else if (textboxChipSizeY.Text == "" || isNumber(textboxChipSizeY.Text) == false)
                {
                    toolStripLabelMessage.Text = "กรุณากรอก ChipSize Y";
                    return false;
                }
            }
            else
            {
                if (comboBoxPasteNozzleType.Text == "")
                {
                    toolStripLabelMessage.Text = "กรุณาเลือก NozzleType";
                    return false;
                }
                else if (comboBoxPastNozzleNo.Text == "")
                {
                    toolStripLabelMessage.Text = "กรุณาเลือก NozzleNo";
                    return false;
                }
                else if (radiobuttonPasteNozzleA.Checked == false && radiobuttonPasteNozzleB.Checked == false && radiobuttonPasteNozzleC.Checked == false)
                {
                    toolStripLabelMessage.Text = "กรุณาเลือกโหมด Nozzle";
                    return false;
                }
            }
            toolStripLabelMessage.Text = "";
            return true;
        }


        bool isNumber(string txt)
        {
            double num;
            return double.TryParse(txt, out num);
        }

        private void EditDBDataDialog_Load(object sender, EventArgs e)
        {
            toolStripLabelMessage.Text = "";
        }

        //enum  MCType {
        //    Preform = 1,
        //    Solder = 2
        //};


        private void ComboBoxPasteNozzleType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            InitialNozzleNoComboBoxItems();
        }

        public void GetInputFinalForm()
        {
            textboxInputQty.Text = c_InputValue.InputQty.ToString();
            textboxGoodQty.Text = c_InputValue.TotalGood.ToString();
            textboxNGQty.Text = "";

            textboxAlmBonder.Text = c_InputValue.AlarmBonder.ToString();
            textboxAlmBridgeInsp.Text = c_InputValue.AlarmBridgeInsp.ToString();
            textboxAlmFrameOut.Text = c_InputValue.AlarmFrameOut.ToString();
            textboxAlmPickup.Text = c_InputValue.AlarmPickUp.ToString();
            textboxAlmPreform.Text = c_InputValue.AlarmPreform.ToString();
            textboxAlmPreformInsp.Text = c_InputValue.AlarmPreformInsp.ToString();

        }
        bool CheckFinalFormData()
        {
            if (textboxAlmBonder.Text == "" || textboxAlmBridgeInsp.Text == "" || textboxAlmFrameOut.Text == "" || textboxAlmPickup.Text == "" || textboxAlmPreform.Text == "" || textboxAlmPreformInsp.Text == "")
            {
                toolStripLabelMessage.Text = "กรุณากรอก Alarm Major ให้ครบ";
                return false;
            }
            else if (isNumber(textboxAlmBonder.Text) == false || isNumber(textboxAlmBridgeInsp.Text) == false || isNumber(textboxAlmFrameOut.Text) == false || isNumber(textboxAlmPickup.Text) == false || isNumber(textboxAlmPreform.Text) == false || isNumber(textboxAlmPreformInsp.Text) == false)
            {
                toolStripLabelMessage.Text = "กรุณากรอก Alarm Major ไม่ถูกต้องกรุณาตรวจสอบ";
                return false;
            }
            else if (textboxInputQty.Text == "" || textboxGoodQty.Text == "" || textboxNGQty.Text == "" || textboxNoChip.Text == "")
            {
                toolStripLabelMessage.Text = "กรุณากรอก จำนวนงานให้ครบ";
                return false;
            }
            else if (isNumber(textboxInputQty.Text) == false || isNumber(textboxGoodQty.Text) == false || isNumber(textboxNGQty.Text) == false || isNumber(textboxNoChip.Text) == false)
            {
                toolStripLabelMessage.Text = "กรุณากรอก จำนวนงานไม่ถูกต้อง";
                return false;
            }
            else if (textboxDoubleFrame.Text != "" && isNumber(textboxDoubleFrame.Text) == false)
            {
                toolStripLabelMessage.Text = "กรุณากรอก จำนวน Double Frame ไม่ถูกต้อง";
                return false;
            }
            else if (textboxFrameBent.Text != "" && isNumber(textboxFrameBent.Text) == false)
            {
                toolStripLabelMessage.Text = "กรุณากรอกจำนวน Frame Bent ไม่ถูกต้อง";
                return false;
            }
            else if (textboxFrameBurn.Text != "" && isNumber(textboxFrameBurn.Text) == false)
            {
                toolStripLabelMessage.Text = "กรุณากรอกจำนวน Frame Burn ไม่ถูกต้อง";
                return false;
            }
            else if (textboxBondingNG.Text != "" && isNumber(textboxBondingNG.Text) == false)
            {
                toolStripLabelMessage.Text = "กรุณากรอกจำนวน Bonding NG ไม่ถูกต้อง";
                return false;
            }

            return true;

        }
        void QueryLotInfoFromDenpyoPrint()
        {
            string connection = "Data Source=172.16.0.102;Initial Catalog=APCSDB;Persist Security Info=True;User ID=apcsdbuser";
            SqlConnection sqlConnection1 = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            string commandText = "SELECT RUBBER_NO AS RubberNo, MANU_COND_CHIP_SIZE_1 AS ChipSizeX, MANU_COND_CHIP_SIZE_2 AS ChipSizeY, PIN_NO AS TsukaigeNo FROM LCQW_UNION_WORK_DENPYO_PRINT WHERE (LOT_NO_1 =" + "'" + c_InputValue.LotNo + "'" + ")";

            cmd.CommandText = commandText;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            if (reader.HasRows != false)
            {
                reader.Read();
                textboxRubberColletNo.Text = reader.GetString(0);
                textboxChipSizeX.Text = reader.GetString(1);
                textboxChipSizeY.Text = reader.GetString(2);
                textboxTsukaigeNeedNo.Text = reader.GetString(3);
            }
            sqlConnection1.Close();
        }


        private void textboxThickness1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CalCulateThickness();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panelFirst.Enabled == true)
            {
                if (CheckFirstFormData(c_InputValue.PasteType) == false)
                {
                    toolStripInfo.BackColor = Color.Yellow;
                }
                else
                {
                    SetParameterFirstInsp();
                    toolStripInfo.BackColor = DefaultBackColor;
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (CheckFinalFormData() == false)
                {
                    toolStripInfo.BackColor = Color.Yellow;
                }
                else
                {
                    SetParameterFinalInsp();
                    toolStripInfo.BackColor = DefaultBackColor;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (CheckFirstFormData(c_InputValue.PasteType) == false)
            {
                toolStripInfo.BackColor = Color.Yellow;
            }
            else
            {
                SetParameterFirstInsp();
                toolStripInfo.BackColor = DefaultBackColor;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void textboxChipSizeX_Click(object sender, EventArgs e)
        {
            if (c_numPad == null)
            {
                c_numPad = new NumPadControl(this.Name);
            }
            else if (c_numPad.IsDisposed == true)
            {
                c_numPad = new NumPadControl(this.Name);
            }
            if (c_numPad.Visible == false)
            {
                c_numPad.Show();
            }
        }




    }



}


