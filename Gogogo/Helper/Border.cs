using System;
using System.Collections.Generic;
using System.Linq;

namespace Gogogo.Helper
{
    public class Border
    {
        private readonly CellStatus[][] _cellStatusArr;
        private readonly Stack<Pos> _stepStack = new Stack<Pos>();

        public Action ChessChanged;
        public Pos LastStepPos => _stepStack.Peek();
        public int StepIndex => _stepStack.Count;

        public Border()
        {
            _cellStatusArr = new CellStatus[Configs.BORDER_SIZE][];

            for (var i = 0; i < Configs.BORDER_SIZE; i++)
            {
                _cellStatusArr[i] = new CellStatus[Configs.BORDER_SIZE];
            }
            ReInitCellStatusAndPosGole();
        }

        private void ReInitCellStatusAndPosGole()
        {
            for (var i = 0; i < Configs.BORDER_SIZE; i++)
            {
                for (var j = 0; j < Configs.BORDER_SIZE; j++)
                {
                    _cellStatusArr[i][j] = CellStatus.Empty;
                }
            }
        }

        #region 读取位置棋子状态
        public CellStatus GetCellStatus(Pos pos)
        {
            return _cellStatusArr[pos.X][pos.Y];
        }

        public CellStatus GetCellStatus(int x, int y)
        {
            return _cellStatusArr[x][y];
        }
        #endregion

        /// <summary>
        /// 下棋
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="cellStatus"></param>
        /// <param name="needRefresh"></param>
        /// <returns></returns>
        public void PutChess(Pos pos, CellStatus cellStatus, bool needRefresh = true)
        {
            if (_cellStatusArr[pos.X][pos.Y] != CellStatus.Empty)
            {
                throw new Exception("putchess not emput");
            }
            _cellStatusArr[pos.X][pos.Y] = cellStatus;

            _stepStack.Push(pos);

            if (needRefresh)
            {
                ChessChanged.Invoke();
            }
        }

        /// <summary>
        /// 悔棋
        /// </summary>
        /// <returns></returns>
        public bool UnPutChess(bool needRefresh = true)
        {
            if (!_stepStack.Any())
            {
                return false;
            }
            var pos = _stepStack.Pop();
            _cellStatusArr[pos.X][pos.Y] = CellStatus.Empty;
            if (needRefresh)
            {
                ChessChanged.Invoke();
            }
            return true;
        }

        /// <summary>
        /// 重新开始
        /// </summary>
        public void ClearChess()
        {
            _stepStack.Clear();
            ReInitCellStatusAndPosGole();
            ChessChanged.Invoke();
        }
    }
}
