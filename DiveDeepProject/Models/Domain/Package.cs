using System.ComponentModel.DataAnnotations;

namespace DiveDeepProject.Models.Domain
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; } = "Lib/Public/DesignImageTemplate.png";

		public ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
		public double TotalPricePerDay
        {
            get // Returns the pric of all the products in the package with a 20% discount
            {
                return Products.Sum(p => p.PricePerDay) * 0.8;
            }
        }



    }
}
