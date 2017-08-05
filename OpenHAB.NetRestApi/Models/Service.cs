using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Service
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("configDescriptionURI")]
        public string ConfigDescriptionUri { get; set; }
    }
}