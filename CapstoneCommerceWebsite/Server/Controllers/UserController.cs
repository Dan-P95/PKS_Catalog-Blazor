using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PKS_Catalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("adduser")]
        public async Task<ActionResult<ServiceResponse<int>>> AddUser(CreateUser createUser)
        {
            var user = new User { UserName = createUser.UserName, Password = createUser.Password };

            var response = await _userService.AddUser(user, user.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(LoginUser request)
        {
            var response = await _userService.Login(request.UserName, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ServiceResponse<User>>> GetUser(int userId)
        {
            var result = await _userService.GetUser(userId);
            return Ok(result);
        }
    }
}
