using System.Collections.Generic;
using Newtonsoft.Json;
using OpenHAB.NetRestApi.Models.Events;
using OpenHAB.NetRestApi.RestApi;

namespace OpenHAB.NetRestApi.Models
{
    public class Item
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("groupNames")]
        public List<string> GroupNames { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("transformedState")]
        public string TransformedState { get; set; }

        [JsonProperty("stateDescription")]
        public StateDescription StateDescription { get; set; }

        protected bool Equals(Item other)
        {
            return string.Equals(Type, other.Type) && string.Equals(Name, other.Name) &&
                   string.Equals(Label, other.Label) && string.Equals(Category, other.Category) &&
                   Equals(Tags, other.Tags) && Equals(GroupNames, other.GroupNames) &&
                   string.Equals(Link, other.Link) && string.Equals(State, other.State) &&
                   string.Equals(TransformedState, other.TransformedState) &&
                   Equals(StateDescription, other.StateDescription);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Item) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Type != null ? Type.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Category != null ? Category.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Tags != null ? Tags.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (GroupNames != null ? GroupNames.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Link != null ? Link.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TransformedState != null ? TransformedState.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StateDescription != null ? StateDescription.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        #region Event Handlers

        // Note: this is experimental

        public event ItemUpdatedEventHandler Updated;
        public event ItemStateChangedEventHandler StateChanged;

        public void InitializeEvents()
        {
            var eventService = OpenHab.RestClient.EventService;

            eventService.ItemUpdated += EventServiceOnItemUpdated;
            eventService.ItemStateChanged += EventServiceOnItemStateChanged;

            if (!eventService.IsInitialized) eventService.InitializeAsync();
        }

        public void TerminateEvents()
        {
            var eventService = OpenHab.RestClient.EventService;

            eventService.ItemUpdated -= EventServiceOnItemUpdated;
            eventService.ItemStateChanged -= EventServiceOnItemStateChanged;
        }

        private void EventServiceOnItemUpdated(object sender, ItemUpdatedEvent eventObject)
        {
            if (eventObject.Target == Name) Updated?.Invoke(this, eventObject);
        }

        private void EventServiceOnItemStateChanged(object sender, ItemStateChangedEvent eventObject)
        {
            if (eventObject.Target == Name) StateChanged?.Invoke(this, eventObject);
        }

        #endregion

        #region Service Methods

        /// <summary>
        ///     Adds the item to the registry or updates the existing item.
        /// </summary>
        /// <returns></returns>
        public Item Create()
        {
            return OpenHab.RestClient.ItemService.CreateItem(this);
        }

        /// <summary>
        ///     Adds the item to the registry or updates the existing item.
        /// </summary>
        /// <returns></returns>
        public Item Update()
        {
            return OpenHab.RestClient.ItemService.UpdateItem(this);
        }

        /// <summary>
        ///     Refreshes information about the thing.
        /// </summary>
        /// <returns></returns>
        public Item Refresh()
        {
            var item = OpenHab.RestClient.ItemService.GetItem(Name);
            Type = item.Type;
            Name = item.Name;
            Label = item.Label;
            Category = item.Category;
            Tags = item.Tags;
            GroupNames = item.GroupNames;
            Link = item.Link;
            State = item.State;
            TransformedState = item.TransformedState;
            StateDescription = item.StateDescription;
            return this;
        }

        /// <summary>
        ///     Removes the item from the registry.
        /// </summary>
        /// <returns></returns>
        public string Delete()
        {
            return OpenHab.RestClient.ItemService.DeleteItem(this);
        }

        /// <summary>
        ///     Adds a tag to the item.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string AddTag(string tag)
        {
            return OpenHab.RestClient.ItemService.AddItemTag(this, tag);
        }

        /// <summary>
        ///     Removes a tag from the item.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string RemoveTag(string tag)
        {
            return OpenHab.RestClient.ItemService.RemoveItemTag(this, tag);
        }

        /// <summary>
        ///     Adds this item as a new member to a group item.
        /// </summary>
        /// <param name="groupItem"></param>
        /// <returns></returns>
        public string AddToGroup(Item groupItem)
        {
            return OpenHab.RestClient.ItemService.AddItemToGroup(this, groupItem);
        }

        /// <summary>
        ///     Adds this item as a new member to a group item.
        /// </summary>
        /// <param name="groupItem"></param>
        /// <returns></returns>
        public string AddToGroup(string groupItem)
        {
            return OpenHab.RestClient.ItemService.AddItemToGroup(Name, groupItem);
        }

        /// <summary>
        ///     Removes this item as a member from a group item.
        /// </summary>
        /// <param name="groupItem"></param>
        /// <returns></returns>
        public string RemoveFromGroup(Item groupItem)
        {
            return OpenHab.RestClient.ItemService.RemoveItemFromGroup(this, groupItem);
        }

        /// <summary>
        ///     Removes this item as a member from a group item.
        /// </summary>
        /// <param name="groupItem"></param>
        /// <returns></returns>
        public string RemoveFromGroup(string groupItem)
        {
            return OpenHab.RestClient.ItemService.RemoveItemFromGroup(Name, groupItem);
        }

        /// <summary>
        ///     Sends a command to an item.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string SendCommand(string command)
        {
            return OpenHab.RestClient.ItemService.SendCommand(this, command);
        }

        #endregion
    }
}