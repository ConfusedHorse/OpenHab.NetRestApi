using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Firmware
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("updatableVersion")]
        public string UpdatableVersion { get; set; }

        protected bool Equals(Firmware other)
        {
            return string.Equals(Status, other.Status) && string.Equals(UpdatableVersion, other.UpdatableVersion);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Firmware) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Status != null ? Status.GetHashCode() : 0) * 397) ^
                       (UpdatableVersion != null ? UpdatableVersion.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return Status;
        }
    }
}