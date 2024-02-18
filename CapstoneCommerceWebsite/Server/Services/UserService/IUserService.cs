namespace PKS_Catalog.Server.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<int>> AddUser(User user, string password);
        Task<bool> CheckUser(string username);

        Task<ServiceResponse<string>> Login(string username, string password);
        Task<ServiceResponse<User>> GetUser(int userId);
    }
}
