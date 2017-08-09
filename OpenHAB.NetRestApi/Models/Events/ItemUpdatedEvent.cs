using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ItemUpdatedEventHandler(object sender, ItemUpdatedEvent eventObject);

    public class ItemUpdatedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public List<Item> Payload { get; set; }

        #region Payload Parameters


        public Item NewItem => Payload.FirstOrDefault();

        public Item OldItem => Payload.LastOrDefault();

        #endregion
    }
}