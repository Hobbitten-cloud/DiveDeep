using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models.Domain
{
    public class SnorkelSet : Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public string ImagePath { get; set; } = "lib/Public/DesignImageTemplate.png";

        public List<Product>? Products { get; set; }

        public SnorkelSet()
        {

        }
    }
}
