using System;
using OpenHAB.NetRestApi.Constants;
using OpenHAB.NetRestApi.RestApi;

namespace OpenHAB.NetRestApi.Client
{
    /// <summary>
    /// THIS IS A TEST ENVIRONMENT (can be ignored)
    /// </summary>
    class Program
    {
        //private const string Url = "http://localhost:8080/rest";
        private const string Url = "http://192.168.2.111:8080/rest";
        private const bool StartEventService = true;

        static void Main(string[] args)
        {
            var openHab = OpenHab.CreateRestClient(Url, StartEventService);
            var moduleTypeService = openHab.ModuleTypeService;

            var moduleTypeActions = moduleTypeService.GetModuleTypes(RuleMemberType.action);
            var moduleTypeConditionss = moduleTypeService.GetModuleTypes(RuleMemberType.condition);
            var moduleTypeTriggers = moduleTypeService.GetModuleTypes(RuleMemberType.trigger);

            Console.ReadLine();
        }
    }
}
