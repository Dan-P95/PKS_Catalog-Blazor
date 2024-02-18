namespace PKS_Catalog.Client.Services.GroupService
{
	public class GroupService : IGroupService
	{
		private readonly HttpClient _http;

		public GroupService(HttpClient http)
		{
			_http = http;
		}
		public List<Group> Groups { get; set; }
		public async Task GetGroups()
		{
			var response = await _http.GetFromJsonAsync<ServiceResponse<List<Group>>>("api/Group");
			if(response != null && response != null)
			{
				Groups = response.Data;
			}

		}
	}
}
