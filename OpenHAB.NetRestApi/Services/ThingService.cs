using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class ThingService
    {
        /// <summary>
        ///     Get all available things.
        /// </summary>
        /// <returns></returns>
        public List<Thing> GetThings()
        {
            return GetThingsAsync().Result;
        }

        /// <summary>
        ///     Get all available things.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<Thing>> GetThingsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/things";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Thing>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets thing by UID.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public Thing GetThing(string uid)
        {
            var thing = GetThingAsync(uid).Result;
            return thing?.Uid == null ? null : thing;
        }

        /// <summary>
        ///     Gets thing by UID.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Thing> GetThingAsync(string uid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{uid}";
            return OpenHab.RestClient.ExecuteRequestAsync<Thing>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets thing's config status.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string GetThingConfigStatus(string uid)
        {
            return GetThingConfigStatusAsync(uid).Result.Content;
        }

        /// <summary>
        ///     Gets thing's config status.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> GetThingConfigStatusAsync(string uid,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{uid}/config/status";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets thing's firmware status.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string GetThingFirmwareStatus(string uid)
        {
            return GetThingFirmwareStatusAsync(uid).Result.Content;
        }

        /// <summary>
        ///     Gets thing's firmware status.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> GetThingFirmwareStatusAsync(string uid,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{uid}/firmware/status";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets thing's status.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public StatusInfo GetThingStatus(string uid)
        {
            return GetThingStatusAsync(uid).Result;
        }

        /// <summary>
        ///     Gets thing's status.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<StatusInfo> GetThingStatusAsync(string uid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{uid}/status";
            return OpenHab.RestClient.ExecuteRequestAsync<StatusInfo>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Creates a new thing and adds it to the registry.
        /// </summary>
        /// <param name="thing"></param>
        /// <returns></returns>
        public Thing CreateThing(Thing thing)
        {
            return CreateThingAsync(thing).Result;
        }

        /// <summary>
        ///     Creates a new thing and adds it to the registry.
        /// </summary>
        /// <param name="thing"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Thing> CreateThingAsync(Thing thing, CancellationToken token = default(CancellationToken))
        {
            //configuration must be applied seperately
            var thingConfiguration = thing.Configuration;
            thing.Configuration = null;

            //channels will be generated automagically
            thing.Channels = null;

            //creating thing
            const string resource = "/things";
            var thingResult = OpenHab.RestClient.ExecuteRequestAsync<Thing>(Method.POST, resource, thing, token: token);

            //applying configuration
            return UpdateThingConfigurationAsync(thingResult.Result.Uid, thingConfiguration, token);
        }

        /// <summary>
        ///     Links item to a channel. Creates item if such does not exist yet.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public string CreateChannelLink(string thingUid, string channelId)
        {
            return CreateChannelLinkAsync(thingUid, channelId).Result.Content;
        }

        /// <summary>
        ///     Links item to a channel. Creates item if such does not exist yet.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <param name="channelId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> CreateChannelLinkAsync(string thingUid, string channelId,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thingUid}/channels/{channelId}/link";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }

        /// <summary>
        ///     Links item to a channel. Creates item if such does not exist yet.
        /// </summary>
        /// <param name="thing"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public string CreateChannelLink(Thing thing, Channel channel)
        {
            return CreateChannelLinkAsync(thing, channel).Result.Content;
        }

        /// <summary>
        ///     Links item to a channel. Creates item if such does not exist yet.
        /// </summary>
        /// <param name="thing"></param>
        /// <param name="channel"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> CreateChannelLinkAsync(Thing thing, Channel channel,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thing.Uid}/channels/{channel.Id}/link";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }

        /// <summary>
        ///     Updates a thing.
        /// </summary>
        /// <param name="thing"></param>
        /// <returns></returns>
        public Thing UpdateThing(Thing thing)
        {
            return UpdateThingAsync(thing).Result;
        }

        /// <summary>
        ///     Updates a thing.
        /// </summary>
        /// <param name="thing"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Thing> UpdateThingAsync(Thing thing, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thing.Uid}";
            return OpenHab.RestClient.ExecuteRequestAsync<Thing>(Method.PUT, resource, thing, token: token);
        }

        /// <summary>
        ///     Updates thing's configuration.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <param name="thingConfiguration"></param>
        /// <returns></returns>
        public Thing UpdateThingConfiguration(string thingUid, object thingConfiguration)
        {
            return UpdateThingConfigurationAsync(thingUid, thingConfiguration).Result;
        }

        /// <summary>
        ///     Updates thing's configuration.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <param name="thingConfiguration"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Thing> UpdateThingConfigurationAsync(string thingUid, object thingConfiguration,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thingUid}/config";
            return OpenHab.RestClient.ExecuteRequestAsync<Thing>(Method.PUT, resource, thingConfiguration,
                token: token);
        }

        /// <summary>
        ///     Updates thing's configuration.
        /// </summary>
        /// <param name="thing"></param>
        /// <returns></returns>
        public Thing UpdateThingConfiguration(Thing thing)
        {
            return UpdateThingConfigurationAsync(thing).Result;
        }

        /// <summary>
        ///     Updates thing's configuration.
        /// </summary>
        /// <param name="thing"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Thing> UpdateThingConfigurationAsync(Thing thing,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thing.Uid}/config";
            return OpenHab.RestClient.ExecuteRequestAsync<Thing>(Method.PUT, resource, thing.Configuration,
                RequestHeader.FullJson, token);
        }

        /// <summary>
        ///     Update thing firmware.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="firmwareVersion"></param>
        /// <returns></returns>
        public string UpdateThingFirmware(string uid, string firmwareVersion)
        {
            return UpdateThingFirmwareAsync(uid, firmwareVersion).Result.Content;
        }

        /// <summary>
        ///     Update thing firmware.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="firmwareVersion"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> UpdateThingFirmwareAsync(string uid, string firmwareVersion,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{uid}/firmware/{firmwareVersion}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, token: token);
        }

        /// <summary>
        ///     Removes a thing from the registry. Set 'force' to true if you want the thing to be removed immediately.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        public string DeleteThing(string uid, bool force = false)
        {
            return DeleteThingAsync(uid).Result.Content;
        }

        /// <summary>
        ///     Removes a thing from the registry. Set 'force' to true if you want the thing to be removed immediately.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="force"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> DeleteThingAsync(string uid, bool force = false,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{uid}?force={force}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        /// <summary>
        ///     Removes a thing from the registry. Set 'force' to true if you want the thing to be removed immediately.
        /// </summary>
        /// <param name="thing"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        public string DeleteThing(Thing thing, bool force = false)
        {
            return DeleteThingAsync(thing).Result.Content;
        }

        /// <summary>
        ///     Removes a thing from the registry. Set 'force' to true if you want the thing to be removed immediately.
        /// </summary>
        /// <param name="thing"></param>
        /// <param name="force"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> DeleteThingAsync(Thing thing, bool force = false,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thing.Uid}?force={force}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        /// <summary>
        ///     Unlinks item from a channel.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public string DeleteChannelLink(string thingUid, string channelId)
        {
            return DeleteChannelLinkAsync(thingUid, channelId).Result.Content;
        }

        /// <summary>
        ///     Unlinks item from a channel.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <param name="channelId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> DeleteChannelLinkAsync(string thingUid, string channelId,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thingUid}/channels/{channelId}/link";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        /// <summary>
        ///     Unlinks item from a channel.
        /// </summary>
        /// <param name="thing"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public string DeleteChannelLink(Thing thing, Channel channel)
        {
            return DeleteChannelLinkAsync(thing, channel).Result.Content;
        }

        /// <summary>
        ///     Unlinks item from a channel.
        /// </summary>
        /// <param name="thing"></param>
        /// <param name="channel"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> DeleteChannelLinkAsync(Thing thing, Channel channel,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thing.Uid}/channels/{channel.Id}/link";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }
    }
}