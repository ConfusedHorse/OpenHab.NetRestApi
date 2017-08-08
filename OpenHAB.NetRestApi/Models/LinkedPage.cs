using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class LinkedPage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        public string PageId => Regex.Match(Link, @"http://(.*?)/rest/(.*?)/(.*?)/(.*)").Groups[4].Value;

        [JsonProperty("leaf")]
        public bool Leaf { get; set; }

        [JsonProperty("widgets")]
        public List<Widget> Widgets { get; set; }

        protected bool Equals(LinkedPage other)
        {
            return string.Equals(Id, other.Id) && string.Equals(Title, other.Title) &&
                   string.Equals(Icon, other.Icon) && string.Equals(Link, other.Link) && Leaf == other.Leaf &&
                   Equals(Widgets, other.Widgets);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((LinkedPage) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id != null ? Id.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Icon != null ? Icon.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Link != null ? Link.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Leaf.GetHashCode();
                hashCode = (hashCode * 397) ^ (Widgets != null ? Widgets.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Id;
        }
    }
}