using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Extension
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("installed")]
        public bool Installed { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        protected bool Equals(Extension other)
        {
            return string.Equals(Id, other.Id) && string.Equals(Label, other.Label) &&
                   string.Equals(Version, other.Version) && string.Equals(Link, other.Link) &&
                   Installed == other.Installed && string.Equals(Type, other.Type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Extension) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id != null ? Id.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Version != null ? Version.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Link != null ? Link.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Installed.GetHashCode();
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Id;
        }
    }
}