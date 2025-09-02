using DiveDeepProject.Models.Enums;
using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models
{
    public class DivingSuit : Category, IProduct
    {
		public int Id { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public Size Size { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string? Thickness { get; set; }
        public string Model { get; set; }

        public DivingSuit()
        {

        }

		public string GetCategory()
		{
			return Category;
		}
	}
}
