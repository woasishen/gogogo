using System;
using System.Collections.Generic;
using Newtonsoft.Json;
// ReSharper disable InconsistentNaming

namespace TcpConnect.ServerInterface
{
    public enum ServerMsgId
    {
        loginc,
        registc,
        getroomsc,

        createroomc,
        joinroomc,
        leaveroomc,
        logoutc,
        forcelogoutc,

        b_leavec,
        b_joinc,
        b_putc,
        b_unputc,
        b_restartc,
        b_setroomsizec,
    }

    public class ServerMsgBase
    {
        /// <summary>
        /// server error
        /// </summary>
        [JsonProperty(@"err")]
        internal string Err { get; private set; }

        /// <summary>
        /// normal error
        /// </summary>
        [JsonProperty(@"error")]
        internal string Error { get; private set; }

        /// <summary>
        /// sucess
        /// </summary>
        [JsonProperty(@"succeed")]
        internal bool Succeed { get; private set; }
    }

    public class ServerIdAttribute : Attribute
    {
        public ServerMsgId Id { get; }
        public ServerIdAttribute(ServerMsgId id)
        {
            Id = id;
        }
    }

    public abstract class ServerMsgType
    {
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

        [ServerId(ServerMsgId.getroomsc)]
        public class GetRooms : ServerMsgBase
        {
            /// <summary>
            /// Data
            /// </summary>
            [JsonProperty(@"data")]
            public Dictionary<string, RoomInfo> Data { get; private set; }
        }

        [ServerId(ServerMsgId.joinroomc)]
        public class JoinRoom : ServerMsgBase
        {
            [JsonProperty(@"roomsize")]
            public int RoomSize { get; private set; }

            [JsonProperty(@"roomsteps")]
            public Stack<PosInfo> RoomSteps { get; private set; }
        }
    }

    public abstract class BroadcastMsgType
    {
        [ServerId(ServerMsgId.b_putc)]
        public class PutChess
        {
            [JsonProperty(@"posinfo")]
            public PosInfo PosInfo { get; private set; }
        }
    }

    public class ServerMsgAction
    {
        [ServerId(ServerMsgId.loginc)]
        public Action<ServerMsgType.Login> Loginc;

        [ServerId(ServerMsgId.registc)]
        public Action<ServerMsgType.Regist> Registc;

        [ServerId(ServerMsgId.logoutc)]
        public Action<ServerMsgBase> Logoutc;

        [ServerId(ServerMsgId.forcelogoutc)]
        public Action<ServerMsgBase> ForceLogoutc;

        [ServerId(ServerMsgId.getroomsc)]
        public Action<ServerMsgType.GetRooms> GetRoomsc;

        [ServerId(ServerMsgId.createroomc)]
        public Action<ServerMsgBase> CreateRoomc;

        [ServerId(ServerMsgId.joinroomc)]
        public Action<ServerMsgType.JoinRoom> JoinRoomc;

        [ServerId(ServerMsgId.leaveroomc)]
        public Action<ServerMsgBase> LeaveRoomc;


        //broadcast
        [ServerId(ServerMsgId.b_joinc)]
        public Action<string> B_Join;

        [ServerId(ServerMsgId.b_leavec)]
        public Action<string> B_Leave;

        [ServerId(ServerMsgId.b_putc)]
        public Action<BroadcastMsgType.PutChess> B_Putc;

        [ServerId(ServerMsgId.b_unputc)]
        public Action<string> B_UnPutc;

        [ServerId(ServerMsgId.b_restartc)]
        public Action<string> B_Restartc;

        [ServerId(ServerMsgId.b_setroomsizec)]
        public Action<string> B_SetRoomSizec;
    }
}
