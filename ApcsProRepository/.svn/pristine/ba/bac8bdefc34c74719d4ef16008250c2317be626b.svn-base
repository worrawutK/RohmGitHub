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
    public partial class InputUserPasswordDialog : Form
    {
        private User c_InputValue;
        public User InputValue
        {
            get { return c_InputValue; }
            set { c_InputValue = value; }
        }
        public InputUserPasswordDialog()
        {
            InitializeComponent();
        }

        private void InputUserPasswordDialog_Shown(object sender, EventArgs e)
        {
            textBoxUserCode.Focus();
            textBoxUserCode.Text = "UserName";
            textBoxPassword.Text = "Password";
            textBoxUserCode.ForeColor = Color.LightGray;
            textBoxPassword.ForeColor = Color.LightGray;
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
                textBoxPassword.Focus();
            }
        }

        private void textBoxUserCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxUserCode.Text == "")
            {
                textBoxUserCode.ForeColor = Color.LightGray;
                textBoxUserCode.Text = "UserName";
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxPassword.Text == "Password")
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.Black;
                pictureBoxEyePassword.Visible = true;
                //textBoxPassword.UseSystemPasswordChar = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }

        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                //textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.ForeColor = Color.LightGray;
                textBoxPassword.Text = "Password";
                pictureBoxEyePassword.Visible = false;
            }
        }

        private void pictureBoxEyePassword_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
        }

        private void pictureBoxEyePassword_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                UserRepository db = new UserRepository();
                c_InputValue = db.GetUserBy(textBoxUserCode.Text, textBoxPassword.Text);
                if (c_InputValue != null)
                {
                    labelFirstName.Text = c_InputValue.FirstName;
                    labelLastName.Text = c_InputValue.LastName;
                    labelMessage.Text = "";
                    this.DialogResult = DialogResult.OK;
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

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
