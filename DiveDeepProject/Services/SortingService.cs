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
                                                 .Where(p => p.BCDs != null && p.BCDs.Any())
                                                 .ToList();
                }

                else if (item.Name == "Maske/snorkel") // SnorkelSet
                {
                    sortedProducts = _productRepo.GetAll()
                                                 .Where(p => p.SnorkelSets != null && p.SnorkelSets.Any())
                                                 .ToList();
                }

                else if (item.Name == "Regulatorsæt") // Regulatorset
                {
                    sortedProducts = _productRepo.GetAll()
                                                 .Where(p => p.Regulatorsets != null && p.Regulatorsets.Any())
                                                 .ToList();
                }

                else if (item.Name == "Tanke") // Tank
                {
                    sortedProducts = _productRepo.GetAll()
                                                 .Where(p => p.Tanks != null && p.Tanks.Any())
                                                 .ToList();
                }

                else if (item.Name == "Finner") // Flippers
                {
                    sortedProducts = _productRepo.GetAll()
                                                 .Where(p => p.Flippers != null && p.Flippers.Any())
                                                 .ToList();
                }

                else if (item.Name == "Dykkerdragter") // DivingSuit
                {
                    sortedProducts = _productRepo.GetAll()
                                                 .Where(p => p.DivingSuits != null && p.DivingSuits.Any())
                                                 .ToList();
                }

                else if (item.Name == "Alle Produkter")
                {
                    sortedProducts = _productRepo.GetAll();
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