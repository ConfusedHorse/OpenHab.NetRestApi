using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Parent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("leaf")]
        public bool Leaf { get; set; }
    }
}