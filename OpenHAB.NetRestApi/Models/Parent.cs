using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Parent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("leaf")]
        public bool Leaf { get; set; }

        protected bool Equals(Parent other)
        {
            return string.Equals(Id, other.Id) && string.Equals(Title, other.Title) &&
                   string.Equals(Link, other.Link) && Leaf == other.Leaf;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Parent) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id != null ? Id.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Link != null ? Link.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Leaf.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Id;
        }
    }
}