using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Models.Domain;

namespace DiveDeepProject.Services
{
    public class SortingService : IService //This service is for handling logick surrounding sorting products by category
    {
        private readonly ProductRepo _productRepo;
        public SortingService(ProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public List<Product> SortProductsByCategory(Category item)
        {
            try
            {
                List<Product> sortedProducts = new List<Product>();

                if (item.Name == "BCD") // BCD
                {
                    sortedProducts = _productRepo.GetAll()
                                                 .Where(p => p.GetType() == typeof(BCD))
                                                 .ToList();
                }

                else if (item.Name == "Maske/snorkel") // SnorkelSet
                {
                    sortedProducts = _productRepo.GetAll()
                                                 .Where(p => p.GetType() == typeof(SnorkelSet))
                                                 .ToList();
                }

                else if (item.Name == "Regulatorsæt") // Regulatorset
                {
                    sortedProducts = _productRepo.GetAll()
                                                 .Where(p => p.GetType() == typeof(Regulatorset))
                                                 .ToList();
                }

                else if (item.Name == "Tanke") // Tank
                {
                    sortedProducts = _productRepo.GetAll()
                                                 .Where(p => p.GetType() == typeof(Tank))
                                                 .ToList();
                }

                else if (item.Name == "Finner") // Flippers
                {
                    sortedProducts = _productRepo.GetAll()
                                                 .Where(p => p.GetType() == typeof(Flipper))
                                                 .ToList();
                }

                else if (item.Name == "Dykkerdragter") // DivingSuit
                {
                    sortedProducts = _productRepo.GetAll()
                                                 .Where(p => p.GetType() == typeof(DivingSuit))
                                                 .ToList();
                }
                return sortedProducts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return _productRepo.GetAll();
            }
        }

        public List<Product> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}