using System.Security.Cryptography;

namespace PKS_Catalog.Client.Services.GroupService
{
	public interface IGroupService
	{
		 List<Group> Groups { get; set; }
		 Task GetGroups();
	}
}
