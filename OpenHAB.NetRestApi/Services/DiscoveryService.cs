using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class DiscoveryService
    {
        /// <summary>
        ///     Gets all bindings that support discovery.
        /// </summary>
        /// <returns></returns>
        public List<string> GetBindings()
        {
            return GetBindingsAsync().Result;
        }

        /// <summary>
        ///     Gets all bindings that support discovery.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<string>> GetBindingsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/discovery";
            return OpenHab.RestClient.ExecuteRequestAsync<List<string>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Starts asynchronous discovery process for a binding and returns the timeout in seconds of the discovery operation.
        /// </summary>
        /// <param name="bindingId"></param>
        /// <returns></returns>
        public int GetTimeout(string bindingId)
        {
            return GetTimeoutAsync(bindingId).Result;
        }

        /// <summary>
        ///     Starts asynchronous discovery process for a binding and returns the timeout in seconds of the discovery operation.
        /// </summary>
        /// <param name="bindingId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<int> GetTimeoutAsync(string bindingId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/discovery/bindings/{bindingId}/scan";
            return OpenHab.RestClient.ExecuteRequestAsync<int>(Method.POST, resource,
                requestHeaders: RequestHeader.AcceptPlainText, token: token);
        }
    }
}