using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models
{
    public class Category
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; }

        private List<IProduct> _products;

        public List<IProduct> GetAllProducts()
        {
            return _products;
        }
    }
}
