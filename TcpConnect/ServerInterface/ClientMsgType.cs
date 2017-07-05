using System.Collections.Generic;
using Newtonsoft.Json;
// ReSharper disable InconsistentNaming

namespace TcpConnect.ServerInterface
{
    public enum ClientMsgId
    {
        login,
        regist,
        logout,
        getrooms,
        createroom,
        joinroom,
        leaveroom,

        put,
        unput,
        restart,
        setroomsize,
    }

    public abstract class ClientMsgBase
    {
        [JsonIgnore]
        public abstract ClientMsgId ClientMsgId { get; }

        public Packet ToPacket()
        {
            return new Packet(ClientMsgId.ToString(), this);
        }
    }

    public abstract class ClientMsgType
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

        public class Logout : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.logout;
        }

        public class GetRooms : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.getrooms;
        }

        public class CreateRoom : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.createroom;
            public CreateRoom(int size, string name, string pwd)
            {
                Size = size;
                Name = name;
                Pwd = pwd;
            }

            [JsonProperty(@"size")]
            public int Size { get; private set; }
            [JsonProperty(@"name")]
            public string Name { get; private set; }
            [JsonProperty(@"pwd")]
            public string Pwd { get; private set; }
        }

        public class JoinRoom : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.joinroom;
            public JoinRoom(string name, string pwd)
            {
                Name = name;
                Pwd = pwd;
            }

            [JsonProperty(@"name")]
            public string Name { get; private set; }
            [JsonProperty(@"pwd")]
            public string Pwd { get; private set; }
        }

        public class LeaveRoom : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.leaveroom;
        }

        public class Put : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.put;

            public Put(PosInfo posInfo)
            {
                PosInfo = posInfo.ToString();
            }

            [JsonProperty(@"posinfo")]
            public string PosInfo { get; }
        }

        public class UnPut : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.unput;
        }

        public class Restart : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.restart;
        }

        public class SetRoomSize : ClientMsgBase
        {
            public override ClientMsgId ClientMsgId => ClientMsgId.setroomsize;

            public SetRoomSize(int size)
            {
                Size = size;
            }

            [JsonProperty(@"size")]
            public int Size { get; private set; }
        }
    }

    public class SendMethod
    {
        private readonly SyncQueue<ClientMsgBase> _sendQueue;

        public SendMethod(SyncQueue<ClientMsgBase> sendQueue)
        {
            _sendQueue = sendQueue;
        }

        public void Login(string name, string password)
        {
            var msg = new ClientMsgType.Login(name, password);
            _sendQueue.Enqueue(msg);
        }

        public void Regist(string name, string password)
        {
            var msg = new ClientMsgType.Regist(name, password);
            _sendQueue.Enqueue(msg);
        }

        public void Logout()
        {
            var msg = new ClientMsgType.Logout();
            _sendQueue.Enqueue(msg);
        }

        public void CreateRoom(int size, string name, string password)
        {
            var msg = new ClientMsgType.CreateRoom(size, name, password);
            _sendQueue.Enqueue(msg);
        }

        public void GetRooms()
        {
            var msg = new ClientMsgType.GetRooms();
            _sendQueue.Enqueue(msg);
        }

        public void JoinRoom(string name, string pwd = "")
        {
            var msg = new ClientMsgType.JoinRoom(name, pwd);
            _sendQueue.Enqueue(msg);
        }

        public void LeaveRoom(string name)
        {
            var msg = new ClientMsgType.LeaveRoom();
            _sendQueue.Enqueue(msg);
        }

        public void PutChess(PosInfo posInfo)
        {
            var msg = new ClientMsgType.Put(posInfo);
            _sendQueue.Enqueue(msg);
        }

        public void UnPutChess()
        {
            var msg = new ClientMsgType.UnPut();
            _sendQueue.Enqueue(msg);
        }

        public void Restart()
        {
            var msg = new ClientMsgType.Restart();
            _sendQueue.Enqueue(msg);
        }

        public void SetRoomSize(int size)
        {
            var msg = new ClientMsgType.SetRoomSize(size);
            _sendQueue.Enqueue(msg);
        }
    }
}
