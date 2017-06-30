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

        public void Logout()
        {
            var msg = new ClientMsgType.Logout();
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

        public void JoinRoom(string name, string pwd = "")
        {
            var msg = new ClientMsgType.JoinRoom(name, pwd);
            _sendQueue.Enqueue(new Packet(msg.ClientMsgId.ToString(), msg));
        }

        public void LeaveRoom(string name)
        {
            var msg = new ClientMsgType.LeaveRoom();
            _sendQueue.Enqueue(new Packet(msg.ClientMsgId.ToString(), msg));
        }
    }
}
