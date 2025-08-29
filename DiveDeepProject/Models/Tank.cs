using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models
{
    public class Tank : IProduct
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public int Volume { get; set; }

        public Tank()
        {

        }
    }
}
