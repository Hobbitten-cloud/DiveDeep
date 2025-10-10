using DiveDeepProject.Controllers;
using DiveDeepProject.Data;
using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.IRepo;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepProject.Persistence.Repo
{
    public class ProductRepo : IRepo<Product>, IGetRepo<Product>
    {
        private readonly DiveDeepContext _diveDeepContext;

        public ProductRepo(DiveDeepContext context)
        {
            _diveDeepContext = context;
        }

        public async Task<Product> Create(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            _diveDeepContext.Products.Add(product);
            await _diveDeepContext.SaveChangesAsync();
            return product;
        }

        //public void Create(Product product)
        //{
        //    if (product == null) return;

        //    _diveDeepContext.Products.Add(product);
        //    _diveDeepContext.SaveChanges();
        //}

        //public void Edit(int id, Product product) 
        //{
        //    var productToUpdate = Get(id);
        //    if (productToUpdate != null)
        //    {
        //        productToUpdate.Brand = product.Brand;
        //        productToUpdate.Description = product.Description;
        //        productToUpdate.Model = product.Model;
        //        productToUpdate.PricePerDay = product.PricePerDay;
        //        productToUpdate.ImagePath = product.ImagePath;

        //        _diveDeepContext.SaveChanges();
        //    }
        //}

        public async Task<Product> Edit(int id, Product product)
        {
            var productToUpdate = await GetProduct(id);
            if (productToUpdate == null) throw new ArgumentNullException(nameof(productToUpdate));

            productToUpdate.Brand = product.Brand;
            productToUpdate.Description = product.Description;
            productToUpdate.Model = product.Model;
            productToUpdate.PricePerDay = product.PricePerDay;
            productToUpdate.ImagePath = product.ImagePath;

            await _diveDeepContext.SaveChangesAsync();

            return productToUpdate;
        }

        //public Product Get(int Id)
        //{
        //    return _diveDeepContext.Products
        //        .Include(p => p.BCDs)
        //        .Include(p => p.Flippers)
        //        .Include(p => p.DivingSuits)
        //        .Include(p => p.Tanks)
        //        .Include(p => p.Regulatorsets)
        //        .Include(p => p.SnorkelSets)
        //        .FirstOrDefault(p => p.Id == Id);
        //}

        public async Task<Product> GetProduct(int Id)
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

        //public List<Product> GetAll()
        //{
        //    return _diveDeepContext.Products
        //        .Include(p => p.BCDs)
        //        .Include(p => p.Flippers)
        //        .Include(p => p.DivingSuits)
        //        .Include(p => p.Tanks)
        //        .Include(p => p.Regulatorsets)
        //        .Include(p => p.SnorkelSets)
        //        .ToList();
        //}

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

        //public void Delete(Product product)
        //{
        //    if (product != null)
        //    {
        //        _diveDeepContext.Products.Remove(product);
        //        _diveDeepContext.SaveChanges();
        //    }
        //}

        public async Task Delete(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            _diveDeepContext.Products.Remove(product);
            await _diveDeepContext.SaveChangesAsync();
        }

        // Helpers to create child type entities when creating a product
        //public void CreateBCD(BCD bcd)
        //{
        //    if (bcd == null) return;
        //    _diveDeepContext.BCDs.Add(bcd);
        //    _diveDeepContext.SaveChanges();
        //}

        public async Task CreateBCD(BCD bcd)
        {
            if (bcd == null) throw new ArgumentNullException(nameof(bcd));
            _diveDeepContext.BCDs.Add(bcd);
            await _diveDeepContext.SaveChangesAsync();
        }

        //public void CreateDivingSuit(DivingSuit suit)
        //{
        //    if (suit == null) return;
        //    _diveDeepContext.DivingSuits.Add(suit);
        //    _diveDeepContext.SaveChanges();
        //}

        public async Task CreateDivingSuit(DivingSuit suit)
        {
            if (suit == null) throw new ArgumentNullException(nameof(suit));
            _diveDeepContext.DivingSuits.Add(suit);
            await _diveDeepContext.SaveChangesAsync();
        }

        //public void CreateFlipper(Flipper flipper)
        //{
        //    if (flipper == null) return;
        //    _diveDeepContext.Flippers.Add(flipper);
        //    _diveDeepContext.SaveChanges();
        //}

        public async Task CreateFlipper(Flipper flipper)
        {
            if (flipper == null) throw new ArgumentNullException(nameof(flipper));
            _diveDeepContext.Flippers.Add(flipper);
            await _diveDeepContext.SaveChangesAsync();
        }

        //public void CreateRegulatorset(Regulatorset regulatorset)
        //{
        //    if (regulatorset == null) return;
        //    _diveDeepContext.Regulatorsets.Add(regulatorset);
        //    _diveDeepContext.SaveChanges();
        //}

        public async Task CreateRegulatorset(Regulatorset regulatorset)
        {
            if (regulatorset == null) throw new ArgumentNullException(nameof(regulatorset));
            _diveDeepContext.Regulatorsets.Add(regulatorset);
            await _diveDeepContext.SaveChangesAsync();
        }

        //public void CreateSnorkelSet(SnorkelSet snorkelSet)
        //{
        //    if (snorkelSet == null) return;
        //    _diveDeepContext.SnorkelSets.Add(snorkelSet);
        //    _diveDeepContext.SaveChanges();
        //}

        public async Task CreateSnorkelSet(SnorkelSet snorkelSet)
        {
            if (snorkelSet == null) throw new ArgumentNullException(nameof(snorkelSet));
            _diveDeepContext.SnorkelSets.Add(snorkelSet);
            await _diveDeepContext.SaveChangesAsync();
        }

        //public void CreateTank(Tank tank)
        //{
        //    if (tank == null) return;
        //    _diveDeepContext.Tanks.Add(tank);
        //    _diveDeepContext.SaveChanges();
        //}

        public async Task CreateTank(Tank tank)
        {
            if (tank == null) throw new ArgumentNullException(nameof(tank));
            _diveDeepContext.Tanks.Add(tank);
            await _diveDeepContext.SaveChangesAsync();
        }
    }
}