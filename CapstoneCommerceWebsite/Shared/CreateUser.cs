using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKS_Catalog.Shared
{
	public class CreateUser
	{
		[Required]
		[StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
		public string UserName { get; set; } = string.Empty;
		[Required]
		[StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
		public string Password { get; set; } = string.Empty;
		[Required]
		[Compare(nameof(Password))]
		public string Password2 { get; set; }
		
	}
}
