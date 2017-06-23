using System;
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
        [JsonProperty(@"sucessed")]
        public bool Sucessed { get; private set; }
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
        [ServerId(ServerMsgId.loginc)]
        public class Login : ServerMsgBase
        {
        }

        [ServerId(ServerMsgId.registc)]
        public class Regist : ServerMsgBase
        {
        }

        [ServerId(ServerMsgId.getroomsc)]
        public class GetRooms : ServerMsgBase
        {
        }

        [ServerId(ServerMsgId.createroomc)]
        public class CreateRoomc : ServerMsgBase
        {
        }
    }

    public class ServerMsgAction
    {
        [ServerId(ServerMsgId.loginc)]
        public Action<ServerMsgBase> Loginc;

        [ServerId(ServerMsgId.registc)]
        public Action<ServerMsgBase> Registc;

        [ServerId(ServerMsgId.getroomsc)]
        public Action<ServerMsgBase> GetRoomsc;

        [ServerId(ServerMsgId.createroomc)]
        public Action<ServerMsgBase> CreateRoomc;
    }
}
