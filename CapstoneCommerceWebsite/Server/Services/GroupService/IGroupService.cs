namespace PKS_Catalog.Server.Services.GroupService
{
    public interface IGroupService
    {
        Task<ServiceResponse<List<Group>>> GetGroupsAsync();
    }
}
