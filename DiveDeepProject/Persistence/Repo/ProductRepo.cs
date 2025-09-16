using DiveDeepProject.Data;
using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.IRepo;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepProject.Persistence.Repo
{
    public class ProductRepo : IRepo<Product>, /*ICreateRepo<Product>,*/ IGetRepo<Product>
    {
        private readonly DiveDeepContext _diveDeepContext;

        public ProductRepo(DiveDeepContext context)
        {
            _diveDeepContext = context;
        }

        //public Product Create(Product product)
        //{
        //    product.Id = _products.Any() ? _products.Max(x => x.Id) + 1 : 1;

        //    _products.Add(product);
        //    return product;
        //}

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

        public List<BCD> GetAllBCDs()
        {
            return _diveDeepContext.BCDs.ToList();
        }
    }
}