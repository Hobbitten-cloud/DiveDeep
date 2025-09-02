using DiveDeepProject.Models;

namespace DiveDeepProject.Persistence
{
    public class CategoriesRepository
    {
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Dykkersæt", ImagePath = "" },
            new Category { Id = 2, Name = "Snorkelsæt", ImagePath = "" },
            new Category { Id = 3, Name = "BCD", ImagePath = "lib/Public/BCD.png" },
            new Category { Id = 4, Name = "Dykkerdragter", ImagePath = "lib/Public/BCD.png" },
            new Category { Id = 5, Name = "Tanke", ImagePath = "" },
			new Category { Id = 6, Name = "Regulatorsæt", ImagePath = "" },
            new Category { Id = 7, Name = "Maske/snorkel", ImagePath = "" },
            new Category { Id = 8, Name = "Finner", ImagePath = "lib/Public/DivingFins.png" }
        };

        public static List<Category> GetAll()
        {
            return categories;
        }

        public static Category? GetById(int id)
        {
            return categories.FirstOrDefault(x => x.Id == id);
        }

        public static void Add(Category category)
        {
            if (category == null) return;
            category.Id = categories.Any() ? categories.Max(x => x.Id) + 1 : 1;
            categories.Add(category);
        }

        public static void Delete(int categoryId)
        {
            categories.RemoveAll(x => x.Id == categoryId);
        }

        public static void Update(int categoryId, Category category)
        {
            var categoryToUpdate = GetById(categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
            }
        }
    }
}
