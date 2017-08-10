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
    public class ItemService
    {
        /// <summary>
        ///     Get all available items.
        /// </summary>
        /// <returns></returns>
        public List<Item> GetItems()
        {
            return GetItemsAsync().Result;
        }

        /// <summary>
        ///     Get all available items.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<Item>> GetItemsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/items";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Item>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Get all available items.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tag"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public List<Item> GetItems(ChannelType type, string tag = default(string), bool recursive = default(bool))
        {
            return GetItemsAsync(type, tag, recursive).Result;
        }

        /// <summary>
        ///     Get all available items.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tag"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public Task<List<Item>> GetItemsAsync(ChannelType type, string tag = default(string),
            bool recursive = default(bool), CancellationToken token = default(CancellationToken))
        {
            var typeParameter = !string.IsNullOrWhiteSpace(type?.ItemType)
                ? new ResourceParameter("type", type.ItemType)
                : null;
            var tagsParameter = !string.IsNullOrWhiteSpace(tag) ? new ResourceParameter("tags", tag) : null;
            var recursiveParameter = new ResourceParameter("recursive", recursive.ToString());

            var parameters = Resource.FormatParameters(typeParameter, tagsParameter, recursiveParameter);
            var resource = $"/items{parameters}";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Item>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Get all available items.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tag"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public List<Item> GetItems(string type, string tag = default(string), bool recursive = default(bool))
        {
            return GetItemsAsync(type, tag, recursive).Result;
        }

        /// <summary>
        ///     Get all available items.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tag"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public Task<List<Item>> GetItemsAsync(string type, string tag = default(string), bool recursive = default(bool),
            CancellationToken token = default(CancellationToken))
        {
            var typeParameter = !string.IsNullOrWhiteSpace(type) ? new ResourceParameter("type", type) : null;
            var tagsParameter = !string.IsNullOrWhiteSpace(tag) ? new ResourceParameter("tags", tag) : null;
            var recursiveParameter = new ResourceParameter("recursive", recursive.ToString());

            var parameters = Resource.FormatParameters(typeParameter, tagsParameter, recursiveParameter);
            var resource = $"/items{parameters}";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Item>>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets all available item types.
        /// </summary>
        /// <returns></returns>
        public List<string> GetTypes()
        {
            return OpenHab.RestClient.ChannelTypeService.GetChannelTypes()
                .Select(ct => ct.ItemType)
                .Where(t => t != null)
                .Distinct().ToList();
        }

        /// <summary>
        ///     Gets all available item categories.
        /// </summary>
        /// <returns></returns>
        public List<string> GetCategories()
        {
            return OpenHab.RestClient.ChannelTypeService.GetChannelTypes()
                .Select(ct => ct.Category)
                .Where(c => c != null)
                .Distinct().ToList();
        }

        /// <summary>
        ///     Gets a single item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        public Item GetItem(string itemname)
        {
            return GetItemAsync(itemname).Result;
        }

        /// <summary>
        ///     Gets a single item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Item> GetItemAsync(string itemname, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{itemname}";
            return OpenHab.RestClient.ExecuteRequestAsync<Item>(Method.GET, resource, token: token);
        }

        /// <summary>
        ///     Gets the state of an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        public string GetItemState(string itemname)
        {
            return GetItemStateAsync(itemname).Result.Content;
        }

        /// <summary>
        ///     Gets the state of an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> GetItemStateAsync(string itemname,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{itemname}/state";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        /// <summary>
        ///     Sends a command to an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public string SendCommand(string itemname, string command)
        {
            return SendCommandAsync(itemname, command).Result.Content;
        }

        /// <summary>
        ///     Sends a command to an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="command"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> SendCommandAsync(string itemname, string command,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{itemname}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, command, token: token);
        }

        /// <summary>
        ///     Sends a command to an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public string SendCommand(string itemname, Command command)
        {
            return SendCommandAsync(itemname, command).Result.Content;
        }

        /// <summary>
        ///     Sends a command to an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="command"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> SendCommandAsync(string itemname, Command command,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{itemname}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, command.ToString(), token: token);
        }

        /// <summary>
        ///     Sends a command to an item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public string SendCommand(Item item, string command)
        {
            return SendCommandAsync(item, command).Result.Content;
        }

        /// <summary>
        ///     Sends a command to an item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="command"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> SendCommandAsync(Item item, string command,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{item.Name}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, command, RequestHeader.ContentPlainText, token);
        }

        /// <summary>
        ///     Adds a new item to the registry or updates the existing item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Item CreateItem(Item item)
        {
            return CreateItemAsync(item).Result;
        }

        /// <summary>
        ///     Adds a new item to the registry or updates the existing item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Item> CreateItemAsync(Item item, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{item.Name}";
            return OpenHab.RestClient.ExecuteRequestAsync<Item>(Method.PUT, resource, item, token: token);
        }

        /// <summary>
        ///     Adds a new item to the registry or updates the existing item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Item UpdateItem(Item item)
        {
            return UpdateItemAsync(item).Result;
        }

        /// <summary>
        ///     Adds a new item to the registry or updates the existing item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Item> UpdateItemAsync(Item item, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{item.Name}";
            return OpenHab.RestClient.ExecuteRequestAsync<Item>(Method.PUT, resource, item, token: token);
        }

        /// <summary>
        ///     Updates the state of an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string UpdateItemState(string itemname, string state)
        {
            return UpdateItemStateAsync(itemname, state).Result.Content;
        }

        /// <summary>
        ///     Updates the state of an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="state"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> UpdateItemStateAsync(string itemname, string state,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{itemname}/state";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, state, token: token);
        }

        /// <summary>
        ///     Adds a tag to an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string CreateItemTag(string itemname, string tag)
        {
            return CreateItemTagAsync(itemname, tag).Result.Content;
        }

        /// <summary>
        ///     Adds a tag to an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="tag"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> CreateItemTagAsync(string itemname, string tag,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{itemname}/tags/{tag}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, token: token);
        }

        /// <summary>
        ///     Adds a tag to an item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string CreateItemTag(Item item, string tag)
        {
            return CreateItemTagAsync(item, tag).Result.Content;
        }

        /// <summary>
        ///     Adds a tag to an item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tag"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> CreateItemTagAsync(Item item, string tag,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{item.Name}/tags/{tag}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, token: token);
        }

        /// <summary>
        ///     Adds a tag to an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string AddItemTag(string itemname, string tag)
        {
            return AddItemTagAsync(itemname, tag).Result.Content;
        }

        /// <summary>
        ///     Adds a tag to an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="tag"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> AddItemTagAsync(string itemname, string tag,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{itemname}/tags/{tag}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, token: token);
        }

        /// <summary>
        ///     Adds a tag to an item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string AddItemTag(Item item, string tag)
        {
            return AddItemTagAsync(item, tag).Result.Content;
        }

        /// <summary>
        ///     Adds a tag to an item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tag"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> AddItemTagAsync(Item item, string tag,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{item.Name}/tags/{tag}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, token: token);
        }

        /// <summary>
        ///     Adds a new member to a group item.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public string AddItemToGroup(string itemName, string groupName)
        {
            return AddItemToGroupAsync(itemName, groupName).Result.Content;
        }

        /// <summary>
        ///     Adds a new member to a group item.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="groupName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> AddItemToGroupAsync(string itemName, string groupName,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{groupName}/tags/{itemName}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, token: token);
        }

        /// <summary>
        ///     Adds a new member to a group item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public string AddItemToGroup(Item item, Item group)
        {
            return AddItemToGroupAsync(item, group).Result.Content;
        }

        /// <summary>
        ///     Adds a new member to a group item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="group"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> AddItemToGroupAsync(Item item, Item group,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{group.Name}/tags/{item.Name}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.PUT, resource, token: token);
        }

        /// <summary>
        ///     Removes an item from the registry.
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        public string DeleteItem(string itemname)
        {
            return DeleteItemAsync(itemname).Result.Content;
        }

        /// <summary>
        ///     Removes an item from the registry.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> DeleteItemAsync(string itemname,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{itemname}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        /// <summary>
        ///     Removes an item from the registry.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string DeleteItem(Item item)
        {
            return DeleteItemAsync(item).Result.Content;
        }

        /// <summary>
        ///     Removes an item from the registry.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> DeleteItemAsync(Item item, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{item.Name}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        /// <summary>
        ///     Removes a tag from an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string RemoveItemTag(string itemname, string tag)
        {
            return RemoveItemTagAsync(itemname, tag).Result.Content;
        }

        /// <summary>
        ///     Removes a tag from an item.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="tag"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> RemoveItemTagAsync(string itemname, string tag,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{itemname}/tags/{tag}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        /// <summary>
        ///     Removes a tag from an item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string RemoveItemTag(Item item, string tag)
        {
            return RemoveItemTagAsync(item, tag).Result.Content;
        }

        /// <summary>
        ///     Removes a tag from an item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tag"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> RemoveItemTagAsync(Item item, string tag,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{item.Name}/tags/{tag}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        /// <summary>
        ///     Removes an existing member from a group item.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public string RemoveItemFromGroup(string itemName, string groupName)
        {
            return RemoveItemFromGroupAsync(itemName, groupName).Result.Content;
        }

        /// <summary>
        ///     Removes an existing member from a group item.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="groupName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> RemoveItemFromGroupAsync(string itemName, string groupName,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{groupName}/tags/{itemName}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        /// <summary>
        ///     Removes an existing member from a group item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public string RemoveItemFromGroup(Item item, Item group)
        {
            return RemoveItemFromGroupAsync(item, group).Result.Content;
        }

        /// <summary>
        ///     Removes an existing member from a group item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="group"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> RemoveItemFromGroupAsync(Item item, Item group,
            CancellationToken token = default(CancellationToken))
        {
            var resource = $"/items/{group.Name}/tags/{item.Name}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }
    }
}