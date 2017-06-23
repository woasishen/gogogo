using System;
using System.Windows.Forms;
using Gogogo.Forms.LoginForms;
using Gogogo.Helper;
using TcpConnect.ServerInterface;

namespace Gogogo.Forms.ChessForms
{
    public partial class ChessMainForm : BaseForm
    {
        public ChessMainForm()
        {
            InitializeComponent();
            TcpInstance.SOCKET.MsgActions.Loginc += msg =>
            {
                HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                    this,
                    Loginc,
                    msg);
            };
            TcpInstance.SOCKET.MsgActions.Registc += msg =>
            {
                HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                    this,
                    Registc,
                    msg);
            };
        }

        private void Loginc(ServerMsgBase msg)
        {
            if (!string.IsNullOrEmpty(msg.Err))
            {
                MessageBox.Show(@"服务器数据库内部错误:Loginc_" + msg.Err);
                Dispose();
                return;
            }
            if (!string.IsNullOrEmpty(msg.Error))
            {
                MessageBox.Show(@"登录失败:" + msg.Error);
                ShowLogin();
                return;
            }
            if (!msg.Sucessed)
            {
                MessageBox.Show(@"登录失败:未知错误");
                ShowLogin();
                return;
            }
            MessageBox.Show(@"登录成功");
        }

        private void Registc(ServerMsgBase msg)
        {
            if (!string.IsNullOrEmpty(msg.Err))
            {
                MessageBox.Show(@"服务器数据库内部错误:Registc_" + msg.Err);
                Dispose();
                return;
            }
            if (!string.IsNullOrEmpty(msg.Error))
            {
                MessageBox.Show(@"注册失败:" + msg.Error);
                ShowRegist();
                return;
            }
            if (!msg.Sucessed)
            {
                MessageBox.Show(@"注册失败:未知错误");
                ShowRegist();
                return;
            }
            MessageBox.Show(@"注册成功");
            ShowLogin();
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
            if (dialogResult == DialogResult.Cancel || dialogResult == DialogResult.Abort)
            {
                return;
            }
            if (dialogResult == DialogResult.OK)
            {
                TcpInstance.SOCKET.SendMethod.Login(
                    Properties.Settings.Default.AccountId,
                    Properties.Settings.Default.Password);
                return;
            }
            ShowRegist();
        }

        private void ShowRegist()
        {
            using (var registForm = new RegistForm()) //regist
            {
                if (registForm.ShowDialog() == DialogResult.OK)
                {
                    TcpInstance.SOCKET.SendMethod.Regist(
                        registForm.nameTextBox.Text,
                        registForm.passwordTextBox.Text);
                }
            }
        }
    }
}
