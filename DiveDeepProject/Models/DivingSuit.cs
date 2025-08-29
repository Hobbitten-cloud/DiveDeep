using DiveDeepProject.Models.Enums;
using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models
{
    public class DivingSuit : IProduct
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public Size Size { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public double? Thickness { get; set; }

        public DivingSuit()
        {

        }
    }
}
