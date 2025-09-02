using DiveDeepProject.Models.Enums;
using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models
{
	public class BCD : IProduct
    {
 
		public int Id { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public Size Size { get; set; }
        public string Model { get; set; }
        public string ImagePath { get; set; } = "Lib/Public/DesignImageTemplate.png";
        public BCD()
        {

        }

	}
}
