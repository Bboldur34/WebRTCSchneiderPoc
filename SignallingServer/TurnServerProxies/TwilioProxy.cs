using WebRTCme;

namespace SignallingServer.TurnServerProxies
{
    public class TwilioProxy : ITurnServerProxy
    {
        public TwilioProxy()
        {
        }

        public Task<RTCIceServer[]> GetIceServersAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}