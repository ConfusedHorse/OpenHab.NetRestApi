using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ChannelType
    {
        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }

        [JsonProperty("parameterGroups")]
        public List<ParameterGroup> ParameterGroups { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("itemType")]
        public string ItemType { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("UID")]
        public string Uid { get; set; }

        [JsonProperty("advanced")]
        public bool Advanced { get; set; }

        [JsonProperty("stateDescription")]
        public StateDescription StateDescription { get; set; }
    }
}