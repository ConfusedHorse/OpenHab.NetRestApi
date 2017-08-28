using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class StatusInfo
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDetail")]
        public string StatusDetail { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public static StatusInfo Default => new StatusInfo
        {
            Status = "DISABLED",
            StatusDetail = "NONE"
        };

        protected bool Equals(StatusInfo other)
        {
            return string.Equals(Status, other.Status) && string.Equals(StatusDetail, other.StatusDetail) &&
                   string.Equals(Description, other.Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((StatusInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Status != null ? Status.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (StatusDetail != null ? StatusDetail.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Status;
        }
    }
}