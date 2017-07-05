using System;
using Newtonsoft.Json;

namespace TcpConnect.ServerInterface
{
    public class PosInfo
    {
        private readonly int _x, _y;
        private readonly CellStatus _cellStatus;

        [JsonProperty(@"pos")]
        public Pos Pos => new Pos(_x, _y);
        [JsonProperty(@"status")]
        public CellStatus CellStatus => _cellStatus;

        public PosInfo(int x, int y, CellStatus cellStatus)
        {
            _x = x;
            _y = y;
            _cellStatus = cellStatus;
        }

        public PosInfo(string serverStr)
        {
            var msg = serverStr.Split('_');

            if (msg.Length != 3)
            {
                return;
            }

            int.TryParse(msg[0], out _x);
            int.TryParse(msg[1], out _y);
            Enum.TryParse(msg[2], out _cellStatus);
        }

        public override string ToString()
        {
            return $@"{_x}_{_y}_{_cellStatus}";
        }
    }

    public struct Pos
    {
        [JsonProperty(@"x")]
        public int X { get; }

        [JsonProperty(@"y")]
        public int Y { get; }

        public Pos(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public enum CellStatus
    {
        /// <summary>
        /// Empty
        /// </summary>
        E = 0,
        /// <summary>
        /// Black
        /// </summary>
        B = 1,
        /// <summary>
        /// White
        /// </summary>
        W = 2,
    }

    public static class CellStatusHelper
    {
        public static CellStatus Not(CellStatus s)
        {
            switch (s)
            {
                case CellStatus.B:
                    return CellStatus.W;
                case CellStatus.W:
                    return CellStatus.B;
                case CellStatus.E:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(s), s, null);
            }
            throw new Exception("cellstatus do not valid to not");
        }
    }

    public class RoomInfo
    {
        [JsonProperty(@"pwd")]
        public string Password { get; private set; }
        [JsonProperty(@"num")]
        public int PlayerCount { get; set; }
    }
}
