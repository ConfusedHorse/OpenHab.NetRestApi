using Newtonsoft.Json;
using OpenHAB.NetRestApi.Models.Events.Payloads;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ThingStatusInfoEventHandler(object sender, ThingStatusInfoEvent eventObject);

    public class ThingStatusInfoEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public ThingStatusInfoPayload Payload { get; set; }

        #region Payload Parameters

        public string Status => Payload.Status;
        
        public string StatusDetail => Payload.StatusDetail;

        #endregion
    }
}