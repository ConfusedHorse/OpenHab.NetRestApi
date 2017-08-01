using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class ExtensionService
    {
        public List<Extension> GetExtensions()
        {
            return GetExtensionsAsync().Result;
        }
        
        public Task<List<Extension>> GetExtensionsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/extensions";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Extension>>(Method.GET, resource, token: token);
        }

        public List<ExtensionType> GetExtensionTypes()
        {
            return GetExtensionTypesAsync().Result;
        }
        
        public Task<List<ExtensionType>> GetExtensionTypesAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/extensions";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ExtensionType>>(Method.GET, resource, token: token);
        }
        
        public Extension GetExtension(string extensionId)
        {
            return GetExtensionAsync(extensionId).Result;
        }
        
        public Task<Extension> GetExtensionAsync(string extensionId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/extensions/{extensionId}";
            return OpenHab.RestClient.ExecuteRequestAsync<Extension>(Method.GET, resource, token: token);
        }

        public string InstallExtensionByUrl(string url)
        {
            return InstallExtensionByUrlAsync(url).Result.Content;
        }

        public Task<IRestResponse> InstallExtensionByUrlAsync(string url, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/extensions/url/{url}/install";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }

        public string InstallExtension(string extensionId)
        {
            return InstallExtensionAsync(extensionId).Result.Content;
        }

        public Task<IRestResponse> InstallExtensionAsync(string extensionId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/extensions/{extensionId}/install";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }

        public string UninstallExtension(string extensionId)
        {
            return UninstallExtensionAsync(extensionId).Result.Content;
        }

        public Task<IRestResponse> UninstallExtensionAsync(string extensionId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/extensions/{extensionId}/uninstall";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }
    }
}