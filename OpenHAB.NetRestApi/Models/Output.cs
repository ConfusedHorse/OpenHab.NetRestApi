using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Output
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}