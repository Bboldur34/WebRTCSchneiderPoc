using System.Text.Json.Serialization;
using WebRTCme;

namespace SignallingServer.TurnServerProxies.Enums
{
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum XirsysTurnStatusResponse
    {
        Ok,
        Error
    }
}
