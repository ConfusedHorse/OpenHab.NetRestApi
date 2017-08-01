using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Trigger
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("configuration")]
        public object Configuration { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}