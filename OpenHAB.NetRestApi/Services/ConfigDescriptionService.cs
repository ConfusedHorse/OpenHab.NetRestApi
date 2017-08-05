using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class ConfigDescriptionService
    {
        /// <summary>
        /// Gets all available config descriptions.
        /// </summary>
        /// <returns></returns>
        public List<ServiceConfiguration> GetConfigDescriptions()
        {
            return GetConfigDescriptionsAsync().Result;
        }

        /// <summary>
        /// Gets all available config descriptions.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<ServiceConfiguration>> GetConfigDescriptionsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/config-descriptions";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ServiceConfiguration>>(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Gets a config description by URI.
        /// </summary>
        /// <param name="configDescriptionUri"></param>
        /// <returns></returns>
        public ServiceConfiguration GetConfigDescription(string configDescriptionUri)
        {
            return GetConfigDescriptionAsync(configDescriptionUri).Result;
        }

        /// <summary>
        /// Gets a config description by URI.
        /// </summary>
        /// <param name="configDescriptionUri"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<ServiceConfiguration> GetConfigDescriptionAsync(string configDescriptionUri, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/config-descriptions/{configDescriptionUri}";
            return OpenHab.RestClient.ExecuteRequestAsync<ServiceConfiguration>(Method.GET, resource, token: token);
        }
    }
}