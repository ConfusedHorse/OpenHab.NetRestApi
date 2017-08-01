using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ThingStatusInfoChangedEventHandler(object sender, ThingStatusInfoChangedEvent eventObject);

    public class ThingStatusInfoChangedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public List<StatusInfo> Payload { get; set; }

        #region Payload Parameters

        public StatusInfo New => Payload.FirstOrDefault();

        public StatusInfo Old => Payload.LastOrDefault();

        #endregion
    }
}