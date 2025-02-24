using WebRTCme;

namespace SignallingServer.TurnServerProxies
{
    public class StunOnlyProxy : ITurnServerProxy
    {
        public StunOnlyProxy()
        {
        }

        public Task<RTCIceServer[]> GetIceServersAsync()
        {
            // Hard coded STUN servers. 
            return Task.FromResult(new RTCIceServer[] 
            { 
                new RTCIceServer
                {
                    Urls = new string[]
                    {
                        "stun:stun4.l.google.com:19302"
                    },
                }
            });
        }
    }
}
