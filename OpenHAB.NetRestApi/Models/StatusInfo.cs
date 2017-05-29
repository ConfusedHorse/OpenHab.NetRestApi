using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class StatusInfo
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDetail")]
        public string StatusDetail { get; set; }
    }
}