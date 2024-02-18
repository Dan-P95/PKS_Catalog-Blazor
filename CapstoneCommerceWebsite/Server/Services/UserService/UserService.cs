using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace PKS_Catalog.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<int>> AddUser(User user, string password)
        {
            if (await CheckUser(user.UserName))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "This username already exists"
                };
            }
            user.Password = password;
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int> { Data = user.Id, Message = "User Added" };
        }

        public async Task<bool> CheckUser(string username)
        {
            //USER should be USERS but was implemented incorrectly
            if (
                await _context.User.AnyAsync(user =>
                    user.UserName.ToLower().Equals(username.ToLower())
                )
            )
            {
                return true;
            }
            return false;
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.User.FirstOrDefaultAsync(i =>
                i.UserName.ToLower().Equals(username.ToLower())
            );
            if (user == null)
            {
                response.Success = false;
                response.Message = "Incorrect Login";
            }
            else if (user.Password != password)
            {
                response.Success = false;
                response.Message = "Password is incorrect";
            }
            else
            {
                response.Data = CreateToken(user);
            }
            return response;
        }

        public async Task<ServiceResponse<User>> GetUser(int userId)
        {
            var response = new ServiceResponse<User>();
            var user = await _context.User.FirstOrDefaultAsync(p => p.Id == userId);
            if (user == null)
            {
                response.Success = false;
                response.Message = "This user does not currently exist";
            }
            else
            {
                response.Data = user;
            }

            return response;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var key = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value
                )
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return jwtToken;
        }
    }
}
