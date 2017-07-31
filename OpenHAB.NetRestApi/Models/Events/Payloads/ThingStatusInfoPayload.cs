using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events.Payloads
{
    public class ThingStatusInfoPayload
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDetail")]
        public string StatusDetail { get; set; }
    }
}