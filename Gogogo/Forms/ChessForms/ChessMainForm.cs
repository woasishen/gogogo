using System;
using System.Windows.Forms;
using Gogogo.Forms.LoginForms;

namespace Gogogo.Forms.ChessForms
{
    public partial class ChessMainForm : BaseForm
    {
        public ChessMainForm()
        {
            InitializeComponent();
        }

        private void restarBtn_Click(object sender, EventArgs e)
        {
            _chessMainControl.RestartGame();

        }

        private void redo_Click(object sender, EventArgs e)
        {
            _chessMainControl.Redo();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            ShowLogin();
        }

        private void ShowLogin()
        {
            DialogResult dialogResult;
            using (var loginForm = new LoginForm())
            {
                dialogResult = loginForm.ShowDialog();
            }
            if (dialogResult == DialogResult.Yes)
            {
                ShowRegist();
            }
        }

        private void ShowRegist()
        {
            using (var registForm = new RegistForm()) //regist
            {
                registForm.ShowDialog();
            }
        }
    }
}
