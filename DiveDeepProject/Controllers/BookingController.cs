using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Services;
using DiveDeepProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace DiveDeepProject.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly ReceiptRepo _repo;
        private readonly ProductRepo _productRepo;
        private readonly PackageRepo _packageRepo;
        public BookingController(ReceiptRepo repo, ProductRepo productrepo, PackageRepo packagerepo)
        {
            _repo = repo;
            _productRepo = productrepo;
            _packageRepo = packagerepo;
        }
        public IActionResult Index()
        {
            
            
            var receipts = _repo.GetAll();
            var bookings = receipts.Select(r => new CheckOutPageViewData
            {
                Receipt = r
            }).ToList();



            return View(bookings);
            //new List<Receipt>()
        }
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
           var receipt = _repo.GetById(id);
            
            if (receipt == null)
            {
                return null;
            }

            var booking = new BookingViewModel
            {
                Receipt = receipt,
                Lreceipt = receipt.Products.ToList(),
                AllProducts = _productRepo.GetAll(),
                AllPackages = _packageRepo.GetAll()
            };
            return View(booking);
        }

        public IActionResult DeleteProduct(int bookingId, int productId)
        {
            var receipt = _repo.GetById(bookingId); 
            if (receipt != null)
            {
                var productToDelete = receipt.Products.FirstOrDefault(p => p.Id == productId);
                if (productToDelete != null)
                {
                    receipt.Products.Remove(productToDelete);
                    _repo.Save();
                }
            }

            
            return RedirectToAction("Edit", new { id = bookingId });
        }
        [HttpPost]
        public IActionResult SaveBooking(int id, string pickupDate, string returnDate, int? newProductId, string delete)
        {
            
            var receipt = _repo.GetById(id);
            
            if (receipt != null)
            {
                // Opdater datoer (Duer ikke indtil videre)
                //if (!string.IsNullOrEmpty(pickupDate) && !string.IsNullOrEmpty(returnDate))
                //{
                //    receipt.PickupDate = DateTime.Parse(pickupDate);
                //    receipt.ReturnDate = DateTime.Parse(returnDate);
                //}
                
                // Håndter tilføjelse af nyt produkt 
                if (newProductId.HasValue)
                {
                    var newProduct = receipt.Products.FirstOrDefault(p => p.Id == newProductId.Value);
                    if (newProduct != null)
                    {
                        receipt.Products.Add(newProduct);
                    }
                }

                // Håndter sletning af produkt (det duer)
                if (!string.IsNullOrEmpty(delete) && delete.StartsWith("deleteProduct_"))
                {
                    int productId = int.Parse(delete.Split('_')[1]);
                    var productToDelete = receipt.Products.FirstOrDefault(p => p.Id == productId);
                    if (productToDelete != null)
                    {
                        receipt.Products.Remove(productToDelete);
                    }
                }
                
                double total = 0;
                foreach (var product in receipt.Products)
                {

                    total += product.PricePerDay;
                   
                }
                foreach (var product in receipt.Products)
                {
                    total += product.Package.TotalPricePerDay;
                }

                var dato = receipt.ReturnDate - receipt.PickupDate;
                receipt.Total = total * dato.Days;
                
                // Gem ændringer i databasen
                _repo.Save();
                
                return RedirectToAction("Edit", new { id = receipt.Id });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddProductToBooking(int bookingId, string selectedId) // hvad den her function skal gøre er at tilføje produkter til en booking
        {
            var receipt = _repo.GetById(bookingId);
            if (receipt == null || string.IsNullOrEmpty(selectedId)) // kigger om receipt var null
                return RedirectToAction("Edit", new { id = bookingId });

            if (selectedId.StartsWith("product_") && int.TryParse(selectedId.Replace("product_", ""), out int productId)) // kigger om det der er valg er et produkt 
            {
                var product = _productRepo.Get(productId); // får produktet fra databasen
                if (product != null) 
                {
                    receipt.Products.Add(product); // tilføjer til listen / bookingen
                }
            }
            else if (selectedId.StartsWith("package_") && int.TryParse(selectedId.Replace("package_", ""), out int packageId)) //kigger om det der er valg er en pakke
            {
                var package = _packageRepo.Get(packageId);
                if (package != null)
                {
                    receipt.Packages.Add(package); // tilføjer til listen / bookingen
                }
            }

            _repo.Save(); // gemmer i databasen

            return RedirectToAction("Edit", new { id = bookingId });
        }

    }
}
