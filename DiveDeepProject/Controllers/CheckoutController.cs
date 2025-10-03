using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.ViewModels;
using DiveDeepProject.Models;
using DiveDeepProject.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace DiveDeepProject.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ReceiptRepo _receiptRepo;
		private readonly UserRepo _userRepo;
        private readonly UserManager<ApplicationUser> _userManager;
       

        public CheckoutController(ReceiptRepo receiptRepo, UserRepo customerRepo, UserManager<ApplicationUser> userManager)
		{
			_receiptRepo = receiptRepo;
            _userRepo = customerRepo;
            _userManager = userManager;
        }
		public IActionResult Index()
        {
            var CheckOutPageViewData = new CheckOutPageViewData();
			CheckOutPageViewData.Receipt = new Receipt();
			CheckOutPageViewData.User = _userRepo.Get(_userManager.GetUserId(User));


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

		
		[HttpPost]
		public IActionResult Reserve(CheckOutPageViewData Data) 
		{
			var currentUser = _userRepo.Get(_userManager.GetUserId(User));
			Data.Receipt.UserId = currentUser.Id;
			Data.Receipt.User = currentUser;
			if (!ModelState.IsValid)
			{
				return View("Index", Data);
			}

			if (Basket.Products.Count != 0 || Basket.Packages.Count != 0)
			{
				Data.Receipt.Products = Basket.Products;
				Data.Receipt.Packages = Basket.Packages;
         
                Data.Receipt.Total = Basket.GetTotalPricePerDay();
				if(Data.Receipt.Comment == null)
					Data.Receipt.Comment = "";
				Data.Receipt.PickupDate = DateTime.Now;// needs to be set from user input
				Data.Receipt.ReturnDate = DateTime.Now.AddDays(7);// needs to be set from user input

				
				_receiptRepo.Create(Data.Receipt);
				return View("Reserve",Data.Receipt);
			}
			return RedirectToAction("Index"); 
		}
	}
}
