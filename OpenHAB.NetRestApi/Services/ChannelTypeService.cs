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
        /// <summary>
        ///     Gets all available channel types.
        /// </summary>
        /// <returns></returns>
        public List<ChannelType> GetChannelTypes()
        {
            return GetChannelTypesAsync().Result;
        }

        /// <summary>
        ///     Gets all available channel types.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<ChannelType>> GetChannelTypesAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/channel-types";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ChannelType>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets channel type by UID.
        /// </summary>
        /// <param name="channelTypeId"></param>
        /// <returns></returns>
        public ChannelType GetChannelType(string channelTypeId)
        {
            return GetChannelTypeAsync(channelTypeId).Result;
        }

        /// <summary>
        ///     Gets channel type by UID.
        /// </summary>
        /// <param name="channelTypeId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<ChannelType> GetChannelTypeAsync(string channelTypeId,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/channel-types/{channelTypeId}";
            return OpenHab.RestClient.ExecuteRequestAsync<ChannelType>(Method.GET, resource, token: token);
        }
    }
}