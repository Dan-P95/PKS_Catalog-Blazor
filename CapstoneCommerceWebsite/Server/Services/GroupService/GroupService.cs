namespace PKS_Catalog.Server.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly DataContext _context;

        public GroupService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Group>>> GetGroupsAsync()
        {
            var groups = await _context.Groups.ToListAsync();
            return new ServiceResponse<List<Group>> { Data = groups };
        }
    }
}
