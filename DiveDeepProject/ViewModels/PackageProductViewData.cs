using System.Security.Cryptography.X509Certificates;
using DiveDeepProject.Models;
using DiveDeepProject.Models.Enums;

namespace DiveDeepProject.ViewModels
{
    public class PackageProductViewData
    {
        public int PackageId { get; set; }

        public string PackageName { get; set; }
        public string PackageImagePath { get; set; }
        public double PackageTotalPricePerDay { get; set; }

        public List<ProductViewData> Products { get; set; } = new();

        public Size? SelectedSize { get; set; }
    }
}