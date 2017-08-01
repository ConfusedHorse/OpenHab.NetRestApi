using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Link
    {
        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("channelUID")]
        public string ChannelUid { get; set; }
    }
}