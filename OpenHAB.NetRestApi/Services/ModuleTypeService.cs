using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Constants;
using OpenHAB.NetRestApi.Helpers;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class ModuleTypeService
    {
        /// <summary>
        ///     Get all available module types.
        /// </summary>
        /// <returns></returns>
        public List<ModuleType> GetModuleTypes()
        {
            return GetModuleTypesAsync().Result;
        }

        /// <summary>
        ///     Get all available module types.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<ModuleType>> GetModuleTypesAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/module-types";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ModuleType>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Get all available module types.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public List<ModuleType> GetModuleTypes(string type, string tag = default(string))
        {
            return GetModuleTypesAsync(type, tag).Result;
        }

        /// <summary>
        ///     Get all available module types.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tag"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<ModuleType>> GetModuleTypesAsync(string type, string tag = default(string),
            CancellationToken token = default(CancellationToken))
        {
            var typeParameter = !string.IsNullOrWhiteSpace(type) ? new ResourceParameter("type", type) : null;
            var tagsParameter = !string.IsNullOrWhiteSpace(tag) ? new ResourceParameter("tags", tag) : null;

            var parameters = Resource.FormatParameters(typeParameter, tagsParameter);
            var resource = $"/module-types{parameters}";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ModuleType>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Get all available module types.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public List<ModuleType> GetModuleTypes(RuleMemberType type, string tag = default(string))
        {
            return GetModuleTypesAsync(type, tag).Result;
        }

        /// <summary>
        ///     Get all available module types of type "trigger"
        /// </summary>
        /// <returns></returns>
        public List<Trigger> GetTriggers()
        {
            return GetModuleTypesAsync<Trigger>(RuleMemberType.trigger).Result;
        }

        /// <summary>
        ///     Get all available module types of type "condition"
        /// </summary>
        /// <returns></returns>
        public List<Condition> GetConditions()
        {
            return GetModuleTypesAsync<Condition>(RuleMemberType.condition).Result;
        }

        /// <summary>
        ///     Get all available module types of type "action"
        /// </summary>
        /// <returns></returns>
        public List<Action> GetActions()
        {
            return GetModuleTypesAsync<Action>(RuleMemberType.action).Result;
        }

        /// <summary>
        ///     Get all available module types.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tag"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<ModuleType>> GetModuleTypesAsync(RuleMemberType type, string tag = default(string),
            CancellationToken token = default(CancellationToken))
        {
            var typeParameter = !string.IsNullOrWhiteSpace(type.ToString())
                ? new ResourceParameter("type", type.ToString())
                : null;
            var tagsParameter = !string.IsNullOrWhiteSpace(tag) ? new ResourceParameter("tags", tag) : null;

            var parameters = Resource.FormatParameters(typeParameter, tagsParameter);
            var resource = $"/module-types{parameters}";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ModuleType>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Get all available module types.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tag"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        internal Task<List<T>> GetModuleTypesAsync<T>(RuleMemberType type, string tag = default(string),
            CancellationToken token = default(CancellationToken))
        {
            var typeParameter = !string.IsNullOrWhiteSpace(type.ToString())
                ? new ResourceParameter("type", type.ToString())
                : null;
            var tagsParameter = !string.IsNullOrWhiteSpace(tag) ? new ResourceParameter("tags", tag) : null;

            var parameters = Resource.FormatParameters(typeParameter, tagsParameter);
            var resource = $"/module-types{parameters}";
            return OpenHab.RestClient.ExecuteRequestAsync<List<T>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets a module type corresponding to the given UID.
        /// </summary>
        /// <param name="moduleTypeUid"></param>
        /// <returns></returns>
        public ModuleType GetModuleType(string moduleTypeUid)
        {
            return GetModuleTypeAsync(moduleTypeUid).Result;
        }

        /// <summary>
        ///     Gets a module type corresponding to the given UID.
        /// </summary>
        /// <param name="moduleTypeUid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<ModuleType> GetModuleTypeAsync(string moduleTypeUid,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/module-types/{moduleTypeUid}";
            return OpenHab.RestClient.ExecuteRequestAsync<ModuleType>(Method.GET, resource, token: token);
        }
    }
}