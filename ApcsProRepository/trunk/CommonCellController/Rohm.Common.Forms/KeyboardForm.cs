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
    public partial class KeyboardForm : Form
    {
        private string c_FormName;
        private bool c_IsUpper = true;
        public void SetFormPosition(int xPosition,int yPosition)
        {
            this.Location = new Point(xPosition, yPosition);
        }
        public KeyboardForm(string formName,Boolean isUpperCase)
        {
            InitializeComponent();
            c_FormName = formName;
            c_IsUpper = isUpperCase;
            SetUpperCaseText();
        }

        private void SetUpperCaseText()
        {
            if (c_IsUpper)
            {
                c_IsUpper = false;
                buttonShift.BackColor = Color.White;
                Button btn;
                foreach (Control ctrl in this.Controls)
                {
                    btn = ctrl as Button;
                    if (btn != null)
                    {
                        if (btn.Name == "buttonLanguage" || btn.Name == "buttonNumpad"
                            || btn.Name == "buttonSpace" || btn.Name == "buttonReturn")
                        {
                            
                        }
                        else
                        {
                            btn.Text = btn.Text.ToUpper();
                        }
                    }   
                }
            }
            else
            {
                c_IsUpper = true;
                buttonShift.BackColor = Color.Silver;
                Button btn;
                foreach (Control ctrl in this.Controls)
                {
                    btn = ctrl as Button;
                    if (btn != null)
                    {
                        if (btn.Name == "buttonLanguage" || btn.Name == "buttonNumpad"
                              || btn.Name == "buttonSpace" || btn.Name == "buttonReturn")
                        {
                           
                        }
                        else
                        {
                            btn.Text = btn.Text.ToLower();
                        }
                    }
                }
            } // if (c_IsUpper)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Interaction.AppActivate(c_FormName);
            switch (bt.Name)
            {
                case "buttonLanguage":
                    MessageBox.Show("Coming soon");
                    break;
                case "buttonNumpad":
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Name == "NumPadControl")
                        {
                            return;
                        }
                    }
                    NumPadControl numPad = new NumPadControl(c_FormName);
                    numPad.Show();
                    break;
                case "buttonSpace":
                    System.Windows.Forms.SendKeys.Send(" ");
                    break;
                case "buttonReturn":
                    System.Windows.Forms.SendKeys.Send("{ENTER}");
                    break;
                case "buttonShift":
                    SetUpperCaseText();
                    break;
                case "buttonBackSpace":
                    System.Windows.Forms.SendKeys.Send("{BS}");
                    break;
                default:
                    System.Windows.Forms.SendKeys.Send(bt.Text);
                    break;
            }
        }

        private void KeyboardForm_Shown(object sender, EventArgs e)
        {
            //if (c_Xpos != 0 && c_Ypos != 0)
            //{
            //    this.Location = new Point(c_Xpos, c_Ypos);
            //}
        }

    }
}
