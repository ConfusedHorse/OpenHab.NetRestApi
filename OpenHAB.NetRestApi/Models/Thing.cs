using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OpenHAB.NetRestApi.RestApi;

namespace OpenHAB.NetRestApi.Models
{
    public class Thing
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("bridgeUID")]
        public string BridgeUid { get; set; }

        [JsonProperty("configuration")]
        public object Configuration { get; set; }

        [JsonProperty("properties")]
        public object Properties { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("thingTypeUID")]
        public string ThingTypeUid { get; set; }

        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("statusInfo")]
        public StatusInfo StatusInfo { get; set; }

        [JsonProperty("firmwareStatus")]
        public Firmware FirmwareStatus { get; set; }

        [JsonProperty("editable ")]
        public bool Editable { get; set; }

        public override string ToString()
        {
            return Uid;
        }

        protected bool Equals(Thing other)
        {
            return string.Equals(Label, other.Label) && string.Equals(BridgeUid, other.BridgeUid) &&
                   Equals(Configuration, other.Configuration) && Equals(Properties, other.Properties) &&
                   string.Equals(Uid, other.Uid) && string.Equals(ThingTypeUid, other.ThingTypeUid) &&
                   Equals(Channels, other.Channels) && string.Equals(Location, other.Location) &&
                   Equals(StatusInfo, other.StatusInfo) && Equals(FirmwareStatus, other.FirmwareStatus) &&
                   Editable == other.Editable;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Thing) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Label != null ? Label.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (BridgeUid != null ? BridgeUid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Configuration != null ? Configuration.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Properties != null ? Properties.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Uid != null ? Uid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ThingTypeUid != null ? ThingTypeUid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Channels != null ? Channels.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Location != null ? Location.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StatusInfo != null ? StatusInfo.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirmwareStatus != null ? FirmwareStatus.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Editable.GetHashCode();
                return hashCode;
            }
        }

        #region Service Methods

        /// <summary>
        ///     Creates the thing and adds it to the registry.
        /// </summary>
        /// <returns></returns>
        public Thing Create()
        {
            return OpenHab.RestClient.ThingService.CreateThing(this);
        }

        /// <summary>
        ///     Updates the thing.
        /// </summary>
        /// <returns></returns>
        public Thing Update()
        {
            return OpenHab.RestClient.ThingService.UpdateThing(this);
        }

        /// <summary>
        ///     Removes the thing from the registry. Set 'force' to true if you want the thing to be removed immediately.
        /// </summary>
        /// <param name="force"></param>
        /// <returns></returns>
        public string Delete(bool force = false)
        {
            return OpenHab.RestClient.ThingService.DeleteThing(this, force);
        }

        /// <summary>
        ///     Refreshes information about the thing.
        /// </summary>
        /// <returns></returns>
        public Thing Refresh()
        {
            var thing = OpenHab.RestClient.ThingService.GetThing(Uid);
            BridgeUid = thing.BridgeUid;
            Channels = thing.Channels;
            Configuration = thing.Configuration;
            Editable = thing.Editable;
            FirmwareStatus = thing.FirmwareStatus;
            Label = thing.Label;
            Location = thing.Location;
            Properties = thing.Location;
            StatusInfo = thing.StatusInfo;
            ThingTypeUid = thing.ThingTypeUid;
            return this;
        }

        /// <summary>
        ///     Links item to a channel. Creates item if such does not exist yet.
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public string CreateChannelLink(Channel channel)
        {
            Channels.Add(channel);
            return OpenHab.RestClient.ThingService.CreateChannelLink(this, channel);
        }

        /// <summary>
        ///     Unlinks item from a channel.
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public string DeleteChannelLink(Channel channel)
        {
            var channelToBeDeleted = Channels.FirstOrDefault(c => c.Uid == channel.Uid);
            if (channelToBeDeleted == null) return $"{channel} is not linked.";
            Channels.Remove(channelToBeDeleted);
            return OpenHab.RestClient.ThingService.DeleteChannelLink(this, channel);
        }

        /// <summary>
        ///     Update thing firmware.
        /// </summary>
        /// <returns></returns>
        public string UpdateFirmware()
        {
            return OpenHab.RestClient.ThingService.UpdateThingFirmware(Uid, FirmwareStatus.UpdatableVersion);
        }

        /// <summary>
        ///     Updates thing's configuration.
        /// </summary>
        /// <returns></returns>
        public Thing UpdateChannelConfiguration()
        {
            return OpenHab.RestClient.ThingService.UpdateThingConfiguration(this);
        }

        #endregion
    }
}