using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class ChannelTypeService
    {
        public List<ChannelType> GetChannelTypes()
        {
            return GetChannelTypesAsync().Result;
        }

        public Task<List<ChannelType>> GetChannelTypesAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/channel-types";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ChannelType>>(Method.GET, resource, token: token);
        }

        public ChannelType GetChannelType(string channelTypeId)
        {
            return GetChannelTypeAsync(channelTypeId).Result;
        }

        public Task<ChannelType> GetChannelTypeAsync(string channelTypeId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/channel-types/{channelTypeId}";
            return OpenHab.RestClient.ExecuteRequestAsync<ChannelType>(Method.GET, resource, token: token);
        }
    }
}