using DiveDeepProject.Models;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Services;

namespace DiveDeepProject.Persistence.Repo
{
    public class CategoryRepo : ICreateRepo<Category>, IGetRepo<Category>
    {
        private List<Category> _categories;

        public CategoryRepo()
        {
            _categories = new List<Category>();
        }

        public Category Create(Category item, SortingService sortingService)
        {
            item.products = sortingService.SortProductsByCategory(item);
            _categories.Add(item);
            return item;
        }

        /// <summary>
        /// Use Overload when creating a Category, that uses products from product repo
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Category Create(Category item)
        {
            _categories.Add(item);
            return item;
        }

        public Category Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
