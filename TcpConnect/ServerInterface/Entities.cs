using Newtonsoft.Json;

namespace TcpConnect.ServerInterface
{
    public class RoomInfo
    {
        [JsonProperty(@"pwd")]
        public string Password { get; private set; }
        [JsonProperty(@"num")]
        public int PlayerCount { get; set; }
    }
}
