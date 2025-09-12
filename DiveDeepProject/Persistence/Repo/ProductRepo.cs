using DiveDeepProject.Models.Domain;
using DiveDeepProject.Models.Enums;
using DiveDeepProject.Models.Inferfaces;
using DiveDeepProject.Persistence.IRepo;
using System.Threading.Tasks;

namespace DiveDeepProject.Persistence.Repo
{
    public class ProductRepo : IRepo<IProduct>, ICreateRepo<IProduct>, IGetRepo<IProduct>
    {
        private List<IProduct> _products;
        public IProduct Create(IProduct product)
        {
			

			product.Id = _products.Any() ? _products.Max(x => x.Id) + 1 : 1;

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
        public ProductRepo()
        {

            //Adding Buisness data.
            #region
            _products = new List<IProduct>()
            {
                // ------------------ BCDs ------------------  

                // ------------------ DivingSuit ------------------
  
                // ------------------ Tanks ------------------

                // ------------------ Regulators ------------------

                // ------------------ SnorkelSet ------------------

                // ------------------ Flipper ------------------

            };
            #endregion
        }
    }
}
