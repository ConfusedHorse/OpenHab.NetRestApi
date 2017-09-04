using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;

namespace Openhab.NetRestApi.UnitTest
{
    [TestClass]
    public class OpenHabRestClientUnitTest
    {
        //connection parameters
        private const string Url = "192.168.2.111";
        private const bool StartEventService = false;

        private OpenHabRestClient _testClient;

        private const int ShortDelay = 100;
        private const int LongDelay = 500;

        [TestInitialize]
        public void InitializeConnection()
        {
            _testClient = OpenHab.CreateRestClient(Url, StartEventService);
        }

        public void TerminateConnection()
        {
            _testClient.EventService.TerminateAsync();
            _testClient.ClearCache();
        }

        [TestMethod]
        public void CheckConnection()
        {
            var success = _testClient.TestConnection();

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetTriggers()
        {
            var triggers = _testClient.ModuleTypeService.GetTriggers();
            var triggersCount = triggers.Count;

            Assert.AreEqual(8, triggersCount);
        }

        [TestMethod]
        public void GetConditions()
        {
            var conditions = _testClient.ModuleTypeService.GetConditions();
            var conditionsCount = conditions.Count;

            Assert.AreEqual(6, conditionsCount);
        }

        [TestMethod]
        public void GetActions()
        {
            var actions = _testClient.ModuleTypeService.GetActions();
            var actionsCount = actions.Count;

            Assert.AreEqual(7, actionsCount);
        }

        [TestMethod]
        public void GetThings()
        {
            var things = _testClient.ThingService.GetThings();
            var thingsCount = things.Count;

            Assert.AreNotEqual(0, thingsCount);
        }

        [TestMethod]
        public void GetThingTypes()
        {
            var thingTypes = _testClient.ThingTypeService.GetThingTypes();
            var thingTypesCount = thingTypes.Count;

            Assert.AreNotEqual(0, thingTypesCount);
        }

        [TestMethod]
        public void CreateAndDeleteThingByService()
        {
            var thingType = _testClient.ThingTypeService.GetThingTypes()?.First();
            Assert.IsNotNull(thingType);

            var thingService = _testClient.ThingService;

            var testThing = new Thing
            {
                Label = "This is a test thing. When you see it, delete it.",
                ThingTypeUid = thingType.ToString(), //returns uid
            };

            //create
            var thingCreated = thingService.CreateThing(testThing);
            Thread.Sleep(ShortDelay);

            var thingCreatedFromServer = thingService.GetThing(thingCreated.Uid);
            Assert.IsNotNull(thingCreatedFromServer); //created

            //delete
            thingService.DeleteThing(thingCreated, true);
            Thread.Sleep(LongDelay);

            var thingDeletedFromServer = thingService.GetThing(thingCreated.Uid);
            Assert.IsNull(thingDeletedFromServer); //deleted
        }

        [TestMethod]
        public void CreateAndDeleteThingByModel()
        {
            var thingType = _testClient.ThingTypeService.GetThingTypes()?.First();
            Assert.IsNotNull(thingType);

            var thingService = _testClient.ThingService;

            var testThing = new Thing
            {
                Label = "This is a test thing. When you see it, delete it.",
                ThingTypeUid = thingType.ToString() //returns uid
            };

            //create
            var thingCreated = testThing.Create();
            Thread.Sleep(ShortDelay);

            var thingCreatedFromServer = thingService.GetThing(thingCreated.Uid);
            Assert.IsNotNull(thingCreatedFromServer); //created

            //delete
            thingCreated.Delete(true);
            Thread.Sleep(LongDelay);

            var thingDeletedFromServer = thingService.GetThing(thingCreated.Uid);
            Assert.IsNull(thingDeletedFromServer); //deleted
        }

        [TestMethod]
        public void CreateAndDeleteRule()
        {
            const string ruleUid = "very:special:rule:uid";
            var ruleService = _testClient.RuleService;
            
            var testRule = new Rule
            {
                Name = "This is a test rule. When you see it, delete it.",
                Uid = ruleUid
            };

            //create
            var ruleCreated = ruleService.CreateRule(testRule);
            Assert.AreEqual(string.Empty, ruleCreated, true, ruleCreated);
            Thread.Sleep(ShortDelay);

            var ruleCreatedFromServer = ruleService.GetRule(ruleUid);
            Assert.IsNotNull(ruleCreatedFromServer); //created

            //delete
            var ruleDeleted = ruleService.DeleteRule(ruleUid);
            Assert.AreEqual(string.Empty, ruleDeleted, true, ruleDeleted);
            Thread.Sleep(LongDelay);

            var ruleDeletedFromServer = ruleService.GetRule(ruleUid);
            Assert.IsNull(ruleDeletedFromServer); //deleted
        }

        [TestMethod]
        public void CreateAndDeleteComplexRule()
        {
            const string ruleUid = "a:complex:rule:uid";

            const string todt = "timer.TimeOfDayTrigger";
            var triggerConfiguration = new { time = "22:00" };

            const string dowc = "timer.DayOfWeekCondition";
            var conditionConfiguration = new { days = new [] {"MON", "FRI"} };

            const string cica = "core.ItemCommandAction";
            var actionConfiguration = new { itemName = "notarealitem", command = "none" };

            var ruleService = _testClient.RuleService;

            var trigger = _testClient.ModuleTypeService.GetTriggers().FirstOrDefault(t => t.Uid == todt);
            var condition = _testClient.ModuleTypeService.GetConditions().FirstOrDefault(c => c.Uid == dowc);
            var action = _testClient.ModuleTypeService.GetActions().FirstOrDefault(a => a.Uid == cica);

            Assert.IsNotNull(trigger);
            Assert.IsNotNull(condition);
            Assert.IsNotNull(action);

            trigger.Configuration = triggerConfiguration;
            condition.Configuration = conditionConfiguration;
            action.Configuration = actionConfiguration;

            var testRule = new Rule
            {
                Name = "This is a test rule. When you see it, delete it.",
                Uid = ruleUid,
                Triggers = new List<Trigger> { trigger },
                Conditions = new List<Condition> { condition },
                Actions = new List<Action> { action }
            };

            //create
            var ruleCreated = ruleService.CreateRule(testRule);
            Assert.AreEqual(string.Empty, ruleCreated, true, ruleCreated);
            Thread.Sleep(ShortDelay);

            var ruleCreatedFromServer = ruleService.GetRule(ruleUid);
            Assert.IsNotNull(ruleCreatedFromServer); //created

            Assert.AreEqual(1, ruleCreatedFromServer.Triggers.Count);
            Assert.AreEqual(1, ruleCreatedFromServer.Conditions.Count);
            Assert.AreEqual(1, ruleCreatedFromServer.Actions.Count);

            //delete
            var ruleDeleted = ruleService.DeleteRule(ruleUid);
            Assert.AreEqual(string.Empty, ruleDeleted, true, ruleDeleted);
            Thread.Sleep(LongDelay);

            var ruleDeletedFromServer = ruleService.GetRule(ruleUid);
            Assert.IsNull(ruleDeletedFromServer); //deleted
        }
    }
}
