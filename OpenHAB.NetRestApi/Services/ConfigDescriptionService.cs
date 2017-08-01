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
        public List<ConfigDescriptor> GetConfigDescriptors()
        {
            return GetConfigDescriptorsAsync().Result;
        }

        /// <summary>
        /// Gets all available config descriptions.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<ConfigDescriptor>> GetConfigDescriptorsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/config-descriptions";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ConfigDescriptor>>(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Gets a config description by URI.
        /// </summary>
        /// <param name="configDescriptorUri"></param>
        /// <returns></returns>
        public ConfigDescriptor GetConfigDescriptor(string configDescriptorUri)
        {
            return GetConfigDescriptorAsync(configDescriptorUri).Result;
        }

        /// <summary>
        /// Gets a config description by URI.
        /// </summary>
        /// <param name="configDescriptorUri"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<ConfigDescriptor> GetConfigDescriptorAsync(string configDescriptorUri, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/config-descriptions/{configDescriptorUri}";
            return OpenHab.RestClient.ExecuteRequestAsync<ConfigDescriptor>(Method.GET, resource, token: token);
        }
    }
}