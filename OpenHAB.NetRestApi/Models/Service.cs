using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Service
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("configDescriptionURI")]
        public string ConfigDescriptionUri { get; set; }

        protected bool Equals(Service other)
        {
            return string.Equals(Id, other.Id) && string.Equals(Label, other.Label) &&
                   string.Equals(Category, other.Category) &&
                   string.Equals(ConfigDescriptionUri, other.ConfigDescriptionUri);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Service) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id != null ? Id.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Category != null ? Category.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ConfigDescriptionUri != null ? ConfigDescriptionUri.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Id;
        }
    }
}