using Newtonsoft.Json;
using OpenHAB.NetRestApi.Models.Events.Payloads;

namespace OpenHAB.NetRestApi.Models.Events
{
    public class ItemCommandEvent : Event
    {
        [JsonProperty("payload")]
        public ItemCommandPayload Payload { get; set; }
    }
}