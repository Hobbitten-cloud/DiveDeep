using Microsoft.AspNetCore.Identity;

namespace DiveDeepProject.Models.Domain
{
	public class ApplicationUser : IdentityUser
	{
		public List<Product>? Products { get; set; }
	}
}
