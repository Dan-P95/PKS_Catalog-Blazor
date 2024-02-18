using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PKS_Catalog.Shared
{
	public class ItemVariant
	{
		[JsonIgnore]
		public Item Item { get; set; }
		public int ItemId { get; set; }
		public ItemGroup ItemGroup { get; set; }
		public int ItemGroupId { get; set; }
		[Column(TypeName ="decimal(18,2)")]
		public decimal Price { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal OriginalPrice { get; set; }
	}
}
