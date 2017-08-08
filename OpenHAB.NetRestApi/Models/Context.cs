using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Context
    {
        [JsonProperty("headers")]
        public Header Header { get; set; }

        [JsonProperty("committingOutputStream")]
        public Stream CommittingOutputStream { get; set; }

        [JsonProperty("entityAnnotations")]
        public List<object> EntityAnnotations { get; set; }

        [JsonProperty("entityStream")]
        public Stream EntityStream { get; set; }

        protected bool Equals(Context other)
        {
            return Equals(Header, other.Header) && Equals(CommittingOutputStream, other.CommittingOutputStream) &&
                   Equals(EntityAnnotations, other.EntityAnnotations) && Equals(EntityStream, other.EntityStream);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Context) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Header != null ? Header.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^
                           (CommittingOutputStream != null ? CommittingOutputStream.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EntityAnnotations != null ? EntityAnnotations.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EntityStream != null ? EntityStream.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Header.ToString();
        }
    }
}