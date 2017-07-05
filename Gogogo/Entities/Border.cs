using System;
using System.Linq;
using Gogogo.Instances;
using Gogogo.Statics;
using TcpConnect.ServerInterface;

namespace Gogogo.Entities
{
    public class Border
    {
        private readonly CellStatus[][] _cellStatusArr;
        public Action ChessChanged;

        public CellStatus CurStatus { get; set; } = CellStatus.Black;
        public bool AutoChangeCellStatus { set; private get; } = true;
        public Border()
        {
            _cellStatusArr = new CellStatus[RoomStatic.BorderSize][];

            for (var i = 0; i < RoomStatic.BorderSize; i++)
            {
                _cellStatusArr[i] = new CellStatus[RoomStatic.BorderSize];
            }
            ReInitCellStatus();
            var tempSteps = RoomStatic.Steps.ToList();
            foreach (var posInfo in tempSteps)
            {
                _cellStatusArr[posInfo.X][posInfo.Y] = posInfo.CellStatus;
            }

            TcpInstance.Instance.Socket.MsgActions.B_Putc += msg => PutChess(msg.PosInfo);
            TcpInstance.Instance.Socket.MsgActions.B_UnPutc += UnPutChess;
            TcpInstance.Instance.Socket.MsgActions.B_Restartc += RestartGame;
        }

        private void ReInitCellStatus()
        {
            for (var i = 0; i < RoomStatic.BorderSize; i++)
            {
                for (var j = 0; j < RoomStatic.BorderSize; j++)
                {
                    _cellStatusArr[i][j] = CellStatus.Empty;
                }
            }
        }

        public CellStatus GetCellStatus(int x, int y)
        {
            return _cellStatusArr[x][y];
        }

        /// <returns></returns>
        public void PutChess(PosInfo posInfo)
        {
            if (_cellStatusArr[posInfo.X][posInfo.Y] != CellStatus.Empty)
            {
                throw new Exception("putchess not emput");
            }
            _cellStatusArr[posInfo.X][posInfo.Y] = posInfo.CellStatus;

            RoomStatic.Steps.Push(posInfo);

            if (AutoChangeCellStatus)
            {
                CurStatus = CellStatusHelper.Not(CurStatus);
            }

            ChessChanged.Invoke();
        }

        /// <summary>
        /// 悔棋
        /// </summary>
        /// <returns></returns>
        public void UnPutChess(object msg)
        {
            if (!RoomStatic.Steps.Any())
            {
                return;
            }
            var posInfo = RoomStatic.Steps.Pop();
            _cellStatusArr[posInfo.X][posInfo.Y] = CellStatus.Empty;

            if (AutoChangeCellStatus)
            {
                CurStatus = CellStatusHelper.Not(CurStatus);
            }

            ChessChanged.Invoke();
        }

        /// <summary>
        /// 重新开始
        /// </summary>
        public void RestartGame(object msg)
        {
            RoomStatic.Steps.Clear();
            ReInitCellStatus();
            ChessChanged.Invoke();
        }
    }
}
