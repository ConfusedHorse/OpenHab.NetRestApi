using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ItemChannelLinkAddedEventHandler(object sender, ItemChannelLinkAddedEvent eventObject);

    public class ItemChannelLinkAddedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public Link Payload { get; set; }

        #region Payload Parameters

        public string ChannelUid => Payload.ChannelUid;

        public string ItemName => Payload.ItemName;

        #endregion
    }
}