using DiveDeepProject.Persistence.Repo;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly ProductRepo _prodRepo;

        public ProductAPIController(ProductRepo prodRepo)
        {
            _prodRepo = prodRepo;
        }

        public IActionResult Index()
        {

        }
    }
}
