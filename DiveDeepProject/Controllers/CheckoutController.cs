using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.ViewModels;
using DiveDeepProject.Models;
using DiveDeepProject.Models.Domain;
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
    }
}
