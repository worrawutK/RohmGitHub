using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Rohm.Common.Forms
{
    public partial class NumPadControl : Form
    {
        string c_FormName;
        public NumPadControl(string formName)
        {
            InitializeComponent();
            Interaction.AppActivate(formName);
            c_FormName = formName;
        }
        public void SetStartPosition(int xPos, int yPos)
        {
            this.Location = new Point(xPos, yPos);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Interaction.AppActivate(c_FormName);
            switch (bt.Text)
            {
                case "Del":
                    System.Windows.Forms.SendKeys.Send("{BS}");
                    break;
                case "/":
                    System.Windows.Forms.SendKeys.Send("{DIVIDE}");
                    break;
                case "*":
                    System.Windows.Forms.SendKeys.Send("{MULTIPLY}");
                    break;
                case "-":
                    System.Windows.Forms.SendKeys.Send("{SUBTRACT}");
                    break;
                case "+":
                    System.Windows.Forms.SendKeys.Send("{ADD}");
                    break;
                case "Ent":
                    System.Windows.Forms.SendKeys.Send("{ENTER}");
                    break;
                default:
                    System.Windows.Forms.SendKeys.Send(bt.Text);
                    break;
            }
            //if (bt.Text == "Del")
            //{
            //    System.Windows.Forms.SendKeys.Send("{BS}");
            //}
            //else
            //{
            //    System.Windows.Forms.SendKeys.Send(bt.Text);
            //}
        }
    }
}
