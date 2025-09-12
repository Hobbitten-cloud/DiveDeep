using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models.Domain
{
    public class Tank : IProduct
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public string Volume { get; set; }
        public string ImagePath { get; set; } = "lib/Public/DesignImageTemplate.png";

        public Tank()
        {

        }


    }
}
