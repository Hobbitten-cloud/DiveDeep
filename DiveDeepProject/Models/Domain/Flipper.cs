using DiveDeepProject.Models.Enums;

namespace DiveDeepProject.Models.Domain
{
    public class Flipper
    {
        // TBH NOT NEEDED WHEN WE WORK WITH DATABASES
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

        public int Id { get; set; }
        //public string Description { get; set; }
        //public string Brand { get; set; }
        //public double PricePerDay { get; set; }
        //public string ImagePath { get; set; } = "lib/Public/DesignImageTemplate.png";
        public Size? Size { get; set; }
        public string Model { get; set; }

        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }

        public Flipper()
        {

        }
    }
}
