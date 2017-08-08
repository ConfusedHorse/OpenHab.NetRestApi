using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Binding
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("configDescriptionURI")]
        public string ConfigDescriptionUri { get; set; }

        protected bool Equals(Binding other)
        {
            return string.Equals(Author, other.Author) && string.Equals(Description, other.Description) &&
                   string.Equals(Id, other.Id) && string.Equals(Name, other.Name) &&
                   string.Equals(ConfigDescriptionUri, other.ConfigDescriptionUri);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Binding) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Author != null ? Author.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
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