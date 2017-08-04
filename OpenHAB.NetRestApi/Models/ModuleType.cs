using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ModuleType
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("string")]
        public List<string> Tags { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("configDescriptions")]
        public List<ConfigDescription> ConfigDescriptions { get; set; }
    }
}