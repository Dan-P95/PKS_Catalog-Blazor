using Microsoft.AspNetCore.Mvc;

namespace PKS_Catalog.Server.Services.Items
{
    public interface IItemService
    {
        Task<ServiceResponse<List<Item>>> GetItemsAsync();
        Task<ServiceResponse<Item>> GetItemAsync(int itemId);
        Task<ServiceResponse<List<Item>>> GetItemsByGroup(string groupUrl);
        Task<ServiceResponse<List<Item>>> SearchItems(string searchText);
        Task<ServiceResponse<List<string>>> GetItemSuggestions(string searchText);
        Task<ServiceResponse<int>> AddItem(Item item);
        Task<ServiceResponse<int>> AddItemVariant(ItemVariant itemVariant);

        Task<ServiceResponse<List<ItemGroup>>> GetItemGroups();
        Task<ServiceResponse<int>> DeleteItem(int itemId);
        Task<ServiceResponse<int>> DeleteItemVariant(int itemVariantId, int itemGroupId);

        Task<ServiceResponse<int>> EditItem(Item item, int id);
    }
}
