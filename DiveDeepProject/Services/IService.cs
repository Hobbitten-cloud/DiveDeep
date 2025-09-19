using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Models.Domain;

namespace DiveDeepProject.Services
{
    public interface IService
    {

        public List<Product> SortProductsByCategory(Category item);

        public List<Product> SearchProducts(string searchTerm);
    }
}
