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
        public List<string> GetBindings()
        {
            return GetBindingsAsync().Result;
        }

        public Task<List<string>> GetBindingsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/discovery";
            return OpenHab.RestClient.ExecuteRequestAsync<List<string>>(Method.GET, resource, token: token);
        }

        public int GetTimeout(string bindingId)
        {
            return GetTimeoutAsync(bindingId).Result;
        }

        public Task<int> GetTimeoutAsync(string bindingId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/discovery/bindings/{bindingId}/scan";
            return OpenHab.RestClient.ExecuteRequestAsync<int>(Method.POST, resource, requestHeaders: RequestHeader.AcceptPlainText, token: token);
        }
    }
}