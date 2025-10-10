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

        public void Create(Product product)
        {
            if (product == null) return;
            
            _diveDeepContext.Products.Add(product);
            _diveDeepContext.SaveChanges();
        }

        public void Edit(int id, Product product) 
        {
            var productToUpdate = Get(id);
            if (productToUpdate != null)
            {
                productToUpdate.Brand = product.Brand;
                productToUpdate.Description = product.Description;
                productToUpdate.Model = product.Model;
                productToUpdate.PricePerDay = product.PricePerDay;
                productToUpdate.ImagePath = product.ImagePath;
                
                _diveDeepContext.SaveChanges();
            }
        }

        public Product Get(int Id)
        {
            return _diveDeepContext.Products
                .Include(p => p.BCDs)
                .Include(p => p.Flippers)
                .Include(p => p.DivingSuits)
                .Include(p => p.Tanks)
                .Include(p => p.Regulatorsets)
                .Include(p => p.SnorkelSets)
                .FirstOrDefault(p => p.Id == Id);
        }

        public List<Product> GetAll()
        {
            return _diveDeepContext.Products
                .Include(p => p.BCDs)
                .Include(p => p.Flippers)
                .Include(p => p.DivingSuits)
                .Include(p => p.Tanks)
                .Include(p => p.Regulatorsets)
                .Include(p => p.SnorkelSets)
                .ToList();
        }

        public void Delete(Product product)
        {
            if (product != null)
            {
                _diveDeepContext.Products.Remove(product);
                _diveDeepContext.SaveChanges();
            }
        }

        // Helpers to create child type entities when creating a product
        public void CreateBCD(BCD bcd)
        {
            if (bcd == null) return;
            _diveDeepContext.BCDs.Add(bcd);
            _diveDeepContext.SaveChanges();
        }

        public void CreateDivingSuit(DivingSuit suit)
        {
            if (suit == null) return;
            _diveDeepContext.DivingSuits.Add(suit);
            _diveDeepContext.SaveChanges();
        }

        public void CreateFlipper(Flipper flipper)
        {
            if (flipper == null) return;
            _diveDeepContext.Flippers.Add(flipper);
            _diveDeepContext.SaveChanges();
        }

        public void CreateRegulatorset(Regulatorset regulatorset)
        {
            if (regulatorset == null) return;
            _diveDeepContext.Regulatorsets.Add(regulatorset);
            _diveDeepContext.SaveChanges();
        }

        public void CreateSnorkelSet(SnorkelSet snorkelSet)
        {
            if (snorkelSet == null) return;
            _diveDeepContext.SnorkelSets.Add(snorkelSet);
            _diveDeepContext.SaveChanges();
        }

        public void CreateTank(Tank tank)
        {
            if (tank == null) return;
            _diveDeepContext.Tanks.Add(tank);
            _diveDeepContext.SaveChanges();
        }
    }
}