using PKS_Catalog.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PKS_Catalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Item>>>> GetItems()
        {
            var result = await _itemService.GetItemsAsync();
            return Ok(result);
        }

        [HttpGet("{itemId}")]
        public async Task<ActionResult<ServiceResponse<Item>>> GetItem(int itemId)
        {
            var result = await _itemService.GetItemAsync(itemId);
            return Ok(result);
        }

        [HttpGet("group/{groupUrl}")]
        public async Task<ActionResult<ServiceResponse<Item>>> GetItemsByGroup(string groupUrl)
        {
            var result = await _itemService.GetItemsByGroup(groupUrl);
            return Ok(result);
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<ServiceResponse<Item>>> SearchItems(string searchText)
        {
            var result = await _itemService.SearchItems(searchText);
            return Ok(result);
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<Item>>> GetItemSuggestions(string searchText)
        {
            var result = await _itemService.GetItemSuggestions(searchText);
            return Ok(result);
        }

        [HttpPost("additem")]
        public async Task<ActionResult<ServiceResponse<int>>> AddItem(CreateItem createItem)
        {
            var item = new Item
            {
                Name = createItem.Name,
                Description = createItem.Description,
                ImageUrl = createItem.ImageUrl,
                Brand = createItem.Brand,
                GroupId = createItem.GroupId,
            };

            var response = await _itemService.AddItem(item);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("additemvariant")]
        public async Task<ActionResult<ServiceResponse<int>>> AddItemVariant(
            CreateItemVariant createItemVariant
        )
        {
            var itemVariant = new ItemVariant
            {
                Price = createItemVariant.Price,
                OriginalPrice = createItemVariant.OriginalPrice,
                ItemGroupId = createItemVariant.ItemGroupId,
                ItemId = createItemVariant.ItemId
            };

            var response = await _itemService.AddItemVariant(itemVariant);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("itemgroups")]
        public async Task<ActionResult<ServiceResponse<List<ItemGroup>>>> GetItemGroups()
        {
            var result = await _itemService.GetItemGroups();
            return Ok(result);
        }

        [HttpDelete("remove/{id}")]
        public async Task<ActionResult<ServiceResponse<int>>> DeleteItem(int id)
        {
            var result = await _itemService.DeleteItem(id);
            return Ok(result);
        }

        [HttpDelete("removevar/{id}/{groupId}")]
        public async Task<ActionResult<ServiceResponse<int>>> DeleteItemVariant(int id, int groupId)
        {
            var result = await _itemService.DeleteItemVariant(id, groupId);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ServiceResponse<int>>> EditItem(
            CreateItem createItem,
            int id
        )
        {
            var item = new Item
            {
                Name = createItem.Name,
                Description = createItem.Description,
                ImageUrl = createItem.ImageUrl,
                Brand = createItem.Brand,
                GroupId = createItem.GroupId,
            };

            var result = await _itemService.EditItem(item, id);
            return Ok(result);
        }
    }
}
