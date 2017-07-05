using System;
using Gogogo.Instances;
using Gogogo.Statics;
using TcpConnect.ServerInterface;

namespace Gogogo.Forms.ChessForms
{
    public partial class ChessMainForm : BaseForm
    {
        public ChessMainForm()
        {
            InitializeComponent();
            userLabel.Text = $@"欢迎：{GlobalStatic.CurUser}";
        }

        private void restarBtn_Click(object sender, EventArgs e)
        {
            TcpInstance.Instance.Socket.SendMethod.Restart();

        }

        private void redo_Click(object sender, EventArgs e)
        {
            TcpInstance.Instance.Socket.SendMethod.UnPutChess();
        }
    }
}
