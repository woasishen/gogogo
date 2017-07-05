using System.Collections.Generic;
using TcpConnect.ServerInterface;

namespace Gogogo.Statics
{
    public static class RoomStatic
    {
        public static Dictionary<string, RoomInfo> RoomsDict;

        public static int BorderSize { set; get; }
        public static Stack<PosInfo> Steps { set; get; }
    }
}
