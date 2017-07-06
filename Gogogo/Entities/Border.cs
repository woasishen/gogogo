using System.Collections.Generic;
using TcpConnect.ServerInterface;

namespace Gogogo.Entities
{
    public class CellInfo
    {
        public CellStatus CellStatus { get; set; } = CellStatus.Empty;
        public int Index { get; set; }
    }

    public class Border
    {
        private int _curIndex;
        private readonly CellInfo[][] _cellStatusArr;

        public int Size { get; }

        public Border(int size, List<PosInfo> defaultSteps)
        {
            Size = size;

            _curIndex = 0;
            _cellStatusArr = new CellInfo[Size][];

            for (var i = 0; i < Size; i++)
            {
                _cellStatusArr[i] = new CellInfo[Size];
                for (var j = 0; j < Size; j++)
                {
                    _cellStatusArr[i][j] = new CellInfo();
                }
            }

            foreach (var setp in defaultSteps)
            {
                PutChess(setp);
            }
        }


        public void PutChess(PosInfo posInfo)
        {
            _cellStatusArr[posInfo.X][posInfo.Y].CellStatus = posInfo.CellStatus;
            _cellStatusArr[posInfo.X][posInfo.Y].Index = _curIndex++;
        }

        public void UnPutChess(PosInfo posInfo)
        {
            _cellStatusArr[posInfo.X][posInfo.Y].CellStatus = CellStatus.Empty;
            _curIndex--;
        }

        public void Restart()
        {
            _curIndex = 0;
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    _cellStatusArr[i][j].CellStatus = CellStatus.Empty;
                }
            }
        }

        public CellInfo GetCellInfo(int x, int y)
        {
            return _cellStatusArr[x][y];
        }
    }
}
