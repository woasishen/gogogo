using System;
using System.Collections.Generic;
using Gogogo.Instances;
using Gogogo.Statics;
using TcpConnect.ServerInterface;

namespace Gogogo.Forms.ChessForms
{
    public partial class ChessMainForm : BaseForm
    {
        private readonly Stack<PosInfo> _stepStack;

        private CellStatus CurStatus
        {
            get { return blackRadioButton.Checked ? CellStatus.Black : CellStatus.White; }
            set
            {
                switch (value)
                {
                    case CellStatus.Empty:
                        break;
                    case CellStatus.Black:
                        blackRadioButton.Checked = true;
                        break;
                    case CellStatus.White:
                        whiteRadioButton.Checked = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }

        public ChessMainForm()
        {
            _stepStack = new Stack<PosInfo>(RoomStatic.Steps);
            InitializeComponent();

            userLabel.Text = $@"欢迎：{GlobalStatic.CurUser}";
            _chessMainControl.OnChessboardClick += (x, y) =>
            {
                TcpInstance.Instance.Socket.SendMethod.PutChess(
                    new PosInfo(x, y, CurStatus));
            };

            TcpInstance.Instance.Socket.MsgActions.B_Putc += BPutc;
            TcpInstance.Instance.Socket.MsgActions.B_UnPutc += BUnPutc;
            TcpInstance.Instance.Socket.MsgActions.B_Restartc += BRestartc;
        }

        private void BRestartc(string s)
        {
            HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                this,
                () =>
                {
                    RoomStatic.Steps.Clear();
                    _chessMainControl.Border.Restart();
                    CurStatus = CellStatus.Black;
                    Refresh();
                });
        }

        private void BUnPutc(string s)
        {
            HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                this,
                () =>
                {
                    var posInfo = _stepStack.Pop();
                    CurStatus = posInfo.CellStatus;
                    _chessMainControl.Border.UnPutChess(posInfo);
                    Refresh();
                });
        }

        private void BPutc(BroadcastMsgType.PutChess putChess)
        {
            HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                this,
                posInfo =>
                {
                    _stepStack.Push(posInfo);
                    _chessMainControl.Border.PutChess(posInfo);
                    if (autoCheckBox.Checked)
                    {
                        CurStatus = CellStatusHelper.Not(CurStatus);
                    }
                    Refresh();
                },
                putChess.PosInfo);
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
