using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models
{
    public class SnorkelSet : IProduct
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public SnorkelSet()
        {

        }
    }
}
