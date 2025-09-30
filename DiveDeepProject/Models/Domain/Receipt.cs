using System.ComponentModel.DataAnnotations;

namespace DiveDeepProject.Models.Domain
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }
        public Customer Customer { get; set; } 
        public DateTime PickupDate { get; set; } 
        public DateTime ReturnDate { get; set; }

		public double Total { get; set; }
        public string? Comment { get; set; }
		
		[Range(typeof(bool),"true","true",ErrorMessage ="DykkerCertifikat Krævet")]
		public bool HasDivingCertificat { get; set; }
		[Range(typeof(bool), "true", "true", ErrorMessage = "Handels Betingelserne skal accepteres")]
		public bool AcceptedTerms { get; set; }

        public int CustomerId { get; set; }
		public ICollection<Product> Products { get; set; } = new List<Product>();
		public ICollection<Package> Packages { get; set; } = new List<Package>();

		public Receipt()
        {

        }
    }
}
