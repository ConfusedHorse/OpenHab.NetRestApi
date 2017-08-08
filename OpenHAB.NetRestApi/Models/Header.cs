using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Header
    {
        [JsonProperty("Location")]
        public List<string> Locations { get; set; }

        public List<string> SubscriptionIds
            => Locations.Select(l =>
                    Regex.Match(l, @"http://(.*?)/rest/(.*?)/(.*?)/(.*)").Groups[4].Value)
                .ToList();

        protected bool Equals(Header other)
        {
            return Equals(Locations, other.Locations);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Header) obj);
        }

        public override int GetHashCode()
        {
            return Locations != null ? Locations.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Join(", ", SubscriptionIds);
        }
    }
}