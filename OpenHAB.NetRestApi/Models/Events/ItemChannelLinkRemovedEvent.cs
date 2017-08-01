using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ItemChannelLinkRemovedEventHandler(object sender, ItemChannelLinkRemovedEvent eventObject);

    public class ItemChannelLinkRemovedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public ChannelLink Payload { get; set; }

        #region Payload Parameters

        public string ChannelUid => Payload.ChannelUid;

        public string ItemName => Payload.ItemName;

        #endregion
    }
}