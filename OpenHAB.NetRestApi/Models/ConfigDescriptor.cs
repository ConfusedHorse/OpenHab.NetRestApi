using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ConfigDescriptor
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }

        [JsonProperty("parameterGroups")]
        public List<ParameterGroup> ParameterGroups { get; set; }
    }
}