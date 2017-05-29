using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Helpers;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class ThingService
    {
        public List<Thing> GetThings()
        {
            return GetThingsAsync().Result;
        }

        public Task<List<Thing>> GetThingsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/things";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Thing>>(Method.GET, resource, token: token);
        }

        public Thing GetThing(string uid)
        {
            return GetThingAsync(uid).Result;
        }

        public Task<Thing> GetThingAsync(string uid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{uid}";
            return OpenHab.RestClient.ExecuteRequestAsync<Thing>(Method.GET, resource, token: token);
        }

        public string GetThingConfigStatus(string uid)
        {
            return GetThingConfigStatusAsync(uid).Result.Content;
        }

        public Task<IRestResponse> GetThingConfigStatusAsync(string uid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{uid}/config/status";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.GET, resource, token: token);
        }

        public Thing CreateThing(Thing thing)
        {
            return CreateThingAsync(thing).Result;
        }

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

        public string CreateChannelLink(string thingUid, string channelId)
        {
            return CreateChannelLinkAsync(thingUid, channelId).Result.Content;
        }

        public Task<IRestResponse> CreateChannelLinkAsync(string thingUid, string channelId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thingUid}/channels/{channelId}/link";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }

        public string CreateChannelLink(Thing thing, Channel channel)
        {
            return CreateChannelLinkAsync(thing, channel).Result.Content;
        }

        public Task<IRestResponse> CreateChannelLinkAsync(Thing thing, Channel channel, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thing.Uid}/channels/{channel.Id}/link";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }

        public Thing UpdateThing(Thing thing)
        {
            return UpdateThingAsync(thing).Result;
        }

        public Task<Thing> UpdateThingAsync(Thing thing, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thing.Uid}";
            return OpenHab.RestClient.ExecuteRequestAsync<Thing>(Method.PUT, resource, thing, token: token);
        }

        public Thing UpdateThingConfiguration(string thingUid, object thingConfiguration)
        {
            return UpdateThingConfigurationAsync(thingUid, thingConfiguration).Result;
        }

        public Task<Thing> UpdateThingConfigurationAsync(string thingUid, object thingConfiguration, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thingUid}/config";
            return OpenHab.RestClient.ExecuteRequestAsync<Thing>(Method.PUT, resource, thingConfiguration, token: token);
        }

        public Thing UpdateThingConfiguration(Thing thing)
        {
            return UpdateThingConfigurationAsync(thing).Result;
        }

        public Task<Thing> UpdateThingConfigurationAsync(Thing thing, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thing.Uid}/config";
            return OpenHab.RestClient.ExecuteRequestAsync<Thing>(Method.PUT, resource, thing.Configuration, RequestHeader.FullJson, token: token);
        }

        public string DeleteThing(string uid, bool force = false)
        {
            return DeleteThingAsync(uid).Result.Content;
        }

        public Task<IRestResponse> DeleteThingAsync(string uid, bool force = false, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{uid}?force={force}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }
        
        public string DeleteThing(Thing thing, bool force = false)
        {
            return DeleteThingAsync(thing).Result.Content;
        }

        public Task<IRestResponse> DeleteThingAsync(Thing thing, bool force = false, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thing.Uid}?force={force}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        public string DeleteChannelLink(string thingUid, string channelId)
        {
            return DeleteChannelLinkAsync(thingUid, channelId).Result.Content;
        }

        public Task<IRestResponse> DeleteChannelLinkAsync(string thingUid, string channelId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thingUid}/channels/{channelId}/link";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        public string DeleteChannelLink(Thing thing, Channel channel)
        {
            return DeleteChannelLinkAsync(thing, channel).Result.Content;
        }

        public Task<IRestResponse> DeleteChannelLinkAsync(Thing thing, Channel channel, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/things/{thing.Uid}/channels/{channel.Id}/link";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }
    }
}