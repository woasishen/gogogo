using System;
using System.Collections.Generic;
using Newtonsoft.Json;
// ReSharper disable InconsistentNaming

namespace TcpConnect.ServerInterface
{
    public enum ServerMsgId
    {
        no_user_err_c,
        loginc,
        registc,
        logoutc,
        getroomsc,
        createroomc,
        joinroomc,
        leaveroomc,
        b_leave,
        b_join,
    }

    public abstract class ServerMsgBase
    {
        /// <summary>
        /// server error
        /// </summary>
        [JsonProperty(@"err")]
        public string Err { get; private set; }

        /// <summary>
        /// normal error
        /// </summary>
        [JsonProperty(@"error")]
        public string Error { get; private set; }

        /// <summary>
        /// sucess
        /// </summary>
        [JsonProperty(@"succeed")]
        public bool Succeed { get; private set; }
    }

    public class ServerIdAttribute : Attribute
    {
        public ServerMsgId Id { get; }
        public ServerIdAttribute(ServerMsgId id)
        {
            Id = id;
        }
    }

    public class ServerMsgType
    {
        [ServerId(ServerMsgId.no_user_err_c)]
        public class NoUserErr: ServerMsgBase
        {
        }

        [ServerId(ServerMsgId.loginc)]
        public class Login : ServerMsgBase
        {
            /// <summary>
            /// userName
            /// </summary>
            [JsonProperty(@"userName")]
            public string UserName { get; private set; }
        }

        [ServerId(ServerMsgId.registc)]
        public class Regist : ServerMsgBase
        {
            /// <summary>
            /// userName
            /// </summary>
            [JsonProperty(@"userName")]
            public string UserName { get; private set; }
        }

        [ServerId(ServerMsgId.logoutc)]
        public class Logout : ServerMsgBase
        {
        }

        [ServerId(ServerMsgId.getroomsc)]
        public class GetRooms : ServerMsgBase
        {
            /// <summary>
            /// Data
            /// </summary>
            [JsonProperty(@"data")]
            public Dictionary<string, RoomInfo> Data { get; private set; }
        }

        [ServerId(ServerMsgId.createroomc)]
        public class CreateRoomc : ServerMsgBase
        {
        }

        [ServerId(ServerMsgId.joinroomc)]
        public class JoinRoom : ServerMsgBase
        {
        }

        [ServerId(ServerMsgId.leaveroomc)]
        public class LeaveRoom : ServerMsgBase
        {
        }
    }

    public class ServerMsgAction
    {
        [ServerId(ServerMsgId.no_user_err_c)]
        public Action<ServerMsgType.NoUserErr> NoUserErr;

        [ServerId(ServerMsgId.loginc)]
        public Action<ServerMsgType.Login> Loginc;

        [ServerId(ServerMsgId.registc)]
        public Action<ServerMsgType.Regist> Registc;

        [ServerId(ServerMsgId.logoutc)]
        public Action<ServerMsgType.Logout> Logoutc;

        [ServerId(ServerMsgId.getroomsc)]
        public Action<ServerMsgType.GetRooms> GetRoomsc;

        [ServerId(ServerMsgId.createroomc)]
        public Action<ServerMsgType.CreateRoomc> CreateRoomc;

        [ServerId(ServerMsgId.joinroomc)]
        public Action<ServerMsgType.JoinRoom> JoinRoomc;

        [ServerId(ServerMsgId.leaveroomc)]
        public Action<ServerMsgType.LeaveRoom> LeaveRoomc;

        [ServerId(ServerMsgId.b_join)]
        public Action<string> B_Join;

        [ServerId(ServerMsgId.b_leave)]
        public Action<string> B_Leave;
    }
}
