using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ItemStateChangedEventHandler(object sender, ItemStateChangedEvent eventObject);

    public class ItemStateChangedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public Property Payload { get; set; }
        
        #region Payload Parameters

        public string StateType => Payload.Type;

        public string StateValue => Payload.Value;

        public string OldStateType => Payload.OldType;

        public string OldStateValue => Payload.OldValue;

        #endregion
    }
}