using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.ViewModels;
using DiveDeepProject.Models;
using DiveDeepProject.Models.Domain;
using Microsoft.AspNetCore.Authorization;
namespace DiveDeepProject.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ReceiptRepo _receiptRepo;

        public CheckoutController(ReceiptRepo receiptRepo)
		{
			_receiptRepo = receiptRepo;
		}
		public IActionResult Index()
        {
            var CheckOutPageViewData = new CheckOutPageViewData();
			CheckOutPageViewData.Receipt = new Receipt();
           


			return View(CheckOutPageViewData);
        }

        
        public IActionResult Add(int id, string type)
        {
            Basket.AddItem(id, type);
			return RedirectToAction("Index");
		}

		
		public IActionResult Remove(int id, string type)
		{
			Basket.Remove(id, type);
			return RedirectToAction("Index");
		}

		[Authorize]
		[HttpPost]
		public IActionResult Reserve(CheckOutPageViewData Data) 
		{
			if (!ModelState.IsValid)
			{
				return View("Index", Data);
			}

			if (Basket.Products.Count != 0 || Basket.Packages.Count != 0)
			{
				Data.Receipt.Products = Basket.Products;
				Data.Receipt.Packages = Basket.Packages;
				
				Data.Receipt.Total = Basket.GetTotalPricePerDay();
				Data.Receipt.Comment = "items in basket";
				Data.Receipt.PickupDate = DateTime.Now;// needs to be set from user input
				Data.Receipt.ReturnDate = DateTime.Now.AddDays(7);// needs to be set from user input
			
				_receiptRepo.Create(Data.Receipt);
				return View("Reserve");
			}
			return RedirectToAction("Index"); 
		}
	}
}
