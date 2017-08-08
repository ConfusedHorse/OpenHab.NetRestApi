using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OpenHAB.NetRestApi.RestApi;

namespace OpenHAB.NetRestApi.Models
{
    public class Rule
    {
        [JsonProperty("triggers")]
        public List<Trigger> Triggers { get; set; }

        [JsonProperty("conditions")]
        public List<Condition> Conditions { get; set; }

        [JsonProperty("actions")]
        public List<Action> Actions { get; set; }

        [JsonProperty("configuration")]
        public object Configuration { get; set; }

        [JsonProperty("configDescriptions")]
        public List<ConfigDescription> ConfigDescriptions { get; set; }

        [JsonProperty("templateUID")]
        public string TemplateUid { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("status")]
        public StatusInfo Status { get; set; }

        protected bool Equals(Rule other)
        {
            return Equals(Triggers, other.Triggers) && Equals(Conditions, other.Conditions) &&
                   Equals(Actions, other.Actions) && Equals(Configuration, other.Configuration) &&
                   Equals(ConfigDescriptions, other.ConfigDescriptions) &&
                   string.Equals(TemplateUid, other.TemplateUid) && string.Equals(Uid, other.Uid) &&
                   string.Equals(Name, other.Name) && Equals(Tags, other.Tags) &&
                   string.Equals(Visibility, other.Visibility) && string.Equals(Description, other.Description) &&
                   Enabled == other.Enabled && Equals(Status, other.Status);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Rule) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Triggers != null ? Triggers.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Conditions != null ? Conditions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Actions != null ? Actions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Configuration != null ? Configuration.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ConfigDescriptions != null ? ConfigDescriptions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TemplateUid != null ? TemplateUid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Uid != null ? Uid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Tags != null ? Tags.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Visibility != null ? Visibility.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Enabled.GetHashCode();
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Uid;
        }

        #region Service Methods

        /// <summary>
        ///     Creates the rule.
        /// </summary>
        /// <returns></returns>
        public string Create()
        {
            return OpenHab.RestClient.RuleService.CreateRule(this);
        }

        /// <summary>
        ///     Updates the rule.
        /// </summary>
        /// <returns></returns>
        public string Update()
        {
            return OpenHab.RestClient.RuleService.UpdateRule(this);
        }

        /// <summary>
        ///     Refreshes information about the rule.
        /// </summary>
        /// <returns></returns>
        public Rule Refresh()
        {
            var rule = OpenHab.RestClient.RuleService.GetRule(Uid);
            Triggers = rule.Triggers;
            Conditions = rule.Conditions;
            Actions = rule.Actions;
            Configuration = rule.Configuration;
            ConfigDescriptions = rule.ConfigDescriptions;
            TemplateUid = rule.TemplateUid;
            Uid = rule.Uid;
            Name = rule.Name;
            Tags = rule.Tags;
            Visibility = rule.Visibility;
            Description = rule.Description;
            Enabled = rule.Enabled;
            Status = rule.Status;
            return this;
        }

        /// <summary>
        ///     Removes the rule.
        /// </summary>
        /// <returns></returns>
        public string Delete()
        {
            return OpenHab.RestClient.RuleService.DeleteRule(this);
        }

        /// <summary>
        ///     Sets the rule enabled status to true.
        /// </summary>
        /// <returns></returns>
        public string Enable()
        {
            return OpenHab.RestClient.RuleService.EnableRule(this);
        }

        /// <summary>
        ///     Sets the rule enabled status to false.
        /// </summary>
        /// <returns></returns>
        public string Disable()
        {
            return OpenHab.RestClient.RuleService.DisableRule(this);
        }

        /// <summary>
        ///     Executes actions of the rule.
        /// </summary>
        /// <returns></returns>
        public string Run()
        {
            return OpenHab.RestClient.RuleService.RunRule(this);
        }

        /// <summary>
        ///     Sets the rule configuration values.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public string SetConfiguration(object configuration)
        {
            Configuration = configuration;
            return OpenHab.RestClient.RuleService.SetRuleConfiguration(this, configuration);
        }

        /// <summary>
        ///     Adds an action To the rule and updates it.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public string AddAction(Action action)
        {
            Actions.Add(action);
            return Update();
        }

        /// <summary>
        ///     Adds a trigger To the rule and updates it.
        /// </summary>
        /// <param name="trigger"></param>
        /// <returns></returns>
        public string AddTrigger(Trigger trigger)
        {
            Triggers.Add(trigger);
            return Update();
        }

        /// <summary>
        ///     Adds a condition To the rule and updates it.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public string AddCondition(Condition condition)
        {
            Conditions.Add(condition);
            return Update();
        }

        /// <summary>
        ///     Removes an action from the rule and updates it.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public string RemoveAction(Action action)
        {
            var actionToBeRemoved = Actions.FirstOrDefault(a => a.Id == action.Id);
            if (actionToBeRemoved == null) return $"{action} was not found.";
            Actions.Remove(actionToBeRemoved);
            return Update();
        }

        /// <summary>
        ///     Removes a trigger from the rule and updates it.
        /// </summary>
        /// <param name="trigger"></param>
        /// <returns></returns>
        public string RemoveTrigger(Trigger trigger)
        {
            var triggerToBeRemoved = Triggers.FirstOrDefault(t => t.Id == trigger.Id);
            if (triggerToBeRemoved == null) return $"{trigger} was not found.";
            Triggers.Remove(triggerToBeRemoved);
            return Update();
        }

        /// <summary>
        ///     Removes a condition from the rule and updates it.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public string RemoveCondition(Condition condition)
        {
            var conditionToBeRemoved = Conditions.FirstOrDefault(c => c.Id == condition.Id);
            if (conditionToBeRemoved == null) return $"{condition} was not found.";
            Conditions.Remove(conditionToBeRemoved);
            return Update();
        }

        #endregion
    }
}