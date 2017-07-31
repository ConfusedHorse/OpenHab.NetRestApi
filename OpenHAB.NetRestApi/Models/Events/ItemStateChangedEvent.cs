using Newtonsoft.Json;
using OpenHAB.NetRestApi.Models.Events.Payloads;

namespace OpenHAB.NetRestApi.Models.Events
{
    public class ItemStateChangedEvent : Event
    {
        [JsonProperty("payload")]
        public ItemStateChangedPayload Payload { get; set; }
    }
}