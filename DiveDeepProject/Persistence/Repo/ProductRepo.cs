using DiveDeepProject.Data;
using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.IRepo;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepProject.Persistence.Repo
{
    public class ProductRepo : IRepo<Product>, /*ICreateRepo<Product>,*/ IGetRepo<Product>
    {
        private readonly DiveDeepContext _diveDeepContext;
        private List<Product> _products;
        public ProductRepo(DiveDeepContext context)
        {
            _diveDeepContext = context;
        }

        public void Create(Product product)
        {
            if (product == null) return;
            product.Id = _products.Any() ? _products.Max(x => x.Id) + 1 : 1;

            _products.Add(product);
        }

        public void Edit(int id, Product product) 
        {
            var productToUpdate = Get(product.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Id = id;
                productToUpdate.Brand = product.Brand;
                productToUpdate.Description = product.Description;
                productToUpdate.Model = product.Model;
                productToUpdate.PricePerDay = product.PricePerDay;
                productToUpdate.ImagePath = product.ImagePath;
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
     
    }
}