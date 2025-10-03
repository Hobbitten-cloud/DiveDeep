using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Services;
using DiveDeepProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
