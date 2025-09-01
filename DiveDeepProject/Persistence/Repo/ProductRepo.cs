using DiveDeepProject.Models;
using DiveDeepProject.Models.Inferfaces;
using DiveDeepProject.Persistence.IRepo;

namespace DiveDeepProject.Persistence.Repo
{
    public class ProductRepo : IRepo<IProduct>, ICreateRepo<IProduct>,IGetRepo<IProduct>
	{
        private List<IProduct> _products = new List<IProduct>();
        public IProduct Create(IProduct product)
        {
            _products.Add(product);
            return product;
        }

        public IProduct Get(int Id)
		{
			return _products.Find(p => p.Id == Id);
		}

		public List<IProduct> GetAll()
		{
			return _products;
			
		}


	}
}
