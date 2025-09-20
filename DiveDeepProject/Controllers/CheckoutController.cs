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
            CheckOutPageViewData.Customer = new Customer();


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
		public IActionResult Reserve(CheckOutPageViewData ViewData) 
		{ 
			if(Basket.Products.Count != 0 && Basket.Packages.Count != 0)
			{
				ViewData.Receipt.Products = Basket.Products;
				ViewData.Receipt.Packages = Basket.Packages;
				ViewData.Receipt.Customer = ViewData.Customer;
				ViewData.Receipt.Total = Basket.GetTotalPricePerDay();
				ViewData.Receipt.Comment = "items in basket";
				ViewData.Receipt.AcceptedTerms = true;// needs to be set from user input
				ViewData.Receipt.HasDivingCertificat = true;// needs to be set from user input
				ViewData.Receipt.PickupDate = DateTime.Now;// needs to be set from user input
				ViewData.Receipt.ReturnDate = DateTime.Now.AddDays(7);// needs to be set from user input
				_receiptRepo.Create(ViewData.Receipt);
				return View("Reserve");
			}
			return RedirectToAction("Index"); 
		}
	}
}
