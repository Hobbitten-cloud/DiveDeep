using DiveDeepProject.Data;
using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly DiveDeepContext _diveDeepContext;

        public ProductAPIController(DiveDeepContext diveDeepContext)
        {
            _diveDeepContext = diveDeepContext;
        }

        [HttpPost, Authorize]
        public async Task<Product> Create(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            _diveDeepContext.Products.Add(product);
            await _diveDeepContext.SaveChangesAsync();
            return product;
        }

        [HttpGet, Authorize]
        public async Task<Product> Edit(int id, Product product)
        {
            var productToUpdate = await Get(id);
            if (productToUpdate == null) throw new ArgumentNullException(nameof(productToUpdate));

            productToUpdate.Brand = product.Brand;
            productToUpdate.Description = product.Description;
            productToUpdate.Model = product.Model;
            productToUpdate.PricePerDay = product.PricePerDay;
            productToUpdate.ImagePath = product.ImagePath;

            await _diveDeepContext.SaveChangesAsync();

            return productToUpdate;
        }

        [HttpGet("{id}"), Authorize]
        public async Task<Product> Get(int Id)
        {
            var product = await _diveDeepContext.Products
                .Include(p => p.BCDs)
                .Include(p => p.Flippers)
                .Include(p => p.DivingSuits)
                .Include(p => p.Tanks)
                .Include(p => p.Regulatorsets)
                .Include(p => p.SnorkelSets)
                .FirstOrDefaultAsync(p => p.Id == Id);
            if (product == null) throw new ArgumentNullException(nameof(product));
            return product;
        }

        [HttpGet, Authorize]
        public async Task<List<Product>> GetAll()
        {
            return await _diveDeepContext.Products
                .Include(p => p.BCDs)
                .Include(p => p.Flippers)
                .Include(p => p.DivingSuits)
                .Include(p => p.Tanks)
                .Include(p => p.Regulatorsets)
                .Include(p => p.SnorkelSets)
                .ToListAsync();
        }

        [HttpDelete, Authorize]
        public async Task Delete(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            _diveDeepContext.Products.Remove(product);
            await _diveDeepContext.SaveChangesAsync();
        }

        [HttpPost, Authorize]
        public async Task CreateBCD(BCD bcd)
        {
            if (bcd == null) throw new ArgumentNullException(nameof(bcd));
            _diveDeepContext.BCDs.Add(bcd);
            await _diveDeepContext.SaveChangesAsync();
        }

        [HttpPost, Authorize]
        public async Task CreateDivingSuit(DivingSuit suit)
        {
            if (suit == null) throw new ArgumentNullException(nameof(suit));
            _diveDeepContext.DivingSuits.Add(suit);
            await _diveDeepContext.SaveChangesAsync();
        }

        [HttpPost, Authorize]
        public async Task CreateFlipper(Flipper flipper)
        {
            if (flipper == null) throw new ArgumentNullException(nameof(flipper));
            _diveDeepContext.Flippers.Add(flipper);
            await _diveDeepContext.SaveChangesAsync();
        }

        [HttpPost, Authorize]
        public async Task CreateRegulatorset(Regulatorset regulatorset)
        {
            if (regulatorset == null) throw new ArgumentNullException(nameof(regulatorset));
            _diveDeepContext.Regulatorsets.Add(regulatorset);
            await _diveDeepContext.SaveChangesAsync();
        }

        [HttpPost, Authorize]
        public async Task CreateSnorkelSet(SnorkelSet snorkelSet)
        {
            if (snorkelSet == null) throw new ArgumentNullException(nameof(snorkelSet));
            _diveDeepContext.SnorkelSets.Add(snorkelSet);
            await _diveDeepContext.SaveChangesAsync();
        }

        [HttpPost, Authorize]
        public async Task CreateTank(Tank tank)
        {
            if (tank == null) throw new ArgumentNullException(nameof(tank));
            _diveDeepContext.Tanks.Add(tank);
            await _diveDeepContext.SaveChangesAsync();
        }
    }
}