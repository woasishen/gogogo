using System;
using System.Drawing;
using System.Windows.Forms;
using Gogogo.Instances;

namespace Gogogo.Forms.RoomForms
{
    public partial class CreateRoomForm : BaseForm
    {
        public CreateRoomForm()
        {
            InitializeComponent();
            sizeComboBox.SelectedIndex = 0;
        }

        private void createRoomButton_Click(object sender, EventArgs e)
        {
            if (TextBoxNotValid(nameTextBox, nameLabel, 12) 
                || TextBoxNotValid(passwordTextBox, passwordCheckBox, 12, passwordCheckBox.Checked))
            {
                return;
            }
            TcpInstance.Instance.Socket.SendMethod.CreateRoom(
                Convert.ToInt32(sizeComboBox.SelectedItem.ToString()),
                nameTextBox.Text.Trim(),
                passwordTextBox.Text.Trim());
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

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //enter
            {
                createRoomButton_Click(null, null);
            }
        }
    }
}
