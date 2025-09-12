using DiveDeepProject.Models.Inferfaces;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Models.Domain;

namespace DiveDeepProject.Services
{
    public interface IService
    {

        public List<IProduct> SortProductsByCategory(Category item);

        public List<IProduct> SearchProducts(string searchTerm);
    }
}
