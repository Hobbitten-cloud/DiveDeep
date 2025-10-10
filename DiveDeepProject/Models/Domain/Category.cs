
namespace DiveDeepProject.Models.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; } = "Lib/Public/DesignImageTemplate.png";

        public List<Product> products;

        public Category()
        {
            products = new List<Product>();
        }

    }
}

