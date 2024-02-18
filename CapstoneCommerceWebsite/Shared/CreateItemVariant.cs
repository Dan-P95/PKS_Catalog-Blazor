using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKS_Catalog.Shared
{
	public class CreateItemVariant
	{
		[Required]
		public decimal Price { get; set; }
		[Required]
		public decimal OriginalPrice { get; set; }
		[Required]
		public int ItemGroupId { get; set; }
		[Required]
		public int ItemId { get; set; }
	}
}
