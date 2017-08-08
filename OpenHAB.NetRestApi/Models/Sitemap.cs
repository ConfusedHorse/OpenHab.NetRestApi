using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Sitemap
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("homepage")]
        public Homepage Homepage { get; set; }

        protected bool Equals(Sitemap other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Label, other.Label) &&
                   string.Equals(Link, other.Link) && Equals(Homepage, other.Homepage);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Sitemap) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name != null ? Name.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Link != null ? Link.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Homepage != null ? Homepage.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}