using DiveDeepProject.Models;

namespace DiveDeepProject.Persistence
{
    public class CategoriesRepository
    {
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Wetsuits" },
            new Category { Id = 2, Name = "Dive Computers" },
            new Category { Id = 3, Name = "BCDs" },
            new Category { Id = 4, Name = "Regulators" },
            new Category { Id = 5, Name = "Fins" }
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
