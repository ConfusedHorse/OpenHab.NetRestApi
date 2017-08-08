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
    public class RuleService
    {
        /// <summary>
        ///     Get available rules, optionally filtered by prefix.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public List<Rule> GetRules(string prefix = default(string))
        {
            return GetRulesAsync(prefix, null).Result;
        }

        /// <summary>
        ///     Get available rules, optionally filtered by tags and/or prefix.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public List<Rule> GetRules(string prefix, params string[] tags)
        {
            return GetRulesAsync(prefix, tags).Result;
        }

        /// <summary>
        ///     Get available rules, optionally filtered by tags and/or prefix.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="tags"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<Rule>> GetRulesAsync(string prefix, string[] tags,
            CancellationToken token = default(CancellationToken))
        {
            var prefixParamater = !string.IsNullOrWhiteSpace(prefix) ? new ResourceParameter("prefix", prefix) : null;
            var tagParameters = tags?.Select(t => new ResourceParameter("tags", t)).ToList();
            var combinedParameters = new List<ResourceParameter>();
            if (prefixParamater != null) combinedParameters.Add(prefixParamater);
            if (tagParameters != null) combinedParameters.AddRange(tagParameters);

            var parameters = Resource.FormatParameters(combinedParameters.ToArray());
            var resource = $"/rules{parameters}";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Rule>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets the rule corresponding to the given UID.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public Rule GetRule(string uid)
        {
            return GetRuleAsync(uid).Result;
        }

        /// <summary>
        ///     Gets the rule corresponding to the given UID.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Rule> GetRuleAsync(string uid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}";
            return OpenHab.RestClient.ExecuteRequestAsync<Rule>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets the rule actions.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ModuleType> GetRuleActions(string uid)
        {
            return GetRuleActionsAsync(uid).Result;
        }

        /// <summary>
        ///     Gets the rule actions.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<ModuleType>> GetRuleActionsAsync(string uid,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}/actions";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ModuleType>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets the rule conditions.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ModuleType> GetRuleConditions(string uid)
        {
            return GetRuleConditionsAsync(uid).Result;
        }

        /// <summary>
        ///     Gets the rule conditions.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<ModuleType>> GetRuleConditionsAsync(string uid,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}/conditions";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ModuleType>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets the rule triggers.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ModuleType> GetRuleTriggers(string uid)
        {
            return GetRuleTriggersAsync(uid).Result;
        }

        /// <summary>
        ///     Gets the rule triggers.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<ModuleType>> GetRuleTriggersAsync(string uid,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}/triggers";
            return OpenHab.RestClient.ExecuteRequestAsync<List<ModuleType>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets the rule configuration values.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public object GetRuleConfiguration(string uid)
        {
            return GetRuleConfigurationAsync(uid).Result;
        }

        /// <summary>
        ///     Gets the rule configuration values.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<object> GetRuleConfigurationAsync(string uid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}/config";
            return OpenHab.RestClient.ExecuteRequestAsync<object>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets the rule's module corresponding to the given Category and ID.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="moduleCategory"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ModuleType GetRuleModule(string uid, string moduleCategory, string id)
        {
            return GetRuleModuleAsync(uid, moduleCategory, id).Result;
        }

        /// <summary>
        ///     Gets the rule's module corresponding to the given Category and ID.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="moduleCategory"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ModuleType GetRuleModule(string uid, RuleModuleCategory moduleCategory, string id)
        {
            return GetRuleModuleAsync(uid, moduleCategory.ToString(), id).Result;
        }

        /// <summary>
        ///     Gets the rule's module corresponding to the given Category and ID.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="moduleCategory"></param>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<ModuleType> GetRuleModuleAsync(string uid, string moduleCategory, string id,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}/{moduleCategory}/{id}";
            return OpenHab.RestClient.ExecuteRequestAsync<ModuleType>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets the module's configuration.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="moduleCategory"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetRuleModuleConfiguration(string uid, string moduleCategory, string id)
        {
            return GetRuleModuleConfigurationAsync(uid, moduleCategory, id).Result;
        }

        /// <summary>
        ///     Gets the module's configuration.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="moduleCategory"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetRuleModuleConfiguration(string uid, RuleModuleCategory moduleCategory, string id)
        {
            return GetRuleModuleConfigurationAsync(uid, moduleCategory.ToString(), id).Result;
        }

        /// <summary>
        ///     Gets the module's configuration.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="moduleCategory"></param>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<object> GetRuleModuleConfigurationAsync(string uid, string moduleCategory, string id,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}/{moduleCategory}/{id}/config";
            return OpenHab.RestClient.ExecuteRequestAsync<object>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets the module's configuration parameter.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="moduleCategory"></param>
        /// <param name="id"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string GetRuleModuleConfigurationParameter(string uid, string moduleCategory, string id, string param)
        {
            return GetRuleModuleConfigurationParameterAsync(uid, moduleCategory, id, param).Result.Content;
        }

        /// <summary>
        ///     Gets the module's configuration parameter.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="moduleCategory"></param>
        /// <param name="id"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string GetRuleModuleCGetRuleModuleConfigurationParameteronfiguration(string uid,
            RuleModuleCategory moduleCategory, string id, string param)
        {
            return GetRuleModuleConfigurationParameterAsync(uid, moduleCategory.ToString(), id, param).Result.Content;
        }

        /// <summary>
        ///     Gets the module's configuration parameter.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="moduleCategory"></param>
        /// <param name="id"></param>
        /// <param name="param"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> GetRuleModuleConfigurationParameterAsync(string uid, string moduleCategory,
            string id, string param, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}/{moduleCategory}/{id}/config/{param}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Creates a rule.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public string CreateRule(Rule rule)
        {
            return CreateRuleAsync(rule).Result.Content;
        }

        /// <summary>
        ///     Creates a rule.
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> CreateRuleAsync(Rule rule, CancellationToken token = default(CancellationToken))
        {
            const string resource = "/rules";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, rule, token: token);
        }

        /// <summary>
        ///     Sets the rule enabled status to true.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string EnableRule(string uid)
        {
            return EnableRuleAsync(uid, true).Result.Content;
        }

        /// <summary>
        ///     Sets the rule enabled status to true.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public string EnableRule(Rule rule)
        {
            return EnableRuleAsync(rule.Uid, true).Result.Content;
        }

        /// <summary>
        ///     Sets the rule enabled status to false.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string DisableRule(string uid)
        {
            return EnableRuleAsync(uid, false).Result.Content;
        }

        /// <summary>
        ///     Sets the rule enabled status to false.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public string DisableRule(Rule rule)
        {
            return EnableRuleAsync(rule.Uid, false).Result.Content;
        }

        /// <summary>
        ///     Sets the rule enabled status.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="enable"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> EnableRuleAsync(string uid, bool enable,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}/enable";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, enable, token: token);
        }

        /// <summary>
        ///     Executes actions of the rule.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string RunRule(string uid)
        {
            return RunRuleAsync(uid).Result.Content;
        }

        /// <summary>
        ///     Executes actions of the rule.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public string RunRule(Rule rule)
        {
            return RunRuleAsync(rule.Uid).Result.Content;
        }

        /// <summary>
        ///     Executes actions of the rule.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> RunRuleAsync(string uid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}/runnow";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }

        /// <summary>
        ///     Updates an existing rule.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public string UpdateRule(Rule rule)
        {
            return CreateRuleAsync(rule).Result.Content;
        }

        /// <summary>
        ///     Updates an existing rule.
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> UpdateRuleAsync(Rule rule, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{rule.Uid}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, rule, token: token);
        }

        /// <summary>
        ///     Sets the rule configuration values.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public string SetRuleConfiguration(string uid, object configuration)
        {
            return SetRuleConfigurationAsync(uid, configuration).Result.Content;
        }

        /// <summary>
        ///     Sets the rule configuration values.
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public string SetRuleConfiguration(Rule rule, object configuration)
        {
            return SetRuleConfigurationAsync(rule.Uid, configuration).Result.Content;
        }

        /// <summary>
        ///     Sets the rule configuration values.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="configuration"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> SetRuleConfigurationAsync(string uid, object configuration,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}/config";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, configuration, token: token);
        }

        /// <summary>
        ///     Sets the module's configuration parameter value.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="moduleCategory"></param>
        /// <param name="id"></param>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SetRuleModuleConfigurationParameter(string uid, string moduleCategory, string id, string param,
            string value)
        {
            return SetRuleModuleConfigurationParameterAsync(uid, moduleCategory, id, param, value).Result.Content;
        }

        /// <summary>
        ///     Sets the module's configuration parameter value.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="moduleCategory"></param>
        /// <param name="id"></param>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SetRuleModuleConfigurationParameter(string uid, RuleModuleCategory moduleCategory, string id,
            string param, string value)
        {
            return SetRuleModuleConfigurationParameterAsync(uid, moduleCategory.ToString(), id, param, value).Result
                .Content;
        }

        /// <summary>
        ///     Sets the module's configuration parameter value.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="moduleCategory"></param>
        /// <param name="id"></param>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> SetRuleModuleConfigurationParameterAsync(string uid, string moduleCategory,
            string id, string param, string value, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}/{moduleCategory}/{id}/config/{param}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, value, token: token);
        }

        /// <summary>
        ///     Removes an existing rule corresponding to the given UID.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string DeleteRule(string uid)
        {
            return DeleteRuleAsync(uid).Result.Content;
        }

        /// <summary>
        ///     Removes an existing rule.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public string DeleteRule(Rule rule)
        {
            return DeleteRuleAsync(rule.Uid).Result.Content;
        }

        /// <summary>
        ///     Removes an existing rule corresponding to the given UID.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> DeleteRuleAsync(string uid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/rules/{uid}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }
    }
}