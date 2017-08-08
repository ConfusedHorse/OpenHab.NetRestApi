using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class ThingTypeService
    {
        /// <summary>
        ///     Gets all available thing types without config description, channels and properties.
        /// </summary>
        /// <returns></returns>
        public List<ThingType> GetThingTypes()
        {
            return GetThingTypesAsync().Result;
        }

        /// <summary>
        ///     Gets all available thing types without config description, channels and properties.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<ThingType>> GetThingTypesAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/thing-types";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ThingType>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets thing type by UID.
        /// </summary>
        /// <param name="thingTypeUid"></param>
        /// <returns></returns>
        public ThingType GetThingType(string thingTypeUid)
        {
            return GetThingTypeAsync(thingTypeUid).Result;
        }

        /// <summary>
        ///     Gets thing type by UID.
        /// </summary>
        /// <param name="thingTypeUid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<ThingType> GetThingTypeAsync(string thingTypeUid,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/thing-types/{thingTypeUid}";
            return OpenHab.RestClient.ExecuteRequestAsync<ThingType>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Get all available firmwares for provided thingType.
        /// </summary>
        /// <param name="thingTypeUid"></param>
        /// <returns></returns>
        public List<string> GetFirmwares(string thingTypeUid)
        {
            return GetFirmwaresAsync(thingTypeUid).Result;
        }

        /// <summary>
        ///     Get all available firmwares for provided thingType.
        /// </summary>
        /// <param name="thingTypeUid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<string>> GetFirmwaresAsync(string thingTypeUid,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/thing-types/{thingTypeUid}/firmwares";
            return OpenHab.RestClient.ExecuteRequestAsync<List<string>>(Method.GET, resource, token: token);
        }
    }
}