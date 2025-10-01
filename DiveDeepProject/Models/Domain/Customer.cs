using System.ComponentModel.DataAnnotations;

namespace DiveDeepProject.Models.Domain
{
    public class Customer
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
        public Customer()
        {

        }
    }
}
