using System.ComponentModel.DataAnnotations;

namespace DiveDeepProject.Models.Domain
{
    public class Receipt
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public List<Product> Products { get; set; }
        
        public List<Package> Packages { get; set; }
		public double Total { get; set; }
        public string Comment { get; set; }
        [Required]
        public bool HasDivingCertificat { get; set; }
        [Required]
        public bool AcceptedTerms { get; set; }
        public Receipt()
        {

        }
    }
}
