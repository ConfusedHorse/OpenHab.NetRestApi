using System.Linq;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Subscription
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("context")]
        public Context Context { get; set; }

        public string SubscriptionId => Context?.Header?.SubscriptionIds?.FirstOrDefault();
    }
}