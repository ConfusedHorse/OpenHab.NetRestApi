using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Extension
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("installed")]
        public bool Installed { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}