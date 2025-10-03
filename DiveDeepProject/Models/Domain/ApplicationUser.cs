using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepProject.Models.Domain
{
	public class ApplicationUser : IdentityUser
	{
        [Required]
        public string Name { get; set; }
     
        [Required]
        public string Address { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }

        public List<Product>? Products { get; set; }
        public ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
    }
}
