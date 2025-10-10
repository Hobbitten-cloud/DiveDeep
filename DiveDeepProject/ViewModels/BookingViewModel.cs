using DiveDeepProject.Models.Domain;

namespace DiveDeepProject.ViewModels
{
    public class BookingViewModel
    {
        
        public Receipt Receipt { get; set; } = new Receipt();

        public List<Product> Lreceipt { get; set; } = new List<Product>();
        public List<Package> AllPackages { get; set; } = new List<Package>();
        public List<Product> AllProducts { get; set; } = new List<Product>();
        
        public string PackageName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double PricePerDay { get; set; }


    }
}
