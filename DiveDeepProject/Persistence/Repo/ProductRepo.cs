using DiveDeepProject.Data;
using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.IRepo;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            return _diveDeepContext.Products.Find(Id);
        }

        public List<Product> GetAll()
        {
            return _diveDeepContext.Products.ToList();
        }
    }
}