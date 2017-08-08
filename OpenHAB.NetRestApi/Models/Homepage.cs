using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Homepage
    {
        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("leaf")]
        public bool Leaf { get; set; }

        [JsonProperty("widgets")]
        public List<Widget> Widgets { get; set; }

        protected bool Equals(Homepage other)
        {
            return string.Equals(Link, other.Link) && Leaf == other.Leaf && Equals(Widgets, other.Widgets);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Homepage) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Link != null ? Link.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ Leaf.GetHashCode();
                hashCode = (hashCode * 397) ^ (Widgets != null ? Widgets.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Link;
        }
    }
}