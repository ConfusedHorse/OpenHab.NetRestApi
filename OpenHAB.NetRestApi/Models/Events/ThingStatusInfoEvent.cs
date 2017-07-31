using Newtonsoft.Json;
using OpenHAB.NetRestApi.Models.Events.Payloads;

namespace OpenHAB.NetRestApi.Models.Events
{
    public class ThingStatusInfoEvent : Event
    {
        [JsonProperty("payload")]
        public ThingStatusInfoPayload Payload { get; set; }
    }
}