using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;

namespace TcpConect
{
    public class TcpSocket
    {
        [DataContract]
        private class Package
        {
            public Package(string cfyId, string msg)
            {
                CfyId = cfyId;
                Msg = msg;
            }

            [DataMember]
            public string CfyId { get; private set; }
            [DataMember]
            public string Msg { get; private set; }
        }

        private readonly TcpClient _client;
        private readonly DataContractJsonSerializer _serializer = new DataContractJsonSerializer(typeof(Package));
        private readonly SyncQueue<Package> _sendQueue = new SyncQueue<Package>();
        private readonly SyncQueue<Package> _getQueue = new SyncQueue<Package>();

        public TcpSocket(string address, int port)
        {
            _client = new TcpClient(address, port);
            var sendThread = new Thread(Send);
            var getThread = new Thread(Get);
            sendThread.Start();
            getThread.Start();
        }

        public void SendMsg(string id, string msg)
        {
            _sendQueue.Enqueue(new Package(id, msg));
        }

        private void Send()
        {
            while (true)
            {
                var msg = _sendQueue.Dequeue();
                using (var ms = new MemoryStream())
                {
                    _serializer.WriteObject(ms, msg);

                    var title = BitConverter.GetBytes(ms.Length);
                    _client.GetStream().Write(title, 0, title.Length);
                    _client.GetStream().Write(ms.GetBuffer(), 0, (int)ms.Length);
                }
            }
        }

        private void Get()
        {
            var buffer = new byte[_client.ReceiveBufferSize];
            
            while (true)
            {
                var length = _client.GetStream().Read(buffer, 0, buffer.Length);

                Console.WriteLine(BitConverter.ToInt32(buffer, 0));

                Console.WriteLine(Encoding.UTF8.GetString(buffer, 8 , length - 8));
            }
        }
    }
}
