using System.Collections.Generic;
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
        public List<ModuleType> GetModuleTypes()
        {
            return GetModuleTypesAsync().Result;
        }

        public Task<List<ModuleType>> GetModuleTypesAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/module-types";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ModuleType>>(Method.GET, resource, token: token);
        }

        public List<ModuleType> GetModuleTypes(string type, string tag = default(string))
        {
            return GetModuleTypesAsync(type, tag).Result;
        }

        public Task<List<ModuleType>> GetModuleTypesAsync(string type, string tag = default(string), CancellationToken token = default(CancellationToken))
        {
            var typeParameter = !string.IsNullOrWhiteSpace(type) ? new ResourceParameter("type", type) : null;
            var tagsParameter = !string.IsNullOrWhiteSpace(tag) ? new ResourceParameter("tags", tag) : null;

            var parameters = Resource.FormatParameters(typeParameter, tagsParameter);
            var resource = $"/module-types{parameters}";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ModuleType>>(Method.GET, resource, token: token);
        }

        public List<ModuleType> GetModuleTypes(RuleMemberType type, string tag = default(string))
        {
            return GetModuleTypesAsync(type, tag).Result;
        }

        public Task<List<ModuleType>> GetModuleTypesAsync(RuleMemberType type, string tag = default(string), CancellationToken token = default(CancellationToken))
        {
            var typeParameter = !string.IsNullOrWhiteSpace(type.ToString()) ? new ResourceParameter("type", type.ToString()) : null;
            var tagsParameter = !string.IsNullOrWhiteSpace(tag) ? new ResourceParameter("tags", tag) : null;

            var parameters = Resource.FormatParameters(typeParameter, tagsParameter);
            var resource = $"/module-types{parameters}";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ModuleType>>(Method.GET, resource, token: token);
        }

        public ModuleType GetModuleType(string moduleTypeUid)
        {
            return GetModuleTypeAsync(moduleTypeUid).Result;
        }

        public Task<ModuleType> GetModuleTypeAsync(string moduleTypeUid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/module-types/{moduleTypeUid}";
            return OpenHab.RestClient.ExecuteRequestAsync<ModuleType>(Method.GET, resource, token: token);
        }
    }
}