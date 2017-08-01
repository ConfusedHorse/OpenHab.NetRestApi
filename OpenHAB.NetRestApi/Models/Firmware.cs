using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Firmware
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("updatableVersion")]
        public string UpdatableVersion { get; set; }
    }
}