using System;
using System.Drawing;
using System.Windows.Forms;
using Gogogo.Instances;
using Gogogo.StaticData;

namespace Gogogo.Forms.LoginForms
{
    public partial class RegistForm : BaseForm
    {
        public RegistForm()
        {
            InitializeComponent();
        }

        private void registButton_Click(object sender, EventArgs e)
        {
            if (TextBoxNotValid(nameTextBox, nameLabel, 12) 
                || TextBoxNotValid(passwordTextBox, passwordLabel, 20))
            {
                return;
            }
            if (passwordTextBox.Text != confirmTextBox.Text)
            {
                MessageBox.Show(@"两次密码不一致");
                passwordTextBox.BackColor = GlobalStatic.InvalidBackColor;
                confirmTextBox.BackColor = GlobalStatic.InvalidBackColor;
                return;
            }
            TcpInstance.Instance.Socket.SendMethod.Regist(
                nameTextBox.Text,
                passwordTextBox.Text);
            DialogResult = DialogResult.OK;
        }

        private void confirmTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //enter
            {
                registButton_Click(null, null);
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }
    }
}
