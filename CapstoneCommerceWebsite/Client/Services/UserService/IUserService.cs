namespace PKS_Catalog.Client.Services.UserService
{
	public interface IUserService
	{
		Task<ServiceResponse<int>> AddUser(CreateUser request);
		Task<ServiceResponse<string>> LoginUser(LoginUser request);
		Task<ServiceResponse<User>> GetUser(int userId);
	}
}
