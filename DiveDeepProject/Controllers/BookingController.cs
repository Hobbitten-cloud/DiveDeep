using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Services;
using DiveDeepProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepProject.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly ReceiptRepo _repo;
        public BookingController(ReceiptRepo repo)
        {
            _repo = repo;
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
                Lreceipt = receipt.Products.ToList()
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
                if (!string.IsNullOrEmpty(pickupDate) && !string.IsNullOrEmpty(returnDate))
                {
                    receipt.PickupDate = DateTime.Parse(pickupDate);
                    receipt.ReturnDate = DateTime.Parse(returnDate);
                }

                // Håndter tilføjelse af nyt produkt (Har ikke logi til at tilføje endnu så kan ikke teste)
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
    }
}
