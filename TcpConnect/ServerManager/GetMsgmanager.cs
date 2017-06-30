using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using TcpConnect.ServerInterface;

namespace TcpConnect.ServerManager
{
    internal class GetMsgManager
    {
        private readonly ServerMsgAction _serverMsgAction;

        private readonly Dictionary<ServerMsgId, FieldInfo> _msgActionDict =
            new Dictionary<ServerMsgId, FieldInfo>();
        private readonly Dictionary<ServerMsgId, Type> _msgTypeDict =
            new Dictionary<ServerMsgId, Type>();

        public GetMsgManager(ServerMsgAction serverMsgAction)
        {
            _serverMsgAction = serverMsgAction;
            foreach (var fieldInfo in typeof(ServerMsgAction).GetFields())
            {
                var serverIdAttr = (ServerIdAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(ServerIdAttribute));
                if (serverIdAttr == null)
                {
                    continue;
                }
                _msgActionDict[serverIdAttr.Id] = fieldInfo;
            }

            foreach (var typeInfo in typeof(ServerMsgType).GetNestedTypes())
            {
                var serverIdAttr = (ServerIdAttribute)Attribute.GetCustomAttribute(typeInfo, typeof(ServerIdAttribute));
                if (serverIdAttr == null)
                {
                    continue;
                }
                _msgTypeDict[serverIdAttr.Id] = typeInfo;
            }
        }

        public void HandleMsg(Packet packet)
        {
            var id = (ServerMsgId)Enum.Parse(typeof(ServerMsgId), packet.Id);
            var action = _msgActionDict[id].GetValue(_serverMsgAction);
            if (action == null)
            {
                return;
            }
            var methond = action.GetType().GetMethod("Invoke");
            if (packet.Id.StartsWith("b_"))
            {
                methond.Invoke(action, new object[] {packet.Msg.ToString()});
                return;
            }
            var msg = JsonConvert.DeserializeObject(packet.Msg.ToString(), _msgTypeDict[id]);
            
            methond.Invoke(action, new[] { msg });
        }
    }
}
