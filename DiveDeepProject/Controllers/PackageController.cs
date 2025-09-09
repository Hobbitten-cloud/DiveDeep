using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.Controllers
{
    public class PackageController : Controller
    {
        private readonly PackageRepo _packageRepo;

        public PackageController(PackageRepo packageRepo)
        {
            _packageRepo = packageRepo;
        }

        public IActionResult ShowPackage(int id)
        {
            var package = _packageRepo.Get(id);

            var viewModel = new PackageProductViewData
            {
                PackageId = package.id,
                PackageName = package.Name,
                PackageImagePath = package.ImagePath,
                PackageTotalPricePerDay = package.TotalPricePerDay,
                Products = package.Products,
            };

            return View(viewModel);
        }
    }
}
