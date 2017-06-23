using System;
using System.Drawing;
using System.Windows.Forms;
using Gogogo.Helper;

namespace Gogogo.Forms.LoginForms
{
    public partial class LoginForm : BaseForm
    {
        public LoginForm()
        {
            InitializeComponent();
            nameTextBox.Text = Properties.Settings.Default.AccountId;
            passwordTextBox.Text = Properties.Settings.Default.Password;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (TextBoxNotValid(nameTextBox, nameLabel, 0)
                || TextBoxNotValid(nameTextBox, nameLabel, 0))
            {
                return;
            }

            Properties.Settings.Default.AccountId = nameTextBox.Text;
            Properties.Settings.Default.Password = passwordTextBox.Text;
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //enter
            {
                loginButton_Click(null, null);
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }
    }
}
