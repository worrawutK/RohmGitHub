using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rohm.Common.Model;
using Rohm.DataAccess;

namespace Rohm.Common.Forms
{
    public partial class InputUserCodeDialog : Form
    {
        private User c_InputValue;
        public User InputValue
        {
            get { return c_InputValue; }
            set { c_InputValue = value; }
        }

        public InputUserCodeDialog()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InputUserCodeDialog_Shown(object sender, EventArgs e)
        {
            textBoxUserCode.Focus();
            textBoxUserCode.Text = "UserName";
        }

        private void InputUserCodeDialog_Load(object sender, EventArgs e)
        {
            textBoxUserCode.Focus();
        }

        private void pnlUser_Click(object sender, EventArgs e)
        {
            textBoxUserCode.Focus();
        }

        private void textBoxUserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxUserCode.Text == "UserName") 
            {
                textBoxUserCode.Text = "";
                textBoxUserCode.ForeColor = Color.Black;
            }
     
            if (e.KeyCode == Keys.Enter)
            {
                //c_UserCode = new User();
                try
                {
                    UserRepository userRespones = new UserRepository();
                    c_InputValue = userRespones.GetUserBy(textBoxUserCode.Text);
                    if (c_InputValue != null)
                    {
                        labelFirstName.Text = c_InputValue.FirstName;
                        labelLastName.Text = c_InputValue.LastName;
                        labelMessage.Text = "";
                    }
                    else
                    {
                        labelMessage.Text = "Not found user";
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = ex.Message;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void textBoxUserCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxUserCode.Text == "")
            {
                textBoxUserCode.ForeColor = Color.LightGray;
                textBoxUserCode.Text = "UserName";
            }
        }

     

      

    }
}
