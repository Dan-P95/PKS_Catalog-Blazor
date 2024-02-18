using PKS_Catalog.Shared;

namespace PKS_Catalog.Client.Services.ItemService
{
	public interface IItemService
	{
		event Action ItemsChanged;

		List<Item> Items { get; set; }
		List<ItemGroup> ItemGroups { get; set; }
		string Message { get; set; }
		Task GetItems(string? groupUrl = null);
		Task<ServiceResponse<Item>> GetItem(int itemId);
		Task SearchItems(string searchText);
		Task<List<string>> GetSearchSuggestions(string searchText);

		Task<ServiceResponse<int>> AddItem(CreateItem request);
		Task<ServiceResponse<int>> AddItemVariant(CreateItemVariant request);

		
		Task GetItemGroups();

		Task DeleteItem(int itemId);
		Task DeleteItemVariant(int itemId, int itemGroupId);

		Task<ServiceResponse<int>> EditItem(CreateItem item, int id);

		//Task GetItemGroupsByItemId(int groupId);
	};

}

