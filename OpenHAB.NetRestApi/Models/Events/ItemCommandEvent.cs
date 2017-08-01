using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ItemCommandEventHandler(object sender, ItemCommandEvent eventObject);

    public class ItemCommandEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public Property Payload { get; set; }

        #region Payload Parameters

        public string CommandType => Payload.Type;

        public string CommandValue => Payload.Value;

        #endregion
    }
}