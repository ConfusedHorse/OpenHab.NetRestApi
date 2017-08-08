using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Template
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        protected bool Equals(Template other)
        {
            return string.Equals(Label, other.Label) && string.Equals(Uid, other.Uid) &&
                   string.Equals(Description, other.Description) && Equals(Tags, other.Tags) &&
                   string.Equals(Visibility, other.Visibility);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Template) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Label != null ? Label.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Uid != null ? Uid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Tags != null ? Tags.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Visibility != null ? Visibility.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Uid;
        }
    }
}