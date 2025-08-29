using DiveDeepProject.Models;

namespace DiveDeepProject.Persistence
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Wetsuit", PricePerDay = 15.00m },
            new Product { Id = 2, Name = "Dive Computer", PricePerDay = 20.00m },
            new Product { Id = 3, Name = "BCD", PricePerDay = 10.00m },
            new Product { Id = 4, Name = "Regulator", PricePerDay = 12.00m },
            new Product { Id = 5, Name = "Fins", PricePerDay = 8.00m }

        };

        public static List<Product> GetAll()
        {
            return products;
        }

        public static Product? GetById(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        public static void Add(Product product)
        {
            if (product == null) return;

            product.Id = products.Any() ? products.Max(x => x.Id) + 1 : 1;

            products.Add(product);
        }

        public static void Delete(int productId)
        {
            products.RemoveAll(x => x.Id == productId);
        }

        public static void Update(int productId, Product product)
        {
            var productToUpdate = GetById(productId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.PricePerDay = product.PricePerDay;
            }
        }
    }
}
