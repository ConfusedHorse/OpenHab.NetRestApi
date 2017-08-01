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
        /// <summary>
        /// Get all extensions.
        /// </summary>
        /// <returns></returns>
        public List<Extension> GetExtensions()
        {
            return GetExtensionsAsync().Result;
        }

        /// <summary>
        /// Get all extensions.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<Extension>> GetExtensionsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/extensions";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Extension>>(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Get all extension types.
        /// </summary>
        /// <returns></returns>
        public List<ExtensionType> GetExtensionTypes()
        {
            return GetExtensionTypesAsync().Result;
        }

        /// <summary>
        /// Get all extension types.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<ExtensionType>> GetExtensionTypesAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/extensions";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ExtensionType>>(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Get extension with given ID.
        /// </summary>
        /// <param name="extensionId"></param>
        /// <returns></returns>
        public Extension GetExtension(string extensionId)
        {
            return GetExtensionAsync(extensionId).Result;
        }

        /// <summary>
        /// Get extension with given ID.
        /// </summary>
        /// <param name="extensionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Extension> GetExtensionAsync(string extensionId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/extensions/{extensionId}";
            return OpenHab.RestClient.ExecuteRequestAsync<Extension>(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Installs the extension from the given URL.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string InstallExtensionByUrl(string url)
        {
            return InstallExtensionByUrlAsync(url).Result.Content;
        }

        /// <summary>
        /// Installs the extension from the given URL.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> InstallExtensionByUrlAsync(string url, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/extensions/url/{url}/install";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }

        /// <summary>
        /// Installs the extension with the given ID.
        /// </summary>
        /// <param name="extensionId"></param>
        /// <returns></returns>
        public string InstallExtension(string extensionId)
        {
            return InstallExtensionAsync(extensionId).Result.Content;
        }

        /// <summary>
        /// Installs the extension with the given ID.
        /// </summary>
        /// <param name="extensionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> InstallExtensionAsync(string extensionId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/extensions/{extensionId}/install";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }

        /// <summary>
        /// Uninstalls the extension with the given ID.
        /// </summary>
        /// <param name="extensionId"></param>
        /// <returns></returns>
        public string UninstallExtension(string extensionId)
        {
            return UninstallExtensionAsync(extensionId).Result.Content;
        }

        /// <summary>
        /// Uninstalls the extension with the given ID.
        /// </summary>
        /// <param name="extensionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> UninstallExtensionAsync(string extensionId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/extensions/{extensionId}/uninstall";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }
    }
}