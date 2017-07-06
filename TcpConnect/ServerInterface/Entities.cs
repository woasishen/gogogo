using System;
using Newtonsoft.Json;

namespace TcpConnect.ServerInterface
{
    public class PosInfo : Pos
    {
        [JsonProperty(@"status")]
        public CellStatus CellStatus { get; }

        public PosInfo(int x, int y, CellStatus cellStatus)
            : base(x, y)
        {
            CellStatus = cellStatus;
        }
    }

    public class Pos
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
        Empty = 0,
        /// <summary>
        /// Black
        /// </summary>
        Black = 1,
        /// <summary>
        /// White
        /// </summary>
        White = 2,
    }

    public static class CellStatusHelper
    {
        public static CellStatus Not(CellStatus s)
        {
            switch (s)
            {
                case CellStatus.Black:
                    return CellStatus.White;
                case CellStatus.White:
                    return CellStatus.Black;
                case CellStatus.Empty:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(s), s, null);
            }
            throw new Exception("cellstatus do not valid to not");
        }
    }

    public class RoomInfo
    {
        public const string DEFAULT_PWD = "default";

        [JsonProperty(@"pwd")]
        public string Password { get; private set; }
        [JsonProperty(@"num")]
        public int PlayerCount { get; set; }
    }
}
