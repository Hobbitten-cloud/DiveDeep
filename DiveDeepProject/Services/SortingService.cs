using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Services
{
    public class SortingService //This service is for handling logick surrounding sorting products by category
    {

        private readonly ProductRepo _prodRepo;

        public SortingService(ProductRepo prodRepo)
        {
            _prodRepo = prodRepo;
        }

        public List<IProduct> SortProducts(IProduct category) // Sort products by category
        {

            try
            {
                return _prodRepo.GetAll().Where(p => p.GetCategory() == category.GetCategory()).ToList();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return _prodRepo.GetAll();
            }
        }

        public List<IProduct> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }
    
    }
    
}
