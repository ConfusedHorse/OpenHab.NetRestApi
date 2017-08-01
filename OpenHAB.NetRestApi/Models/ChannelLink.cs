using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ChannelLink
    {
        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("channelUID")]
        public string ChannelUid { get; set; }
    }
}