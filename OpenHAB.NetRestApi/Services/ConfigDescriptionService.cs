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
        public List<ConfigDescriptor> GetConfigDescriptors()
        {
            return GetConfigDescriptorsAsync().Result;
        }

        public Task<List<ConfigDescriptor>> GetConfigDescriptorsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/config-descriptions";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ConfigDescriptor>>(Method.GET, resource, token: token);
        }

        public ConfigDescriptor GetConfigDescriptor(string configDescriptorUri)
        {
            return GetConfigDescriptorAsync(configDescriptorUri).Result;
        }

        public Task<ConfigDescriptor> GetConfigDescriptorAsync(string configDescriptorUri, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/config-descriptions/{configDescriptorUri}";
            return OpenHab.RestClient.ExecuteRequestAsync<ConfigDescriptor>(Method.GET, resource, token: token);
        }
    }
}