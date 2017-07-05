using System.Collections.Generic;
using Gogogo.Statics;
using TcpConnect;
using TcpConnect.ServerInterface;

namespace Gogogo.Instances
{
    public class TcpInstance
    {
        public static TcpInstance Instance { get; } = new TcpInstance();

        //public static readonly TcpSocket Socket = new TcpSocket("111.206.45.12", 30021);
        public readonly TcpSocket Socket = new TcpSocket("192.168.0.252", 18080);

        public void Init()
        {
            Socket.ErrAction += s => LogInstance.Instance.LogError(@"Err:" + s);
            Socket.ErrorAction += s => LogInstance.Instance.LogError(@"Error:" + s);
            Socket.NotSucceedAction += () => LogInstance.Instance.LogError(@"请求未成功");

            Socket.MsgActions.Loginc = Loginc;
            Socket.MsgActions.Registc = Registc;
            Socket.MsgActions.Logoutc = Logoutc;
            Socket.MsgActions.ForceLogoutc = ForceLogoutc;

            Socket.MsgActions.GetRoomsc = GetRoomsc;
            Socket.MsgActions.CreateRoomc = CreateRoomc;

            Socket.MsgActions.JoinRoomc = JoinRoomc;

            Socket.MsgActions.B_Join = BJoin;
            Socket.MsgActions.B_Leave = BLeave;
        }

        private void BLeave(string bLeave)
        {
            RoomStatic.RoomsDict[bLeave].PlayerCount--;
        }

        private void BJoin(string bJoin)
        {
            RoomStatic.RoomsDict[bJoin].PlayerCount++;
        }

        private void GetRoomsc(ServerMsgType.GetRooms msg)
        {
            RoomStatic.RoomsDict = msg.Data;
        }

        private void Loginc(ServerMsgType.Login msg)
        {
            LogInstance.Instance.LogMsg(@"登录成功");
            GlobalStatic.CurUser = msg.UserName;
        }

        private void Registc(ServerMsgType.Regist msg)
        {
            LogInstance.Instance.LogMsg(@"注册成功");
            GlobalStatic.CurUser = msg.UserName;
        }

        private void Logoutc(ServerMsgType.Logout msg)
        {
            LogInstance.Instance.LogMsg(@"登出成功");
            GlobalStatic.CurUser = null;
        }

        private void ForceLogoutc(ServerMsgType.ForceLogout obj)
        {
            LogInstance.Instance.LogError(@"用户在其他地方登陆，强制登出");
            GlobalStatic.CurUser = null;
        }

        private void CreateRoomc(ServerMsgType.CreateRoomc msg)
        {
            LogInstance.Instance.LogMsg(@"创建房间成功");
            Socket.SendMethod.GetRooms();
        }

        private void JoinRoomc(ServerMsgType.JoinRoom joinRoom)
        {
            LogInstance.Instance.LogMsg(@"加入房间成功");
            RoomStatic.Steps = joinRoom.RoomSteps ?? new Stack<PosInfo>();
            RoomStatic.BorderSize = joinRoom.RoomSize;
        }
    }
}
