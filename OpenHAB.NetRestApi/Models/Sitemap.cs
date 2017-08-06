using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Sitemap
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("homepage")]
        public Homepage Homepage { get; set; }
    }
}