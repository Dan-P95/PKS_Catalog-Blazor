using PKS_Catalog.Shared;
using Microsoft.AspNetCore.Mvc;

namespace PKS_Catalog.Server.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly DataContext _context;

        public ItemService(DataContext context)
        {
            _context = context;
        }

        //GET LIST OF ALL ITEMS
        public async Task<ServiceResponse<List<Item>>> GetItemsAsync()
        {
            var response = new ServiceResponse<List<Item>>
            {
                Data = await _context.Items.Include(p => p.Variants).ToListAsync()
            };
            return response;
        }

        //GET SPECIFIC ITEM BY ID
        public async Task<ServiceResponse<Item>> GetItemAsync(int itemId)
        {
            var response = new ServiceResponse<Item>();
            var item = await _context
                .Items.Include(p => p.Variants)
                .ThenInclude(v => v.ItemGroup)
                .FirstOrDefaultAsync(p => p.Id == itemId);
            if (item == null)
            {
                response.Success = false;
                response.Message = "This item cannot be found";
            }
            else
            {
                response.Data = item;
            }

            return response;
        }

        //GET ITEMS BY ITEM GROUP
        public async Task<ServiceResponse<List<Item>>> GetItemsByGroup(string groupUrl)
        {
            var response = new ServiceResponse<List<Item>>
            {
                Data = await _context
                    .Items.Where(p => p.Group.Url.ToLower().Equals(groupUrl.ToLower()))
                    .Include(p => p.Variants)
                    .ToListAsync()
            };

            return response;
        }

        //METHOD USED FOR SEARCHING ITEM MATCHING TEXT
        private async Task<List<Item>> FindItems(string searchText)
        {
            return await _context
                .Items.Where(p =>
                    p.Name.ToLower().Contains(searchText.ToLower())
                    || p.Description.ToLower().Contains(searchText.ToLower())
                )
                .Include(p => p.Variants)
                .ToListAsync();
        }

        //GET SEARCHED ITEM
        public async Task<ServiceResponse<List<Item>>> SearchItems(string searchText)
        {
            var response = new ServiceResponse<List<Item>> { Data = await FindItems(searchText) };
            return response;
        }

        //GET SEARCH SUGGESTIONS
        public async Task<ServiceResponse<List<string>>> GetItemSuggestions(string searchText)
        {
            var suggestions = await FindItems(searchText);
            List<string> result = new List<string>();

            foreach (var suggestion in suggestions)
            {
                //first search for matches within name
                if (suggestion.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(suggestion.Name);
                }

                //then search for matches in description
                //symbols must removed from the description otherwise matches won't work on certain words
                if (suggestion.Description != null)
                {
                    var symbols = suggestion
                        .Description.Where(char.IsPunctuation)
                        .Distinct()
                        .ToArray();
                    var words = suggestion.Description.Split().Select(s => s.Trim(symbols));

                    foreach (var word in words)
                    {
                        if (
                            word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word)
                        )
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }

        //ADD ITEM
        public async Task<ServiceResponse<int>> AddItem(Item item)
        {
            if (await CheckItem(item.Name))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "This item already exists"
                };
            }
            _context.Items.Add(item);
            //_context.ItemVariants.Add(itemVariant);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int> { Data = item.Id, Message = "Item Added" };
        }

        public async Task<ServiceResponse<int>> AddItemVariant(ItemVariant itemVariant)
        {
            if (await CheckItemVariant(itemVariant))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "This variant already exists"
                };
            }
            _context.Add(itemVariant);
            //_context.ItemVariants.Add(itemVariant);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int> { Data = itemVariant.ItemId, Message = "Item Added" };
        }

        public async Task<ServiceResponse<List<ItemGroup>>> GetItemGroups()
        {
            var response = new ServiceResponse<List<ItemGroup>>
            {
                Data = await _context.ItemGroups.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<int>> DeleteItem(int itemId)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId);
            if (item == null)
                return null;

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int> { Success = true, Message = "Item Deleted" };
        }

        public async Task<ServiceResponse<int>> DeleteItemVariant(
            int itemVariantId,
            int itemGroupId
        )
        {
            var item = await _context
                .ItemVariants.Where(iv => iv.ItemGroupId == itemGroupId)
                .FirstOrDefaultAsync(i => i.ItemId == itemVariantId);
            if (item == null)
            {
                return new ServiceResponse<int> { Success = false, Message = "Error" };
            }

            _context.ItemVariants.Remove(item);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int> { Success = true, Message = "Item Deleted" };
        }

        public async Task<ServiceResponse<int>> EditItem(Item item, int id)
        {
            var currentItem = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (currentItem == null)
            {
                return new ServiceResponse<int> { Success = false, Message = "Item Not Found" };
            }

            currentItem.Name = item.Name;
            currentItem.Description = item.Description;
            currentItem.GroupId = item.GroupId;
            currentItem.ImageUrl = item.ImageUrl;
            currentItem.Brand = item.Brand;

            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Success = true, Message = "Item Updated" };
        }

        public async Task<bool> CheckItem(string name)
        {
            if (await _context.Items.AnyAsync(item => item.Name.ToLower().Equals(name.ToLower())))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckItemVariant(ItemVariant itemVariant)
        {
            if (await _context.ItemVariants.AnyAsync(iv => iv == itemVariant))
            {
                return true;
            }

            return false;
        }
    }
}
