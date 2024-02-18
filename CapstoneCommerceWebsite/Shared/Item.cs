using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKS_Catalog.Shared
{
	public class Item
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		
		public string Brand { get; set; } = string.Empty;

		public Group? Group { get; set; }
		public int GroupId { get; set; }
		public List<ItemVariant> Variants { get; set; } = new List<ItemVariant>();
	}
}
