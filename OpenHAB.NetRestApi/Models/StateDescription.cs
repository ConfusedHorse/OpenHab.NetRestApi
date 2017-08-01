using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class StateDescription
    {
        [JsonProperty("minimum")]
        public int Minimum { get; set; }

        [JsonProperty("maximum")]
        public int Maximum { get; set; }

        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }

        [JsonProperty("options")]
        public List<StateOption> Options { get; set; }

        [JsonProperty("step")]
        public int? Step { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }
    }
}