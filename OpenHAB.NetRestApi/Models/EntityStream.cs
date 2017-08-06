using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class EntityStream
    {
        [JsonProperty("bufferSize")]
        public int BufferSize { get; set; }

        [JsonProperty("directWrite")]
        public bool DirectWrite { get; set; }

        [JsonProperty("isCommitted")]
        public bool IsCommitted { get; set; }

        [JsonProperty("isClosed")]
        public bool IsClosed { get; set; }
    }
}