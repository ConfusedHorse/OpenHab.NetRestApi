using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events.Payloads
{
    public class ItemStatePayload
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}