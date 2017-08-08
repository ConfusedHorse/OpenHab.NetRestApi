using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class ServiceService
    {
        /// <summary>
        ///     Get all configurable services.
        /// </summary>
        /// <returns></returns>
        public List<Service> GetServices()
        {
            return GetServicesAsync().Result;
        }

        /// <summary>
        ///     Get all configurable services.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<Service>> GetServicesAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/services";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Service>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Get configurable service for given service ID.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public Service GetService(string serviceId)
        {
            return GetServiceAsync(serviceId).Result;
        }

        /// <summary>
        ///     Get configurable service for given service ID.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Service> GetServiceAsync(string serviceId,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/services/{serviceId}";
            return OpenHab.RestClient.ExecuteRequestAsync<Service>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Get service configuration for given service ID.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public object GetServiceConfiguration(string serviceId)
        {
            return GetServiceConfigurationAsync(serviceId).Result;
        }

        /// <summary>
        ///     Get service configuration for given service ID.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<object> GetServiceConfigurationAsync(string serviceId,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/services/{serviceId}/config";
            return OpenHab.RestClient.ExecuteRequestAsync<object>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Updates a service configuration for given service ID and returns the old configuration.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public object UpdateServiceConfiguration(string serviceId, object configuration)
        {
            return UpdateServiceConfigurationAsync(serviceId, configuration).Result;
        }

        /// <summary>
        ///     Updates a service configuration for given service ID and returns the old configuration.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="configuration"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<object> UpdateServiceConfigurationAsync(string serviceId, object configuration,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/services/{serviceId}/config";
            return OpenHab.RestClient.ExecuteRequestAsync<object>(Method.PUT, resource, configuration, token: token);
        }

        /// <summary>
        ///     Deletes a service configuration for given service ID and returns the old configuration.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public object DeleteServiceConfiguration(string serviceId)
        {
            return DeleteServiceConfigurationAsync(serviceId).Result;
        }

        /// <summary>
        ///     Deletes a service configuration for given service ID and returns the old configuration.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<object> DeleteServiceConfigurationAsync(string serviceId,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/services/{serviceId}/config";
            return OpenHab.RestClient.ExecuteRequestAsync<object>(Method.DELETE, resource, token: token);
        }
    }
}