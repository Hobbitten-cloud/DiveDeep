using DiveDeepProject.Models.Domain;
using DiveDeepProject.Models.Enums;

namespace DiveDeepProject.ViewModels
{
    public class ProductViewData
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public List<UnavailableDates>? UnavailableDates { get; set; }


        // Domain models information
        public Size? Size { get; set; }
        public string Model { get; set; }
    }
}
