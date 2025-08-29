using DiveDeepProject.Models.Inferfaces;
using DiveDeepProject.Persistence.IRepo;

namespace DiveDeepProject.Persistence.Repo
{
    public class ProductRepo : IRepo<IProduct>, ICreateRepo<IProduct>
    {
        private List<IProduct> _products = new List<IProduct>();
        public IProduct Create(IProduct product)
        {
            _products.Add(product);
            return product;
        }
    }
}
