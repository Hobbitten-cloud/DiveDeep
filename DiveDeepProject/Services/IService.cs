using DiveDeepProject.Models.Inferfaces;
using DiveDeepProject.Models;
using DiveDeepProject.Persistence.Repo;

namespace DiveDeepProject.Services
{
    public interface IService
    {

        public List<IProduct> SortProductsByCategory(Category item);

        public List<IProduct> SearchProducts(string searchTerm);
    }
}
