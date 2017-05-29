using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class BindingService
    {
        public List<Binding> GetBindings()
        {
            return GetBindingsAsync().Result;
        }

        public Task<List<Binding>> GetBindingsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/bindings";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Binding>>(Method.GET, resource, token: token);
        }

        public object GetBindingConfiguration(string bindingId)
        {
            var result = GetBindingConfigurationAsync(bindingId).Result.Content;
            return JsonConvert.DeserializeObject(result);
        }

        public T GetBindingConfiguration<T>(string bindingId)
        {
            var result = GetBindingConfigurationAsync(bindingId).Result.Content;
            return JsonConvert.DeserializeObject<T>(result);
        }

        public Task<IRestResponse> GetBindingConfigurationAsync(string bindingId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/bindings/{bindingId}/config";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.GET, resource, token: token);
        }

        public object UpdateBindingConfiguration(string bindingId, object configuration)
        {
            return SetBindingConfigurationAsync(bindingId, configuration).Result;
        }

        public Task<IRestResponse> SetBindingConfigurationAsync(string bindingId, object configuration, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/bindings/{bindingId}/config";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, configuration, RequestHeader.FullJson, token);
        }

        public T UpdateBindingConfiguration<T>(string bindingId, T configuration)
        {
            return SetBindingConfigurationAsync(bindingId, configuration).Result;
        }

        public Task<T> SetBindingConfigurationAsync<T>(string bindingId, T configuration, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/bindings/{bindingId}/config";
            return OpenHab.RestClient.ExecuteRequestAsync<T>(Method.PUT, resource, configuration, RequestHeader.FullJson, token);
        }
    }
}