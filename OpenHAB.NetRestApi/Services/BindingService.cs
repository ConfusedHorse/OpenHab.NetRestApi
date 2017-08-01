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
        /// <summary>
        /// Get all bindings.
        /// </summary>
        /// <returns></returns>
        public List<Binding> GetBindings()
        {
            return GetBindingsAsync().Result;
        }

        /// <summary>
        /// Get all bindings.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<Binding>> GetBindingsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/bindings";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Binding>>(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Get binding configuration for given binding ID.
        /// </summary>
        /// <param name="bindingId"></param>
        /// <returns></returns>
        public object GetBindingConfiguration(string bindingId)
        {
            var result = GetBindingConfigurationAsync(bindingId).Result.Content;
            return JsonConvert.DeserializeObject(result);
        }

        /// <summary>
        /// Get binding configuration for given binding ID.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bindingId"></param>
        /// <returns></returns>
        public T GetBindingConfiguration<T>(string bindingId)
        {
            var result = GetBindingConfigurationAsync(bindingId).Result.Content;
            return JsonConvert.DeserializeObject<T>(result);
        }

        /// <summary>
        /// Get binding configuration for given binding ID.
        /// </summary>
        /// <param name="bindingId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> GetBindingConfigurationAsync(string bindingId, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/bindings/{bindingId}/config";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Updates a binding configuration for given binding ID and returns the old configuration.
        /// </summary>
        /// <param name="bindingId"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public object UpdateBindingConfiguration(string bindingId, object configuration)
        {
            return SetBindingConfigurationAsync(bindingId, configuration).Result;
        }

        /// <summary>
        /// Updates a binding configuration for given binding ID and returns the old configuration.
        /// </summary>
        /// <param name="bindingId"></param>
        /// <param name="configuration"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> SetBindingConfigurationAsync(string bindingId, object configuration, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/bindings/{bindingId}/config";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, configuration, RequestHeader.FullJson, token);
        }

        /// <summary>
        /// Updates a binding configuration for given binding ID and returns the old configuration.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bindingId"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public T UpdateBindingConfiguration<T>(string bindingId, T configuration)
        {
            return SetBindingConfigurationAsync(bindingId, configuration).Result;
        }

        /// <summary>
        /// Updates a binding configuration for given binding ID and returns the old configuration.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bindingId"></param>
        /// <param name="configuration"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<T> SetBindingConfigurationAsync<T>(string bindingId, T configuration, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/bindings/{bindingId}/config";
            return OpenHab.RestClient.ExecuteRequestAsync<T>(Method.PUT, resource, configuration, RequestHeader.FullJson, token);
        }
    }
}