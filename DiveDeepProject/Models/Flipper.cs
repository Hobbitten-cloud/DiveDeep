using DiveDeepProject.Models.Enums;
using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models
{
    public class Flipper : IProduct
    {
        public class FlipperRentalToken
		{ // Token class to keep track of availability and rental periods
			public bool IsAvailable 
            { 
                get 
                {
                    return IsAvailable;
                } 
                set
                {
					// When setting availability to true, reset dates
					if (value == true)
                    {
                        StartDate = null;						
                        EndDate = null;
					}
					IsAvailable = value;
				}
            }
			public DateTime? StartDate { get; set; }
			public DateTime? EndDate { get; set; }
		}
		public static string Category = "Finner";
		public int Id { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public Size Size { get; set; }
        public string Model { get; set; }

        public Flipper() 
        {
            
        }

		public string GetCategory()
		{
			return Category;
		}
	}
}
