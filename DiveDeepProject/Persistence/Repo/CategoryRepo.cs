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

            Create(new Category { Id = 1, Name = "Dykkersæt", ImagePath = "lib/Public/DivingGearSet.png" });
            Create(new Category { Id = 2, Name = "Snorkelsæt", ImagePath = "lib/Public/SnorkelSet.png" });
            Create(new Category { Id = 3, Name = "BCD", ImagePath = "lib/Public/BCD.png" });
            Create(new Category { Id = 4, Name = "Dykkerdragter", ImagePath = "lib/Public/BCD.png" });
            Create(new Category { Id = 5, Name = "Tanke", ImagePath = "lib/Public/DivingTank.png" });
            Create(new Category { Id = 6, Name = "Regulatorsæt", ImagePath = "lib/Public/Regulator.png" });
            Create(new Category { Id = 7, Name = "Maske/snorkel", ImagePath = "lib/Public/DivingMask-Snorkel.png" });
            Create(new Category { Id = 8, Name = "Finner", ImagePath = "lib/Public/DivingFins.png" });
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
