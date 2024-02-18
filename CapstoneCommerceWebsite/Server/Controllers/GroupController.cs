using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PKS_Catalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Group>>>> GetGroups()
        {
            var result = await _groupService.GetGroupsAsync();
            return Ok(result);
        }
    }
}
