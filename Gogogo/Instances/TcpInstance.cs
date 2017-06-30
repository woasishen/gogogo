using System.Collections.Generic;
using Gogogo.StaticData;
using TcpConnect;
using TcpConnect.ServerInterface;

namespace Gogogo.Instances
{
    public class TcpInstance
    {
        public Dictionary<string, RoomInfo> RoomsDict = new Dictionary<string, RoomInfo>();

        public static TcpInstance Instance { get; } = new TcpInstance();

        //public static readonly TcpSocket Socket = new TcpSocket("111.206.45.12", 30021);
        public readonly TcpSocket Socket = new TcpSocket("192.168.0.252", 18080);

        public void Init()
        {
            Socket.MsgActions.NoUserErr = NoUserErrc;
            Socket.MsgActions.Loginc = Loginc;
            Socket.MsgActions.Registc = Registc;
            Socket.MsgActions.Logoutc = Logoutc;

            Socket.MsgActions.GetRoomsc = GetRoomsc;
            Socket.MsgActions.CreateRoomc = CreateRoomc;

            Socket.MsgActions.B_Join = BJoin;
            Socket.MsgActions.B_Leave = BLeave;
        }

        private void BLeave(string bLeave)
        {
            RoomsDict[bLeave].PlayerCount--;
        }

        private void BJoin(string bJoin)
        {
            RoomsDict[bJoin].PlayerCount++;
        }

        private void GetRoomsc(ServerMsgType.GetRooms msg)
        {
            RoomsDict = msg.Data;
        }

        private void NoUserErrc(ServerMsgType.NoUserErr msg)
        {
            LogInstance.Instance.LogError(@"请先登录");
        }

        private void Loginc(ServerMsgType.Login msg)
        {
            if (!string.IsNullOrEmpty(msg.Err))
            {
                LogInstance.Instance.LogError(@"服务器数据库内部错误:Loginc_" + msg.Err);
                return;
            }
            if (!string.IsNullOrEmpty(msg.Error))
            {
                LogInstance.Instance.LogError(@"登录失败:" + msg.Error);
                return;
            }
            if (!msg.Succeed)
            {
                LogInstance.Instance.LogError(@"登录失败:未知错误");
                return;
            }
            LogInstance.Instance.LogMsg(@"登录成功");
            GlobalStatic.CurUser = ((ServerMsgType.Login) msg).UserName;
        }

        private void Registc(ServerMsgType.Regist msg)
        {
            if (!string.IsNullOrEmpty(msg.Err))
            {
                LogInstance.Instance.LogError(@"服务器数据库内部错误:Registc_" + msg.Err);
                return;
            }
            if (!string.IsNullOrEmpty(msg.Error))
            {
                LogInstance.Instance.LogError(@"注册失败:" + msg.Error);
                return;
            }
            if (!msg.Succeed)
            {
                LogInstance.Instance.LogError(@"注册失败:未知错误");
                return;
            }
            LogInstance.Instance.LogMsg(@"注册成功");
            GlobalStatic.CurUser = ((ServerMsgType.Regist)msg).UserName;
        }

        private void Logoutc(ServerMsgType.Logout msg)
        {
            if (!msg.Succeed)
            {
                LogInstance.Instance.LogError(@"登出失败:未知错误");
                return;
            }
            LogInstance.Instance.LogMsg(@"登出成功");
            GlobalStatic.CurUser = null;
        }

        private void CreateRoomc(ServerMsgType.CreateRoomc msg)
        {
            if (!string.IsNullOrEmpty(msg.Err))
            {
                LogInstance.Instance.LogError(@"服务器数据库内部错误:CreateRoomc_" + msg.Err);
                return;
            }
            if (!string.IsNullOrEmpty(msg.Error))
            {
                LogInstance.Instance.LogError(@"创建房间失败:" + msg.Error);
                return;
            }
            if (!msg.Succeed)
            {
                LogInstance.Instance.LogError(@"创建房间失败:未知错误");
                return;
            }
            LogInstance.Instance.LogMsg(@"创建房间成功");
            Socket.SendMethod.GetRooms();
        }
    }
}
