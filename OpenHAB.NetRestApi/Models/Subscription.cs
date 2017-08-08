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

        protected bool Equals(Subscription other)
        {
            return string.Equals(Status, other.Status) && Equals(Context, other.Context);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Subscription) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Status != null ? Status.GetHashCode() : 0) * 397) ^
                       (Context != null ? Context.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return SubscriptionId ?? GetType().ToString();
        }
    }
}