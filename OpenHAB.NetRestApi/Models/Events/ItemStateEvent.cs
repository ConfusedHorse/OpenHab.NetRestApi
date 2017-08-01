using Newtonsoft.Json;
using OpenHAB.NetRestApi.Models.Events.Payloads;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ItemStateEventHandler(object sender, ItemStateEvent eventObject);

    public class ItemStateEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public ItemStatePayload Payload { get; set; }

        #region Payload Parameters

        public string StateType => Payload.Type;

        public string StateValue => Payload.Value;

        #endregion
    }
}