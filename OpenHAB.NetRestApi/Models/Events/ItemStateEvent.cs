using Newtonsoft.Json;
using OpenHAB.NetRestApi.Models.Events.Payloads;

namespace OpenHAB.NetRestApi.Models.Events
{
    public class ItemStateEvent : Event
    {
        [JsonProperty("payload")]
        public ItemStatePayload Payload { get; set; }
    }
}