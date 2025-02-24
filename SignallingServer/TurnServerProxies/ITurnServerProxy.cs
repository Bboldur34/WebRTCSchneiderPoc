using WebRTCme;

namespace SignallingServer.TurnServerProxies
{
    public interface ITurnServerProxy
    {
        Task<RTCIceServer[]> GetIceServersAsync(); 
    }
}
