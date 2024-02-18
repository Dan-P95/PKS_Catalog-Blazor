using System.Net.Http.Json;
using Azure.Core;
using PKS_Catalog.Client.Shared;
using PKS_Catalog.Shared;
using MudBlazor;

namespace PKS_Catalog.Client.Services.ItemService
{
	public class ItemService : IItemService
	{
		private readonly HttpClient _http;

		public ItemService(HttpClient http)
		{
			_http = http;
		}

		public event Action? ItemsChanged;
		public List<Item> Items { get; set; } = new List<Item>();
		public string Message { get; set; } = "Loading items...";

		public List<ItemGroup> ItemGroups { get; set; } = new List<ItemGroup>();
		public async Task GetItemGroups()
		{
			var result = await _http.GetFromJsonAsync<ServiceResponse<List<ItemGroup>>>("api/item/itemgroups");
			
			if (result != null && result.Data != null)
			{
				ItemGroups = result.Data;
			}

			ItemsChanged?.Invoke();
		}

		public async Task DeleteItem(int itemId)
		{
			var result = await _http.DeleteAsync($"api/item/remove/{itemId}");
			ItemsChanged.Invoke();
		}
		public async Task DeleteItemVariant(int itemId, int itemGroupId)
		{
			var result = await _http.DeleteAsync($"api/item/removevar/{itemId}/{itemGroupId}");
			ItemsChanged.Invoke();
		}

		public async Task<ServiceResponse<int>> EditItem(CreateItem item, int id)
		{
			var result = await _http.PutAsJsonAsync($"api/item/update/{id}", item);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
		}


		public async Task GetItems(string? groupUrl = null)
		{
			var result = groupUrl == null
				? await _http.GetFromJsonAsync<ServiceResponse<List<Item>>>("api/item")
				: await _http.GetFromJsonAsync<ServiceResponse<List<Item>>>($"api/item/group/{groupUrl}");
			if (result != null && result.Data != null)
			{
				Items = result.Data;
			}

			ItemsChanged?.Invoke();
		}

		public async Task<ServiceResponse<Item>> GetItem(int itemId)
		{
			var result = await _http.GetFromJsonAsync<ServiceResponse<Item>>($"api/item/{itemId}");
			return result;
		}

		public async Task SearchItems(string searchText)
		{
			var result =
				await _http.GetFromJsonAsync<ServiceResponse<List<Item>>>($"api/item/search/{searchText}");


			if (result != null && result.Data != null)
			{
				Items = result.Data;
			}
			if (Items.Count == 0)
			{
				Message = "No items found";
				
			}
			ItemsChanged?.Invoke();
		}

		public async Task<List<string>> GetSearchSuggestions(string searchText)
		{
			var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/item/searchsuggestions/{searchText}");
			return result.Data;
		}

		public async Task<ServiceResponse<int>> AddItem(CreateItem request)
		{
			var result = await _http.PostAsJsonAsync("api/item/additem", request);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
		}

		public async Task<ServiceResponse<int>> AddItemVariant(CreateItemVariant request)
		{
			var result = await _http.PostAsJsonAsync("api/item/additemvariant", request);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
		}

		

	}
}
