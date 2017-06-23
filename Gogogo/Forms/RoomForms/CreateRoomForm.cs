using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gogogo.Forms.RoomForms
{
    public partial class CreateRoomForm : BaseForm
    {
        public CreateRoomForm()
        {
            InitializeComponent();
        }

        private void createRoomButton_Click(object sender, EventArgs e)
        {
            if (TextBoxNotValid(nameTextBox, nameLabel, 4) 
                || TextBoxNotValid(passwordTextBox, passwordCheckBox, 12, passwordCheckBox.Checked))
            {
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void passwordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.Enabled = passwordCheckBox.Checked;
            if (!passwordTextBox.Enabled)
            {
                passwordCheckBox.Text = string.Empty;
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }
    }
}
