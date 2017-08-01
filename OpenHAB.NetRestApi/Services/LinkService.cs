using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class LinkService
    {
        /// <summary>
        /// Gets all available links.
        /// </summary>
        /// <returns></returns>
        public List<Link> GetLinks()
        {
            return GetLinksAsync().Result;
        }

        /// <summary>
        /// Gets all available links.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<Link>> GetLinksAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/links";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Link>>(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Tells whether automatic link mode is active or not.
        /// </summary>
        /// <returns></returns>
        public bool AutoLink()
        {
            return AutoLinkAsync().Result;
        }

        /// <summary>
        /// Tells whether automatic link mode is active or not.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<bool> AutoLinkAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/links/auto";
            return OpenHab.RestClient.ExecuteRequestAsync<bool>(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Links item to a channel.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="channelUid"></param>
        /// <returns></returns>
        public string LinkChannel(string itemName, string channelUid)
        {
            return LinkChannelAsync(itemName, channelUid).Result.Content;
        }

        /// <summary>
        /// Links item to a channel.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="channelUid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> LinkChannelAsync(string itemName, string channelUid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/links/{itemName}/{channelUid}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, token: token);
        }

        /// <summary>
        /// Unlinks item from a channel.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="channelUid"></param>
        /// <returns></returns>
        public string UnlinksChannel(string itemName, string channelUid)
        {
            return UnlinksChannelAsync(itemName, channelUid).Result.Content;
        }

        /// <summary>
        /// Unlinks item from a channel.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="channelUid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> UnlinksChannelAsync(string itemName, string channelUid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/links/{itemName}/{channelUid}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }
    }
}