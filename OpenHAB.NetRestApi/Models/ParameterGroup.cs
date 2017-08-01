using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ParameterGroup
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("advanced")]
        public bool Advanced { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}