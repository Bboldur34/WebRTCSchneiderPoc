using WebRTCme;

namespace SignallingServer.TurnServerProxies
{
    public class AppRtcProxy : ITurnServerProxy
    {
        public AppRtcProxy()
        {
        }

        public Task<RTCIceServer[]> GetIceServersAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}