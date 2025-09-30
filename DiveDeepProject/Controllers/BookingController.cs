using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly InMemoryReceiptRepo _repo = new InMemoryReceiptRepo();
        public IActionResult Index()
        {
            var bookings = _repo.GetAll();
            return View(bookings);
            //new List<Receipt>()
        }
        public IActionResult Delete(int id)
        {
            InMemoryReceiptRepo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
