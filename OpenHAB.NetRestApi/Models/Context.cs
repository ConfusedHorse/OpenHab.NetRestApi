using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Context
    {
        [JsonProperty("headers")]
        public Header Header { get; set; }

        [JsonProperty("committingOutputStream")]
        public CommittingOutputStream CommittingOutputStream { get; set; }

        [JsonProperty("entityAnnotations")]
        public List<object> EntityAnnotations { get; set; }

        [JsonProperty("entityStream")]
        public EntityStream EntityStream { get; set; }
    }
}