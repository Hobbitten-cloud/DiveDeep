using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models.Domain
{
    public class Package
    {
        public int id;
        public List<IProduct> Products { get; set; } = new List<IProduct>();
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; } = "Lib/Public/DesignImageTemplate.png";

        public double TotalPricePerDay
        {
            get // Returns the pric of all the products in the package with a 20% discount
            {
                return Products.Sum(p => p.PricePerDay) * 0.8;
            }
        }



    }
}
