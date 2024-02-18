using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKS_Catalog.Shared
{
	public class CreateItem
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public string ImageUrl { get; set; }
		[Required]
		public string Brand { get; set; }
		[Required]
		public int GroupId { get; set; }
		//[Required]
		//public CreateItemVariant Variant { get; set; }
		//public decimal Price { get; set; }
		//public decimal OriginalPrice { get; set; }

	}
}
