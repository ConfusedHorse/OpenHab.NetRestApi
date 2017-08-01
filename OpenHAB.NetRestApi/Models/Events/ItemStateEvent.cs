using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ItemStateEventHandler(object sender, ItemStateEvent eventObject);

    public class ItemStateEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public Property Payload { get; set; }

        #region Payload Parameters

        public string StateType => Payload.Type;

        public string StateValue => Payload.Value;

        #endregion
    }
}