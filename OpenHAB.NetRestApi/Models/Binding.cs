using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Binding
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("configDescriptionURI")]
        public string ConfigDescriptionUri { get; set; }
    }
}