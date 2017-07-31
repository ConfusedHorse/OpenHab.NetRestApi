using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public class UnknownEvent : Event
    {
        [JsonProperty("payload")]
        public string Payload { get; set; }
    }
}