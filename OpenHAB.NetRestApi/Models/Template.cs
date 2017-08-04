using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Template
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }
    }
}