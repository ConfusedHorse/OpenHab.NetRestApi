using System;
using System.Diagnostics;
using System.Linq;
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
            var ruleService = openHab.RuleService;

            var rules = ruleService.GetRules();
            var someRule = rules.FirstOrDefault();

            var configuration = ruleService.GetRuleConfiguration(someRule?.Uid);
            var ownConfiguration = someRule?.Configuration;

            var actions = ruleService.GetRuleActions(someRule?.Uid);
            var ownActions = someRule?.Actions;

            var ruleToBeDeleted = someRule;
            Debug.Assert(ruleToBeDeleted != null, "createRule != null");
            ruleToBeDeleted.Uid = "ruleToBeDeleted";
            Debug.WriteLine($"Count before adding new rule: {rules.Count}");

            Debug.WriteLine("Creating new rule...");
            ruleService.CreateRule(ruleToBeDeleted);
            rules = ruleService.GetRules();
            Debug.WriteLine($"Count after adding new rule: {rules.Count}");

            Debug.WriteLine("Deleting new rule...");
            ruleService.DeleteRule(ruleToBeDeleted);
            rules = ruleService.GetRules();
            Debug.WriteLine($"Count after adding new rule: {rules.Count}");

            Console.ReadLine();
        }
    }
}
