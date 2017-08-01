using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ItemAddedEventHandler(object sender, ItemAddedEvent eventObject);

    public class ItemAddedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public Item Payload { get; set; }

        #region Payload Parameters

        public Item Item => Payload;

        #endregion
    }
}