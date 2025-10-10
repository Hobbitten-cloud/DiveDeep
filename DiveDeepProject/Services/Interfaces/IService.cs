using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Models.Domain;

namespace DiveDeepProject.Services.Interfaces
{
    public interface IService
    {

        public List<Product> SortProductsByCategory(Category item);

        public List<Product> SearchProducts(string searchTerm);
    }
}
