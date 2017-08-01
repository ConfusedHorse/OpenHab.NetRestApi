using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Action
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

        [JsonProperty("inputs")]
        public object Inputs { get; set; }
    }
}