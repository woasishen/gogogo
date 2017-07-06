using System.Collections.Generic;
using TcpConnect.ServerInterface;

namespace Gogogo.Statics
{
    public static class RoomStatic
    {
        public static Dictionary<string, RoomInfo> RoomsDict;

        public static int BorderSize { set; get; } = 13;

        public static List<PosInfo> Steps { set; get; } = new List<PosInfo>();
    }
}
