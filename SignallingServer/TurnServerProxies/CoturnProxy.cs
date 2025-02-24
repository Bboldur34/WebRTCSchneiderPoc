using WebRTCme;

namespace SignallingServer.TurnServerProxies
{
    public class CoturnProxy : ITurnServerProxy
    {
        public CoturnProxy()
        {
        }

        public Task<RTCIceServer[]> GetIceServersAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}