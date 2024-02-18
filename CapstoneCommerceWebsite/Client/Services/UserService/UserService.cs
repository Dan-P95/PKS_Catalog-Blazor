using Azure.Core;

namespace PKS_Catalog.Client.Services.UserService
{
	public class UserService : IUserService
	{
		private readonly HttpClient _http;

		public UserService(HttpClient http)
		{
			_http = http;
		}
		public async Task<ServiceResponse<int>> AddUser(CreateUser request)
		{
			var result = await _http.PostAsJsonAsync("api/user/adduser", request);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
		}

		public async Task<ServiceResponse<string>> LoginUser(LoginUser request)
		{
			var result = await _http.PostAsJsonAsync("api/user/login", request);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
		}

		public async Task<ServiceResponse<User>> GetUser(int userId)
		{
			var result = await _http.GetFromJsonAsync<ServiceResponse<User>>($"api/{userId}");
			return result;
		}
	}
}
