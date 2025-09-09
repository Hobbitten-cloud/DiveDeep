using System.Security.Cryptography.X509Certificates;
using DiveDeepProject.Models;
using DiveDeepProject.Models.Enums;
using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.ViewModels
{
    public class PackageProductViewData
    {
        public int PackageId { get; set; }

        public string PackageName { get; set; }
        public string PackageImagePath { get; set; }
        public double PackageTotalPricePerDay { get; set; }

        public List<ProductViewModel> Products { get; set; } = new();

        public Size? SelectedSize { get; set; }
    }
}