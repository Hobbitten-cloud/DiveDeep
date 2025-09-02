using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Models.Inferfaces;
using DiveDeepProject.Models;

namespace DiveDeepProject.Services
{
    public class SortingService //This service is for handling logick surrounding sorting products by category
    {

        private readonly ProductRepo _productRepo;
        private readonly CategoryRepo _catRepo;
        public SortingService(ProductRepo prodRepo, CategoryRepo catRepo)
        {
            _productRepo = prodRepo;
            _catRepo = catRepo;
        }

        public List<IProduct> SortProductsByCategory(Category item)
        {
            try
            {
                List<IProduct> sortedProducts = new List<IProduct>();
                if (item.Name == "BCD") // BCD
                {
                     sortedProducts = _productRepo.GetAll().Where(p => p.GetType() == typeof(BCD)).ToList();
                }

                if (item.Name == "Maske/snorkel") //SnorkelSet
                {
                     sortedProducts = _productRepo.GetAll().Where(p => p.GetType() == typeof(SnorkelSet)).ToList();
                }

                if (item.Name == "Regulatorsæt") //Regulatorset
                {
                     sortedProducts = _productRepo.GetAll().Where(p => p.GetType() == typeof(Regulatorset)).ToList();
                }

                if (item.Name == "Tanke") //Tank
                {
                     sortedProducts = _productRepo.GetAll().Where(p => p.GetType() == typeof(Tank)).ToList();
                }

                if (item.Name == "Finner") //Flippers
                {
                    sortedProducts = _productRepo.GetAll().Where(p => p.GetType() == typeof(Flipper)).ToList();
                }

                if (item.Name == "Dykkerdragter") //DivingSuit
                {
                     sortedProducts = _productRepo.GetAll().Where(p => p.GetType() == typeof(DivingSuit)).ToList();
                }
                return sortedProducts;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return _productRepo.GetAll();
            }
        }

        public List<IProduct> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}