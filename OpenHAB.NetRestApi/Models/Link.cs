using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Link
    {
        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("channelUID")]
        public string ChannelUid { get; set; }

        protected bool Equals(Link other)
        {
            return string.Equals(ItemName, other.ItemName) && string.Equals(ChannelUid, other.ChannelUid);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Link) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((ItemName != null ? ItemName.GetHashCode() : 0) * 397) ^
                       (ChannelUid != null ? ChannelUid.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return $"{ChannelUid} is linked to {ItemName}";
        }
    }
}