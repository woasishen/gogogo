using System;
using System.Collections.Generic;
using Newtonsoft.Json;
// ReSharper disable InconsistentNaming

namespace TcpConnect.ServerInterface
{
    public enum ClientMsgId
    {
        login,
        regist,
        getrooms,
        createroom,
    }

    public abstract class ClientMsgBase
    {
        public abstract ClientMsgId ClientMsgId { get; }
    }

    public class ClientMsgType
    {
        public class Login : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.login;

            public Login(string name, string pwd)
            {
                Name = name;
                Pwd = pwd;
            }

            [JsonProperty(@"name")]
            public string Name { get; private set; }
            [JsonProperty(@"pwd")]
            public string Pwd { get; private set; }
        }

        public class Regist : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.regist;
            public Regist(string name, string pwd)
            {
                Name = name;
                Pwd = pwd;
            }

            [JsonProperty(@"name")]
            public string Name { get; private set; }
            [JsonProperty(@"pwd")]
            public string Pwd { get; private set; }
        }

        public class GetRooms : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.getrooms;
        }

        public class CreateRoom : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.createroom;
            public CreateRoom(string name, string pwd)
            {
                Name = name;
                Pwd = pwd;
            }

            [JsonProperty(@"name")]
            public string Name { get; private set; }
            [JsonProperty(@"pwd")]
            public string Pwd { get; private set; }
        }
    }

    public class SendMethod
    {
        private readonly SyncQueue<Packet> _sendQueue;

        public SendMethod(SyncQueue<Packet> sendQueue)
        {
            _sendQueue = sendQueue;
        }

        public void Login(string name, string password)
        {
            var msg = new ClientMsgType.Login(name, password);
            _sendQueue.Enqueue(new Packet(msg.ClientMsgId.ToString(), msg));
        }

        public void Regist(string name, string password)
        {
            var msg = new ClientMsgType.Regist(name, password);
            _sendQueue.Enqueue(new Packet(msg.ClientMsgId.ToString(), msg));
        }

        public void CreateRoom(string name, string password)
        {
            var msg = new ClientMsgType.CreateRoom(name, password);
            _sendQueue.Enqueue(new Packet(msg.ClientMsgId.ToString(), msg));
        }

        public void GetRooms()
        {
            var msg = new ClientMsgType.GetRooms();
            _sendQueue.Enqueue(new Packet(msg.ClientMsgId.ToString(), msg));
        }
    }
}
