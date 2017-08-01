using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ItemRemovedEventHandler(object sender, ItemRemovedEvent eventObject);

    public class ItemRemovedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public Item Payload { get; set; }

        #region Payload Parameters

        public Item Item => Payload;

        #endregion
    }
}