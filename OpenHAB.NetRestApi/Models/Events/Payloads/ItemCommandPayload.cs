using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events.Payloads
{
    public class ItemCommandPayload
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}